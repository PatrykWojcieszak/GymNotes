using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using GymNotes.Entity.Models;
using Microsoft.AspNetCore.Identity;

namespace GymNotes.Models
{
  public class ApplicationUser : IdentityUser
  {
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Alias { get; set; }

    public string Instagram { get; set; }

    public string Facebook { get; set; }

    public string Description { get; set; }

    public string Discipline { get; set; }

    public string Twitter { get; set; }

    public string Youtube { get; set; }

    public int? YearsOfExperience { get; set; }

    public DateTime? Birthday { get; set; }

    public double? Height { get; set; }

    [Required]
    public bool IsCoach { get; set; }

    public string Gender { get; set; }

    public string FullName
    {
      get
      {
        if (FirstName == null || LastName == null)
        {
          return null;
        }
        return FirstName + " " + LastName;
      }
    }

    public List<AchievementDyscypline> AchievementDyscyplines { get; set; }

    public List<Contact> Contacts { get; set; }
    public List<Message> Messages { get; set; }

    public ApplicationUser()
    {
      AchievementDyscyplines = new List<AchievementDyscypline>();

      Contacts = new List<Contact>();

      Messages = new List<Message>();
    }
  }
}