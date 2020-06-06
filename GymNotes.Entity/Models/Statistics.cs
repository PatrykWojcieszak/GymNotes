using System;
using System.Collections.Generic;
using System.Text;

namespace GymNotes.Entity.Models
{
  public class Statistics
  {
    public int Id { get; set; }

    public string ApplicationUserId { get; set; }

    public float Weight { get; set; }

    public DateTime Date { get; set; }

    public List<StatisticsDyscypline> StatisticsDyscyplines { get; set; }

    public Statistics()
    {
      StatisticsDyscyplines = new List<StatisticsDyscypline>();
    }
  }
}