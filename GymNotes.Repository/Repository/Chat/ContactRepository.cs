using GymNotes.Data;
using GymNotes.Entity.Models;
using GymNotes.Repository.Base;
using GymNotes.Repository.IRepository.Chat;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymNotes.Repository.Repository.Chat
{
  public class ContactRepository : BaseRepository<Contact>, IContactRepository
  {
    public ContactRepository(ApplicationDbContext context) :
      base(context)
    {
    }
  }
}