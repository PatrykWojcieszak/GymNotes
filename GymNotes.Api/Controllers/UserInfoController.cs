using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GymNotes.Service.IService;
using GymNotes.Service.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GymNotes.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class UserInfoController : ControllerBase
  {
    private readonly IUserInfoService _userInfoService;

    public UserInfoController(IUserInfoService userInfoService)
    {
      _userInfoService = userInfoService;
    }

    [Authorize]
    [HttpPost("updateInstagramUrl/")]
    public async Task<IActionResult> UpdateInstagramURL([FromBody] UpdateURLVm updateURLVm)
    {
      if (!ModelState.IsValid)
        return BadRequest(ModelState);

      var result = await _userInfoService.UpdateInstagramURL(updateURLVm);

      if (result)
        return Ok();
      else
        return BadRequest("Something went wrong!");
    }

    [Authorize]
    [HttpPost("updateFacebookUrl/")]
    public async Task<IActionResult> UpdateFacebookURL([FromBody] UpdateURLVm updateURLVm)
    {
      if (!ModelState.IsValid)
        return BadRequest(ModelState);

      var result = await _userInfoService.UpdateFacebookURL(updateURLVm);

      if (result)
        return Ok();
      else
        return BadRequest("Something went wrong!");
    }

    [Authorize]
    [HttpPost("updateTwitterUrl/")]
    public async Task<IActionResult> UpdateTwitterURL([FromBody] UpdateURLVm updateURLVm)
    {
      if (!ModelState.IsValid)
        return BadRequest(ModelState);

      var result = await _userInfoService.UpdateTwitterURL(updateURLVm);

      if (result)
        return Ok();
      else
        return BadRequest("Something went wrong!");
    }

    [Authorize]
    [HttpPost("updateYoutubeUrl/")]
    public async Task<IActionResult> UpdateYoutubeUrl([FromBody] UpdateURLVm updateURLVm)
    {
      if (!ModelState.IsValid)
        return BadRequest(ModelState);

      var result = await _userInfoService.UpdateYoutubeURL(updateURLVm);

      if (result)
        return Ok();
      else
        return BadRequest("Something went wrong!");
    }

    [Authorize]
    [HttpPost("updateDescription/")]
    public async Task<IActionResult> UpdateDescription([FromBody] StringUpdateVm stringUpdateVm)
    {
      if (!ModelState.IsValid)
        return BadRequest(ModelState);

      var result = await _userInfoService.UpdateDescription(stringUpdateVm);

      if (result)
        return Ok();
      else
        return BadRequest("Something went wrong!");
    }

    [Authorize]
    [HttpPost("updateDiscipline/")]
    public async Task<IActionResult> UpdateDiscipline([FromBody] StringUpdateVm stringUpdateVm)
    {
      if (!ModelState.IsValid)
        return BadRequest(ModelState);

      var result = await _userInfoService.UpdateDiscipline(stringUpdateVm);

      if (result)
        return Ok();
      else
        return BadRequest("Something went wrong!");
    }

    [Authorize]
    [HttpPost("updateGender/")]
    public async Task<IActionResult> UpdateGender([FromBody] StringUpdateVm stringUpdateVm)
    {
      if (!ModelState.IsValid)
        return BadRequest(ModelState);

      var result = await _userInfoService.UpdateGender(stringUpdateVm);

      if (result)
        return Ok();
      else
        return BadRequest("Something went wrong!");
    }

    [Authorize]
    [HttpPost("updateYearsOfExperience/")]
    public async Task<IActionResult> UpdateYearsOfExperience([FromBody] NumberUpdateVm numberUpdateVm)
    {
      if (!ModelState.IsValid)
        return BadRequest(ModelState);

      var result = await _userInfoService.UpdateYearsOfExperience(numberUpdateVm);

      if (result)
        return Ok();
      else
        return BadRequest("Something went wrong!");
    }

    [Authorize]
    [HttpPost("updateHeight/")]
    public async Task<IActionResult> UpdateHeight([FromBody] NumberUpdateVm numberUpdateVm)
    {
      if (!ModelState.IsValid)
        return BadRequest(ModelState);

      var result = await _userInfoService.UpdateHeight(numberUpdateVm);

      if (result)
        return Ok();
      else
        return BadRequest("Something went wrong!");
    }

    [Authorize]
    [HttpPost("updateIsCoach/")]
    public async Task<IActionResult> UpdateIsCoach([FromBody] StringUpdateVm stringUpdateVm)
    {
      if (!ModelState.IsValid)
        return BadRequest(ModelState);

      var result = await _userInfoService.UpdateIsCoach(stringUpdateVm);

      if (result)
        return Ok();
      else
        return BadRequest("Something went wrong!");
    }

    [Authorize]
    [HttpPost("updateBirthday/")]
    public async Task<IActionResult> UpdateBirthday([FromBody] DateUpdateVm dateUpdateVm)
    {
      if (!ModelState.IsValid)
        return BadRequest(ModelState);

      var result = await _userInfoService.UpdateBirthday(dateUpdateVm);

      if (result)
        return Ok();
      else
        return BadRequest("Something went wrong!");
    }
  }
}