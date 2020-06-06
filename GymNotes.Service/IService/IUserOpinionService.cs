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
    Task<bool> AddUserOpinion(AddUserOpinionVm addUserOpinionVm);

    Task<bool> AddLikeToUserOpinion(UserOpinionLikesVm userOpinionLikesVm);

    Task<bool> RemoveLikeFromUserOpinion(string userId, int opinionId);

    Task<List<UserOpinionVm>> GetUserOpinions(string userId);
  }
}