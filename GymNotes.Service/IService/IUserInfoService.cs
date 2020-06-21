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
    Task<ApiResponse> UpdateInstagramURL(StringVm updateURLVm);

    Task<ApiResponse> UpdateFacebookURL(StringVm updateURLVm);

    Task<ApiResponse> UpdateTwitterURL(StringVm updateURLVm);

    Task<ApiResponse> UpdateYoutubeURL(StringVm updateURLVm);

    Task<ApiResponse> UpdateIsCoach(StringVm stringUpdateVm);

    Task<ApiResponse> UpdateBirthday(DateVm dateUpdateVm);

    Task<ApiResponse> UpdateHeight(NumberVm numberUpdateVm);

    Task<ApiResponse> UpdateYearsOfExperience(NumberVm numberUpdateVm);

    Task<ApiResponse> UpdateGender(StringVm stringUpdateVm);

    Task<ApiResponse> UpdateDiscipline(StringVm stringUpdateVm);

    Task<ApiResponse> UpdateDescription(StringVm stringUpdateVm);
  }
}