using GymNotes.Data;
using GymNotes.Entity.Models;
using GymNotes.Models;
using GymNotes.Repository.Base;
using GymNotes.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GymNotes.Repository.Repository
{
  public class StatisticsDisciplineRepository : BaseRepository<StatisticsDyscypline>, IStatisticsDisciplineRepository
  {
    public StatisticsDisciplineRepository(ApplicationDbContext context) :
      base(context)
    {
    }
  }
}