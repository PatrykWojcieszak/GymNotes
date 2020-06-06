using GymNotes.Entity.Models;
using GymNotes.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymNotes.Repository.IRepository
{
    public interface ICoachingRequestRepository
    {
        void AddCoachRequest(CoachingRequest coachRequest);
        void UpdateCoachRequest(CoachingRequest model);
        CoachingRequest GetCoachingRequest(string coachId, string userId);
        List<CoachingRequest> CoachRequestList(string userId);
       

    }
}
