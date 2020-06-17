using GymNotes.Data;
using GymNotes.Entity.Models;
using GymNotes.Models;
using GymNotes.Repository.Base;
using GymNotes.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GymNotes.Repository.Repository
{
  public class AchievementRepository : BaseRepository<Achievement>, IAchievementRepository
  {
    private readonly ApplicationDbContext _context;

    public AchievementRepository(ApplicationDbContext context) :
      base(context)
    {
      _context = context;
    }

    //public Achievement GetAchievement(int id)
    //{
    //  return _context.Achievements.FirstOrDefault(x => x.Id == id);
    //}

    //public async void AddAchievemen(Achievement model)
    //{
    //  await _context.Achievements.AddAsync(model);
    //}

    //public void UpdateAchievement(Achievement model)
    //{
    //  _context.Achievements.Update(model);
    //}

    //public void DeleteAchievement(Achievement model)
    //{
    //  _context.Achievements.Remove(model);
    //}
  }
}