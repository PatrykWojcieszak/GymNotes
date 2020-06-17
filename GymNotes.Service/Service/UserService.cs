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
using GymNotes.Service.Utils;
using GymNotes.Repository.IRepository.User;
using Microsoft.EntityFrameworkCore;

namespace GymNotes.Service.Service
{
  public class UserService : IApplicationUserService
  {
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public UserService(
      IMapper mapper,
      IUnitOfWork unitOfWork)
    {
      _mapper = mapper;
      _unitOfWork = unitOfWork;
    }

    public async Task<bool> UpdateUserInfo(string id, ApplicationUserVm userVm)
    {
      try
      {
        var userModel = _unitOfWork.userRepository.FindByCondition(x => x.Id == id).FirstOrDefault();

        if (userModel == null)
          return false;

        _mapper.Map(userVm, userModel);

        _unitOfWork.userRepository.Update(userModel);

        _unitOfWork.CompleteAsync();

        return true;
      }
      catch (Exception ex)
      {
        return false;
      }
    }

    public UserUpdateInfoVm GetUserUpdateInfo(string id)
    {
      try
      {
        var user = _unitOfWork.userRepository.FindByCondition(x => x.Id == id).FirstOrDefault();

        if (user == null)
          return null;

        var result = _mapper.Map<ApplicationUser, UserUpdateInfoVm>(user);

        return result;
      }
      catch (Exception ex)
      {
        return null;
      }
    }

    public ApplicationUserVm GetUser(string id)
    {
      try
      {
        var user = _unitOfWork.userRepository.FindByCondition(x => x.Id == id).FirstOrDefault();

        if (user == null)
          return null;

        var result = _mapper.Map<ApplicationUser, ApplicationUserVm>(user);

        return result;
      }
      catch (Exception ex)
      {
        return null;
      }
    }

    public async Task<bool> AddOrUpdateUserAchievement(string id, AchievementDyscyplineVm achievementDyscyplineVm)
    {
      try
      {
        var user = _unitOfWork.userRepository.FindByCondition(x => x.Id == id).FirstOrDefault();

        if (user == null)
          return false;

        if (achievementDyscyplineVm.Id == 0)
        {
          var model = _mapper.Map<AchievementDyscyplineVm, AchievementDyscypline>(achievementDyscyplineVm);

          model.ApplicationUserId = id;

          _unitOfWork.achievementDyscyplineRepository.Create(model);
        }
        else
        {
          var model = _unitOfWork.achievementDyscyplineRepository.FindByCondition(x => x.Id == achievementDyscyplineVm.Id).FirstOrDefault();

          _mapper.Map<AchievementDyscyplineVm, AchievementDyscypline>(achievementDyscyplineVm, model);

          _unitOfWork.achievementDyscyplineRepository.Update(model);
        }

        _unitOfWork.CompleteAsync();

        return true;
      }
      catch (Exception ex)
      {
        return false;
      }
    }

    public AchievementDyscyplineVm GetUserAchievements(string userId, int id)
    {
      try
      {
        var user = _unitOfWork.userRepository.FindByCondition(x => x.Id == userId).FirstOrDefault();

        if (user == null)
          return null;

        var model = _unitOfWork.achievementDyscyplineRepository.FindByCondition(x => x.Id == id).Include(x => x.Achievements).FirstOrDefault();

        var result = _mapper.Map<AchievementDyscypline, AchievementDyscyplineVm>(model);

        return result;
      }
      catch (Exception ex)
      {
        return null;
      }
    }

    public List<AchievementDyscyplineVm> GetUserAchievementsList(string userId)
    {
      try
      {
        var user = _unitOfWork.userRepository.FindByCondition(x => x.Id == userId).FirstOrDefault();

        if (user == null)
          return null;

        var model = _unitOfWork.achievementDyscyplineRepository.FindByCondition(x => x.ApplicationUserId == userId).Include(x => x.Achievements).ToList();

        var result = _mapper.Map<List<AchievementDyscypline>, List<AchievementDyscyplineVm>>(model);

        return result;
      }
      catch (Exception ex)
      {
        return null;
      }
    }

