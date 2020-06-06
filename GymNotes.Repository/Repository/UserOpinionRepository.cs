using GymNotes.Data;
using GymNotes.Entity.Models;
using GymNotes.Models;
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
  public class UserOpinionRepository : IUserOpinionRepository
  {
    private readonly ApplicationDbContext _context;

    public UserOpinionRepository(ApplicationDbContext context)
    {
      _context = context;
    }

    public async Task<int> AddUserOpinion(UserOpinion userOpinion)
    {
      await _context.UserOpinions.AddAsync(userOpinion);

      return await _context.SaveChangesAsync();
    }

    public async Task<List<UserOpinion>> GetUserOpinions(string userId)
    {
      return await _context.UserOpinions.Where(x => x.ProfileUserId == userId).ToListAsync();
    }

    public async Task<UserOpinion> GetUserOpinion(int opinionId)
    {
      return await _context.UserOpinions.FirstOrDefaultAsync(x => x.Id == opinionId);
    }
  }
}