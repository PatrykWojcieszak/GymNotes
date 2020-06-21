using System;
using System.Collections.Generic;
using System.Text;

namespace GymNotes.Service.ViewModels
{
  public class ChatMessageVm
  {
    public string SenderId { get; set; }

    public string ReceiverId { get; set; }

    public string Content { get; set; }

    public DateTime SendDate { get; set; }

    public Boolean IsSender { get; set; }
  }
}