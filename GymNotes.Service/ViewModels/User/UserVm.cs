﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GymNotes.Service.ViewModels
{
  public class UserVm
  {
    public string Id { get; set; }

    public string Email { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string FullName { get; set; }

    public string Alias { get; set; }

    public string Instagram { get; set; }

    public string Facebook { get; set; }

    public string Description { get; set; }

    public string Discipline { get; set; }

    public string Twitter { get; set; }

    public string Youtube { get; set; }

    public DateTime? TrainingSince { get; set; }

    public int? YearsOfExperience {
            get
            {
                if (TrainingSince != null)
                    return DateTime.Now.Year - TrainingSince.Value.Year;
                else
                    return 0;
            }
        }

    public DateTime? Birthday { get; set; }

    public double? Height { get; set; }

    public bool IsCoach { get; set; }

    public string Gender { get; set; }

    public List<AchievementDyscyplineVm> AchievementDyscyplines { get; set; }

    public UserVm()
    {
      AchievementDyscyplines = new List<AchievementDyscyplineVm>();
    }
  }
}