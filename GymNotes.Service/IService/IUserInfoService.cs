using GymNotes.Models;
using GymNotes.Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GymNotes.Service.IService
{
  public interface IUserInfoService
  {
    Task<bool> UpdateInstagramURL(UpdateURLVm updateURLVm);

    Task<bool> UpdateFacebookURL(UpdateURLVm updateURLVm);

    Task<bool> UpdateTwitterURL(UpdateURLVm updateURLVm);

    Task<bool> UpdateYoutubeURL(UpdateURLVm updateURLVm);

    Task<bool> UpdateIsCoach(StringUpdateVm stringUpdateVm);

    Task<bool> UpdateBirthday(DateUpdateVm dateUpdateVm);

    Task<bool> UpdateHeight(NumberUpdateVm numberUpdateVm);

    Task<bool> UpdateYearsOfExperience(NumberUpdateVm numberUpdateVm);

    Task<bool> UpdateGender(StringUpdateVm stringUpdateVm);

    Task<bool> UpdateDiscipline(StringUpdateVm stringUpdateVm);

    Task<bool> UpdateDescription(StringUpdateVm stringUpdateVm);
  }
}