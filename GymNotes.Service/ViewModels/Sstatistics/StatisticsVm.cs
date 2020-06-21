using AutoMapper.Configuration.Annotations;
using GymNotes.Service.Base;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GymNotes.Service.ViewModels
{
  public class StatisticsVm
  {
    public int Id { get; set; }

    public string ApplicationUserId { get; set; }

    public float Weight { get; set; }

    [JsonConverter(typeof(JsonFormatDate), "yyyy-MM-dd")]
    public DateTime Date { get; set; }

    public List<StatisticsDisciplineVm> StatisticsDisciplines { get; set; }

    public StatisticsVm()
    {
            StatisticsDisciplines = new List<StatisticsDisciplineVm>();
    }
  }
}