using GymNotes.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GymNotes.Entity.Models
{
    public class Pupil
    {
        public int Id { get; set; }
        public string ProfileCoachId { get; set; }
        public string ProfilePupilId { get; set; }
        public bool Partnership { get; set; }
        [ForeignKey("ProfilePupilId")]
        public ApplicationUser ProfilePupil { get; set; }
        [ForeignKey("ProfileCoachId")]
        public ApplicationUser ProfileCoach { get; set; }
        
    }
}
