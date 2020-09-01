using GymNotes.Data;
using GymNotes.Entity.Models.NewFolder;
using GymNotes.Repository.Base;
using GymNotes.Repository.IRepository.Training;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymNotes.Repository.Repository.Training
{
  public class TrainingPlanRepository : BaseRepository<TrainingPlan>, ITrainingPlanRepository
  {
    public TrainingPlanRepository(ApplicationDbContext repositoryContext) 
      : base(repositoryContext){ }

    public IQueryable<TrainingPlan> GetTrainingPlan(int id)
    {
      return RepositoryContext.TrainingPlans
        .Include(x => x.Owner)
        .Include(x => x.Creator)
        .Include(x => x.TrainingWeeks)
        .ThenInclude(x => x.TrainingDays)
        .ThenInclude(x => x.TrainingExercises)
        .AsNoTracking()
        .Where(x => x.Id == id);
    }

    public IQueryable<TrainingPlan> GetWeeksFromTrainingPlan(int id)
    {
      return RepositoryContext.TrainingPlans
        .Include(x => x.TrainingWeeks)
        .Where(x => x.Id == id)
        .AsNoTracking();
    }

    public IQueryable<TrainingPlan> GetAllTrainingPlans(string id)
    {
      return RepositoryContext.TrainingPlans
        .Include(x => x.Owner)
        .Include(x => x.Creator)
        .Where(x => x.OwnerId == id)
        .AsNoTracking();
    }

    public IQueryable<TrainingPlan> FilterBy(IQueryable<TrainingPlan> query, int filterBy)
    {
      switch (filterBy)
      {
        case (int)FilterByTrainingPlan.All:
          return query;

        case (int)FilterByTrainingPlan.Favorites:
          return query.Where(x => x.IsFavorite);
        
        case (int)FilterByTrainingPlan.Newest:
          return query.OrderByDescending(x => x.ModifiedAt);

        default:
          return query;
      }
    }
  }
}
