using AutoMapper;
using GymNotes.Entity.Models.NewFolder;
using GymNotes.Repository.IRepository;
using GymNotes.Service.Exceptions;
using GymNotes.Service.IService;
using GymNotes.Service.Utils;
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

      trainingPlanVm.ModifiedAt = DateTime.Now;

      var res = _mapper.Map<TrainingPlan>(trainingPlanVm);
      _unitOfWork.trainingPlanRepository.Create(res);

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

    public async Task<PaginatedList<TrainingPlanVm>> Search(string id, PageQuery pageQuery)
    {
      var user = _unitOfWork.userRepository.FindByCondition(x => x.Id == id).FirstOrDefault();

      if (user == null)
        throw new MyNotFoundException(ApiResponseDescription.USER_NOT_FOUND);

      var trainingPlan = _unitOfWork.trainingPlanRepository.GetAllTrainingPlans(id);

      trainingPlan = _unitOfWork.trainingPlanRepository.FilterBy(trainingPlan, pageQuery.Filterby[0]);

      IQueryable<TrainingPlanVm> FilteredQuery = GetSearchQuery(trainingPlan, pageQuery.Search).Select(x => _mapper.Map<TrainingPlanVm>(x));

      var result = await PaginatedList<TrainingPlanVm>.CreateAsync(FilteredQuery, pageQuery.Page, pageQuery.Pagesize);

      result.Items = FilteredQuery.ToList();
      return result;
    }

    private IQueryable<TrainingPlan> GetSearchQuery(IQueryable<TrainingPlan> query, string searchString)
    {
      if (String.IsNullOrEmpty(searchString))
      {
        return query;
      }
      return query
          .Where(trainingPlan => trainingPlan.Name.ToUpper().Contains(searchString.ToUpper()));
    }

    public async Task<ApiResponse> ToggleFavorite(int id, bool flag)
    {
      var trainingPlan = _unitOfWork.trainingPlanRepository.FindByCondition(x => x.Id == id).FirstOrDefault();

      if (trainingPlan == null)
        throw new MyNotFoundException(ApiResponseDescription.TRAINING_PLAN_NOT_FOUND);

      trainingPlan.IsFavorite = flag;
      _unitOfWork.trainingPlanRepository.Update(trainingPlan);
      await _unitOfWork.CompleteAsync();

      return new ApiResponse(true);
    }

    public async Task<ApiResponse> ToggleMain(string userId, int id, bool flag)
    {
      var mainTrainingPlan = _unitOfWork.trainingPlanRepository
        .FindByCondition(x => x.OwnerId == userId && x.IsMain == true)
        .FirstOrDefault();

      if (mainTrainingPlan != null)
      {
        if (mainTrainingPlan.Id == id)
        {
          mainTrainingPlan.IsMain = flag;
          _unitOfWork.trainingPlanRepository.Update(mainTrainingPlan);
        }
        else
        {
          mainTrainingPlan.IsMain = !flag;

          var trainingPlan = _unitOfWork.trainingPlanRepository.FindByCondition(x => x.Id == id).FirstOrDefault();

          if (trainingPlan == null)
            throw new MyNotFoundException(ApiResponseDescription.TRAINING_PLAN_NOT_FOUND);

          trainingPlan.IsMain = flag;

          _unitOfWork.trainingPlanRepository.Update(mainTrainingPlan);
          _unitOfWork.trainingPlanRepository.Update(trainingPlan);
        }
      }
      else
      {
        var training = _unitOfWork.trainingPlanRepository.FindByCondition(x => x.Id == id).FirstOrDefault();

        if (training == null)
          throw new MyNotFoundException(ApiResponseDescription.TRAINING_PLAN_NOT_FOUND);

        training.IsMain = flag;

        _unitOfWork.trainingPlanRepository.Update(training);
      }

      await _unitOfWork.CompleteAsync();

      return new ApiResponse(true);
    }

    public async Task<ApiResponse> Delete(string userId, int id)
    {
      var trainingPlan = _unitOfWork.trainingPlanRepository.GetTrainingPlan(id).FirstOrDefault();

      if (trainingPlan == null)
        throw new MyNotFoundException(ApiResponseDescription.TRAINING_PLAN_NOT_FOUND);

      _unitOfWork.trainingPlanRepository.Delete(trainingPlan);
      await _unitOfWork.CompleteAsync();

      return new ApiResponse(true);
    }

    public List<TrainingExerciseVm> GetTrainingExercise(int id)
    {
      var exercise = _unitOfWork.trainingExerciseRepository.FindByCondition(x => x.Id == id).ToList();

      return _mapper.Map<List<TrainingExerciseVm>>(exercise);
    }
  }
}