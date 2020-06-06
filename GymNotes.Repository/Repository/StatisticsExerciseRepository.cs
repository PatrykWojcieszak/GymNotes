using GymNotes.Data;
using GymNotes.Entity.Models;
using GymNotes.Models;
using GymNotes.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GymNotes.Repository.Repository
{
  public class StatisticsExerciseRepository : IStatisticsExerciseRepository
  {
    private readonly ApplicationDbContext _context;

    public StatisticsExerciseRepository(ApplicationDbContext context)
    {
      _context = context;
    }
    

    public StatisticsExercise GetStatisticsExercise(int id)
    {
      return _context.StatisticsExercises.FirstOrDefault(x => x.Id == id);
    }

    public async void AddStatisticsExercise(StatisticsExercise model)
    {
      await _context.StatisticsExercises.AddAsync(model);
    }

    public void UpdateStatisticsExercise(StatisticsExercise model)
    {
      _context.StatisticsExercises.Update(model);
    }

    public void DeleteStatisticsExercise(StatisticsExercise model)
    {
      _context.StatisticsExercises.Remove(model);
    }
  }
}
