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
    public async Task<IActionResult> UpdateInstagramURL([FromBody] StringVm stringVm) =>
      Ok(await _userInfoService.UpdateInstagramURL(stringVm));

    [Authorize]
    [ApiValidationFilter]
    [HttpPost("updateFacebookUrl/")]
    public async Task<IActionResult> UpdateFacebookURL([FromBody] StringVm stringVm) =>
      Ok(await _userInfoService.UpdateFacebookURL(stringVm));

    [Authorize]
    [ApiValidationFilter]
    [HttpPost("updateTwitterUrl/")]
    public async Task<IActionResult> UpdateTwitterURL([FromBody] StringVm stringVm) =>
      Ok(await _userInfoService.UpdateTwitterURL(stringVm));

    [Authorize]
    [ApiValidationFilter]
    [HttpPost("updateYoutubeUrl/")]
    public async Task<IActionResult> UpdateYoutubeUrl([FromBody] StringVm stringVm) =>
      Ok(await _userInfoService.UpdateYoutubeURL(stringVm));

    [Authorize]
    [ApiValidationFilter]
    [HttpPost("updateDescription/")]
    public async Task<IActionResult> UpdateDescription([FromBody] StringVm stringVm) =>
      Ok(await _userInfoService.UpdateDescription(stringVm));

    [Authorize]
    [ApiValidationFilter]
    [HttpPost("updateDiscipline/")]
    public async Task<IActionResult> UpdateDiscipline([FromBody] StringVm stringVm) =>
      Ok(await _userInfoService.UpdateDiscipline(stringVm));

    [Authorize]
    [ApiValidationFilter]
    [HttpPost("updateGender/")]
    public async Task<IActionResult> UpdateGender([FromBody] StringVm stringVm) =>
      Ok(await _userInfoService.UpdateGender(stringVm));

    [Authorize]
    [ApiValidationFilter]
    [HttpPost("updateYearsOfExperience/")]
    public async Task<IActionResult> UpdateYearsOfExperience([FromBody] DateVm dateVm) =>
      Ok(await _userInfoService.UpdateTrainingSince(dateVm));

    [Authorize]
    [ApiValidationFilter]
    [HttpPost("updateHeight/")]
    public async Task<IActionResult> UpdateHeight([FromBody] NumberVm numberVm) =>
      Ok(await _userInfoService.UpdateHeight(numberVm));

    [Authorize]
    [ApiValidationFilter]
    [HttpPost("updateIsCoach/")]
    public async Task<IActionResult> UpdateIsCoach([FromBody] StringVm stringVm) =>
      Ok(await _userInfoService.UpdateIsCoach(stringVm));

    [Authorize]
    [ApiValidationFilter]
    [HttpPost("updateBirthday/")]
    public async Task<IActionResult> UpdateBirthday([FromBody] DateVm dateVm) =>
      Ok(await _userInfoService.UpdateBirthday(dateVm));

    #endregion Post
  }
}