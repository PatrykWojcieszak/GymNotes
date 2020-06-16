using GymNotes.Entity.Models;
using GymNotes.Models;
using GymNotes.Repository.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GymNotes.Repository.IRepository
{
  public interface IUserOpinionRepository : IBaseRepository<UserOpinion>
  {
    //Task<int> AddUserOpinion(UserOpinion userOpinion);

    //Task<List<UserOpinion>> GetUserOpinions(string userId);

    //Task<UserOpinion> GetUserOpinion(int opinionId);
  }
}