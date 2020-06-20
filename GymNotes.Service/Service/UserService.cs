using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using GymNotes.Models;
using GymNotes.Repository.IRepository;
using GymNotes.Service.IService;
using GymNotes.Service.ViewModels;
using GymNotes.Entity.Models;
using System.Threading.Tasks;
using GymNotes.Service.Utils;
using GymNotes.Repository.IRepository.User;
using Microsoft.EntityFrameworkCore;
using GymNotes.Service.Exceptions;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.WebUtilities;
using GymNotes.Service.Email;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

namespace GymNotes.Service.Service
{
  public class UserService : IUserService
  {
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private UserManager<ApplicationUser> _userManager;
    private SignInManager<ApplicationUser> _signInManager;
    private ApplicationSettings _appSettings;

    public UserService(
      IMapper mapper,
      IUnitOfWork unitOfWork,
      UserManager<ApplicationUser> userManager,
      SignInManager<ApplicationUser> signInManager,
      IOptions<ApplicationSettings> appSettings)
    {
      _mapper = mapper;
      _unitOfWork = unitOfWork;
      _userManager = userManager;
      _signInManager = signInManager;
      _appSettings = appSettings.Value;
    }

    public async Task<ApiResponse> Register(UserRegisterVm userModel)
    {
      var applicationUser = new ApplicationUser()
      {
        Email = userModel.Email,
        FirstName = userModel.FirstName,
        LastName = userModel.LastName,
        UserName = userModel.Email,
      };

      var result = await _userManager.CreateAsync(applicationUser, userModel.Password);

      var user = await _userManager.FindByEmailAsync(applicationUser.Email);

      if (user != null && result.Succeeded)
      {
        await _unitOfWork.CompleteAsync();

        var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);

        byte[] tokenGeneratedBytes = Encoding.UTF8.GetBytes(token);
        var codeEncoded = WebEncoders.Base64UrlEncode(tokenGeneratedBytes);

        var url = "http://localhost:5000/emailConfirmation" + "?email=" + user.Email + "&token=" + codeEncoded;

        SendEmail.Send(user.Email, "Email confirmation", url);

        return new ApiResponse(result.Succeeded);
      }
      else
      {
        throw new MyException(ApiResponseDescription.EMAIL_ALREADY_IN_USE);
      }
    }

