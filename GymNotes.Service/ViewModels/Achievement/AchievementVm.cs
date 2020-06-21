using AutoMapper.Configuration.Annotations;
using GymNotes.Service.Base;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GymNotes.Service.ViewModels
{
  public class AchievementVm
  {
    public int Id { get; set; }

    public string Name { get; set; }

    public string Place { get; set; }

    [JsonConverter(typeof(JsonFormatDate), "yyyy-MM-dd")]
    public DateTime Date { get; set; }

    public AchievementDyscyplineVm achievementDyscypline { get; set; }
  }
}