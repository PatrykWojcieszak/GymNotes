using System;
using System.Collections.Generic;
using System.Text;

namespace GymNotes.Entity.Models.TrainingHistory
{
  public class PlannedTraining
  {
    public int Id { get; set; }

    public int TrainingPlanId { get; set; }

    public int TrainingWeekId { get; set; }

    public int TrainingDayId { get; set; }
  }
}
