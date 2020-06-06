using GymNotes.Entity.Models;
using GymNotes.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymNotes.Repository.IRepository
{
  public interface IStatisticsExerciseRepository
  {
    StatisticsExercise GetStatisticsExercise(int id);

    void AddStatisticsExercise(StatisticsExercise model);

    void UpdateStatisticsExercise(StatisticsExercise model);

    void DeleteStatisticsExercise(StatisticsExercise model);
  }
}
