using GymNotes.Entity.Models;
using GymNotes.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymNotes.Repository.IRepository
{
  public interface IStatisticsDisciplineRepository
  {
    void AddStatisticsDiscipline(StatisticsDiscipline model);

    void UpdateStatisticsDiscipline(StatisticsDiscipline model);

    StatisticsDiscipline GetStatisticsDiscipline(int id);

    void DeleteStatisticsDiscipline(StatisticsDiscipline model);
  }
}