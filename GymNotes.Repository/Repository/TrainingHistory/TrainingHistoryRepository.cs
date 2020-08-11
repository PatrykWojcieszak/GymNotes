using GymNotes.Data;
using GymNotes.Entity.Models.TrainingHistory;
using GymNotes.Repository.Base;
using GymNotes.Repository.IRepository;
using System;
using System.Collections.Generic;
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
  }
}
