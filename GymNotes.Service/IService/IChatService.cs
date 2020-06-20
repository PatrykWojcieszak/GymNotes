﻿using GymNotes.Models;
using GymNotes.Service.ViewModels;
using GymNotes.Service.ViewModels.Chat;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GymNotes.Service.IService
{
  public interface IChatService
  {
    Task<bool> AddContact(ContactVm addContactVm);

    List<ApplicationUserVm> GetContactList(string userId);

    ApplicationUserVm GetContact(ContactVm contactVm);

    Task<ApiResponse> AddMessage(ChatMessageVm chatMessageVm);

    List<ChatMessageVm> GetMessageList(ContactVm contactVm);
  }
}