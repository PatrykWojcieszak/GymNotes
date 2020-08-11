using GymNotes.Service.ViewModels;
using GymNotes.Service.ViewModels.TrainingHistory;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GymNotes.Service.IService
{
  public interface ITrainingHistoryService
  {
    TrainingElementsVm GetTrainingPlans(string id);
    TrainingElementsVm GetTrainingWeeks(int id);
    TrainingElementsVm GetTrainingDays(int id);
    Task<ApiResponse> AddFinishedWorkout(TrainingHistoryVm trainingHistoryVm);
  }
}
