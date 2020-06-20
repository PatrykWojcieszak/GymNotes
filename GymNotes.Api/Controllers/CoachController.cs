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
  [Route("api/coach")]
  [ApiController]
  public class CoachController : ControllerBase
  {
    private readonly ICoachService _coachService;

    public CoachController(ICoachService coachService)
    {
      _coachService = coachService;
    }

    #region Post

    //TODO: Sprawdzić
    [Authorize]
    [ApiValidationFilter]
    [HttpPost("coachManagmentRequest")]
    public async Task<IActionResult> CoachManagmentRequest([FromBody] CoachManagmentRequestVm coachManagmentRequestVm) =>
      Ok(await _coachService.CoachManagmentRequest(coachManagmentRequestVm));

    //TODO: Sprawdzić
    [Authorize]
    [ApiValidationFilter]
    [HttpPost("coachCancelManagment")]
    public async Task<IActionResult> CoachCancelManagment([FromBody] CoachCancelManagmentVm coachCancelManagmentVm) =>
      Ok(await _coachService.CoachCancelManagment(coachCancelManagmentVm));

    #endregion Post

    #region Get

    //TODO: Sprawdzić
    [Authorize]
    [HttpGet("coachPupilList/{coachId}")]
    public IActionResult CoachPupilList(string coachId) =>
      Ok(_coachService.CoachPupilList(coachId));

    //TODO: Sprawdzić
    [Authorize]
    [HttpGet("coachRequestList/{coachId}")]
    public IActionResult CoachRequestList(string coachId) =>
      Ok(_coachService.CoachRequestList(coachId));

    #endregion Get
  }
}