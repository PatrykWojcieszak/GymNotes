using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using GymNotes.Entity.Models;
using GymNotes.Models;
using GymNotes.Repository.IRepository;
using GymNotes.Service.Email;
using GymNotes.Service.IService;
using GymNotes.Service.Utils;
using GymNotes.Service.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using NETCore.MailKit.Core;

namespace GymNotes.Controllers
{
  [Route("api/user")]
  [ApiController]
  public class ApplicationUserController : ControllerBase
  {
    private readonly ICoachService _coachService;
    private IApplicationUserService _userService;
    private UserManager<ApplicationUser> _userManager;
    private SignInManager<ApplicationUser> _signInManager;
    private ApplicationSettings _appSettings;
    private IUnitOfWork _unitOfWork;
    // private IApplicationUserRepository _userRepo;

    public ApplicationUserController(IApplicationUserService userService,
      IUnitOfWork unitOfWork,
      UserManager<ApplicationUser> userManager,
      SignInManager<ApplicationUser> signInManager,
      IOptions<ApplicationSettings> appSettings,
      ICoachService coachService)
    {
      _userService = userService;
      _unitOfWork = unitOfWork;
      _userManager = userManager;
      _signInManager = signInManager;
      _appSettings = appSettings.Value;
      _coachService = coachService;
    }

    [Authorize]
    [HttpGet("search")]
    public async Task<ActionResult<PaginatedList<ApplicationUserVm>>> GetUsers([FromQuery] PageQuery pageQuery, [FromQuery] string search) =>
        Ok(await _userService.GetUsers(pageQuery, search));

