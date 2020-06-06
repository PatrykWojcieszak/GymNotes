using GymNotes.Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GymNotes.Service.IService
{
    public interface ICoachService
    {
        Task<bool> CoachCancelManagment(CoachCancelManagmentVm coachCancelManagmentVm);
        Task<bool> CoachManagmentRequest(CoachManagmentRequestVm coachManagmentRequestVm);
        List<CoachManagmentRequestVm> CoachPupilList(string coachId);
        List<CoachingRequestVm> CoachRequestList(string coachId);

    }
}
