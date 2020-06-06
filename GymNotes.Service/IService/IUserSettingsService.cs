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
    Task<bool> ChangeName(UpdateUserNameVm updateUserNameVm);

    Task<IdentityResult> ChangePassword(UpdatePasswordVm updatePasswordVm);

    Task<bool> ChangeEmail(UserEmailVm userEmailVm);

    UpdateUserNameVm GetuserFullName(string userId);

    UserEmailVm GetUserEmail(string userId);
  }
}