    [AllowAnonymous]
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] UserRegisterVm userModel)
    {
      if (!ModelState.IsValid)
        return BadRequest(ModelState);

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

        var url = Url.Content("http://localhost:5000/emailConfirmation" + "?email=" + user.Email + "&token=" + codeEncoded);

        SendEmail.Send(user.Email, "Email confirmation", url);

        return Ok(result);
      }
      else
      {
        return BadRequest(new { message = "Email already in use." });
      }
    }

    [AllowAnonymous]
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] UserLoginVm model)
    {
      if (!ModelState.IsValid)
        return BadRequest(ModelState);

      var user = await _userManager.FindByNameAsync(model.Email);
      if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
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
        return Ok(new { token, user.Id, user.FirstName, user.LastName, user.Email, user.Alias });
      }
      else
      {
        return BadRequest(new { message = "Incorrect password or email. Please try again or click 'Forgot password' to reset it." });
      }
    }

    [AllowAnonymous]
    [HttpPost("confirmEmailAddress")]
    public async Task<IActionResult> ConfirmEmailAddress([FromBody] EmailConfirmationVm model)
    {
      if (!ModelState.IsValid)
        return BadRequest(ModelState);

      var user = await _userManager.FindByEmailAsync(model.Email);
      if (user != null)
      {
        var codeDecodedBytes = WebEncoders.Base64UrlDecode(model.Token);
        var codeDecoded = Encoding.UTF8.GetString(codeDecodedBytes);

        var result = await _userManager.ConfirmEmailAsync(user, codeDecoded);

        if (result.Succeeded)
          return Ok();
        else
          return BadRequest("Email address could not be confirmed!");
      }
      else
        return BadRequest("User not found");
    }

    [AllowAnonymous]
    [HttpPost("forgotPassword")]
    public async Task<IActionResult> ForgotPassword(EmailVm model)
    {
      if (!ModelState.IsValid)
        return BadRequest(ModelState);

      var user = await _userManager.FindByEmailAsync(model.Email);

      if (user == null)
        return NotFound();

      var token = await _userManager.GeneratePasswordResetTokenAsync(user);

      byte[] tokenGeneratedBytes = Encoding.UTF8.GetBytes(token);
      var codeEncoded = WebEncoders.Base64UrlEncode(tokenGeneratedBytes);

      var url = Url.Content("http://localhost:5000/forgotPassword" + "?email=" + user.Email + "&token=" + codeEncoded);

      SendEmail.Send(user.Email, "Password reset request", url);

      return Ok();
    }

    [AllowAnonymous]
    [HttpPost("resetPassword")]
    public async Task<IActionResult> ResetPassword(PasswordResetVm model)
    {
      if (!ModelState.IsValid)
        return BadRequest(ModelState);

      var user = await _userManager.FindByEmailAsync(model.Email);

      if (user == null)
        return NotFound();

      var codeDecodedBytes = WebEncoders.Base64UrlDecode(model.Token);
      var tokenDecoded = Encoding.UTF8.GetString(codeDecodedBytes);

      var result = await _userManager.ResetPasswordAsync(user, tokenDecoded, model.Password);

      return Ok(result);
    }

    [Authorize]
    [HttpPost("updateUserInfo/{id}")]
    public async Task<IActionResult> UpdateUserInfo(string id, [FromBody] ApplicationUserVm model)
    {
      if (!ModelState.IsValid)
        return BadRequest(ModelState);

      var result = await _userService.UpdateUserInfo(id, model);

      if (result)
        return Ok();
      else
        return BadRequest("Something went wrong!");
    }

    [Authorize]
    [HttpGet("getUserUpdateInfo/{id}")]
    public IActionResult GetUserUpdateInfo(string id)
    {
      var result = _userService.GetUserUpdateInfo(id);

      if (result != null)
        return Ok(result);
      else
        return BadRequest("Something went wrong!");
    }

    [Authorize]
    [HttpGet("getUser/{id}")]
    public IActionResult GetUser(string id)
    {
      var result = _userService.GetUser(id);

      if (result != null)
        return Ok(result);
      else
        return BadRequest("Something went wrong!");
    }

    [Authorize]
    [HttpPost("addOrUpdateUserAchievements/{id}")]
    public async Task<IActionResult> AddOrUpdateUserAchievements(string id, [FromBody] AchievementDyscyplineVm achievementDyscyplineVm)
    {
      if (!ModelState.IsValid)
        return BadRequest(ModelState);

      var result = await _userService.AddOrUpdateUserAchievement(id, achievementDyscyplineVm);

      if (result)
        return Ok();
      else
        return BadRequest("Something went wrong");
    }

    [Authorize]
    [HttpGet("getUserAchievements/{userid}/{id}")]
    public IActionResult GetUserAchievements(string userid, int id)
    {
      var result = _userService.GetUserAchievements(userid, id);

      if (result != null)
        return Ok(result);
      else
        return BadRequest("Something went wrong!");
    }

    [Authorize]
    [HttpGet("getUserAchievementsList/{id}")]
    public IActionResult GetUserAchievementsList(string id)
    {
      var result = _userService.GetUserAchievementsList(id);

      if (result != null)
        return Ok(result);
      else
        return BadRequest("Something went wrong!");
    }

    [Authorize]
    [HttpDelete("deleteUserAchievementsList/{userId}/{id}")]
    public async Task<IActionResult> DeleteUserAchievementsList(string userId, int id)
    {
      var result = await _userService.DeleteUserAchievementDyscypline(userId, id);

      if (result)
        return Ok();
      else
        return BadRequest("Something went wrong!");
    }

    [Authorize]
    [HttpDelete("deleteUserAchievement/{userId}/{id}")]
    public async Task<IActionResult> DeleteUserAchievement(string userId, int id)
    {
      var result = await _userService.DeleteUserAchievement(userId, id);

      if (result)
        return Ok();
      else
        return BadRequest("Something went wrong!");
    }

    [Authorize]
    [HttpPost("coachingRequest")]
    public async Task<IActionResult> SendCoachingRequest([FromBody] CoachingRequestVm coachRequestVm)
    {
      var result = await _userService.SendCoachingRequest(coachRequestVm);

      if (result)
        return Ok();
      else
        return BadRequest("Something went wrong!");
    }

    [Authorize]
    [HttpPost("coachCancelManagment")]
    public async Task<IActionResult> CoachCancelManagment([FromBody] CoachCancelManagmentVm coachCancelManagmentVm)
    {
      var result = await _coachService.CoachCancelManagment(coachCancelManagmentVm);

      if (result)
        return Ok();
      else
        return BadRequest("Something went wrong!");
    }
  }
}