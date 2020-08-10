using GymNotes.Service.ViewModels.TrainingHistory;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymNotes.Service.IService
{
  public interface ITrainingHistoryService
  {
    TrainingElementsVm GetTrainingPlans(string id);
    TrainingElementsVm GetTrainingWeeks(int id);
    TrainingElementsVm GetTrainingDays(int id);
  }
}
