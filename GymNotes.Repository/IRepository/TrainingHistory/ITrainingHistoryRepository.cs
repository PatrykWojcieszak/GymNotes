using GymNotes.Entity.Models.TrainingHistory;
using GymNotes.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GymNotes.Repository.IRepository
{
  public interface ITrainingHistoryRepository : IBaseRepository<TrainingHistory>
  {
    IQueryable<TrainingHistory> GetWorkoutHistoryByIserOd(string id);
    IQueryable<TrainingHistory> GetWorkoutHistory(int id);
  }
}
