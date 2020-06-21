using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GymNotes.Service.ViewModels
{
  public class AddUserOpinionVm
  {
    [Required]
    public string CommenterId { get; set; }

    [Required]
    public string ProfileUserId { get; set; }

    [Required]
    public string OpinionMessage { get; set; }

    public DateTime DateAdded { get; set; }

    [Required]
    public int Rating { get; set; }
  }
}