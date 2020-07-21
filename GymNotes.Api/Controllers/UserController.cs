using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using GymNotes.Entity.Models;
using GymNotes.Filters;
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
  public class UserController : ControllerBase
  {
    private readonly ICoachService _coachService;
    private IUserService _userService;

    public UserController(
      IUserService userService,
      ICoachService coachService)
    {
      _userService = userService;
      _coachService = coachService;
    }

    #region POST

    [AllowAnonymous]
    [ApiValidationFilter]
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] UserRegisterVm userModel) =>
      Ok(await _userService.Register(userModel));

    [AllowAnonymous]
    [ApiValidationFilter]
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] UserLoginVm model) =>
      Ok(await _userService.Login(model));

    [AllowAnonymous]
    [ApiValidationFilter]
    [HttpPost("confirmEmailAddress")]
    public async Task<IActionResult> ConfirmEmailAddress([FromBody] EmailConfirmationVm model) =>
      Ok(await _userService.ConfirmEmailAddress(model));

    [AllowAnonymous]
    [ApiValidationFilter] //TODO: Przyjąć email z parametru
    [HttpPost("forgotPassword")]
    public async Task<IActionResult> ForgotPassword(EmailVm model) =>
      Ok(await _userService.ForgotPassword(model));

    [AllowAnonymous]
    [ApiValidationFilter]
    [HttpPost("resetPassword")]
    public async Task<IActionResult> ResetPassword(PasswordResetVm model) =>
      Ok(await _userService.ResetPassword(model));

    [Authorize]
    [ApiValidationFilter]
    [HttpPost("updateUserInfo/{id}")]
    public async Task<IActionResult> UpdateUserInfo(string id, [FromBody] UserVm model) =>
      Ok(await _userService.UpdateUserInfo(id, model));

    [Authorize]
    [ApiValidationFilter]
    [HttpPost("addOrUpdateUserAchievements/{id}")]
    public async Task<IActionResult> AddOrUpdateUserAchievements(string id, [FromBody] AchievementDyscyplineVm achievementDyscyplineVm) =>
      Ok(await _userService.AddOrUpdateUserAchievement(id, achievementDyscyplineVm));

    //TODO: Sprawdzić
    [Authorize]
    [ApiValidationFilter]
    [HttpPost("coachingRequest")]
    public async Task<IActionResult> SendCoachingRequest([FromBody] CoachingRequestVm coachRequestVm) =>
      Ok(await _userService.SendCoachingRequest(coachRequestVm));

    //TODO: Sprawdzić
    [Authorize]
    [ApiValidationFilter]
    [HttpPost("coachCancelManagment")]
    public async Task<IActionResult> CoachCancelManagment([FromBody] CoachCancelManagmentVm coachCancelManagmentVm) =>
      Ok(await _coachService.CoachCancelManagment(coachCancelManagmentVm));

    #endregion POST

    #region DELETE

    [Authorize]
    [HttpDelete("deleteUserAchievementsList/{userId}/{id}")]
    public async Task<IActionResult> DeleteUserAchievementsList(string userId, int id) =>
      Ok(await _userService.DeleteUserAchievementDyscypline(userId, id));

    [Authorize]
    [HttpDelete("deleteUserAchievement/{userId}/{id}")]
    public async Task<IActionResult> DeleteUserAchievement(string userId, int id) =>
      Ok(await _userService.DeleteUserAchievement(userId, id));

    #endregion DELETE

    #region GET

    [Authorize]
    [HttpGet("search")]
    public async Task<ActionResult<PaginatedList<UserVm>>> GetUsers([FromQuery] PageQuery pageQuery, [FromQuery] string search, [FromQuery] string key) =>
        Ok(await _userService.GetUsers(pageQuery, search));

    [Authorize]
    [HttpGet("getUser/{id}")]
    public IActionResult GetUser(string id) =>
      Ok(_userService.GetUser(id));

    [Authorize]
    [HttpGet("getUserAchievements/{userid}/{id}")]
    public IActionResult GetUserAchievements(string userid, int id) =>
      Ok(_userService.GetUserAchievements(userid, id));

    [Authorize]
    [HttpGet("getUserAchievementsList/{id}")]
    public IActionResult GetUserAchievementsList(string id) =>
      Ok(_userService.GetUserAchievementsList(id));

    #endregion GET
  }
}