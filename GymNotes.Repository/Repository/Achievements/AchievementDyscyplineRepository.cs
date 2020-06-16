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
  public class AchievementDyscyplineRepository : BaseRepository<AchievementDyscypline>, IAchievementDyscyplineRepository
  {
    public AchievementDyscyplineRepository(ApplicationDbContext context) :
      base(context)
    {
    }

    //public AchievementDyscypline GetAchievementDyscypline(int id)
    //{
    //  return _context.AchievementDyscyplines.FirstOrDefault(x => x.Id == id);
    //}

    //public async void AddAchievementDyscypline(AchievementDyscypline model)
    //{
    //  await _context.AchievementDyscyplines.AddAsync(model);
    //}

    //public void UpdateAchievementDyscypline(AchievementDyscypline model)
    //{
    //  _context.AchievementDyscyplines.Update(model);
    //}

    //public AchievementDyscypline GetUserAchievements(int id)
    //{
    //  return _context.AchievementDyscyplines.Include(x => x.Achievements).FirstOrDefault(x => x.Id == id);
    //}

    //public List<AchievementDyscypline> GetUserAchievementsList(string id)
    //{
    //  return _context.AchievementDyscyplines.Include(x => x.Achievements).Where(x => x.ApplicationUserId == id).ToList();
    //}

    //public void DeleteAchievementDyscypline(AchievementDyscypline model)
    //{
    //  _context.AchievementDyscyplines.Remove(model);
    //}
  }
}