using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GymNotes.Service.ViewModels
{
  public class UpdatePasswordVm
  {
    [Required]
    public string UserId { get; set; }

    [Required]
    public string OldPassword { get; set; }

    [Required]
    public string NewPassword { get; set; }
  }
}