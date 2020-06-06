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
  public class StatisticsRepository : IStatisticsRepository
  {
    private readonly ApplicationDbContext _context;

    public StatisticsRepository(ApplicationDbContext context)
    {
      _context = context;
    }

    public List<Statistics> GetStatisticsList(string userId)
    {
      return _context.Statistics.Include(x=>x.StatisticsDisciplines).ThenInclude(x=>x.StatisticsExercises).Where(x => x.ApplicationUserId == userId).ToList();
    }

    public Statistics GetStatistics(int id)
    {
      return _context.Statistics.Include(x => x.StatisticsDisciplines).ThenInclude(x => x.StatisticsExercises).FirstOrDefault(x => x.Id == id);
    }

    public async void AddStatistics(Statistics model)
    {
      await _context.Statistics.AddAsync(model);
    }

    public void UpdateStatistics(Statistics model)
    {
      _context.Statistics.Update(model);
    }

    public void DeleteStatistics(Statistics model)
    {
      _context.Statistics.Remove(model);
    }
  }
}