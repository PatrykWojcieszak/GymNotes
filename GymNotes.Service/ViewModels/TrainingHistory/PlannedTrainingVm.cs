using System;
using System.Collections.Generic;
using System.Text;

namespace GymNotes.Service.ViewModels.TrainingHistory
{
  public class PlannedTrainingVm
  {
    public int Id { get; set; }

    public int TrainingPlanId { get; set; }

    public int TrainingWeekId { get; set; }

    public int TrainingDayId { get; set; }
  }
}
