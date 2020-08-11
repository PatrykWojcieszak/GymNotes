using GymNotes.Data;
using GymNotes.Entity.Models.TrainingHistory;
using GymNotes.Repository.Base;
using GymNotes.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymNotes.Repository.Repository
{
  public class PlannedTrainingRepository : BaseRepository<PlannedTraining>, IPlannedTrainingRepository
  {
    private readonly ApplicationDbContext _context;
    public PlannedTrainingRepository(ApplicationDbContext repositoryContext) 
      : base(repositoryContext)
    {
      _context = repositoryContext;
    }
  }
}
