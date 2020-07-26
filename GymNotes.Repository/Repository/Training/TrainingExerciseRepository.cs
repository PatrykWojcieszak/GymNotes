using GymNotes.Data;
using GymNotes.Entity.Models.NewFolder;
using GymNotes.Repository.Base;
using GymNotes.Repository.IRepository.Training;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymNotes.Repository.Repository.Training
{
  public class TrainingExerciseRepository : BaseRepository<TrainingExercise>, ITrainingExerciseRepository
  {
    private readonly ApplicationDbContext _context;
    public TrainingExerciseRepository(ApplicationDbContext repositoryContext) 
      : base(repositoryContext)
    {
      _context = repositoryContext;
    }
  }
}
