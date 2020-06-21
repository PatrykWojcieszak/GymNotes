using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GymNotes.Service.ViewModels
{
  public class UserOpinionLikesVm : BaseVm
  {
    [Required]
    public int UserOpinionId { get; set; }
  }
}