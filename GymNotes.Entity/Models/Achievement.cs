using System;
using System.Collections.Generic;
using System.Text;

namespace GymNotes.Entity.Models
{
  public class Achievement
  {
    public int Id { get; set; }

    public string Name { get; set; }

    public string Place { get; set; }

    public DateTime Date { get; set; }

    public AchievementDyscypline achievementDyscypline { get; set; }
  }
}