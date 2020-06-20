using AutoMapper;
using GymNotes.Entity.Models;
using GymNotes.Models;
using GymNotes.Repository.IRepository;
using GymNotes.Repository.IRepository.User;
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

    public async Task<ApiResponse> UpdateInstagramURL(UpdateURLVm updateURLVm)
    {
      try
      {
        var user = _unitOfWork.userRepository.FindByCondition(x => x.Id == updateURLVm.UserId).FirstOrDefault();

        if (user == null)
          return new ApiResponse((int)HttpStatusCode.NotFound, "User not found");

        user.Instagram = updateURLVm.URL;

        _unitOfWork.userRepository.Update(user);
        await _unitOfWork.CompleteAsync();

        return new ApiResponse((int)HttpStatusCode.OK);
      }
      catch (Exception ex)
      {
        return new ApiResponse((int)HttpStatusCode.InternalServerError, "Something went wrong");
      }
    }

    public async Task<ApiResponse> UpdateFacebookURL(UpdateURLVm updateURLVm)
    {
      try
      {
        var user = _unitOfWork.userRepository.FindByCondition(x => x.Id == updateURLVm.UserId).FirstOrDefault();

        if (user == null)
          return new ApiResponse((int)HttpStatusCode.NotFound, "User with ID: " + updateURLVm.UserId + "not found");

        user.Facebook = updateURLVm.URL;

        _unitOfWork.userRepository.Update(user);
        await _unitOfWork.CompleteAsync();

        return new ApiResponse((int)HttpStatusCode.OK);
      }
      catch (Exception ex)
      {
        return new ApiResponse((int)HttpStatusCode.InternalServerError, "Something went wrong");
      }
    }

    public async Task<ApiResponse> UpdateTwitterURL(UpdateURLVm updateURLVm)
    {
      try
      {
        var user = _unitOfWork.userRepository.FindByCondition(x => x.Id == updateURLVm.UserId).FirstOrDefault();

        if (user == null)
          return new ApiResponse((int)HttpStatusCode.NotFound, "User with ID: " + updateURLVm.UserId + "not found");

        user.Twitter = updateURLVm.URL;

        _unitOfWork.userRepository.Update(user);
        await _unitOfWork.CompleteAsync();

        return new ApiResponse((int)HttpStatusCode.OK);
      }
      catch (Exception ex)
      {
        return new ApiResponse((int)HttpStatusCode.InternalServerError, "Something went wrong");
      }
    }

    public async Task<ApiResponse> UpdateYoutubeURL(UpdateURLVm updateURLVm)
    {
      try
      {
        var user = _unitOfWork.userRepository.FindByCondition(x => x.Id == updateURLVm.UserId).FirstOrDefault();

        if (user == null)
          return new ApiResponse((int)HttpStatusCode.NotFound, "User with ID: " + updateURLVm.UserId + "not found");

        user.Youtube = updateURLVm.URL;

        _unitOfWork.userRepository.Update(user);
        await _unitOfWork.CompleteAsync();

        return new ApiResponse((int)HttpStatusCode.OK);
      }
      catch (Exception ex)
      {
        return new ApiResponse((int)HttpStatusCode.InternalServerError, "Something went wrong");
      }
    }

    public async Task<ApiResponse> UpdateDescription(StringUpdateVm stringUpdateVm)
    {
      try
      {
        var user = _unitOfWork.userRepository.FindByCondition(x => x.Id == stringUpdateVm.UserId).FirstOrDefault();

        if (user == null)
          return new ApiResponse((int)HttpStatusCode.NotFound, "User with ID: " + stringUpdateVm.UserId + "not found");

        user.Description = stringUpdateVm.Content;

        _unitOfWork.userRepository.Update(user);
        await _unitOfWork.CompleteAsync();

        return new ApiResponse((int)HttpStatusCode.OK);
      }
      catch (Exception ex)
      {
        return new ApiResponse((int)HttpStatusCode.InternalServerError, "Something went wrong");
      }
    }

    public async Task<ApiResponse> UpdateDiscipline(StringUpdateVm stringUpdateVm)
    {
      try
      {
        var user = _unitOfWork.userRepository.FindByCondition(x => x.Id == stringUpdateVm.UserId).FirstOrDefault();

        if (user == null)
          return new ApiResponse((int)HttpStatusCode.NotFound, "User with ID: " + stringUpdateVm.UserId + "not found");

        user.Discipline = stringUpdateVm.Content;

        _unitOfWork.userRepository.Update(user);
        await _unitOfWork.CompleteAsync();

        return new ApiResponse((int)HttpStatusCode.OK);
      }
      catch (Exception ex)
      {
        return new ApiResponse((int)HttpStatusCode.InternalServerError, "Something went wrong");
      }
    }

    public async Task<ApiResponse> UpdateGender(StringUpdateVm stringUpdateVm)
    {
      try
      {
        var user = _unitOfWork.userRepository.FindByCondition(x => x.Id == stringUpdateVm.UserId).FirstOrDefault();

        if (user == null)
          return new ApiResponse((int)HttpStatusCode.NotFound, "User with ID: " + stringUpdateVm.UserId + "not found");

        user.Gender = stringUpdateVm.Content;

        _unitOfWork.userRepository.Update(user);
        await _unitOfWork.CompleteAsync();

        return new ApiResponse((int)HttpStatusCode.OK);
      }
      catch (Exception ex)
      {
        return new ApiResponse((int)HttpStatusCode.InternalServerError, "Something went wrong");
      }
    }

    public async Task<ApiResponse> UpdateYearsOfExperience(NumberUpdateVm numberUpdateVm)
    {
      try
      {
        var user = _unitOfWork.userRepository.FindByCondition(x => x.Id == numberUpdateVm.UserId).FirstOrDefault();

        if (user == null)
          return new ApiResponse((int)HttpStatusCode.NotFound, "User with ID: " + numberUpdateVm.UserId + "not found");

        user.YearsOfExperience = numberUpdateVm.Value;

        _unitOfWork.userRepository.Update(user);
        await _unitOfWork.CompleteAsync();

        return new ApiResponse((int)HttpStatusCode.OK);
      }
      catch (Exception ex)
      {
        return new ApiResponse((int)HttpStatusCode.InternalServerError, "Something went wrong");
      }
    }

    public async Task<ApiResponse> UpdateHeight(NumberUpdateVm numberUpdateVm)
    {
      try
      {
        var user = _unitOfWork.userRepository.FindByCondition(x => x.Id == numberUpdateVm.UserId).FirstOrDefault();

        if (user == null)
          return new ApiResponse((int)HttpStatusCode.NotFound, "User with ID: " + numberUpdateVm.UserId + "not found");

        user.Height = numberUpdateVm.Value;

        _unitOfWork.userRepository.Update(user);
        await _unitOfWork.CompleteAsync();

        return new ApiResponse((int)HttpStatusCode.OK);
      }
      catch (Exception ex)
      {
        return new ApiResponse((int)HttpStatusCode.InternalServerError, "Something went wrong");
      }
    }

    public async Task<ApiResponse> UpdateBirthday(DateUpdateVm dateUpdateVm)
    {
      try
      {
        var user = _unitOfWork.userRepository.FindByCondition(x => x.Id == dateUpdateVm.UserId).FirstOrDefault();

        if (user == null)
          return new ApiResponse((int)HttpStatusCode.NotFound, "User with ID: " + dateUpdateVm.UserId + "not found");

        user.Birthday = dateUpdateVm.Date;

        _unitOfWork.userRepository.Update(user);
        await _unitOfWork.CompleteAsync();

        return new ApiResponse((int)HttpStatusCode.OK);
      }
      catch (Exception ex)
      {
        return new ApiResponse((int)HttpStatusCode.InternalServerError, "Something went wrong");
      }
    }

    public async Task<ApiResponse> UpdateIsCoach(StringUpdateVm stringUpdateVm)
    {
      try
      {
        var user = _unitOfWork.userRepository.FindByCondition(x => x.Id == stringUpdateVm.UserId).FirstOrDefault();
        if (user == null)
          return new ApiResponse((int)HttpStatusCode.NotFound, "User with ID: " + stringUpdateVm.UserId + "not found");

        user.IsCoach = Convert.ToBoolean(stringUpdateVm.Content);

        _unitOfWork.userRepository.Update(user);
        await _unitOfWork.CompleteAsync();

        return new ApiResponse((int)HttpStatusCode.OK);
      }
      catch (Exception ex)
      {
        return new ApiResponse((int)HttpStatusCode.InternalServerError, "Something went wrong");
      }
    }
  }
}