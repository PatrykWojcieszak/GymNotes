using AutoMapper.Configuration.Annotations;
using GymNotes.Service.Base;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GymNotes.Service.ViewModels
{
  public class StatisticsDisciplineVm
  {
    public int Id { get; set; }

    public int StatisticsId { get; set; }

    public string Name { get; set; }

    public List<StatisticsExerciseVm> StatisticsExercises { get; set; }

    public StatisticsDisciplineVm()
    {
            StatisticsExercises = new List<StatisticsExerciseVm>();
    }
  }
}