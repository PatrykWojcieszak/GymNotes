using GymNotes.Entity.Models.NewFolder;
using GymNotes.Entity.Models.TrainingHistory;
using GymNotes.Models;
using GymNotes.Service.ViewModels.Training;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymNotes.Service.ViewModels.TrainingHistory
{
  public class TrainingHistoryVm
  {
    public int Id { get; set; }

    public bool IsCustomTraining { get; set; }

    public DateTime Date { get; set; }

    public string WorkoutName { get; set; }

    public string UserId { get; set; }

    public UserVm User { get; set; }

    public List<TrainingExerciseVm>? TrainingExercise { get; set; }

    public int? PlannedTrainingId { get; set; }

    public PlannedTrainingVm? PlannedTraining { get; set; }
  }
}
