using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GymNotes.Service.ViewModels
{
  public class BaseVm
  {
    [Required]
    public string UserId { get; set; }
  }
}