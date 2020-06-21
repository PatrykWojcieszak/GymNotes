using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GymNotes.Service.ViewModels.Chat
{
  public class ContactVm
  {
    [Required]
    public string UserId { get; set; }

    [Required]
    public string ReceipentId { get; set; }
  }
}