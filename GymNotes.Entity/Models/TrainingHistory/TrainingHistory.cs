using GymNotes.Entity.Models.NewFolder;
using GymNotes.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GymNotes.Entity.Models.TrainingHistory
{
  public class TrainingHistory
  {
    [Key]
    public int Id { get; set; }

    public DateTime Date { get; set; }

    public string WorkoutName { get; set; }

    public string UserId { get; set; }

    [ForeignKey("UserId")]
    public ApplicationUser User { get; set; }

    public int TrainingExerciseId { get; set; }

    [ForeignKey("TrainingExerciseId")]
    public TrainingExercise TrainingExercise { get; set; }

    public int PlannedTrainingId { get; set; }

    [ForeignKey("PlannedTrainingId")]
    public PlannedTraining PlannedTraining { get; set; }
  }
}
