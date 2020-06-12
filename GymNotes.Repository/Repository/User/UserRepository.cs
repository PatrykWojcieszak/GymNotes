using GymNotes.Data;
using GymNotes.Models;
using GymNotes.Repository.Base;
using GymNotes.Repository.IRepository.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymNotes.Repository.Repository.User
{
  public class UserRepository : BaseRepository<ApplicationUser>, IUserRepository
  {
    public UserRepository(ApplicationDbContext applicationDbContext) :
      base(applicationDbContext)
    {
    }
  }
}