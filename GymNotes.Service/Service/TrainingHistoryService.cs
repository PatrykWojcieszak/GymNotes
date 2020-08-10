using AutoMapper;
using GymNotes.Repository.IRepository;
using GymNotes.Service.Exceptions;
using GymNotes.Service.IService;
using GymNotes.Service.ViewModels.TrainingHistory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GymNotes.Service.Service
{
  public class TrainingHistoryService : ITrainingHistoryService
  {
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public TrainingHistoryService(
      IMapper mapper,
      IUnitOfWork unitOfWork)
    {
      _mapper = mapper;
      _unitOfWork = unitOfWork;
    }

    public TrainingElementsVm GetTrainingPlans(string id)
    {
      var user = _unitOfWork.userRepository.FindByCondition(x => x.Id == id).FirstOrDefault();

      if (user == null)
        throw new MyNotFoundException(ApiResponseDescription.USER_NOT_FOUND);

      var plans = _unitOfWork.trainingPlanRepository.FindByCondition(x => x.OwnerId == id).ToList();

      var result = new TrainingElementsVm();
      foreach(var item in plans)
      {
        result.ElementName.Add(item.Name);
        result.ElementId.Add(item.Id);
      }

      return result;
    }

    public TrainingElementsVm GetTrainingWeeks(int id)
    {
      var plan = _unitOfWork.trainingPlanRepository.GetWeeksFromTrainingPlan(id).FirstOrDefault();

      if (plan == null)
        throw new MyNotFoundException(ApiResponseDescription.TRAINING_PLAN_NOT_FOUND);

      var result = new TrainingElementsVm();
      foreach (var item in plan.TrainingWeeks)
      {
        result.ElementName.Add(item.Name);
        result.ElementId.Add(item.Id);
      }

      return result;
    } 
    
    public TrainingElementsVm GetTrainingDays(int id)
    {
      var week = _unitOfWork.trainingWeekRepository.GetTrainingWeek(id).FirstOrDefault();

      if (week == null)
        throw new MyNotFoundException(ApiResponseDescription.TRAINING_WEEK_NOT_FOUND);

      var result = new TrainingElementsVm();
      foreach (var item in week.TrainingDays)
      {
        result.ElementName.Add(item.Name);
        result.ElementId.Add(item.Id);
      }

      return result;
    }
  }
}
