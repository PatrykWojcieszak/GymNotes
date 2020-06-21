using GymNotes.Service.ViewModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GymNotes.Service.IService
{
  public interface IUserSettingsService
  {
    Task<ApiResponse> ChangeName(UpdateUserNameVm updateUserNameVm);

    Task<IdentityResult> ChangePassword(UpdatePasswordVm updatePasswordVm);

    Task<ApiResponse> ChangeEmail(UpdateEmailVm userEmailVm);

    UpdateUserNameVm GetuserFullName(string userId);

    UpdateEmailVm GetUserEmail(string userId);
  }
}