using AutoMapper;
using GymNotes.Entity.Models;
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

    public async Task<ApiResponse> AddUserOpinion(AddUserOpinionVm addUserOpinionVm)
    {
      var user = _unitOfWork.userRepository.FindByCondition(x => x.Id == addUserOpinionVm.ProfileUserId).FirstOrDefault();

      var opinion = _unitOfWork.userOpinionRepository.FindByCondition(x => x.ProfileUserId == addUserOpinionVm.ProfileUserId).ToList();

      if (user == null)
        throw new MyNotFoundException(ApiResponseDescription.USER_NOT_FOUND);

      addUserOpinionVm.DateAdded = DateTime.Now;

      var model = _mapper.Map<AddUserOpinionVm, UserOpinion>(addUserOpinionVm);

      _unitOfWork.userOpinionRepository.Create(model);

      await _unitOfWork.CompleteAsync();

      return new ApiResponse(true);
    }

    public async Task<ApiResponse> AddLikeToUserOpinion(UserOpinionLikesVm userOpinionLikesVm)
    {
      var opinion = _unitOfWork.userOpinionRepository.FindByCondition(x => x.Id == userOpinionLikesVm.UserOpinionId).FirstOrDefault();

      if (opinion == null)
        throw new MyNotFoundException(ApiResponseDescription.USER_NOT_FOUND);

      var likeModel = _mapper.Map<UserOpinionLikesVm, UserOpinionLikes>(userOpinionLikesVm);

      _unitOfWork.userOpinionLikesRepository.Create(likeModel);

      await _unitOfWork.CompleteAsync();

      return new ApiResponse(true);
    }

    public async Task<ApiResponse> RemoveLikeFromUserOpinion(string userId, int opinionId)
    {
      return new ApiResponse(true);
    }

    public List<UserOpinionVm> GetUserOpinions(string userId)
    {
      var user = _unitOfWork.userRepository.FindByCondition(x => x.Id == userId).FirstOrDefault();

      if (user == null)
        throw new MyNotFoundException(ApiResponseDescription.USER_NOT_FOUND);

      var opinionList = _unitOfWork.userOpinionRepository.FindByCondition(x => x.ProfileUserId == userId).ToList();

      if (opinionList == null)
        throw new MyNotFoundException(ApiResponseDescription.OPINION_NOT_FOUND);

      var result = _mapper.Map<List<UserOpinion>, List<UserOpinionVm>>(opinionList);

      return result;
    }
  }
}