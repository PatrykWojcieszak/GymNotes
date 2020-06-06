using GymNotes.Data;
using GymNotes.Entity.Models;
using GymNotes.Models;
using GymNotes.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GymNotes.Repository.Repository
{
    public class CoachingRequestRepository : ICoachingRequestRepository
    {
        private readonly ApplicationDbContext _context;
        public CoachingRequestRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async void AddCoachRequest(CoachingRequest model)
        {
            await _context.CoachingRequests.AddAsync(model);
        }
        public void UpdateCoachRequest(CoachingRequest model)
        {
            _context.CoachingRequests.Update(model);
        }
      
        public CoachingRequest GetCoachingRequest(string coachId, string userId)
        {
            return _context.CoachingRequests.FirstOrDefault(x => x.CoachId == coachId && x.ApplicationUserId == userId);

        }

        public List<CoachingRequest> CoachRequestList(string coachId)
        {
            return _context.CoachingRequests.Where(x => x.CoachId == coachId && x.Status==(CoachingRequestStatus)0).ToList();
        }
    }
}
