using GymNotes.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymNotes.Repository.IRepository
{
    public interface IPupilRepository
    {
        void AddPupil(Pupil model);
        void UpdatePupil(Pupil model);
        Pupil GetPupil(string coachId, string userId);
        List<Pupil> GetCoachPupilList(string coachId);
    }
}
