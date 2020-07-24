using GymNotes.Models;
using GymNotes.Service.ViewModels;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using GymNotes.Service.Utils;
using GymNotes.Service.ViewModels.Authentication;

namespace GymNotes.Service.IService
{
  public interface IUserService
  {
    UserVm GetUserByEmail(string email);

    Task<ApiResponse> ResetPassword(PasswordResetVm model);

    Task<ApiResponse> ForgotPassword(EmailVm model);

    Task<ApiResponse> ConfirmEmailAddress(EmailConfirmationVm model);

    Task<AuthenticateResponseVm> Authentication(AuthenticationVm model, string IpAddress);

    Task<AuthenticateResponseVm> RefreshToken(string token, string ipAddress);

    Task<bool> RevokeToken(string token, string ipAddress);

    Task<ApiResponse> Register(UserRegisterVm userModel);

    Task<PaginatedList<UserVm>> GetUsers(PageQuery pageQuery);

    IQueryable<ApplicationUser> OrderBy(IQueryable<ApplicationUser> query, string orderBy);

    Task<ApiResponse> UpdateUserInfo(string id, UserVm UserModel);

    UserVm GetUser(string id);

    Task<ApiResponse> AddOrUpdateUserAchievement(string id, AchievementDyscyplineVm achievementDyscyplineVm);

    AchievementDyscyplineVm GetUserAchievements(string userId, int id);

    List<AchievementDyscyplineVm> GetUserAchievementsList(string userId);

    Task<ApiResponse> DeleteUserAchievementDyscypline(string userId, int id);

    Task<ApiResponse> DeleteUserAchievement(string userId, int id);

    Task<ApiResponse> SendCoachingRequest(CoachingRequestVm coachRequestVm);
  }
}