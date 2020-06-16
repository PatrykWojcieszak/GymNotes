using AutoMapper;
using GymNotes.Entity.Models;
using GymNotes.Models;
using GymNotes.Repository.IRepository;
using GymNotes.Repository.IRepository.Chat;
using GymNotes.Repository.IRepository.User;
using GymNotes.Service.IService;
using GymNotes.Service.ViewModels;
using GymNotes.Service.ViewModels.Chat;
using Microsoft.AspNetCore.Identity;
using Org.BouncyCastle.Asn1.Cms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymNotes.Service.Service
{
  public class ChatService : IChatService
  {
    private readonly IUserRepository _userRepo;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IContactRepository _contactRepository;
    private readonly IMessageRepository _messageRepository;

    public ChatService(
      IUserRepository userRepo,
      IMapper mapper,
      IUnitOfWork unitOfWork,
      IContactRepository contactRepository,
      IMessageRepository messageRepository)
    {
      _userRepo = userRepo;
      _mapper = mapper;
      _unitOfWork = unitOfWork;
      _contactRepository = contactRepository;
      _messageRepository = messageRepository;
    }

    public async Task<bool> AddContact(ContactVm addContactVm)
    {
      try
      {
        //var user = _userRepo.GetUserById(addContactVm.UserId);

        //if (user == null)
        //  return false;

        //var receipent = _userRepo.GetUserById(addContactVm.ReceipentId);

        //if (user == null)
        //  return false;

        //var isRecipentExist = user.Contacts.FirstOrDefault(x => x.ReceipentId == receipent.Id);

        //if (isRecipentExist == null)
        //{
        //  var currentDate = DateTime.Now;

        //  var contactUser = new Contact()
        //  {
        //    ReceipentId = receipent.Id,
        //    DateAdded = currentDate,
        //  };

        //  user.Contacts.Add(contactUser);

        //  var contactRecipent = new Contact()
        //  {
        //    ReceipentId = user.Id,
        //    DateAdded = currentDate,
        //  };

        //  receipent.Contacts.Add(contactRecipent);

        //  await _unitOfWork.CompleteAsync();
        //}

        return true;
      }
      catch (Exception ex)
      {
        return false;
      }
    }

    public async Task<List<ApplicationUserVm>> GetContactList(string userId)
    {
      try
      {
        var user = _userRepo.FindByCondition(x => x.Id == userId).FirstOrDefault();

        if (user == null)
          return null;

        var contacts = _contactRepository.FindByCondition(x => x.ReceiverId == userId || x.SenderId == userId).ToList();

        var contactList = new List<ApplicationUserVm>();

        for (int i = 0; i < contacts.Count; i++)
        {
          if (contacts[i].SenderId != userId)
          {
            contacts[i].ReceiverId = contacts[i].SenderId;
            contacts[i].SenderId = userId;
          }

          var receipent = _userRepo.FindByCondition(x => x.Id == contacts[i].ReceiverId).FirstOrDefault();

          var res = _mapper.Map<ApplicationUser, ApplicationUserVm>(receipent);

          contactList.Add(res);
        }

        return contactList;
      }
      catch (Exception ex)
      {
        return null;
      }
    }

    public ApplicationUserVm GetContact(ContactVm contactVm)
    {
      try
      {
        var sender = _userRepo.FindByCondition(x => x.Id == contactVm.UserId).FirstOrDefault();
        var receiver = _userRepo.FindByCondition(x => x.Id == contactVm.ReceipentId).FirstOrDefault();

        if (sender == null || receiver == null)
          return null;

        var result = _mapper.Map<ApplicationUser, ApplicationUserVm>(receiver);

        return result;
      }
      catch (Exception ex)
      {
        return null;
      }
    }

    public async Task<bool> AddMessage(ChatMessageVm chatMessageVm)
    {
      try
      {
        var contact = _contactRepository.FindByCondition(x => x.ReceiverId == chatMessageVm.ReceiverId && x.SenderId == chatMessageVm.SenderId).FirstOrDefault();
        var msg = _mapper.Map<ChatMessageVm, Message>(chatMessageVm);
        msg.SenderId = chatMessageVm.SenderId;

        if (contact == null)
        {
          var con = _mapper.Map<ChatMessageVm, Contact>(chatMessageVm);
          _contactRepository.Create(con);
          await _unitOfWork.CompleteAsync();
        }

        contact = _contactRepository.FindByCondition(x => x.ReceiverId == chatMessageVm.ReceiverId && x.SenderId == chatMessageVm.SenderId).FirstOrDefault();

        msg.ContactId = contact.Id;
        _messageRepository.Create(msg);

        await _unitOfWork.CompleteAsync();

        return true;
      }
      catch (Exception ex)
      {
        return false;
      }
    }

    public async Task<List<ChatMessageVm>> GetMessageList(ContactVm contactVm)
    {
      try
      {
        var sender = _userRepo.FindByCondition(x => x.Id == contactVm.UserId).FirstOrDefault();
        var receiver = _userRepo.FindByCondition(x => x.Id == contactVm.ReceipentId).FirstOrDefault();

        if (sender == null || receiver == null)
          return null;

        var contact = _contactRepository.
          FindByCondition(
          x => x.ReceiverId == contactVm.UserId &&
          x.SenderId == contactVm.ReceipentId ||
          x.ReceiverId == contactVm.ReceipentId &&
          x.SenderId == contactVm.UserId).FirstOrDefault();

        if (contact == null)
          return null;

        var message = _messageRepository.FindByCondition(x => x.ContactId == contact.Id);
        var msg = message.Skip(Math.Max(0, message.Count() - 50)).ToList();
        var result = _mapper.Map<List<Message>, List<ChatMessageVm>>(msg);

        foreach (var item in result)
        {
          if (item.SenderId == contactVm.UserId)
            item.IsSender = true;
          else
            item.IsSender = false;
        }

        return result;
      }
      catch (Exception ex)
      {
        return null;
      }
    }
  }
}