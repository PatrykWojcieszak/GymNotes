using AutoMapper;
using GymNotes.Entity.Models;
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
  public class UserOpinionService : IUserOpinionService
  {
    private readonly IApplicationUserRepository _userRepo;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserOpinionRepository _userOpinionRepository;
    private readonly IUserOpinionLikesRepository _userOpinionLikesRepository;

    public UserOpinionService(
      IApplicationUserRepository userRepo,
      IMapper mapper,
      IUnitOfWork unitOfWork,
      IUserOpinionRepository userOpinionRepository,
      IUserOpinionLikesRepository userOpinionLikesRepository)
    {
      _userRepo = userRepo;
      _mapper = mapper;
      _unitOfWork = unitOfWork;
      _userOpinionRepository = userOpinionRepository;
      _userOpinionLikesRepository = userOpinionLikesRepository;
    }

    public async Task<bool> AddUserOpinion(AddUserOpinionVm addUserOpinionVm)
    {
      try
      {
        var user = _userRepo.GetUserById(addUserOpinionVm.ProfileUserId);

        var opinion = await _userOpinionRepository.GetUserOpinions(addUserOpinionVm.ProfileUserId);

        if (user == null)
          return false;

        addUserOpinionVm.DateAdded = DateTime.Now;

        var model = _mapper.Map<AddUserOpinionVm, UserOpinion>(addUserOpinionVm);

        var result = await _userOpinionRepository.AddUserOpinion(model);

        if (result <= 0)
          return false;

        await _unitOfWork.CompleteAsync();

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
        var opinion = await _userOpinionRepository.GetUserOpinion(userOpinionLikesVm.UserOpinionId);

        if (opinion == null)
          return false;

        var likeModel = _mapper.Map<UserOpinionLikesVm, UserOpinionLikes>(userOpinionLikesVm);

        _userOpinionLikesRepository.AddLike(likeModel);

        await _unitOfWork.CompleteAsync();

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
        var opinionLike = await _userOpinionLikesRepository.GetUserOpinionLike(opinionId, userId);

        if (opinionLike == null)
          return false;

        _userOpinionLikesRepository.RemoveLike(opinionLike);

        await _unitOfWork.CompleteAsync();

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
        var user = _userRepo.GetUserById(userId);

        if (user == null)
          return null;

        var opinionList = await _userOpinionRepository.GetUserOpinions(userId);

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