using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GymNotes.Data;
using GymNotes.Models;
using GymNotes.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace GymNotes.Repository.Repository
{
  public class ApplicationUserRepository : IApplicationUserRepository
  {
    private readonly ApplicationDbContext _context;

    public ApplicationUserRepository(ApplicationDbContext context)
    {
      _context = context;
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

    public ApplicationUser GetUserByEmail(string email)
    {
      return _context.ApplicationUsers.FirstOrDefault(x => x.Email == email);
    }

    public IQueryable<ApplicationUser> GetUsers() =>
      _context.ApplicationUsers;

    public ApplicationUser GetUserById(string id)
    {
      return _context.ApplicationUsers.Include(x => x.Contacts).Include(x => x.Messages).FirstOrDefault(x => x.Id == id);
    }

    public void UpdateUserInfo(ApplicationUser user)
    {
      _context.ApplicationUsers.Update(user);
    }
  }
}