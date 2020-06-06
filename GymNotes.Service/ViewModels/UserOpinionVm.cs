using System;
using System.Collections.Generic;
using System.Text;

namespace GymNotes.Service.ViewModels
{
  public class UserOpinionVm
  {
    public int Id { get; set; }

    public DateTime DateAdded { get; set; }

    public int Rating { get; set; }

    public string OpinionMessage { get; set; }

    public ApplicationUserVm ProfileUser { get; set; }
  }
}