using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

    [Authorize]
    [HttpPost("addContact/")]
    public async Task<IActionResult> AddContact([FromBody] ContactVm contactVm)
    {
      if (!ModelState.IsValid)
        return BadRequest(ModelState);

      var result = await _chatService.AddContact(contactVm);

      if (result)
        return Ok(result);
      else
        return BadRequest("Something went wrong!");
    }

    [Authorize]
    [HttpGet("getContactList/{userId}")]
    public async Task<IActionResult> GetContactList(string userId)
    {
      if (!ModelState.IsValid)
        return BadRequest(ModelState);

      var result = await _chatService.GetContactList(userId);

      if (result != null)
        return Ok(result);
      else
        return BadRequest("Something went wrong!");
    }

    [Authorize]
    [HttpGet("getContact/")]
    public IActionResult GetContact([FromQuery] ContactVm contactVm)
    {
      if (!ModelState.IsValid)
        return BadRequest(ModelState);

      var result = _chatService.GetContact(contactVm); ;

      if (result != null)
        return Ok(result);
      else
        return BadRequest("Something went wrong!");
    }

    [Authorize]
    [HttpPost("addMessage/")]
    public async Task<IActionResult> AddMessage([FromBody] ChatMessageVm chatMessageVm)
    {
      if (!ModelState.IsValid)
        return BadRequest(ModelState);

      var result = await _chatService.AddMessage(chatMessageVm);

      if (result)
        return Ok(result);
      else
        return BadRequest("Something went wrong!");
    }

    [Authorize]
    [HttpGet("getMessageList/")]
    public async Task<IActionResult> GetMessageList([FromQuery] ContactVm contactVm)
    {
      if (!ModelState.IsValid)
        return BadRequest(ModelState);

      var result = await _chatService.GetMessageList(contactVm);

      if (result != null)
        return Ok(result);
      else
        return BadRequest("Something went wrong!");
    }
  }
}