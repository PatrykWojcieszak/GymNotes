using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using GymNotes.Filters;
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
    [ApiValidationFilter]
    [HttpPost("updateInstagramUrl/")]
    public async Task<IActionResult> UpdateInstagramURL([FromBody] UpdateURLVm updateURLVm)
    {
      var result = await _userInfoService.UpdateInstagramURL(updateURLVm);

      if (result.StatusCode != (int)HttpStatusCode.OK)
      {
        return BadRequest(result);
      }

      return Ok(result);
    }

    [Authorize]
    [ApiValidationFilter]
    [HttpPost("updateFacebookUrl/")]
    public async Task<IActionResult> UpdateFacebookURL([FromBody] UpdateURLVm updateURLVm)
    {
      var result = await _userInfoService.UpdateFacebookURL(updateURLVm);

      if (result.StatusCode != (int)HttpStatusCode.OK)
      {
        return BadRequest(result);
      }

      return Ok(result);
    }

    [Authorize]
    [ApiValidationFilter]
    [HttpPost("updateTwitterUrl/")]
    public async Task<IActionResult> UpdateTwitterURL([FromBody] UpdateURLVm updateURLVm)
    {
      var result = await _userInfoService.UpdateTwitterURL(updateURLVm);

      if (result.StatusCode != (int)HttpStatusCode.OK)
      {
        return BadRequest(result);
      }

      return Ok(result);
    }

    [Authorize]
    [ApiValidationFilter]
    [HttpPost("updateYoutubeUrl/")]
    public async Task<IActionResult> UpdateYoutubeUrl([FromBody] UpdateURLVm updateURLVm)
    {
      var result = await _userInfoService.UpdateYoutubeURL(updateURLVm);

      if (result.StatusCode != (int)HttpStatusCode.OK)
      {
        return BadRequest(result);
      }

      return Ok(result);
    }

    [Authorize]
    [ApiValidationFilter]
    [HttpPost("updateDescription/")]
    public async Task<IActionResult> UpdateDescription([FromBody] StringUpdateVm stringUpdateVm)
    {
      var result = await _userInfoService.UpdateDescription(stringUpdateVm);

      if (result.StatusCode != (int)HttpStatusCode.OK)
      {
        return BadRequest(result);
      }

      return Ok(result);
    }

    [Authorize]
    [ApiValidationFilter]
    [HttpPost("updateDiscipline/")]
    public async Task<IActionResult> UpdateDiscipline([FromBody] StringUpdateVm stringUpdateVm)
    {
      var result = await _userInfoService.UpdateDiscipline(stringUpdateVm);

      if (result.StatusCode != (int)HttpStatusCode.OK)
      {
        return BadRequest(result);
      }

      return Ok(result);
    }

    [Authorize]
    [ApiValidationFilter]
    [HttpPost("updateGender/")]
    public async Task<IActionResult> UpdateGender([FromBody] StringUpdateVm stringUpdateVm)
    {
      var result = await _userInfoService.UpdateGender(stringUpdateVm);

      if (result.StatusCode != (int)HttpStatusCode.OK)
      {
        return BadRequest(result);
      }

      return Ok(result);
    }

    [Authorize]
    [ApiValidationFilter]
    [HttpPost("updateYearsOfExperience/")]
    public async Task<IActionResult> UpdateYearsOfExperience([FromBody] NumberUpdateVm numberUpdateVm)
    {
      var result = await _userInfoService.UpdateYearsOfExperience(numberUpdateVm);

      if (result.StatusCode != (int)HttpStatusCode.OK)
      {
        return BadRequest(result);
      }

      return Ok(result);
    }

    [Authorize]
    [ApiValidationFilter]
    [HttpPost("updateHeight/")]
    public async Task<IActionResult> UpdateHeight([FromBody] NumberUpdateVm numberUpdateVm)
    {
      var result = await _userInfoService.UpdateHeight(numberUpdateVm);

      if (result.StatusCode != (int)HttpStatusCode.OK)
      {
        return BadRequest(result);
      }

      return Ok(result);
    }

    [Authorize]
    [ApiValidationFilter]
    [HttpPost("updateIsCoach/")]
    public async Task<IActionResult> UpdateIsCoach([FromBody] StringUpdateVm stringUpdateVm)
    {
      var result = await _userInfoService.UpdateIsCoach(stringUpdateVm);

      if (result.StatusCode != (int)HttpStatusCode.OK)
      {
        return BadRequest(result);
      }

      return Ok(result);
    }

    [Authorize]
    [ApiValidationFilter]
    [HttpPost("updateBirthday/")]
    public async Task<IActionResult> UpdateBirthday([FromBody] DateUpdateVm dateUpdateVm)
    {
      var result = await _userInfoService.UpdateBirthday(dateUpdateVm);

      if (result.StatusCode != (int)HttpStatusCode.OK)
      {
        return BadRequest(result);
      }

      return Ok(result);
    }
  }
}