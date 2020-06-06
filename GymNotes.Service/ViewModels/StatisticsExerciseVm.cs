using AutoMapper.Configuration.Annotations;
using GymNotes.Service.Base;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GymNotes.Service.ViewModels
{
  public class StatisticsExerciseVm
  {
    public int Id { get; set; }

    public string Name { get; set; }

    public string Value { get; set; }

    [JsonConverter(typeof(JsonFormatDate), "yyyy-MM-dd")]
    public DateTime ExerciseDate { get; set; } 
  }
}