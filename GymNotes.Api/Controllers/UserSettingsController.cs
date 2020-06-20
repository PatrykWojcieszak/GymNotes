using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GymNotes.Filters;
using GymNotes.Service.IService;
using GymNotes.Service.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GymNotes.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class UserSettingsController : ControllerBase
  {
    private readonly IUserSettingsService _userSettingsService;

    public UserSettingsController(IUserSettingsService userSettingsService)
    {
      _userSettingsService = userSettingsService;
    }

    #region Post

    [Authorize]
    [ApiValidationFilter]
    [HttpPost("changeName/")]
    public async Task<IActionResult> ChangeName([FromBody] UpdateUserNameVm updateUserNameVm) =>
      Ok(await _userSettingsService.ChangeName(updateUserNameVm));

    [Authorize]
    [ApiValidationFilter]
    [HttpPost("changePassword/")]
    public async Task<IActionResult> ChangePassword([FromBody] UpdatePasswordVm updatePasswordVm) =>
      Ok(await _userSettingsService.ChangePassword(updatePasswordVm));

    [Authorize]
    [ApiValidationFilter]
    [HttpPost("changeEmail/")]
    public async Task<IActionResult> ChangeEmail([FromBody] UserEmailVm userEmailVm) =>
      Ok(await _userSettingsService.ChangeEmail(userEmailVm));

    #endregion Post

    #region Get

    [Authorize]
    [HttpGet("getUserFullName/{userId}")]
    public IActionResult GetUserFullName(string userId) =>
      Ok(_userSettingsService.GetuserFullName(userId));

    [Authorize]
    [HttpGet("getUserEmail/{userId}")]
    public IActionResult GetUserEmail(string userId) =>
      Ok(_userSettingsService.GetUserEmail(userId));

    #endregion Get
  }
}