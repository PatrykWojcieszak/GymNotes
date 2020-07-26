using System;
using System.Collections.Generic;
using System.Text;

namespace GymNotes.Service.ViewModels.Training
{
  public class TrainingDayVm
  {
    public int Id { get; set; }

    public string Name { get; set; }

    public List<TrainingExerciseVm> TrainingExercises { get; set; }
  }
}
