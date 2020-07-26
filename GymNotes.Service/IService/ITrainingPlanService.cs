using GymNotes.Service.ViewModels;
using GymNotes.Service.ViewModels.Training;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GymNotes.Service.IService
{
  public interface ITrainingPlanService
  {
    Task<ApiResponse> EditTrainingPlan(TrainingPlanVm trainingPlanVm);
    Task<ApiResponse> CreateTrainingPlan(TrainingPlanVm trainingPlanVm);
    TrainingPlanVm GetTrainingPlan(int id);
  }
}
