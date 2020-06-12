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
  public class StatisticsDisciplineRepository : IStatisticsDisciplineRepository
  {
    private readonly ApplicationDbContext _context;

    public StatisticsDisciplineRepository(ApplicationDbContext context)
    {
      _context = context;
    }

    public StatisticsDyscypline GetStatisticsDiscipline(int id)
    {
      return _context.StatisticsDyscyplines.Include(x => x.StatisticsExercises).FirstOrDefault(x => x.Id == id);
    }

    public async void AddStatisticsDiscipline(StatisticsDyscypline model)
    {
      await _context.StatisticsDyscyplines.AddAsync(model);
    }

    public void UpdateStatisticsDiscipline(StatisticsDyscypline model)
    {
      _context.StatisticsDyscyplines.Update(model);
    }

    public void DeleteStatisticsDiscipline(StatisticsDyscypline model)
    {
      _context.StatisticsDyscyplines.Remove(model);
    }
  }
}