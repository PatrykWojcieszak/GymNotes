using AutoMapper;
using GymNotes.Entity.Models.NewFolder;
using GymNotes.Repository.IRepository;
using GymNotes.Service.Exceptions;
using GymNotes.Service.IService;
using GymNotes.Service.ViewModels;
using GymNotes.Service.ViewModels.Training;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymNotes.Service.Service
{
  public class TrainingPlanService : ITrainingPlanService
  {
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public TrainingPlanService(IMapper mapper, IUnitOfWork unitOfWork)
    {
      _mapper = mapper;
      _unitOfWork = unitOfWork;
    }

    public async Task<ApiResponse> EditTrainingPlan(TrainingPlanVm trainingPlanVm)
    {
      

      return new ApiResponse(true);
    }
    
    public async Task<ApiResponse> CreateTrainingPlan(TrainingPlanVm trainingPlanVm)
    {
      var owner = _unitOfWork.userRepository.FindByCondition(x => x.Id == trainingPlanVm.OwnerId).FirstOrDefault();

      if (owner == null)
        throw new MyNotFoundException(ApiResponseDescription.USER_NOT_FOUND);

      var creator = _unitOfWork.userRepository.FindByCondition(x => x.Id == trainingPlanVm.CreatorId).FirstOrDefault();

      if (creator == null)
        throw new MyNotFoundException(ApiResponseDescription.USER_NOT_FOUND);

      trainingPlanVm.ModifiedTime = DateTime.Now;

      var trainingMapped = _mapper.Map<TrainingPlan>(trainingPlanVm);

      trainingMapped.Creator = creator;
      trainingMapped.Owner = owner;

      _unitOfWork.trainingPlanRepository.Create(trainingMapped);

      await _unitOfWork.CompleteAsync();

      return new ApiResponse(true);
    }

    public TrainingPlanVm GetTrainingPlan(int id)
    {
      var trainingPlan = _unitOfWork.trainingPlanRepository.GetTrainingPlan(id)
        .Select(x => _mapper.Map<TrainingPlanVm>(x))
        .FirstOrDefault();

      if (trainingPlan == null)
        throw new MyNotFoundException(ApiResponseDescription.TRAINING_PLAN_NOT_FOUND);

      return trainingPlan;
    }
  }
}
