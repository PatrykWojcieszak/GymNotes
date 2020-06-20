using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using GymNotes.Models;
using GymNotes.Repository.IRepository;
using GymNotes.Service.IService;
using GymNotes.Service.ViewModels;
using GymNotes.Entity.Models;
using System.Threading.Tasks;
using GymNotes.Repository.IRepository.User;
using GymNotes.Service.Exceptions;

namespace GymNotes.Service.Service
{
  public class CoachService : ICoachService
  {
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public CoachService(
      IMapper mapper,
      IUnitOfWork unitOfWork)
    {
      _mapper = mapper;
      _unitOfWork = unitOfWork;
    }

    //TODO: Sprawdzić
    public async Task<ApiResponse> CoachManagmentRequest(CoachManagmentRequestVm coachManagmentRequestVm)
    {
      var user = _unitOfWork.userRepository.FindByCondition(x => x.Id == coachManagmentRequestVm.ProfilePupilId).FirstOrDefault();
      var userCoach = _unitOfWork.userRepository.FindByCondition(x => x.Id == coachManagmentRequestVm.ProfileCoachId).FirstOrDefault();
      var status = coachManagmentRequestVm.Partnership;

      if (user == null && userCoach == null && user.Id != userCoach.Id)
        throw new MyNotFoundException(ApiResponseDescription.USER_NOT_FOUND);

      if (status == true)
      {
        var model = _mapper.Map<CoachManagmentRequestVm, Pupil>(coachManagmentRequestVm);

        model.ProfilePupilId = coachManagmentRequestVm.ProfilePupilId;

        _unitOfWork.pupilRepository.Create(model);

        var coachRequest = _unitOfWork.coachingRequestRepository.FindByCondition(x => x.CoachId == userCoach.Id && x.ApplicationUserId == user.Id).FirstOrDefault();

        coachRequest.Status = CoachingRequestStatus.Accepted; //(CoachingRequestStatus)1;

        _unitOfWork.coachingRequestRepository.Update(coachRequest);

        await _unitOfWork.CompleteAsync();

        return new ApiResponse(true);
      }
      else
      {
        var coachRequest = _unitOfWork.coachingRequestRepository.FindByCondition(x => x.CoachId == userCoach.Id && x.ApplicationUserId == user.Id).FirstOrDefault();

        coachRequest.Status = (CoachingRequestStatus)2;

        _unitOfWork.coachingRequestRepository.Update(coachRequest);

        await _unitOfWork.CompleteAsync();

        return new ApiResponse(true);
      }
    }

    //TODO: Sprawdzić
    public async Task<ApiResponse> CoachCancelManagment(CoachCancelManagmentVm coachCancelManagmentVm)
    {
      var user = _unitOfWork.userRepository.FindByCondition(x => x.Id == coachCancelManagmentVm.ProfilePupilId).FirstOrDefault();
      var userCoach = _unitOfWork.userRepository.FindByCondition(x => x.Id == coachCancelManagmentVm.ProfileCoachId).FirstOrDefault();
      var status = coachCancelManagmentVm.Partnership;

      if (user == null && userCoach == null && user.Id != userCoach.Id && status == true)
        throw new MyNotFoundException(ApiResponseDescription.USER_NOT_FOUND);

      var pupil = _unitOfWork.pupilRepository.FindByCondition(x => x.ProfileCoachId == userCoach.Id && x.ProfilePupilId == user.Id).FirstOrDefault();

      pupil.Partnership = status;

      _unitOfWork.pupilRepository.Update(pupil);

      var coachRequest = _unitOfWork.coachingRequestRepository.FindByCondition(x => x.CoachId == userCoach.Id && x.ApplicationUserId == user.Id).FirstOrDefault();

      coachRequest.Status = (CoachingRequestStatus)2;

      _unitOfWork.coachingRequestRepository.Update(coachRequest);

      await _unitOfWork.CompleteAsync();

      return new ApiResponse(true);
    }

    //TODO: Sprawdzić
    public List<CoachManagmentRequestVm> CoachPupilList(string coachId)
    {
      if (coachId == null)
        throw new MyNotFoundException(ApiResponseDescription.USER_NOT_FOUND);

      var list = _unitOfWork.pupilRepository.FindByCondition(x => x.ProfileCoachId == coachId && x.Partnership == true).ToList();
      var result = _mapper.Map<List<Pupil>, List<CoachManagmentRequestVm>>(list);

      return result;
    }

    //TODO: Sprawdzić
    public List<CoachingRequestVm> CoachRequestList(string coachId)
    {
      if (coachId == null)
        throw new MyNotFoundException(ApiResponseDescription.USER_NOT_FOUND);

      var list = _unitOfWork.coachingRequestRepository.FindByCondition(x => x.CoachId == coachId && x.Status == CoachingRequestStatus.Sent).ToList();
      var result = _mapper.Map<List<CoachingRequest>, List<CoachingRequestVm>>(list);

      return result;
    }
  }
}