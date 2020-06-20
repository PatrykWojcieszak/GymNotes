using GymNotes.Models;
using GymNotes.Service.ViewModels;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using GymNotes.Service.Utils;

namespace GymNotes.Service.IService
{
  public interface IUserService
  {
    ApplicationUserVm GetUserByEmail(string email);

    Task<ApiResponse> ResetPassword(PasswordResetVm model);

    Task<ApiResponse> ForgotPassword(EmailVm model);

    Task<ApiResponse> ConfirmEmailAddress(EmailConfirmationVm model);

    Task<UserAuthenticatedVm> Login(UserLoginVm model);

    Task<ApiResponse> Register(UserRegisterVm userModel);

    Task<PaginatedList<ApplicationUserVm>> GetUsers(PageQuery pageQuery, string searchString = null);

    IQueryable<ApplicationUser> OrderBy(IQueryable<ApplicationUser> query, string orderBy);

    Task<ApiResponse> UpdateUserInfo(string id, ApplicationUserVm UserModel);

    ApplicationUserVm GetUser(string id);

    UserUpdateInfoVm GetUserUpdateInfo(string id);

    Task<ApiResponse> AddOrUpdateUserAchievement(string id, AchievementDyscyplineVm achievementDyscyplineVm);

    AchievementDyscyplineVm GetUserAchievements(string userId, int id);

    List<AchievementDyscyplineVm> GetUserAchievementsList(string userId);

    Task<ApiResponse> DeleteUserAchievementDyscypline(string userId, int id);

    Task<ApiResponse> DeleteUserAchievement(string userId, int id);

    Task<ApiResponse> SendCoachingRequest(CoachingRequestVm coachRequestVm);
  }
}