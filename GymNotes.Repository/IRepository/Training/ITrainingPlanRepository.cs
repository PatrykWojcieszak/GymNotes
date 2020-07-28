using GymNotes.Entity.Models.NewFolder;
using GymNotes.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GymNotes.Repository.IRepository.Training
{
  public interface ITrainingPlanRepository : IBaseRepository<TrainingPlan>
  {
    IQueryable<TrainingPlan> GetTrainingPlan(int id);
    IQueryable<TrainingPlan> GetAllTrainingPlans(string id);
    IQueryable<TrainingPlan> FilterBy(IQueryable<TrainingPlan> query, int filterBy);
  }
}
