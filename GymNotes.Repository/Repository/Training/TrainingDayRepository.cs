using GymNotes.Data;
using GymNotes.Entity.Models.NewFolder;
using GymNotes.Repository.Base;
using GymNotes.Repository.IRepository.Training;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymNotes.Repository.Repository.Training
{
  public class TrainingDayRepository : BaseRepository<TrainingDay>, ITrainingDayRepository
  {
    private readonly ApplicationDbContext _context;

    public TrainingDayRepository(ApplicationDbContext repositoryContext) 
      : base(repositoryContext)
    {
      _context = repositoryContext;
    }
  }
}
