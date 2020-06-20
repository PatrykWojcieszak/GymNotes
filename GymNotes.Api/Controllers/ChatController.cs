using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GymNotes.Filters;
using GymNotes.Service.IService;
using GymNotes.Service.ViewModels;
using GymNotes.Service.ViewModels.Chat;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GymNotes.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ChatController : ControllerBase
  {
    private readonly IChatService _chatService;

    public ChatController(IChatService chatService)
    {
      _chatService = chatService;
    }

    #region Post

    [Authorize]
    [ApiValidationFilter]
    [HttpPost("addContact/")]
    public async Task<IActionResult> AddContact([FromBody] ContactVm contactVm) =>
      Ok(await _chatService.AddContact(contactVm));

    [Authorize]
    [ApiValidationFilter]
    [HttpPost("addMessage/")]
    public async Task<IActionResult> AddMessage([FromBody] ChatMessageVm chatMessageVm) =>
      Ok(await _chatService.AddMessage(chatMessageVm));

    #endregion Post

    #region Get

    [Authorize]
    [ApiValidationFilter]
    [HttpGet("getContactList/{userId}")]
    public IActionResult GetContactList(string userId) =>
      Ok(_chatService.GetContactList(userId));

    [Authorize]
    [ApiValidationFilter]
    [HttpGet("getContact/")]
    public IActionResult GetContact([FromQuery] ContactVm contactVm) =>
      Ok(_chatService.GetContact(contactVm));

    [Authorize]
    [ApiValidationFilter]
    [HttpGet("getMessageList/")]
    public IActionResult GetMessageList([FromQuery] ContactVm contactVm) =>
      Ok(_chatService.GetMessageList(contactVm));

    #endregion Get
  }
}