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
    IQueryable<ApplicationUser> CoachFilterBy(IQueryable<ApplicationUser> query, int orderBy);
    IQueryable<ApplicationUser> FilterBy(IQueryable<ApplicationUser> query, int orderBy);
  }
}