using GymNotes.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace GymNotes.Repository.IRepository
{
  public interface IApplicationUserRepository
  {
    ApplicationUser GetUserByEmail(string email);

    IQueryable<ApplicationUser> GetUsers();
    IQueryable<ApplicationUser> OrderBy(IQueryable<ApplicationUser> query, string orderBy);
    void UpdateUserInfo(ApplicationUser user);

    ApplicationUser GetUserById(string id);
  }
}