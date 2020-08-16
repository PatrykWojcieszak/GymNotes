using System;
using System.Collections.Generic;
using System.Text;

namespace GymNotes.Service.ViewModels.Training
{
  public class TrainingExerciseVm
  {
    public int Id { get; set; }

    public string ExerciseName { get; set; }

    public int Sets { get; set; }

    public int? Reps { get; set; }

    public string Tempo { get; set; }

    public int? Rest { get; set; }

    public int? RPE { get; set; }

    public double? Weight { get; set; }

    public string Description { get; set; }
  }
}