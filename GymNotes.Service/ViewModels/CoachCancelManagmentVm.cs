using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GymNotes.Service.ViewModels
{
    public class CoachCancelManagmentVm
    {

        public string ProfileCoachId { get; set; }
        public string ProfilePupilId { get; set; }
        public bool Partnership { get; set; }
        [ForeignKey("ProfilePupilId")]
        public ApplicationUserVm ProfilePupil { get; set; }
        [ForeignKey("ProfileCoachId")]
        public ApplicationUserVm ProfileCoach { get; set; }

    }

}
