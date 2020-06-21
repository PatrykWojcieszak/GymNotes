using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GymNotes.Service.ViewModels
{
  public class StringVm : BaseVm
  {
    [Required]
    public string Content { get; set; }
  }
}