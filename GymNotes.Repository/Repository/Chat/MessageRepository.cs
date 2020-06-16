using GymNotes.Data;
using GymNotes.Entity.Models;
using GymNotes.Repository.Base;
using GymNotes.Repository.IRepository.Chat;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymNotes.Repository.Repository.Chat
{
  public class MessageRepository : BaseRepository<Message>, IMessageRepository
  {
    public MessageRepository(ApplicationDbContext context) :
      base(context)
    {
    }
  }
}