using GymNotes.Models;
using GymNotes.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GymNotes.Repository.IRepository.User
{
  public interface IUserRepository : IBaseRepository<ApplicationUser>
  {
    IQueryable<ApplicationUser> OrderBy(IQueryable<ApplicationUser> query, string orderBy);
  }
}