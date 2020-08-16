using GymNotes.Service.Utils;
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
    Task<ApiResponse> EditTrainingPlan(string id, TrainingPlanVm trainingPlanVm);

    Task<ApiResponse> CreateTrainingPlan(TrainingPlanVm trainingPlanVm);

    TrainingPlanVm GetTrainingPlan(int id);

    Task<PaginatedList<TrainingPlanVm>> Search(string id, PageQuery pageQuery);

    Task<ApiResponse> ToggleFavorite(int id, bool flag);

    Task<ApiResponse> ToggleMain(string userId, int id, bool flag);

    Task<ApiResponse> Delete(string userId, int id);

    List<TrainingExerciseVm> GetTrainingExercise(int id);
  }
}