using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GymNotes.Filters;
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

    #region Post

    [Authorize]
    [ApiValidationFilter]
    [HttpPost("addUserOpinion/")]
    public async Task<IActionResult> AddUserOpinion([FromBody] AddUserOpinionVm addUserOpinionVm) =>
      Ok(await _userOpinionService.AddUserOpinion(addUserOpinionVm));

    [Authorize]
    [ApiValidationFilter]
    [HttpPost("addLikeToOpinion/")]
    public async Task<IActionResult> AddLikeToOpinion([FromBody] UserOpinionLikesVm userOpinionLikesVm) =>
      Ok(await _userOpinionService.AddLikeToUserOpinion(userOpinionLikesVm));

    [Authorize]
    [HttpPost("removeLikeFromOpinion/{userId}/{opinionId}")]
    public async Task<IActionResult> RemoveLikeFromOpinion(string userId, int opinionId) =>
      Ok(await _userOpinionService.RemoveLikeFromUserOpinion(userId, opinionId));

    #endregion Post

    #region Get

    [Authorize]
    [ApiValidationFilter]
    [HttpGet("getUserOpinions/{userId}")]
    public IActionResult GetUserOpinions(string userId) =>
      Ok(_userOpinionService.GetUserOpinions(userId));

    #endregion Get
  }
}