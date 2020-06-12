using GymNotes.Models;
using GymNotes.Repository.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymNotes.Repository.IRepository.User
{
  public interface IUserRepository : IBaseRepository<ApplicationUser>
  {
  }
}