using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GymNotes.Service.ViewModels
{
  public class UpdateUserNameVm : BaseVm
  {
    [Required]
    public string FirstName { get; set; }

    public string Alias { get; set; }

    [Required]
    public string LastName { get; set; }
  }
}