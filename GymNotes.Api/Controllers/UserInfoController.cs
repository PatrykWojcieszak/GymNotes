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

    #region Post

    [Authorize]
    [ApiValidationFilter]
    [HttpPost("updateInstagramUrl/")]
    public async Task<IActionResult> UpdateInstagramURL([FromBody] UpdateURLVm updateURLVm) =>
      Ok(await _userInfoService.UpdateInstagramURL(updateURLVm));

    [Authorize]
    [ApiValidationFilter]
    [HttpPost("updateFacebookUrl/")]
    public async Task<IActionResult> UpdateFacebookURL([FromBody] UpdateURLVm updateURLVm) =>
      Ok(await _userInfoService.UpdateFacebookURL(updateURLVm));

    [Authorize]
    [ApiValidationFilter]
    [HttpPost("updateTwitterUrl/")]
    public async Task<IActionResult> UpdateTwitterURL([FromBody] UpdateURLVm updateURLVm) =>
      Ok(await _userInfoService.UpdateTwitterURL(updateURLVm));

    [Authorize]
    [ApiValidationFilter]
    [HttpPost("updateYoutubeUrl/")]
    public async Task<IActionResult> UpdateYoutubeUrl([FromBody] UpdateURLVm updateURLVm) =>
      Ok(await _userInfoService.UpdateYoutubeURL(updateURLVm));

    [Authorize]
    [ApiValidationFilter]
    [HttpPost("updateDescription/")]
    public async Task<IActionResult> UpdateDescription([FromBody] StringUpdateVm stringUpdateVm) =>
      Ok(await _userInfoService.UpdateDescription(stringUpdateVm));

    [Authorize]
    [ApiValidationFilter]
    [HttpPost("updateDiscipline/")]
    public async Task<IActionResult> UpdateDiscipline([FromBody] StringUpdateVm stringUpdateVm) =>
      Ok(await _userInfoService.UpdateDiscipline(stringUpdateVm));

    [Authorize]
    [ApiValidationFilter]
    [HttpPost("updateGender/")]
    public async Task<IActionResult> UpdateGender([FromBody] StringUpdateVm stringUpdateVm) =>
      Ok(await _userInfoService.UpdateGender(stringUpdateVm));

    [Authorize]
    [ApiValidationFilter]
    [HttpPost("updateYearsOfExperience/")]
    public async Task<IActionResult> UpdateYearsOfExperience([FromBody] NumberUpdateVm numberUpdateVm) =>
      Ok(await _userInfoService.UpdateYearsOfExperience(numberUpdateVm));

    [Authorize]
    [ApiValidationFilter]
    [HttpPost("updateHeight/")]
    public async Task<IActionResult> UpdateHeight([FromBody] NumberUpdateVm numberUpdateVm) =>
      Ok(await _userInfoService.UpdateHeight(numberUpdateVm));

    [Authorize]
    [ApiValidationFilter]
    [HttpPost("updateIsCoach/")]
    public async Task<IActionResult> UpdateIsCoach([FromBody] StringUpdateVm stringUpdateVm) =>
      Ok(await _userInfoService.UpdateIsCoach(stringUpdateVm));

    [Authorize]
    [ApiValidationFilter]
    [HttpPost("updateBirthday/")]
    public async Task<IActionResult> UpdateBirthday([FromBody] DateUpdateVm dateUpdateVm) =>
      Ok(await _userInfoService.UpdateBirthday(dateUpdateVm));

    #endregion Post
  }
}