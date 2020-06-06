using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace GymNotes.Service.Chat
{
  public class CustomUserIdProvider : IUserIdProvider
  {
    public virtual string GetUserId(HubConnectionContext connection)
    {
      return connection.User?.Claims.FirstOrDefault(x => x.Value != null).Value;
    }
  }
}