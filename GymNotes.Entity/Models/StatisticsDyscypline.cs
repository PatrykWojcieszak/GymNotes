using System;
using System.Collections.Generic;
using System.Text;

namespace GymNotes.Entity.Models
{
  public class StatisticsDyscypline
  {
    public int Id { get; set; }

    public string Name { get; set; }    

    public List<StatisticsExercise> StatisticsExercises { get; set; }

    public StatisticsDyscypline()
    {
      StatisticsExercises = new List<StatisticsExercise>();
    }
  }
}