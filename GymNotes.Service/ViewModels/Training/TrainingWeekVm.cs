using System;
using System.Collections.Generic;
using System.Text;

namespace GymNotes.Service.ViewModels.Training
{
  public class TrainingWeekVm
  {
    public int Id { get; set; }

    public string Name { get; set; }

    public List<TrainingDayVm> TrainingDays { get; set; }
  }
}
