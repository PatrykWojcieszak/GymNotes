using GymNotes.Entity.Models;
using GymNotes.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymNotes.Repository.IRepository
{
  public interface IStatisticsRepository
  {
    List<Statistics> GetStatisticsList(string userId);

    Statistics GetStatistics(int id);

    void AddStatistics(Statistics model);

    void UpdateStatistics(Statistics model);

    void DeleteStatistics(Statistics model);
  }
}