    public async Task<UserAuthenticatedVm> Login(UserLoginVm model)
    {
      var user = await _userManager.FindByNameAsync(model.Email);

      if (user == null)
        throw new MyException(ApiResponseDescription.INCORECT_EMAIL);

      if (await _userManager.CheckPasswordAsync(user, model.Password))
      {
        var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.isPersistent, lockoutOnFailure: false);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
          Subject = new ClaimsIdentity(new Claim[] {
          new Claim ("UserID", user.Id.ToString ()),
          }),
          Expires = DateTime.UtcNow.AddDays(1),
          SigningCredentials = new SigningCredentials(
          new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSettings.JWT_Secret)),
          SecurityAlgorithms.HmacSha256Signature)
        };
        var tokenHandler = new JwtSecurityTokenHandler();
        var securityToken = tokenHandler.CreateToken(tokenDescriptor);
        var token = tokenHandler.WriteToken((securityToken));

        return new UserAuthenticatedVm()
        {
          Token = token,
          Id = user.Id,
          FirstName = user.FirstName,
          LastName = user.LastName,
          Email = user.Email,
          Alias = user.Alias
        };
      }
      else
        throw new MyException(ApiResponseDescription.INCORECT_PAASWORD);
    }

    public async Task<ApiResponse> ConfirmEmailAddress(EmailConfirmationVm model)
    {
      var user = await _userManager.FindByEmailAsync(model.Email);

      if (user == null)
        throw new MyNotFoundException(ApiResponseDescription.USER_NOT_FOUND);

      var codeDecodedBytes = WebEncoders.Base64UrlDecode(model.Token);
      var codeDecoded = Encoding.UTF8.GetString(codeDecodedBytes);

      var result = await _userManager.ConfirmEmailAsync(user, codeDecoded);

      if (result.Succeeded)
        return new ApiResponse(true);
      else
        throw new MyException(ApiResponseDescription.EMAIL_ADDRESS_COULD_NOT_BE_CONFIRMED);
    }

    public async Task<ApiResponse> ForgotPassword(EmailVm model)
    {
      var user = await _userManager.FindByEmailAsync(model.Email);

      if (user == null)
        throw new MyNotFoundException(ApiResponseDescription.USER_NOT_FOUND);

      var token = await _userManager.GeneratePasswordResetTokenAsync(user);

      byte[] tokenGeneratedBytes = Encoding.UTF8.GetBytes(token);
      var codeEncoded = WebEncoders.Base64UrlEncode(tokenGeneratedBytes);

      var url = "http://localhost:5000/forgotPassword" + "?email=" + user.Email + "&token=" + codeEncoded;

      SendEmail.Send(user.Email, "Password reset request", url);

      return new ApiResponse(true);
    }

    public async Task<ApiResponse> ResetPassword(PasswordResetVm model)
    {
      var user = await _userManager.FindByEmailAsync(model.Email);

      if (user == null)
        throw new MyNotFoundException(ApiResponseDescription.USER_NOT_FOUND);

      var codeDecodedBytes = WebEncoders.Base64UrlDecode(model.Token);
      var tokenDecoded = Encoding.UTF8.GetString(codeDecodedBytes);

      var result = await _userManager.ResetPasswordAsync(user, tokenDecoded, model.Password);

      return new ApiResponse(result.Succeeded);
    }

    public async Task<ApiResponse> UpdateUserInfo(string id, ApplicationUserVm userVm)
    {
      var user = _unitOfWork.userRepository.FindByCondition(x => x.Id == id).FirstOrDefault();

      if (user == null)
        throw new MyNotFoundException(ApiResponseDescription.USER_NOT_FOUND);

      _mapper.Map(userVm, user);

      _unitOfWork.userRepository.Update(user);
      await _unitOfWork.CompleteAsync();

      return new ApiResponse(true);
    }

    public UserUpdateInfoVm GetUserUpdateInfo(string id)
    {
      var user = _unitOfWork.userRepository.FindByCondition(x => x.Id == id).FirstOrDefault();

      if (user == null)
        throw new MyNotFoundException(ApiResponseDescription.USER_NOT_FOUND);

      var result = _mapper.Map<ApplicationUser, UserUpdateInfoVm>(user);

      return result;
    }

    public ApplicationUserVm GetUser(string id)
    {
      var user = _unitOfWork.userRepository.FindByCondition(x => x.Id == id).FirstOrDefault();

      if (user == null)
        throw new MyNotFoundException(ApiResponseDescription.USER_NOT_FOUND);

      var result = _mapper.Map<ApplicationUser, ApplicationUserVm>(user);

      return result;
    }

    public async Task<ApiResponse> AddOrUpdateUserAchievement(string id, AchievementDyscyplineVm achievementDyscyplineVm)
    {
      var user = _unitOfWork.userRepository.FindByCondition(x => x.Id == id).FirstOrDefault();

      if (user == null)
        throw new MyNotFoundException(ApiResponseDescription.USER_NOT_FOUND);

      if (achievementDyscyplineVm.Id == 0)
      {
        var model = _mapper.Map<AchievementDyscyplineVm, AchievementDyscypline>(achievementDyscyplineVm);

        model.ApplicationUserId = id;

        _unitOfWork.achievementDyscyplineRepository.Create(model);
      }
      else
      {
        var model = _unitOfWork.achievementDyscyplineRepository.FindByCondition(x => x.Id == achievementDyscyplineVm.Id).FirstOrDefault();

        _mapper.Map<AchievementDyscyplineVm, AchievementDyscypline>(achievementDyscyplineVm, model);

        _unitOfWork.achievementDyscyplineRepository.Update(model);
      }

      await _unitOfWork.CompleteAsync();

      return new ApiResponse(true);
    }

    public AchievementDyscyplineVm GetUserAchievements(string userId, int id)
    {
      var user = _unitOfWork.userRepository.FindByCondition(x => x.Id == userId).FirstOrDefault();

      if (user == null)
        throw new MyNotFoundException(ApiResponseDescription.USER_NOT_FOUND);

      var model = _unitOfWork.achievementDyscyplineRepository.FindByCondition(x => x.Id == id).Include(x => x.Achievements).FirstOrDefault();

      var result = _mapper.Map<AchievementDyscypline, AchievementDyscyplineVm>(model);

      return result;
    }

    public List<AchievementDyscyplineVm> GetUserAchievementsList(string userId)
    {
      var user = _unitOfWork.userRepository.FindByCondition(x => x.Id == userId).FirstOrDefault();

      if (user == null)
        throw new MyNotFoundException(ApiResponseDescription.USER_NOT_FOUND);

      var model = _unitOfWork.achievementDyscyplineRepository.FindByCondition(x => x.ApplicationUserId == userId).Include(x => x.Achievements).ToList();

      var result = _mapper.Map<List<AchievementDyscypline>, List<AchievementDyscyplineVm>>(model);

      return result;
    }

    public async Task<ApiResponse> DeleteUserAchievementDyscypline(string userId, int id)
    {
      var user = _unitOfWork.userRepository.FindByCondition(x => x.Id == userId).FirstOrDefault();

      if (user == null)
        throw new MyNotFoundException(ApiResponseDescription.USER_NOT_FOUND);

      var achievementDyscyplines = _unitOfWork.achievementDyscyplineRepository.FindByCondition(x => x.Id == id).Include(x => x.Achievements).FirstOrDefault();

      if (achievementDyscyplines == null)
        throw new MyNotFoundException(ApiResponseDescription.ACHIEVEMENT_DYSCYPLINE_NOT_FOUND);

      _unitOfWork.achievementDyscyplineRepository.Delete(achievementDyscyplines);
      await _unitOfWork.CompleteAsync();

      return new ApiResponse(true);
    }

    public async Task<ApiResponse> DeleteUserAchievement(string userId, int id)
    {
      var user = _unitOfWork.userRepository.FindByCondition(x => x.Id == userId).FirstOrDefault();

      if (user == null)
        throw new MyNotFoundException(ApiResponseDescription.USER_NOT_FOUND);

      var model = _unitOfWork.achievementsRepository.FindByCondition(x => x.Id == id).FirstOrDefault();

      if (model == null)
        throw new MyNotFoundException(ApiResponseDescription.ACHIEVEMENT_NOT_FOUND);

      _unitOfWork.achievementsRepository.Delete(model);
      await _unitOfWork.CompleteAsync();

      return new ApiResponse(true);
    }

    public IQueryable<ApplicationUser> OrderBy(IQueryable<ApplicationUser> query, string orderBy)
    {
      switch (orderBy)
      {
        case "firstname":
          return query.OrderBy(i => i.FirstName);

        case "-firstname":
          return query.OrderByDescending(i => i.FirstName);

        case "lastname":
          return query.OrderBy(i => i.LastName);

        case "-lastname":
          return query.OrderByDescending(i => i.LastName);

        case "email":
          return query.OrderBy(i => i.Email);

        case "-email":
          return query.OrderByDescending(i => i.Email);

        default:
          return query.OrderBy(i => i.LastName);
      }
    }

    public ApplicationUserVm GetUserByEmail(string email)
    {
      var user = _unitOfWork.userRepository.FindByCondition(x => x.Email == email).FirstOrDefault();
      return _mapper.Map<ApplicationUserVm>(user);
    }

    private IQueryable<ApplicationUser> GetSearchQuery(IQueryable<ApplicationUser> query, string searchString)
    {
      if (String.IsNullOrEmpty(searchString))
      {
        return query;
      }
      return query
          .Where(
                  user => user.LastName.ToUpper().Contains(searchString.ToUpper())
                  || user.FirstName.ToUpper().Contains(searchString.ToUpper())
                  || user.Email.ToUpper().Contains(searchString.ToUpper())
              );
    }

    public async Task<PaginatedList<ApplicationUserVm>> GetUsers(PageQuery pageQuery, string searchString = null)
    {
      var query = _unitOfWork.userRepository.FindAll();
      query = GetSearchQuery(query, searchString); // filtered when will be on DB

      IQueryable<ApplicationUserVm> orderedQuery = _unitOfWork.userRepository.OrderBy(query, pageQuery.Orderby).Select(x => _mapper.Map<ApplicationUserVm>(x));
      return await PaginatedList<ApplicationUserVm>.CreateAsync(orderedQuery, pageQuery.Page, pageQuery.Pagesize);
    }

    //TODO: Sprawdziæ
    public async Task<ApiResponse> SendCoachingRequest(CoachingRequestVm coachRequestVm)
    {
      var user = _unitOfWork.userRepository.FindByCondition(x => x.Id == coachRequestVm.ApplicationUserId).FirstOrDefault();
      var userCoach = _unitOfWork.userRepository.FindByCondition(x => x.Id == coachRequestVm.CoachId).FirstOrDefault();

      if (user == null && userCoach == null && user.Id != userCoach.Id)
        throw new MyNotFoundException(ApiResponseDescription.USER_NOT_FOUND);

      var model = _mapper.Map<CoachingRequestVm, CoachingRequest>(coachRequestVm);

      model.ApplicationUserId = coachRequestVm.ApplicationUserId;
      model.Status = CoachingRequestStatus.Sent;

      _unitOfWork.coachingRequestRepository.Create(model);
      await _unitOfWork.CompleteAsync();

      return new ApiResponse(true);
    }
  }
}