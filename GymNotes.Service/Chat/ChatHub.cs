using GymNotes.Service.ViewModels;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymNotes.Service.Chat
{
  public class ChatHub : Hub
  {
    public async void Send(string userId, ChatMessageVm chatMessageVm)
    {
      await Clients.User(userId).SendAsync("send", chatMessageVm);
    }

    public string GetConnectionId()
    {
      return Context.ConnectionId;
    }
  }
}