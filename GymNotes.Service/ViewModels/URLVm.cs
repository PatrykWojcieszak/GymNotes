using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GymNotes.Service.ViewModels
{
  public class UpdateURLVm
  {
    [Required]
    public string UserId { get; set; }

    [Required]
    public string URL { get; set; }

    [Required]
    public string test { get; set; }
  }
}