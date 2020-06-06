using GymNotes.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GymNotes.Repository.IRepository
{
  public interface IChatRepository
  {
    void AddMessage(Message model);

    Task<List<Message>> GetMessages(int contactId);

    Task AddContact(Contact contact);

    Task<Contact> GetContact(string senderId, string receiverId);

    Task<List<Contact>> GetListOfContacts(string senderId);
  }
}