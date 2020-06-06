using AutoMapper;
using GymNotes.Entity.Models;
using GymNotes.Models;
using GymNotes.Service.ViewModels;

namespace GymNotes.Service.Mapping
{
  public class MappingProfile : Profile
  {
    public MappingProfile()
    {
      #region DOMAIN_API

      //Domain to API resource
      CreateMap<ApplicationUser, ApplicationUserVm>();
      CreateMap<ApplicationUser, UserUpdateInfoVm>();
      CreateMap<AchievementDyscypline, AchievementDyscyplineVm>();
      CreateMap<Achievement, AchievementVm>();
      CreateMap<UserOpinion, UserOpinionVm>();
      CreateMap<UserOpinionLikes, UserOpinionLikesVm>();
      CreateMap<CoachingRequest, CoachingRequestVm>();
      CreateMap<Pupil, CoachManagmentRequestVm>();
      CreateMap<ApplicationUser, UpdateUserNameVm>();
      CreateMap<Message, ChatMessageVm>();

      #endregion DOMAIN_API

      #region API_DOMAIN

      //API to Domain
      CreateMap<ApplicationUserVm, ApplicationUser>();
      CreateMap<AchievementVm, Achievement>();
      CreateMap<AchievementDyscyplineVm, AchievementDyscypline>();
      CreateMap<CoachingRequestVm, CoachingRequest>();
      CreateMap<AddUserOpinionVm, UserOpinion>();
      CreateMap<CoachManagmentRequestVm, Pupil>();
      CreateMap<UserOpinionLikesVm, UserOpinionLikes>();
      CreateMap<ChatMessageVm, Message>();
      CreateMap<ChatMessageVm, Contact>();

      #endregion API_DOMAIN
    }
  }
}