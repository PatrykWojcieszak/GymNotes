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

    public IQueryable<ApplicationUser> CoachFilterBy(IQueryable<ApplicationUser> query, int filterBy)
    {
      switch (filterBy)
      {
        case (int)CoachFilterbyEnum.Coaches:
          return query.Where(i => i.IsCoach);

        case (int)CoachFilterbyEnum.Everyone:
          return query;

        default:
          return query.Where(i => i.IsCoach);
      }
    }

    public IQueryable<ApplicationUser> FilterBy(IQueryable<ApplicationUser> query, int filterBy)
    {
      switch (filterBy)
      {
        case (int)FilterByEnum.Featured:
          return query.Where(i => i.IsCoach);

        case (int)FilterByEnum.Newest:
          return query;

        case (int)FilterByEnum.HighestRating:
          return query;

        default:
          return query.Where(i => i.IsCoach);
      }
    }
  }
}