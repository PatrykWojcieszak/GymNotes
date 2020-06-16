using GymNotes.Entity.Models;
using GymNotes.Models;
using GymNotes.Repository.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GymNotes.Repository.IRepository
{
  public interface IUserOpinionLikesRepository : IBaseRepository<UserOpinionLikes>
  {
    //void AddLike(UserOpinionLikes model);

    //void RemoveLike(UserOpinionLikes model);

    //Task<UserOpinionLikes> GetUserOpinionLike(int userOpinionId, string userId);
  }
}