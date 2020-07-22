using GymNotes.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GymNotes.Entity.Models.NewFolder
{
  public class TrainingPlan
  {
    [Key]
    public int Id { get; set; }

    public string CreatorId { get; set; }

    [Required]
    [ForeignKey("CreatorId")]
    public virtual ApplicationUser Creator { get; set; }

    public string OwnerId { get; set; }

    [ForeignKey("OwnerId")]
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
