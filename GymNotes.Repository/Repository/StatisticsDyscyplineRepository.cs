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

    public StatisticsDiscipline GetStatisticsDiscipline(int id)
    {
      return _context.StatisticsDisciplines.Include(x=>x.StatisticsExercises).FirstOrDefault(x => x.Id == id);
    }

    public async void AddStatisticsDiscipline(StatisticsDiscipline model)
    {
      await _context.StatisticsDisciplines.AddAsync(model);
     
    }

    public void UpdateStatisticsDiscipline(StatisticsDiscipline model)
    {
      _context.StatisticsDisciplines.Update(model);
    }

    public void DeleteStatisticsDiscipline(StatisticsDiscipline model)
    {
      _context.StatisticsDisciplines.Remove(model);
    }

    
  }
}