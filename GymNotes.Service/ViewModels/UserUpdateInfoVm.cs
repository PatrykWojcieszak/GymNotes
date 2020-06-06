using System;
using System.Collections.Generic;
using System.Text;

namespace GymNotes.Service.ViewModels
{
  public class UserUpdateInfoVm
  {
    public string Instagram { get; set; }

    public string Facebook { get; set; }

    public string Twitter { get; set; }

    public string YouTube { get; set; }

    public DateTime? Birthday { get; set; }

    public double? Height { get; set; }

    public bool IsCoach { get; set; }

    public string Gender { get; set; }

    public string Description { get; set; }

    public string Discipline { get; set; }

    public int? YearsOfExperience { get; set; }
  }
}