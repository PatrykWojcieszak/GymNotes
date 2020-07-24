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
using GymNotes.Service.ViewModels.Authentication;
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
  [Authorize]
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
    [HttpPost("authenticate")]
    public async Task<IActionResult> Authenticate([FromBody] AuthenticationVm model)
    {
      var response = await _userService.Authentication(model, ipAddress());

      setTokenCookie(response.RefreshToken);

      return Ok(response);
    }

    [AllowAnonymous]
    [HttpPost("refresh-token")]
    public async Task<IActionResult> RefreshToken()
    {
      var refreshToken = Request.Cookies["refreshToken"];
      var response = await _userService.RefreshToken(refreshToken, ipAddress());

      if (response == null)
        return Unauthorized(new { message = "Invalid token" });

      setTokenCookie(response.RefreshToken);

      return Ok(response);
    }

    [HttpPost("revoke-token")]
    public async Task<IActionResult> RevokeToken([FromBody] RevokeTokenRequestVm model)
    {
      // accept token from request body or cookie
      var token = model.Token ?? Request.Cookies["refreshToken"];

      if (string.IsNullOrEmpty(token))
        return BadRequest(new { message = "Token is required" });

      var response = await _userService.RevokeToken(token, ipAddress());

      if (!response)
        return NotFound(new { message = "Token not found" });

      return Ok(new { message = "Token revoked" });
    }

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

    [ApiValidationFilter]
    [HttpPost("updateUserInfo/{id}")]
    public async Task<IActionResult> UpdateUserInfo(string id, [FromBody] UserVm model) =>
      Ok(await _userService.UpdateUserInfo(id, model));

    [ApiValidationFilter]
    [HttpPost("addOrUpdateUserAchievements/{id}")]
    public async Task<IActionResult> AddOrUpdateUserAchievements(string id, [FromBody] AchievementDyscyplineVm achievementDyscyplineVm) =>
      Ok(await _userService.AddOrUpdateUserAchievement(id, achievementDyscyplineVm));

    //TODO: Sprawdzić
    [ApiValidationFilter]
    [HttpPost("coachingRequest")]
    public async Task<IActionResult> SendCoachingRequest([FromBody] CoachingRequestVm coachRequestVm) =>
      Ok(await _userService.SendCoachingRequest(coachRequestVm));

    //TODO: Sprawdzić
    [ApiValidationFilter]
    [HttpPost("coachCancelManagment")]
    public async Task<IActionResult> CoachCancelManagment([FromBody] CoachCancelManagmentVm coachCancelManagmentVm) =>
      Ok(await _coachService.CoachCancelManagment(coachCancelManagmentVm));

    [ApiValidationFilter]
    [HttpPost("search")]
    public async Task<ActionResult<PaginatedList<UserVm>>> GetUsers([FromBody] PageQuery pageQuery) =>
        Ok(await _userService.GetUsers(pageQuery));

    #endregion POST

    #region DELETE

    [HttpDelete("deleteUserAchievementsList/{userId}/{id}")]
    public async Task<IActionResult> DeleteUserAchievementsList(string userId, int id) =>
      Ok(await _userService.DeleteUserAchievementDyscypline(userId, id));

    [HttpDelete("deleteUserAchievement/{userId}/{id}")]
    public async Task<IActionResult> DeleteUserAchievement(string userId, int id) =>
      Ok(await _userService.DeleteUserAchievement(userId, id));

    #endregion DELETE

    #region GET

    [HttpGet("getUser/{id}")]
    public IActionResult GetUser(string id) =>
      Ok(_userService.GetUser(id));

    [HttpGet("getUserAchievements/{userid}/{id}")]
    public IActionResult GetUserAchievements(string userid, int id) =>
      Ok(_userService.GetUserAchievements(userid, id));

    [HttpGet("getUserAchievementsList/{id}")]
    public IActionResult GetUserAchievementsList(string id) =>
      Ok(_userService.GetUserAchievementsList(id));

    #endregion GET

    //Helper methods
    private void setTokenCookie(string token)
    {
      var cookieOptions = new CookieOptions
      {
        HttpOnly = true,
        Expires = DateTime.UtcNow.AddDays(7)
      };
      Response.Cookies.Append("refreshToken", token, cookieOptions);
    }

    private string ipAddress()
    {
      if (Request.Headers.ContainsKey("X-Forwarded-For"))
        return Request.Headers["X-Forwarded-For"];
      else
        return HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
    }
  }
}