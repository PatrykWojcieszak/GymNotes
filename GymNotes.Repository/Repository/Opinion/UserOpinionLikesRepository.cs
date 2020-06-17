using GymNotes.Data;
using GymNotes.Entity.Models;
using GymNotes.Models;
using GymNotes.Repository.Base;
using GymNotes.Repository.IRepository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymNotes.Repository.Repository
{
  public class UserOpinionLikesRepository : BaseRepository<UserOpinionLikes>, IUserOpinionLikesRepository
  {
    private readonly ApplicationDbContext _context;

    public UserOpinionLikesRepository(ApplicationDbContext context) :
      base(context)
    {
      _context = context;
    }

    //public async void AddLike(UserOpinionLikes model)
    //{
    //  await _context.UserOpinionLikes.AddAsync(model);
    //}

    //public void RemoveLike(UserOpinionLikes model)
    //{
    //  _context.UserOpinionLikes.Remove(model);
    //}

    //public async Task<UserOpinionLikes> GetUserOpinionLike(int userOpinionId, string userId)
    //{
    //  return await _context.UserOpinionLikes.FirstOrDefaultAsync(x => x.ApplicationUserId == userId && x.UserOpinionId == userOpinionId);
    //}
  }
}