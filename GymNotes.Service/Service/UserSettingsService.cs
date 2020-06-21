using AutoMapper;
using GymNotes.Models;
using GymNotes.Repository.IRepository;
using GymNotes.Repository.IRepository.User;
using GymNotes.Service.Exceptions;
using GymNotes.Service.IService;
using GymNotes.Service.ViewModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymNotes.Service.Service
{
  public class UserSettingsService : IUserSettingsService
  {
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private UserManager<ApplicationUser> _userManager;

    public UserSettingsService(
      IMapper mapper,
      IUnitOfWork unitOfWork,
      UserManager<ApplicationUser> userManager)
    {
      _mapper = mapper;
      _unitOfWork = unitOfWork;
      _userManager = userManager;
    }

    public async Task<ApiResponse> ChangeName(UpdateUserNameVm updateUserNameVm)
    {
      var user = _unitOfWork.userRepository.FindByCondition(x => x.Id == updateUserNameVm.UserId).FirstOrDefault();

      if (user == null)
        throw new MyNotFoundException(ApiResponseDescription.USER_NOT_FOUND);

      user.FirstName = updateUserNameVm.FirstName;
      user.LastName = updateUserNameVm.LastName;
      user.Alias = updateUserNameVm.Alias;

      _unitOfWork.userRepository.Update(user);
      await _unitOfWork.CompleteAsync();

      return new ApiResponse(true);
    }

    public async Task<IdentityResult> ChangePassword(UpdatePasswordVm updatePasswordVm)
    {
      var user = _unitOfWork.userRepository.FindByCondition(x => x.Id == updatePasswordVm.UserId).FirstOrDefault();

      if (user == null)
        throw new MyNotFoundException(ApiResponseDescription.USER_NOT_FOUND);

      var result = await _userManager.ChangePasswordAsync(user, updatePasswordVm.OldPassword, updatePasswordVm.NewPassword);

      return result;
    }

    public async Task<ApiResponse> ChangeEmail(UpdateEmailVm userEmailVm)
    {
      var user = _unitOfWork.userRepository.FindByCondition(x => x.Id == userEmailVm.UserId).FirstOrDefault();

      if (user == null)
        throw new MyNotFoundException(ApiResponseDescription.USER_NOT_FOUND);

      user.Email = userEmailVm.Email;

      _unitOfWork.userRepository.Update(user);
      await _unitOfWork.CompleteAsync();

      return new ApiResponse(true);
    }

    public UpdateUserNameVm GetuserFullName(string userId)
    {
      var user = _unitOfWork.userRepository.FindByCondition(x => x.Id == userId).FirstOrDefault();

      if (user == null)
        throw new MyNotFoundException(ApiResponseDescription.USER_NOT_FOUND);

      var result = _mapper.Map<ApplicationUser, UpdateUserNameVm>(user);

      return result;
    }

    public UpdateEmailVm GetUserEmail(string userId)
    {
      var user = _unitOfWork.userRepository.FindByCondition(x => x.Id == userId).FirstOrDefault();

      if (user == null)
        throw new MyNotFoundException(ApiResponseDescription.USER_NOT_FOUND);

      UpdateEmailVm result = new UpdateEmailVm() { Email = user.Email };

      return result;
    }
  }
}