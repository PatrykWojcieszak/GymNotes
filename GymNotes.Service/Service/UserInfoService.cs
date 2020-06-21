using AutoMapper;
using GymNotes.Entity.Models;
using GymNotes.Models;
using GymNotes.Repository.IRepository;
using GymNotes.Repository.IRepository.User;
using GymNotes.Service.Exceptions;
using GymNotes.Service.IService;
using GymNotes.Service.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Asn1.Ocsp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GymNotes.Service.Service
{
  public class UserInfoService : IUserInfoService
  {
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public UserInfoService(
      IMapper mapper,
      IUnitOfWork unitOfWork)
    {
      _mapper = mapper;
      _unitOfWork = unitOfWork;
    }

    public async Task<ApiResponse> UpdateInstagramURL(StringVm updateURLVm)
    {
      var user = _unitOfWork.userRepository.FindByCondition(x => x.Id == updateURLVm.UserId).FirstOrDefault();

      if (user == null)
        throw new MyNotFoundException(ApiResponseDescription.USER_NOT_FOUND);

      user.Instagram = updateURLVm.Content;

      _unitOfWork.userRepository.Update(user);
      await _unitOfWork.CompleteAsync();

      return new ApiResponse(true);
    }

    public async Task<ApiResponse> UpdateFacebookURL(StringVm updateURLVm)
    {
      var user = _unitOfWork.userRepository.FindByCondition(x => x.Id == updateURLVm.UserId).FirstOrDefault();

      if (user == null)
        throw new MyNotFoundException(ApiResponseDescription.USER_NOT_FOUND);

      user.Facebook = updateURLVm.Content;

      _unitOfWork.userRepository.Update(user);
      await _unitOfWork.CompleteAsync();

      return new ApiResponse(true);
    }

    public async Task<ApiResponse> UpdateTwitterURL(StringVm updateURLVm)
    {
      var user = _unitOfWork.userRepository.FindByCondition(x => x.Id == updateURLVm.UserId).FirstOrDefault();

      if (user == null)
        throw new MyNotFoundException(ApiResponseDescription.USER_NOT_FOUND);

      user.Twitter = updateURLVm.Content;

      _unitOfWork.userRepository.Update(user);
      await _unitOfWork.CompleteAsync();

      return new ApiResponse(true);
    }

    public async Task<ApiResponse> UpdateYoutubeURL(StringVm updateURLVm)
    {
      var user = _unitOfWork.userRepository.FindByCondition(x => x.Id == updateURLVm.UserId).FirstOrDefault();

      if (user == null)
        throw new MyNotFoundException(ApiResponseDescription.USER_NOT_FOUND);

      user.Youtube = updateURLVm.Content;

      _unitOfWork.userRepository.Update(user);
      await _unitOfWork.CompleteAsync();

      return new ApiResponse(true);
    }

    public async Task<ApiResponse> UpdateDescription(StringVm stringUpdateVm)
    {
      var user = _unitOfWork.userRepository.FindByCondition(x => x.Id == stringUpdateVm.UserId).FirstOrDefault();

      if (user == null)
        throw new MyNotFoundException(ApiResponseDescription.USER_NOT_FOUND);

      user.Description = stringUpdateVm.Content;

      _unitOfWork.userRepository.Update(user);
      await _unitOfWork.CompleteAsync();

      return new ApiResponse(true);
    }

    public async Task<ApiResponse> UpdateDiscipline(StringVm stringUpdateVm)
    {
      var user = _unitOfWork.userRepository.FindByCondition(x => x.Id == stringUpdateVm.UserId).FirstOrDefault();

      if (user == null)
        throw new MyNotFoundException(ApiResponseDescription.USER_NOT_FOUND);

      user.Discipline = stringUpdateVm.Content;

      _unitOfWork.userRepository.Update(user);
      await _unitOfWork.CompleteAsync();

      return new ApiResponse(true);
    }

    public async Task<ApiResponse> UpdateGender(StringVm stringUpdateVm)
    {
      var user = _unitOfWork.userRepository.FindByCondition(x => x.Id == stringUpdateVm.UserId).FirstOrDefault();

      if (user == null)
        throw new MyNotFoundException(ApiResponseDescription.USER_NOT_FOUND);

      user.Gender = stringUpdateVm.Content;

      _unitOfWork.userRepository.Update(user);
      await _unitOfWork.CompleteAsync();

      return new ApiResponse(true);
    }

    public async Task<ApiResponse> UpdateYearsOfExperience(NumberVm numberUpdateVm)
    {
      var user = _unitOfWork.userRepository.FindByCondition(x => x.Id == numberUpdateVm.UserId).FirstOrDefault();

      if (user == null)
        throw new MyNotFoundException(ApiResponseDescription.USER_NOT_FOUND);

      user.YearsOfExperience = numberUpdateVm.Value;

      _unitOfWork.userRepository.Update(user);
      await _unitOfWork.CompleteAsync();

      return new ApiResponse(true);
    }

    public async Task<ApiResponse> UpdateHeight(NumberVm numberUpdateVm)
    {
      var user = _unitOfWork.userRepository.FindByCondition(x => x.Id == numberUpdateVm.UserId).FirstOrDefault();

      if (user == null)
        throw new MyNotFoundException(ApiResponseDescription.USER_NOT_FOUND);

      user.Height = numberUpdateVm.Value;

      _unitOfWork.userRepository.Update(user);
      await _unitOfWork.CompleteAsync();

      return new ApiResponse(true);
    }

    public async Task<ApiResponse> UpdateBirthday(DateVm dateUpdateVm)
    {
      var user = _unitOfWork.userRepository.FindByCondition(x => x.Id == dateUpdateVm.UserId).FirstOrDefault();

      if (user == null)
        throw new MyNotFoundException(ApiResponseDescription.USER_NOT_FOUND);

      user.Birthday = dateUpdateVm.Date;

      _unitOfWork.userRepository.Update(user);
      await _unitOfWork.CompleteAsync();

      return new ApiResponse(true);
    }

    public async Task<ApiResponse> UpdateIsCoach(StringVm stringUpdateVm)
    {
      var user = _unitOfWork.userRepository.FindByCondition(x => x.Id == stringUpdateVm.UserId).FirstOrDefault();
      if (user == null)
        throw new MyNotFoundException(ApiResponseDescription.USER_NOT_FOUND);

      user.IsCoach = Convert.ToBoolean(stringUpdateVm.Content);

      _unitOfWork.userRepository.Update(user);
      await _unitOfWork.CompleteAsync();

      return new ApiResponse(true);
    }
  }
}