using GymNotes.Data;
using GymNotes.Entity.Models;
using GymNotes.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymNotes.Repository.Repository
{
  public class ChatRepository : IChatRepository
  {
    private readonly ApplicationDbContext _context;

    public ChatRepository(ApplicationDbContext context)
    {
      _context = context;
    }

    public async void AddMessage(Message model)
    {
      await _context.Messages.AddAsync(model);
    }

    public async Task<List<Message>> GetMessages(int contactId)
    {
      var msg = await _context.Messages.Where(x => x.ContactId == contactId).ToListAsync();
      msg = msg.Skip(Math.Max(0, msg.Count() - 50)).ToList();

      return msg;
    }

    public async Task<List<Contact>> GetListOfContacts(string senderId)
    {
      var contacts = await _context.Contacts.Where(x => (x.ReceiverId == senderId || x.SenderId == senderId)).ToListAsync();

      return contacts;
    }

    public async Task<Contact> GetContact(string senderId, string receiverId)
    {
      return await _context.Contacts.FirstOrDefaultAsync(x => x.ReceiverId == receiverId && x.SenderId == senderId || x.ReceiverId == senderId && x.SenderId == receiverId);
    }

    public async Task AddContact(Contact contact)
    {
      await _context.Contacts.AddAsync(contact);
    }
  }
}