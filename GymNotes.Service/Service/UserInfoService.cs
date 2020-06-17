using AutoMapper;
using GymNotes.Entity.Models;
using GymNotes.Models;
using GymNotes.Repository.IRepository;
using GymNotes.Repository.IRepository.User;
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
  public class UserInfoService : IUserInfoService
  {
    //private readonly IUserRepository _userRepo;
    private readonly IMapper _mapper;

    private readonly IUnitOfWork _unitOfWork;

    public UserInfoService(
      IUserRepository userRepo,
      IMapper mapper,
      IUnitOfWork unitOfWork)
    {
      //_userRepo = userRepo;
      _mapper = mapper;
      _unitOfWork = unitOfWork;
    }

    public async Task<bool> UpdateInstagramURL(UpdateURLVm updateURLVm)
    {
      try
      {
        var user = _unitOfWork.userRepository.FindByCondition(x => x.Id == updateURLVm.UserId).FirstOrDefault();

        if (user == null)
          return false;

        user.Instagram = updateURLVm.URL;

        await _unitOfWork.CompleteAsync();

        return true;
      }
      catch (Exception ex)
      {
        return false;
      }
    }

    public async Task<bool> UpdateFacebookURL(UpdateURLVm updateURLVm)
    {
      try
      {
        var user = _unitOfWork.userRepository.FindByCondition(x => x.Id == updateURLVm.UserId).FirstOrDefault();

        if (user == null)
          return false;

        user.Facebook = updateURLVm.URL;

        await _unitOfWork.CompleteAsync();

        return true;
      }
      catch (Exception ex)
      {
        return false;
      }
    }

    public async Task<bool> UpdateTwitterURL(UpdateURLVm updateURLVm)
    {
      try
      {
        var user = _unitOfWork.userRepository.FindByCondition(x => x.Id == updateURLVm.UserId).FirstOrDefault();

        if (user == null)
          return false;

        user.Twitter = updateURLVm.URL;

        await _unitOfWork.CompleteAsync();

        return true;
      }
      catch (Exception ex)
      {
        return false;
      }
    }

    public async Task<bool> UpdateYoutubeURL(UpdateURLVm updateURLVm)
    {
      try
      {
        var user = _unitOfWork.userRepository.FindByCondition(x => x.Id == updateURLVm.UserId).FirstOrDefault();

        if (user == null)
          return false;

        user.Youtube = updateURLVm.URL;

        await _unitOfWork.CompleteAsync();

        return true;
      }
      catch (Exception ex)
      {
        return false;
      }
    }

    public async Task<bool> UpdateDescription(StringUpdateVm stringUpdateVm)
    {
      try
      {
        var user = _unitOfWork.userRepository.FindByCondition(x => x.Id == stringUpdateVm.UserId).FirstOrDefault();

        if (user == null)
          return false;

        user.Description = stringUpdateVm.Content;

        await _unitOfWork.CompleteAsync();

        return true;
      }
      catch (Exception ex)
      {
        return false;
      }
    }

    public async Task<bool> UpdateDiscipline(StringUpdateVm stringUpdateVm)
    {
      try
      {
        var user = _unitOfWork.userRepository.FindByCondition(x => x.Id == stringUpdateVm.UserId).FirstOrDefault();

        if (user == null)
          return false;

        user.Discipline = stringUpdateVm.Content;

        await _unitOfWork.CompleteAsync();

        return true;
      }
      catch (Exception ex)
      {
        return false;
      }
    }

    public async Task<bool> UpdateGender(StringUpdateVm stringUpdateVm)
    {
      try
      {
        var user = _unitOfWork.userRepository.FindByCondition(x => x.Id == stringUpdateVm.UserId).FirstOrDefault();

        if (user == null)
          return false;

        user.Gender = stringUpdateVm.Content;

        await _unitOfWork.CompleteAsync();

        return true;
      }
      catch (Exception ex)
      {
        return false;
      }
    }

    public async Task<bool> UpdateYearsOfExperience(NumberUpdateVm numberUpdateVm)
    {
      try
      {
        var user = _unitOfWork.userRepository.FindByCondition(x => x.Id == numberUpdateVm.UserId).FirstOrDefault();

        if (user == null)
          return false;

        user.YearsOfExperience = numberUpdateVm.Value;

        await _unitOfWork.CompleteAsync();

        return true;
      }
      catch (Exception ex)
      {
        return false;
      }
    }

    public async Task<bool> UpdateHeight(NumberUpdateVm numberUpdateVm)
    {
      try
      {
        var user = _unitOfWork.userRepository.FindByCondition(x => x.Id == numberUpdateVm.UserId).FirstOrDefault();

        if (user == null)
          return false;

        user.Height = numberUpdateVm.Value;

        await _unitOfWork.CompleteAsync();

        return true;
      }
      catch (Exception ex)
      {
        return false;
      }
    }

    public async Task<bool> UpdateBirthday(DateUpdateVm dateUpdateVm)
    {
      try
      {
        var user = _unitOfWork.userRepository.FindByCondition(x => x.Id == dateUpdateVm.UserId).FirstOrDefault();

        if (user == null)
          return false;

        user.Birthday = dateUpdateVm.Date;

        await _unitOfWork.CompleteAsync();

        return true;
      }
      catch (Exception ex)
      {
        return false;
      }
    }

    public async Task<bool> UpdateIsCoach(StringUpdateVm stringUpdateVm)
    {
      try
      {
        var user = _unitOfWork.userRepository.FindByCondition(x => x.Id == stringUpdateVm.UserId).FirstOrDefault();
        if (user == null)
          return false;

        user.IsCoach = Convert.ToBoolean(stringUpdateVm.Content);

        await _unitOfWork.CompleteAsync();

        return true;
      }
      catch (Exception ex)
      {
        return false;
      }
    }
  }
}