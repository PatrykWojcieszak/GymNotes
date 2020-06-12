using GymNotes.Entity.Models;
using GymNotes.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymNotes.Repository.IRepository
{
  public interface IStatisticsDisciplineRepository
  {
    void AddStatisticsDiscipline(StatisticsDyscypline model);

    void UpdateStatisticsDiscipline(StatisticsDyscypline model);

    StatisticsDyscypline GetStatisticsDiscipline(int id);

    void DeleteStatisticsDiscipline(StatisticsDyscypline model);
  }
}