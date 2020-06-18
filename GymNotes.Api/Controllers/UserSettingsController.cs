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

    [Authorize]
    [ApiValidationFilter]
    [HttpPost("changeName/")]
    public async Task<IActionResult> ChangeName([FromBody] UpdateUserNameVm updateUserNameVm)
    {
      //if (!ModelState.IsValid)
      //  return BadRequest(ModelState);

      var result = await _userSettingsService.ChangeName(updateUserNameVm);

      if (result)
        return Ok();
      else
        return BadRequest("Something went wrong!");
    }

    [Authorize]
    [ApiValidationFilter]
    [HttpPost("changePassword/")]
    public async Task<IActionResult> ChangePassword([FromBody] UpdatePasswordVm updatePasswordVm)
    {
      //if (!ModelState.IsValid)
      //  return BadRequest(ModelState);

      var result = await _userSettingsService.ChangePassword(updatePasswordVm);

      if (result == IdentityResult.Success)
        return Ok();
      else
        return BadRequest("Old password does not match.");
    }

    [Authorize]
    [ApiValidationFilter]
    [HttpPost("changeEmail/")]
    public async Task<IActionResult> ChangeEmail([FromBody] UserEmailVm userEmailVm)
    {
      //if (!ModelState.IsValid)
      //  return BadRequest(ModelState);

      var result = await _userSettingsService.ChangeEmail(userEmailVm);

      if (result)
        return Ok();
      else
        return BadRequest("Something went wrong!");
    }

    [Authorize]
    [HttpGet("getUserFullName/{userId}")]
    public IActionResult GetUserFullName(string userId)
    {
      //if (!ModelState.IsValid)
      //  return BadRequest(ModelState);

      var result = _userSettingsService.GetuserFullName(userId);

      if (result != null)
        return Ok(result);
      else
        return BadRequest("Something went wrong!");
    }

    [Authorize]
    [HttpGet("getUserEmail/{userId}")]
    public IActionResult GetUserEmail(string userId)
    {
      //if (!ModelState.IsValid)
      //  return BadRequest(ModelState);

      var result = _userSettingsService.GetUserEmail(userId);

      if (result != null)
        return Ok(result);
      else
        return BadRequest("Something went wrong!");
    }
  }
}