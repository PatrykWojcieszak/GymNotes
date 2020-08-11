using GymNotes.Entity.Models.NewFolder;
using GymNotes.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GymNotes.Entity.Models.TrainingHistory
{
  public class TrainingHistory
  {
    [Key]
    public int Id { get; set; }

    [Required]
    public DateTime Date { get; set; }

    [Required]
    public string WorkoutName { get; set; }

    [Required]
    public string UserId { get; set; }

    [ForeignKey("UserId")]
    public ApplicationUser User { get; set; }

    public virtual ICollection<TrainingExercise>? TrainingExercise { get; set; }

    public int? PlannedTrainingId { get; set; }

    [ForeignKey("PlannedTrainingId")]
    public virtual PlannedTraining? PlannedTraining { get; set; }
  }
}
