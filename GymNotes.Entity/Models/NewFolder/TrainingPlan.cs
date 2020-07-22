using GymNotes.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GymNotes.Entity.Models.NewFolder
{
  public class TrainingPlan
  {
    [Key]
    public int Id { get; set; }

    [Required]
    public string CreatorId { get; set; }

    [Required]
    public virtual ApplicationUser Creator { get; set; }

    [Required]
    public string OwnerId { get; set; }

    [Required]
    public virtual ApplicationUser Owner { get; set; }

    [Required]
    public DateTime ModifiedAt { get; set; }

    [Required]
    public string Description { get; set; }

    [Required]
    public string Name { get; set; }

    public virtual ICollection<TrainingWeek> TrainingWeeks { get; set; }
  }
}
