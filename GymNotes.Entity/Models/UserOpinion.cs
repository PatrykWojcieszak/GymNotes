using GymNotes.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GymNotes.Entity.Models
{
  public class UserOpinion
  {
    public int Id { get; set; }

    public string ProfileUserId { get; set; }

    [ForeignKey("ProfileUserId")]
    public ApplicationUser ProfileUser { get; set; }

    public string CommenterId { get; set; }

    [ForeignKey("CommenterId")]
    public ApplicationUser Commenter { get; set; }

    public DateTime DateAdded { get; set; }

    public int Rating { get; set; }

    public string OpinionMessage { get; set; }

    public List<UserOpinionLikes> UserOpinionLikes { get; set; }

    public UserOpinion()
    {
      UserOpinionLikes = new List<UserOpinionLikes>();
    }
  }
}