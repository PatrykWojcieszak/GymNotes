using System;
using System.Collections.Generic;
using System.Text;

namespace GymNotes.Service.ViewModels
{
  public class AddUserOpinionVm
  {
    public string CommenterId { get; set; }

    public string ProfileUserId { get; set; }

    public string OpinionMessage { get; set; }

    public DateTime DateAdded { get; set; }

    public int Rating { get; set; }
  }
}