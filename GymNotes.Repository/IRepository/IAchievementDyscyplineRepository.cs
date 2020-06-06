using GymNotes.Entity.Models;
using GymNotes.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymNotes.Repository.IRepository
{
  public interface IAchievementDyscyplineRepository
  {
    AchievementDyscypline GetAchievementDyscypline(int id);

    void AddAchievementDyscypline(AchievementDyscypline model);

    void UpdateAchievementDyscypline(AchievementDyscypline model);

    AchievementDyscypline GetUserAchievements(int id);

    List<AchievementDyscypline> GetUserAchievementsList(string id);

    void DeleteAchievementDyscypline(AchievementDyscypline model);
  }
}