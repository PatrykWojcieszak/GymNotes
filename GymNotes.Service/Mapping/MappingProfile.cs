using AutoMapper;
using GymNotes.Entity.Models;
using GymNotes.Entity.Models.NewFolder;
using GymNotes.Models;
using GymNotes.Service.ViewModels;
using GymNotes.Service.ViewModels.Training;

namespace GymNotes.Service.Mapping
{
  public class MappingProfile : Profile
  {
    public MappingProfile()
    {
      #region DOMAIN_API

      //Domain to API resource
      CreateMap<ApplicationUser, UserVm>();
      CreateMap<AchievementDyscypline, AchievementDyscyplineVm>();
      CreateMap<Achievement, AchievementVm>();
      CreateMap<UserOpinion, UserOpinionVm>();
      CreateMap<UserOpinionLikes, UserOpinionLikesVm>();
      CreateMap<CoachingRequest, CoachingRequestVm>();
      CreateMap<Pupil, CoachManagmentRequestVm>();
      CreateMap<ApplicationUser, UpdateUserNameVm>();
      CreateMap<Message, ChatMessageVm>();
      CreateMap<TrainingPlan, TrainingPlanVm>();
      CreateMap<TrainingWeek, TrainingWeekVm>();
      CreateMap<TrainingDay, TrainingDayVm>();
      CreateMap<TrainingExercise, TrainingExerciseVm>();

      #endregion DOMAIN_API

      #region API_DOMAIN

      //API to Domain
      CreateMap<UserVm, ApplicationUser>();
      CreateMap<AchievementVm, Achievement>();
      CreateMap<AchievementDyscyplineVm, AchievementDyscypline>();
      CreateMap<CoachingRequestVm, CoachingRequest>();
      CreateMap<AddUserOpinionVm, UserOpinion>();
      CreateMap<CoachManagmentRequestVm, Pupil>();
      CreateMap<UserOpinionLikesVm, UserOpinionLikes>();
      CreateMap<ChatMessageVm, Message>();
      CreateMap<ChatMessageVm, Contact>();
      CreateMap<TrainingPlanVm, TrainingPlan>();
      CreateMap<TrainingWeekVm, TrainingWeek>();
      CreateMap<TrainingDayVm, TrainingDay>();
      CreateMap<TrainingExerciseVm, TrainingExercise>();

      #endregion API_DOMAIN
    }
  }
}