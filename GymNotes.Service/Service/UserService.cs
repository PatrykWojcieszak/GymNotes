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

namespace GymNotes.Service.Service
{
  public class UserService : IApplicationUserService
  {
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IAchievementDyscyplineRepository _achievementDyscyplineRepo;
    private readonly IAchievementsRepository _achievementsRepo;
    private readonly ICoachingRequestRepository _coachingRequestRepo;
    private readonly IUserRepository _userRepo;

    public UserService(
      IMapper mapper,
      IUnitOfWork unitOfWork,
      IAchievementDyscyplineRepository achievementDyscyplineRepo,
      IAchievementsRepository achievementsRepo,
      ICoachingRequestRepository coachingRequestRepo,
      IUserRepository userRepo)
    {
      _mapper = mapper;
      _unitOfWork = unitOfWork;
      _achievementDyscyplineRepo = achievementDyscyplineRepo;
      _achievementsRepo = achievementsRepo;
      _coachingRequestRepo = coachingRequestRepo;
      _userRepo = userRepo;
    }

    public async Task<bool> UpdateUserInfo(string id, ApplicationUserVm userVm)
    {
      try
      {
        var userModel = _userRepo.FindByCondition(x => x.Id == id).FirstOrDefault();

        if (userModel == null)
          return false;

        _mapper.Map(userVm, userModel);

        _userRepo.Update(userModel);

        await _unitOfWork.CompleteAsync();

        return true;
      }
      catch (Exception ex)
      {
        return false;
      }
    }

    public UserUpdateInfoVm GetUserUpdateInfo(string id)
    {
      try
      {
        var user = _userRepo.FindByCondition(x => x.Id == id).FirstOrDefault();

        if (user == null)
          return null;

        var result = _mapper.Map<ApplicationUser, UserUpdateInfoVm>(user);

        return result;
      }
      catch (Exception ex)
      {
        return null;
      }
    }

    public ApplicationUserVm GetUser(string id)
    {
      try
      {
        var user = _userRepo.FindByCondition(x => x.Id == id).FirstOrDefault();

        if (user == null)
          return null;

        var result = _mapper.Map<ApplicationUser, ApplicationUserVm>(user);

        return result;
      }
      catch (Exception ex)
      {
        return null;
      }
    }

    public async Task<bool> AddOrUpdateUserAchievement(string id, AchievementDyscyplineVm achievementDyscyplineVm)
    {
      try
      {
        var user = _userRepo.FindByCondition(x => x.Id == id).FirstOrDefault();

        if (user == null)
          return false;

        if (achievementDyscyplineVm.Id == 0)
        {
          var model = _mapper.Map<AchievementDyscyplineVm, AchievementDyscypline>(achievementDyscyplineVm);

          model.ApplicationUserId = id;

          _achievementDyscyplineRepo.AddAchievementDyscypline(model);
        }
        else
        {
          var model = _achievementDyscyplineRepo.GetAchievementDyscypline(achievementDyscyplineVm.Id);

          _mapper.Map<AchievementDyscyplineVm, AchievementDyscypline>(achievementDyscyplineVm, model);

          _achievementDyscyplineRepo.UpdateAchievementDyscypline(model);
        }

        await _unitOfWork.CompleteAsync();

        return true;
      }
      catch (Exception ex)
      {
        return false;
      }
    }

    public AchievementDyscyplineVm GetUserAchievements(string userId, int id)
    {
      try
      {
        var user = _userRepo.FindByCondition(x => x.Id == userId).FirstOrDefault();

        if (user == null)
          return null;

        var model = _achievementDyscyplineRepo.GetUserAchievements(id);

        var result = _mapper.Map<AchievementDyscypline, AchievementDyscyplineVm>(model);

        return result;
      }
      catch (Exception ex)
      {
        return null;
      }
    }

    public List<AchievementDyscyplineVm> GetUserAchievementsList(string userId)
    {
      try
      {
        var user = _userRepo.FindByCondition(x => x.Id == userId).FirstOrDefault();

        if (user == null)
          return null;

        var model = _achievementDyscyplineRepo.GetUserAchievementsList(userId);

        var result = _mapper.Map<List<AchievementDyscypline>, List<AchievementDyscyplineVm>>(model);

        return result;
      }
      catch (Exception ex)
      {
        return null;
      }
    }

    public async Task<bool> DeleteUserAchievementDyscypline(string userId, int id)
    {
      var user = _userRepo.FindByCondition(x => x.Id == userId).FirstOrDefault();

      if (user == null)
        return false;

      var model = _achievementDyscyplineRepo.GetUserAchievements(id);

      if (model == null)
        return false;

      _achievementDyscyplineRepo.DeleteAchievementDyscypline(model);

      await _unitOfWork.CompleteAsync();

      return true;
    }

    public async Task<bool> DeleteUserAchievement(string userId, int id)
    {
      var user = _userRepo.FindByCondition(x => x.Id == userId).FirstOrDefault();

      if (user == null)
        return false;

      var model = _achievementsRepo.GetAchievement(id);

      if (model == null)
        return false;

      _achievementsRepo.DeleteAchievement(model);

      await _unitOfWork.CompleteAsync();

      return true;
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
      var user = _userRepo.FindByCondition(x => x.Email == email).FirstOrDefault();
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
      var query = _userRepo.FindAll();
      query = GetSearchQuery(query, searchString); // filtered when will be on DB

      IQueryable<ApplicationUserVm> orderedQuery = _userRepo.OrderBy(query, pageQuery.Orderby).Select(x => _mapper.Map<ApplicationUserVm>(x));
      return await PaginatedList<ApplicationUserVm>.CreateAsync(orderedQuery, pageQuery.Page, pageQuery.Pagesize);
    }

    //TODO: Sprawdziæ
    public async Task<bool> SendCoachingRequest(CoachingRequestVm coachRequestVm)
    {
      try
      {
        var user = _userRepo.FindByCondition(x => x.Id == coachRequestVm.ApplicationUserId).FirstOrDefault();
        var userCoach = _userRepo.FindByCondition(x => x.Id == coachRequestVm.CoachId).FirstOrDefault();

        if (user == null && userCoach == null && user.Id != userCoach.Id)
          return false;

        var model = _mapper.Map<CoachingRequestVm, CoachingRequest>(coachRequestVm);

        model.ApplicationUserId = coachRequestVm.ApplicationUserId;
        model.Status = (CoachingRequestStatus)0;

        _coachingRequestRepo.AddCoachRequest(model);

        await _unitOfWork.CompleteAsync();

        return true;
      }
      catch (Exception ex)
      {
        return false;
      }
    }
  }
}