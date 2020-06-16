using GymNotes.Data;
using GymNotes.Models;
using GymNotes.Repository.Base;
using GymNotes.Repository.IRepository.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GymNotes.Repository.Repository.User
{
  public class UserRepository : BaseRepository<ApplicationUser>, IUserRepository
  {
    public UserRepository(ApplicationDbContext applicationDbContext) :
      base(applicationDbContext)
    {
    }

    public IQueryable<ApplicationUser> OrderBy(IQueryable<ApplicationUser> query, string orderBy)
    {
      switch (orderBy)
      {
        case "username":
          return query.OrderBy(i => i.UserName);

        case "-username":
          return query.OrderByDescending(i => i.UserName);

        case "email":
          return query.OrderBy(i => i.Email);

        case "-email":
          return query.OrderByDescending(i => i.Email);

        default:
          return query.OrderBy(i => i.UserName);
      }
    }
  }
}