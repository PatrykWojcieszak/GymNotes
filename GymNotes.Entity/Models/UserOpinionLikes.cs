using GymNotes.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GymNotes.Entity.Models
{
  public class UserOpinionLikes
  {
    public int Id { get; set; }

    public string ApplicationUserId { get; set; }

    [ForeignKey("ApplicationUserId")]
    public ApplicationUser ApplicationUser { get; set; }

    public int UserOpinionId { get; set; }

    [ForeignKey("UserOpinionId")]
    public UserOpinion UserOpinion { get; set; }
  }
}