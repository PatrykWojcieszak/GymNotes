using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GymNotes.Service.IService;
using GymNotes.Service.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace GymNotes.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class UserOpinionController : ControllerBase
  {
    private readonly IUserOpinionService _userOpinionService;

    public UserOpinionController(IUserOpinionService userOpinionService)
    {
      _userOpinionService = userOpinionService;
    }

    [Authorize]
    [HttpGet("getUserOpinions/{userId}")]
    public async Task<IActionResult> GetUserOpinions(string userId)
    {
      if (!ModelState.IsValid)
        return BadRequest(ModelState);

      var result = await _userOpinionService.GetUserOpinions(userId);

      if (result != null)
        return Ok(result);
      else
        return BadRequest("Something went wrong!");
    }

    [Authorize]
    [HttpPost("addUserOpinion/")]
    public async Task<IActionResult> AddUserOpinion([FromBody] AddUserOpinionVm addUserOpinionVm)
    {
      if (!ModelState.IsValid)
        return BadRequest(ModelState);

      var result = await _userOpinionService.AddUserOpinion(addUserOpinionVm);

      if (result)
        return Ok();
      else
        return BadRequest("Something went wrong!");
    }

    [Authorize]
    [HttpPost("addLikeToOpinion/")]
    public async Task<IActionResult> AddLikeToOpinion([FromBody] UserOpinionLikesVm userOpinionLikesVm)
    {
      var result = await _userOpinionService.AddLikeToUserOpinion(userOpinionLikesVm);

      if (result)
        return Ok();
      else
        return BadRequest("Something went wrong!");
    }

    [Authorize]
    [HttpPost("removeLikeFromOpinion/{userId}/{opinionId}")]
    public async Task<IActionResult> RemoveLikeFromOpinion(string userId, int opinionId)
    {
      var result = await _userOpinionService.RemoveLikeFromUserOpinion(userId, opinionId);

      if (result)
        return Ok();
      else
        return BadRequest("Something went wrong!");
    }
  }
}