    public async Task<bool> DeleteUserAchievementDyscypline(string userId, int id)
    {
      var user = _unitOfWork.userRepository.FindByCondition(x => x.Id == userId).FirstOrDefault();

      if (user == null)
        return false;

      var model = _unitOfWork.achievementDyscyplineRepository.FindByCondition(x => x.Id == id).Include(x => x.Achievements).FirstOrDefault();

      if (model == null)
        return false;

      _unitOfWork.achievementDyscyplineRepository.Delete(model);

      _unitOfWork.CompleteAsync();

      return true;
    }

    public async Task<bool> DeleteUserAchievement(string userId, int id)
    {
      var user = _unitOfWork.userRepository.FindByCondition(x => x.Id == userId).FirstOrDefault();

      if (user == null)
        return false;

      var model = _unitOfWork.achievementsRepository.FindByCondition(x => x.Id == id).FirstOrDefault();

      if (model == null)
        return false;

      _unitOfWork.achievementsRepository.Delete(model);

      _unitOfWork.CompleteAsync();

      return true;
    }

    public IQueryable<ApplicationUser> OrderBy(IQueryable<ApplicationUser> query, string orderBy)
    {
      switch (orderBy)
      {
        case "firstname":
          return query.OrderBy(i => i.FirstName);

        case "-firstname":
          return query.OrderByDescending(i => i.FirstName);

        case "lastname":
          return query.OrderBy(i => i.LastName);

        case "-lastname":
          return query.OrderByDescending(i => i.LastName);

        case "email":
          return query.OrderBy(i => i.Email);

        case "-email":
          return query.OrderByDescending(i => i.Email);

        default:
          return query.OrderBy(i => i.LastName);
      }
    }

    public ApplicationUserVm GetUserByEmail(string email)
    {
      var user = _unitOfWork.userRepository.FindByCondition(x => x.Email == email).FirstOrDefault();
      return _mapper.Map<ApplicationUserVm>(user);
    }

    private IQueryable<ApplicationUser> GetSearchQuery(IQueryable<ApplicationUser> query, string searchString)
    {
      if (String.IsNullOrEmpty(searchString))
      {
        return query;
      }
      return query
          .Where(
                  user => user.LastName.ToUpper().Contains(searchString.ToUpper())
                  || user.FirstName.ToUpper().Contains(searchString.ToUpper())
                  || user.Email.ToUpper().Contains(searchString.ToUpper())
              );
    }

    public async Task<PaginatedList<ApplicationUserVm>> GetUsers(PageQuery pageQuery, string searchString = null)
    {
      var query = _unitOfWork.userRepository.FindAll();
      query = GetSearchQuery(query, searchString); // filtered when will be on DB

      IQueryable<ApplicationUserVm> orderedQuery = _unitOfWork.userRepository.OrderBy(query, pageQuery.Orderby).Select(x => _mapper.Map<ApplicationUserVm>(x));
      return await PaginatedList<ApplicationUserVm>.CreateAsync(orderedQuery, pageQuery.Page, pageQuery.Pagesize);
    }

    //TODO: Sprawdziæ
    public async Task<bool> SendCoachingRequest(CoachingRequestVm coachRequestVm)
    {
      try
      {
        var user = _unitOfWork.userRepository.FindByCondition(x => x.Id == coachRequestVm.ApplicationUserId).FirstOrDefault();
        var userCoach = _unitOfWork.userRepository.FindByCondition(x => x.Id == coachRequestVm.CoachId).FirstOrDefault();

        if (user == null && userCoach == null && user.Id != userCoach.Id)
          return false;

        var model = _mapper.Map<CoachingRequestVm, CoachingRequest>(coachRequestVm);

        model.ApplicationUserId = coachRequestVm.ApplicationUserId;
        model.Status = CoachingRequestStatus.Sent;

        _unitOfWork.coachingRequestRepository.Create(model);

        _unitOfWork.CompleteAsync();

        return true;
      }
      catch (Exception ex)
      {
        return false;
      }
    }
  }
}