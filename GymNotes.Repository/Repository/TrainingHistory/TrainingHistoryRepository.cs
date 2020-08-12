using GymNotes.Data;
using GymNotes.Entity.Models.TrainingHistory;
using GymNotes.Repository.Base;
using GymNotes.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GymNotes.Repository.Repository
{
  public class TrainingHistoryRepository : BaseRepository<TrainingHistory>, ITrainingHistoryRepository
  {
    private readonly ApplicationDbContext _context;
    public TrainingHistoryRepository(ApplicationDbContext repositoryContext) : base(repositoryContext)
    {
      _context = repositoryContext;
    }

    public IQueryable<TrainingHistory> GetWorkoutHistoryByIserOd(string id)
    {
      return _context.TrainingHistories
        .Include(x => x.TrainingExercise)
        .Include(x => x.PlannedTraining)
        .Include(x => x.User)
        .Where(x => x.UserId == id)
        .AsNoTracking();
    }

    public IQueryable<TrainingHistory> GetWorkoutHistory(int id)
    {
      return _context.TrainingHistories
        .Include(x => x.TrainingExercise)
        .Include(x => x.PlannedTraining)
        .Include(x => x.User)
        .Where(x => x.Id == id)
        .AsNoTracking();
    }
  }
}
