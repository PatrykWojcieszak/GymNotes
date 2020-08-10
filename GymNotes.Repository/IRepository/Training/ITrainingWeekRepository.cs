using GymNotes.Entity.Models.NewFolder;
using GymNotes.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GymNotes.Repository.IRepository.Training
{
  public interface ITrainingWeekRepository : IBaseRepository<TrainingWeek>
  {
    IQueryable<TrainingWeek> GetTrainingWeek(int id);
  }
}
