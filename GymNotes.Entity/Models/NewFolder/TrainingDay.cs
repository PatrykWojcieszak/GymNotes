using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GymNotes.Entity.Models.NewFolder
{
  public class TrainingDay
  {
    [Key]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    public virtual ICollection<TrainingExercise> TrainingExercises { get; set; }
  }
}
