using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GymNotes.Service.ViewModels
{
  public class DateVm : BaseVm
  {
    [Required]
    public DateTime Date { get; set; }
  }
}