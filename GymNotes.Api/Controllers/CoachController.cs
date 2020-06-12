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
  [Route("api/coach")]
  [ApiController]
  public class CoachController : ControllerBase
  {
    private readonly ICoachService _coachService;

    public CoachController(ICoachService coachService)
    {
      _coachService = coachService;
    }

    //TODO: Sprawdzić
    [Authorize]
    [HttpPost("coachManagmentRequest")]
    public async Task<IActionResult> CoachManagmentRequest([FromBody] CoachManagmentRequestVm coachManagmentRequestVm)
    {
      var result = await _coachService.CoachManagmentRequest(coachManagmentRequestVm);

      if (result)
        return Ok();
      else
        return BadRequest("Something went wrong!");
    }

    //TODO: Sprawdzić
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

    //TODO: Sprawdzić
    [Authorize]
    [HttpGet("coachPupilList/{coachId}")]
    public IActionResult CoachPupilList(string coachId)
    {
      var list = _coachService.CoachPupilList(coachId);

      if (list != null)
        return Ok(list);
      else
        return BadRequest("Something went wrong!");
    }

    //TODO: Sprawdzić
    [Authorize]
    [HttpGet("coachRequestList/{coachId}")]
    public IActionResult CoachRequestList(string coachId)
    {
      var list = _coachService.CoachRequestList(coachId);

      if (list != null)
        return Ok(list);
      else
        return BadRequest("Something went wrong!");
    }
  }
}