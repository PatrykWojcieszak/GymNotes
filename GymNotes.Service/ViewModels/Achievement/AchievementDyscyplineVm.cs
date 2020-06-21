using System;
using System.Collections.Generic;
using System.Text;

namespace GymNotes.Service.ViewModels
{
  public class AchievementDyscyplineVm
  {
    public int Id { get; set; }

    public string Name { get; set; }

    public List<AchievementVm> Achievements { get; set; }

    public AchievementDyscyplineVm()
    {
      Achievements = new List<AchievementVm>();
    }
  }
}