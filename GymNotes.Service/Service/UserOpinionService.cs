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
  public class UserOpinionService : IUserOpinionService
  {
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public UserOpinionService(
      IMapper mapper,
      IUnitOfWork unitOfWork)
    {
      _mapper = mapper;
      _unitOfWork = unitOfWork;
    }

    public async Task<bool> AddUserOpinion(AddUserOpinionVm addUserOpinionVm)
    {
      try
      {
        var user = _unitOfWork.userRepository.FindByCondition(x => x.Id == addUserOpinionVm.ProfileUserId).FirstOrDefault();

        var opinion = _unitOfWork.userOpinionRepository.FindByCondition(x => x.ProfileUserId == addUserOpinionVm.ProfileUserId).ToList();

        if (user == null)
          return false;

        addUserOpinionVm.DateAdded = DateTime.Now;

        var model = _mapper.Map<AddUserOpinionVm, UserOpinion>(addUserOpinionVm);

        _unitOfWork.userOpinionRepository.Create(model);

        _unitOfWork.CompleteAsync();

        return true;
      }
      catch (Exception ex)
      {
        return false;
      }
    }

    public async Task<bool> AddLikeToUserOpinion(UserOpinionLikesVm userOpinionLikesVm)
    {
      try
      {
        var opinion = _unitOfWork.userOpinionRepository.FindByCondition(x => x.Id == userOpinionLikesVm.UserOpinionId).FirstOrDefault();

        if (opinion == null)
          return false;

        var likeModel = _mapper.Map<UserOpinionLikesVm, UserOpinionLikes>(userOpinionLikesVm);

        _unitOfWork.userOpinionLikesRepository.Create(likeModel);

        _unitOfWork.CompleteAsync();

        return true;
      }
      catch (Exception ex)
      {
        return false;
      }
    }

    public async Task<bool> RemoveLikeFromUserOpinion(string userId, int opinionId)
    {
      try
      {
        //var opinionLike = await _userOpinionLikesRepository.GetUserOpinionLike(opinionId, userId);

        //if (opinionLike == null)
        //  return false;

        //_userOpinionLikesRepository.RemoveLike(opinionLike);

        //await _unitOfWork.CompleteAsync();

        return true;
      }
      catch (Exception ex)
      {
        return false;
      }
    }

    public async Task<List<UserOpinionVm>> GetUserOpinions(string userId)
    {
      try
      {
        var user = _unitOfWork.userRepository.FindByCondition(x => x.Id == userId).FirstOrDefault();

        if (user == null)
          return null;

        var opinionList = _unitOfWork.userOpinionRepository.FindByCondition(x => x.ProfileUserId == userId).ToList();

        if (opinionList == null)
          return null;

        var result = _mapper.Map<List<UserOpinion>, List<UserOpinionVm>>(opinionList);

        return result;
      }
      catch (Exception ex)
      {
        return null;
      }
    }
  }
}