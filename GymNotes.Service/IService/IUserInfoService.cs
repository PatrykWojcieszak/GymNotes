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
    Task<ApiResponse> UpdateInstagramURL(UpdateURLVm updateURLVm);

    Task<ApiResponse> UpdateFacebookURL(UpdateURLVm updateURLVm);

    Task<ApiResponse> UpdateTwitterURL(UpdateURLVm updateURLVm);

    Task<ApiResponse> UpdateYoutubeURL(UpdateURLVm updateURLVm);

    Task<ApiResponse> UpdateIsCoach(StringUpdateVm stringUpdateVm);

    Task<ApiResponse> UpdateBirthday(DateUpdateVm dateUpdateVm);

    Task<ApiResponse> UpdateHeight(NumberUpdateVm numberUpdateVm);

    Task<ApiResponse> UpdateYearsOfExperience(NumberUpdateVm numberUpdateVm);

    Task<ApiResponse> UpdateGender(StringUpdateVm stringUpdateVm);

    Task<ApiResponse> UpdateDiscipline(StringUpdateVm stringUpdateVm);

    Task<ApiResponse> UpdateDescription(StringUpdateVm stringUpdateVm);
  }
}