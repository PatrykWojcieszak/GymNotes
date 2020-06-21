using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GymNotes.Service.ViewModels
{
  public class UpdateEmailVm : BaseVm
  {
    [Required]
    public string Email { get; set; }
  }
}