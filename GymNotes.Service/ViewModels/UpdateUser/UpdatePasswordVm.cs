using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GymNotes.Service.ViewModels
{
  public class UpdatePasswordVm : BaseVm
  {
    [Required]
    public string OldPassword { get; set; }

    [Required]
    public string NewPassword { get; set; }
  }
}