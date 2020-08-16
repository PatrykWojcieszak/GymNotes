using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GymNotes.Entity.Models.NewFolder
{
  public class TrainingExercise
  {
    [Key]
    public int Id { get; set; }

    [Required]
    public string ExerciseName { get; set; }

    [Required]
    public int Sets { get; set; }

    public int? Reps { get; set; }

    public string Tempo { get; set; }

    public int? Rest { get; set; }

    public int? RPE { get; set; }

    public double? Weight { get; set; }

    public string Description { get; set; }
  }
}