using AutoMapper;
using GymNotes.Entity.Models;
using GymNotes.Models;
using GymNotes.Repository.IRepository;
using GymNotes.Repository.IRepository.Chat;
using GymNotes.Repository.IRepository.User;
using GymNotes.Service.Exceptions;
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
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public ChatService(
      IMapper mapper,
      IUnitOfWork unitOfWork)
    {
      _mapper = mapper;
      _unitOfWork = unitOfWork;
    }

    public async Task<bool> AddContact(ContactVm addContactVm)
    {
      return true;
    }

    public List<ApplicationUserVm> GetContactList(string userId)
    {
      var user = _unitOfWork.userRepository.FindByCondition(x => x.Id == userId).FirstOrDefault();

      if (user == null)
        throw new MyNotFoundException(ApiResponseDescription.USER_NOT_FOUND);

      var contacts = _unitOfWork.contactRepository.FindByCondition(x => x.ReceiverId == userId || x.SenderId == userId).ToList();

      var contactList = new List<ApplicationUserVm>();

      for (int i = 0; i < contacts.Count; i++)
      {
        if (contacts[i].SenderId != userId)
        {
          contacts[i].ReceiverId = contacts[i].SenderId;
          contacts[i].SenderId = userId;
        }

        var receipent = _unitOfWork.userRepository.FindByCondition(x => x.Id == contacts[i].ReceiverId).FirstOrDefault();

        var res = _mapper.Map<ApplicationUser, ApplicationUserVm>(receipent);

        contactList.Add(res);
      }

      return contactList;
    }

    public ApplicationUserVm GetContact(ContactVm contactVm)
    {
      var sender = _unitOfWork.userRepository.FindByCondition(x => x.Id == contactVm.UserId).FirstOrDefault();
      var receiver = _unitOfWork.userRepository.FindByCondition(x => x.Id == contactVm.ReceipentId).FirstOrDefault();

      if (sender == null || receiver == null)
        throw new MyNotFoundException(ApiResponseDescription.USER_NOT_FOUND);

      var result = _mapper.Map<ApplicationUser, ApplicationUserVm>(receiver);

      return result;
    }

    public async Task<ApiResponse> AddMessage(ChatMessageVm chatMessageVm)
    {
      var contact = _unitOfWork.contactRepository.FindByCondition(x => x.ReceiverId == chatMessageVm.ReceiverId && x.SenderId == chatMessageVm.SenderId).FirstOrDefault();
      var msg = _mapper.Map<ChatMessageVm, Message>(chatMessageVm);
      msg.SenderId = chatMessageVm.SenderId;

      if (contact == null)
      {
        var con = _mapper.Map<ChatMessageVm, Contact>(chatMessageVm);
        _unitOfWork.contactRepository.Create(con);
        await _unitOfWork.CompleteAsync();
      }

      contact = _unitOfWork.contactRepository.FindByCondition(x => x.ReceiverId == chatMessageVm.ReceiverId && x.SenderId == chatMessageVm.SenderId).FirstOrDefault();

      msg.ContactId = contact.Id;
      _unitOfWork.messageRepository.Create(msg);

      await _unitOfWork.CompleteAsync();

      return new ApiResponse(true);
    }

    public List<ChatMessageVm> GetMessageList(ContactVm contactVm)
    {
      var sender = _unitOfWork.userRepository.FindByCondition(x => x.Id == contactVm.UserId).FirstOrDefault();
      var receiver = _unitOfWork.userRepository.FindByCondition(x => x.Id == contactVm.ReceipentId).FirstOrDefault();

      if (sender == null || receiver == null)
        throw new MyNotFoundException(ApiResponseDescription.USER_NOT_FOUND);

      var contact = _unitOfWork.contactRepository.
        FindByCondition(
        x => x.ReceiverId == contactVm.UserId &&
        x.SenderId == contactVm.ReceipentId ||
        x.ReceiverId == contactVm.ReceipentId &&
        x.SenderId == contactVm.UserId).FirstOrDefault();

      if (contact == null)
        throw new MyNotFoundException(ApiResponseDescription.USER_NOT_FOUND);

      var message = _unitOfWork.messageRepository.FindByCondition(x => x.ContactId == contact.Id);
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
  }
}