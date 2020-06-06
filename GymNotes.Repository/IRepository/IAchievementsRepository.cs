using GymNotes.Entity.Models;
using GymNotes.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymNotes.Repository.IRepository
{
  public interface IAchievementsRepository
  {
    Achievement GetAchievement(int id);

    void AddAchievemen(Achievement model);

    void UpdateAchievement(Achievement model);

    void DeleteAchievement(Achievement model);
  }
}