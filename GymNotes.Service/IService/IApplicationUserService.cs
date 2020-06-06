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
  public interface IApplicationUserService
  {
    ApplicationUserVm GetUserByEmail(string email);

    Task<PaginatedList<ApplicationUserVm>> GetUsers(PageQuery pageQuery, string searchString = null);

    IQueryable<ApplicationUser> OrderBy(IQueryable<ApplicationUser> query, string orderBy);

    Task<bool> UpdateUserInfo(string id, ApplicationUserVm UserModel);

    ApplicationUserVm GetUser(string id);

    UserUpdateInfoVm GetUserUpdateInfo(string id);

    Task<bool> AddOrUpdateUserAchievement(string id, AchievementDyscyplineVm achievementDyscyplineVm);

    AchievementDyscyplineVm GetUserAchievements(string userId, int id);

    List<AchievementDyscyplineVm> GetUserAchievementsList(string userId);

    Task<bool> DeleteUserAchievementDyscypline(string userId, int id);

    Task<bool> DeleteUserAchievement(string userId, int id);

    Task<bool> SendCoachingRequest(CoachingRequestVm coachRequestVm);
  }
}