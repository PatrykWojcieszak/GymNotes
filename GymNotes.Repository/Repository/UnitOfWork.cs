using GymNotes.Data;
using GymNotes.Repository.IRepository;
using GymNotes.Repository.IRepository.Chat;
using GymNotes.Repository.IRepository.User;
using GymNotes.Repository.Repository.Chat;
using GymNotes.Repository.Repository.User;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GymNotes.Repository.Repository
{
  public class UnitOfWork : IUnitOfWork
  {
    private readonly ApplicationDbContext _context;

    public UnitOfWork(ApplicationDbContext context)
    {
      _context = context;
      userRepository = new UserRepository(_context);
      statisticsRepository = new StatisticsRepository(_context);
      statisticsDisciplineRepository = new StatisticsDisciplineRepository(_context);
      statisticsExerciseRepository = new StatisticsExerciseRepository(_context);
      userOpinionRepository = new UserOpinionRepository(_context);
      userOpinionLikesRepository = new UserOpinionLikesRepository(_context);
      coachingRequestRepository = new CoachingRequestRepository(_context);
      pupilRepository = new PupilRepository(_context);
      contactRepository = new ContactRepository(_context);
      messageRepository = new MessageRepository(_context);
      achievementsRepository = new AchievementRepository(_context);
      achievementDyscyplineRepository = new AchievementDyscyplineRepository(_context);
    }

    public IUserRepository userRepository { get; }

    public IStatisticsRepository statisticsRepository { get; }
    public IStatisticsDisciplineRepository statisticsDisciplineRepository { get; }
    public IStatisticsExerciseRepository statisticsExerciseRepository { get; }

    public IUserOpinionRepository userOpinionRepository { get; }
    public IUserOpinionLikesRepository userOpinionLikesRepository { get; }

    public ICoachingRequestRepository coachingRequestRepository { get; }
    public IPupilRepository pupilRepository { get; }

    public IContactRepository contactRepository { get; }
    public IMessageRepository messageRepository { get; }

    public IAchievementRepository achievementsRepository { get; }
    public IAchievementDyscyplineRepository achievementDyscyplineRepository { get; }

    public async Task CompleteAsync()
    {
      await _context.SaveChangesAsync();
    }

    public async Task Dispose()
    {
      await _context.DisposeAsync();
    }
  }
}