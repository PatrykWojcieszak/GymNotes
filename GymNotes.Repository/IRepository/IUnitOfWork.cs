using GymNotes.Repository.IRepository.Chat;
using GymNotes.Repository.IRepository.User;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GymNotes.Repository.IRepository
{
  public interface IUnitOfWork
  {
    IUserRepository userRepository { get; }

    IStatisticsRepository statisticsRepository { get; }
    IStatisticsDisciplineRepository statisticsDisciplineRepository { get; }
    IStatisticsExerciseRepository statisticsExerciseRepository { get; }

    IUserOpinionRepository userOpinionRepository { get; }
    IUserOpinionLikesRepository userOpinionLikesRepository { get; }

    ICoachingRequestRepository coachingRequestRepository { get; }
    IPupilRepository pupilRepository { get; }

    IContactRepository contactRepository { get; }
    IMessageRepository messageRepository { get; }

    IAchievementRepository achievementsRepository { get; }
    IAchievementDyscyplineRepository achievementDyscyplineRepository { get; }

    Task CompleteAsync();

    Task Dispose();
  }
}