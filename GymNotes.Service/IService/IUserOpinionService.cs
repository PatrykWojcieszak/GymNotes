using GymNotes.Models;
using GymNotes.Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GymNotes.Service.IService
{
  public interface IUserOpinionService
  {
    Task<ApiResponse> AddUserOpinion(AddUserOpinionVm addUserOpinionVm);

    Task<ApiResponse> AddLikeToUserOpinion(UserOpinionLikesVm userOpinionLikesVm);

    Task<ApiResponse> RemoveLikeFromUserOpinion(string userId, int opinionId);

    List<UserOpinionVm> GetUserOpinions(string userId);
  }
}