using AutoMapper;
using GymNotes.Models;
using GymNotes.Repository.IRepository;
using GymNotes.Service.IService;
using GymNotes.Service.ViewModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GymNotes.Service.Service
{
  public class UserSettingsService : IUserSettingsService
  {
    private readonly IApplicationUserRepository _userRepo;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private UserManager<ApplicationUser> _userManager;

    public UserSettingsService(IApplicationUserRepository userRepo,
      IMapper mapper,
      IUnitOfWork unitOfWork,
      UserManager<ApplicationUser> userManager)
    {
      _userRepo = userRepo;
      _mapper = mapper;
      _unitOfWork = unitOfWork;
      _userManager = userManager;
    }

    public async Task<bool> ChangeName(UpdateUserNameVm updateUserNameVm)
    {
      try
      {
        var user = _userRepo.GetUserById(updateUserNameVm.UserId);

        if (user == null)
          return false;

        user.FirstName = updateUserNameVm.FirstName;
        user.LastName = updateUserNameVm.LastName;
        user.Alias = updateUserNameVm.Alias;

        await _unitOfWork.CompleteAsync();

        return true;
      }
      catch (Exception ex)
      {
        return false;
      }
    }

    public async Task<IdentityResult> ChangePassword(UpdatePasswordVm updatePasswordVm)
    {
      try
      {
        var user = _userRepo.GetUserById(updatePasswordVm.UserId);

        if (user == null)
          return null;

        var result = await _userManager.ChangePasswordAsync(user, updatePasswordVm.OldPassword, updatePasswordVm.NewPassword);

        return result;
      }
      catch (Exception ex)
      {
        return null;
      }
    }

    public async Task<bool> ChangeEmail(UserEmailVm userEmailVm)
    {
      try
      {
        var user = _userRepo.GetUserById(userEmailVm.UserId);

        if (user == null)
          return false;

        user.Email = userEmailVm.Email;

        await _unitOfWork.CompleteAsync();

        return true;
      }
      catch (Exception ex)
      {
        return false;
      }
    }

    public UpdateUserNameVm GetuserFullName(string userId)
    {
      try
      {
        var user = _userRepo.GetUserById(userId);

        if (user == null)
          return null;

        var result = _mapper.Map<ApplicationUser, UpdateUserNameVm>(user);

        return result;
      }
      catch (Exception ex)
      {
        return null;
      }
    }

    public UserEmailVm GetUserEmail(string userId)
    {
      try
      {
        var user = _userRepo.GetUserById(userId);

        if (user == null)
          return null;

        UserEmailVm result = new UserEmailVm() { Email = user.Email };

        return result;
      }
      catch (Exception ex)
      {
        return null;
      }
    }
  }
}