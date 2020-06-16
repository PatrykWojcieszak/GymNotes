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

namespace GymNotes.Service.Service
{
  public class CoachService : ICoachService
  {
    private readonly IUserRepository _userRepo;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICoachingRequestRepository _coachingRequestRepo;
    private readonly IPupilRepository _pupilRepo;

    public CoachService(
      IUserRepository userRepo,
      IMapper mapper,
      IUnitOfWork unitOfWork,
      ICoachingRequestRepository coachingRequestRepo,
      IPupilRepository pupilRepo)
    {
      _userRepo = userRepo;
      _mapper = mapper;
      _unitOfWork = unitOfWork;
      _coachingRequestRepo = coachingRequestRepo;
      _pupilRepo = pupilRepo;
    }

    //TODO: Sprawdzić
    public async Task<bool> CoachManagmentRequest(CoachManagmentRequestVm coachManagmentRequestVm)
    {
      try
      {
        var user = _userRepo.FindByCondition(x => x.Id == coachManagmentRequestVm.ProfilePupilId).FirstOrDefault();
        var userCoach = _userRepo.FindByCondition(x => x.Id == coachManagmentRequestVm.ProfileCoachId).FirstOrDefault();
        var status = coachManagmentRequestVm.Partnership;

        if (user == null && userCoach == null && user.Id != userCoach.Id)

          return false;

        if (status == true)
        {
          var model = _mapper.Map<CoachManagmentRequestVm, Pupil>(coachManagmentRequestVm);

          model.ProfilePupilId = coachManagmentRequestVm.ProfilePupilId;

          _pupilRepo.AddPupil(model);

          var coachRequest = _coachingRequestRepo.GetCoachingRequest(userCoach.Id, user.Id);

          coachRequest.Status = (CoachingRequestStatus)1;

          _coachingRequestRepo.UpdateCoachRequest(coachRequest);

          await _unitOfWork.CompleteAsync();

          return true;
        }
        if (status == false)
        {
          var coachRequest = _coachingRequestRepo.GetCoachingRequest(userCoach.Id, user.Id);

          coachRequest.Status = (CoachingRequestStatus)2;

          _coachingRequestRepo.UpdateCoachRequest(coachRequest);

          await _unitOfWork.CompleteAsync();

          return true;
        }
        else
        {
          return false;
        }
      }
      catch (Exception ex)
      {
        return false;
      }
    }

    //TODO: Sprawdzić
    public async Task<bool> CoachCancelManagment(CoachCancelManagmentVm coachCancelManagmentVm)
    {
      try
      {
        var user = _userRepo.FindByCondition(x => x.Id == coachCancelManagmentVm.ProfilePupilId).FirstOrDefault();
        var userCoach = _userRepo.FindByCondition(x => x.Id == coachCancelManagmentVm.ProfileCoachId).FirstOrDefault();
        var status = coachCancelManagmentVm.Partnership;

        if (user == null && userCoach == null && user.Id != userCoach.Id && status == true)
          return false;

        var pupil = _pupilRepo.GetPupil(userCoach.Id, user.Id);

        pupil.Partnership = status;

        _pupilRepo.UpdatePupil(pupil);

        var coachRequest = _coachingRequestRepo.GetCoachingRequest(userCoach.Id, user.Id);

        coachRequest.Status = (CoachingRequestStatus)2;

        _coachingRequestRepo.UpdateCoachRequest(coachRequest);

        await _unitOfWork.CompleteAsync();

        return true;
      }
      catch (Exception ex)
      {
        return false;
      }
    }

    //TODO: Sprawdzić
    public List<CoachManagmentRequestVm> CoachPupilList(string coachId)
    {
      try
      {
        if (coachId == null)
          return null;
        var list = _pupilRepo.GetCoachPupilList(coachId);
        var result = _mapper.Map<List<Pupil>, List<CoachManagmentRequestVm>>(list);
        return result;
      }
      catch (Exception ex)
      {
        return null;
      }
    }

    //TODO: Sprawdzić
    public List<CoachingRequestVm> CoachRequestList(string coachId)
    {
      try
      {
        if (coachId == null)
          return null;
        var list = _coachingRequestRepo.CoachRequestList(coachId);
        var result = _mapper.Map<List<CoachingRequest>, List<CoachingRequestVm>>(list);
        return result;
      }
      catch (Exception ex)
      {
        return null;
      }
    }
  }
}