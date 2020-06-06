using System;
using System.Collections.Generic;
using System.Text;

namespace GymNotes.Entity.Models
{
  public class AchievementDyscypline
  {
    public int Id { get; set; }

    public string Name { get; set; }

    public string ApplicationUserId { get; set; }

    public List<Achievement> Achievements { get; set; }

    public AchievementDyscypline()
    {
      Achievements = new List<Achievement>();
    }
  }
}