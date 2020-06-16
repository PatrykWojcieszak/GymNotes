using GymNotes.Data;
using GymNotes.Entity.Models;
using GymNotes.Models;
using GymNotes.Repository.Base;
using GymNotes.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GymNotes.Repository.Repository
{
  public class PupilRepository : BaseRepository<Pupil>, IPupilRepository
  {
    public PupilRepository(ApplicationDbContext context) :
      base(context)
    {
    }

    //public async void AddPupil(Pupil model)
    //{
    //  await _context.Pupils.AddAsync(model);
    //}

    //public void UpdatePupil(Pupil model)
    //{
    //  _context.Pupils.Update(model);
    //}

    //public Pupil GetPupil(string coachId, string userId)
    //{
    //  return _context.Pupils.FirstOrDefault(x => x.ProfileCoachId == coachId && x.ProfilePupilId == userId);
    //}

    //public List<Pupil> GetCoachPupilList(string coachId)
    //{
    //  return _context.Pupils.Where(x => x.ProfileCoachId == coachId && x.Partnership == true).ToList();
    //}
  }
}