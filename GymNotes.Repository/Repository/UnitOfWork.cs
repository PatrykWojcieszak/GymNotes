using GymNotes.Data;
using GymNotes.Repository.IRepository;
using GymNotes.Repository.IRepository.Chat;
using GymNotes.Repository.IRepository.Training;
using GymNotes.Repository.IRepository.User;
using GymNotes.Repository.Repository.Chat;
using GymNotes.Repository.Repository.Training;
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

    private IUserRepository _userRepository;
    private IStatisticsRepository _statisticsRepository;
    private IStatisticsDisciplineRepository _statisticsDisciplineRepository;
    private IStatisticsExerciseRepository _statisticsExerciseRepository;
    private IUserOpinionRepository _userOpinionRepository;
    private IUserOpinionLikesRepository _userOpinionLikesRepository;
    private ICoachingRequestRepository _coachingRequestRepository;
    private IPupilRepository _pupilRepository;
    private IContactRepository _contactRepository;
    private IMessageRepository _messageRepository;
    private IAchievementRepository _achievementsRepository;
    private IAchievementDyscyplineRepository _achievementDyscyplineRepository;
    private ITrainingWeekRepository _trainingWeekRepository;
    private ITrainingPlanRepository _trainingPlanRepository;
    private ITrainingDayRepository _trainingDayRepository;
    private ITrainingExerciseRepository _trainingExerciseRepository;
    private IPlannedTrainingRepository _plannedTrainingRepository;
    private ITrainingHistoryRepository _trainingHistoryRepository;

    public UnitOfWork(ApplicationDbContext context)
    {
      _context = context;
    }

    public IUserRepository userRepository
    {
      get
      {
        if (_userRepository == null)
          _userRepository = new UserRepository(_context);

        return _userRepository;
      }
    }

    public IStatisticsRepository statisticsRepository
    {
      get
      {
        if (_statisticsRepository == null)
          _statisticsRepository = new StatisticsRepository(_context);

        return _statisticsRepository;
      }
    }

    public IStatisticsDisciplineRepository statisticsDisciplineRepository
    {
      get
      {
        if (_statisticsDisciplineRepository == null)
          _statisticsDisciplineRepository = new StatisticsDisciplineRepository(_context);

        return _statisticsDisciplineRepository;
      }
    }

    public IStatisticsExerciseRepository statisticsExerciseRepository
    {
      get
      {
        if (_statisticsExerciseRepository == null)
          _statisticsExerciseRepository = new StatisticsExerciseRepository(_context);

        return _statisticsExerciseRepository;
      }
    }

    public IUserOpinionRepository userOpinionRepository
    {
      get
      {
        if (_userOpinionRepository == null)
          _userOpinionRepository = new UserOpinionRepository(_context);

        return _userOpinionRepository;
      }
    }

    public IUserOpinionLikesRepository userOpinionLikesRepository
    {
      get
      {
        if (_userOpinionLikesRepository == null)
          _userOpinionLikesRepository = new UserOpinionLikesRepository(_context);

        return _userOpinionLikesRepository;
      }
    }

    public ICoachingRequestRepository coachingRequestRepository
    {
      get
      {
        if (_coachingRequestRepository == null)
          _coachingRequestRepository = new CoachingRequestRepository(_context);

        return _coachingRequestRepository;
      }
    }

    public IPupilRepository pupilRepository
    {
      get
      {
        if (_pupilRepository == null)
          _pupilRepository = new PupilRepository(_context);

        return _pupilRepository;
      }
    }

    public IContactRepository contactRepository
    {
      get
      {
        if (_contactRepository == null)
          _contactRepository = new ContactRepository(_context);

        return _contactRepository;
      }
    }

    public IMessageRepository messageRepository
    {
      get
      {
        if (_messageRepository == null)
          _messageRepository = new MessageRepository(_context);

        return _messageRepository;
      }
    }

    public IAchievementRepository achievementsRepository
    {
      get
      {
        if (_achievementsRepository == null)
          _achievementsRepository = new AchievementRepository(_context);

        return _achievementsRepository;
      }
    }

    public IAchievementDyscyplineRepository achievementDyscyplineRepository
    {
      get
      {
        if (_achievementDyscyplineRepository == null)
          _achievementDyscyplineRepository = new AchievementDyscyplineRepository(_context);

        return _achievementDyscyplineRepository;
      }
    }

    public ITrainingPlanRepository trainingPlanRepository
    {
      get
      {
        if (_trainingPlanRepository == null)
          _trainingPlanRepository = new TrainingPlanRepository(_context);

        return _trainingPlanRepository;
      }
    }

    public ITrainingWeekRepository trainingWeekRepository
    {
      get
      {
        if (_trainingWeekRepository == null)
          _trainingWeekRepository = new TrainingWeekRepository(_context);

        return _trainingWeekRepository;
      }
    }

    public ITrainingDayRepository trainingDayRepository
    {
      get
      {
        if (_trainingDayRepository == null)
          _trainingDayRepository = new TrainingDayRepository(_context);

        return _trainingDayRepository;
      }
    }
    public ITrainingExerciseRepository trainingExerciseRepository
    {
      get
      {
        if (_trainingExerciseRepository == null)
          _trainingExerciseRepository = new TrainingExerciseRepository(_context);

        return _trainingExerciseRepository;
      }
    }
    
    public ITrainingHistoryRepository trainingHistoryRepository
    {
      get
      {
        if (_trainingHistoryRepository == null)
          _trainingHistoryRepository = new TrainingHistoryRepository(_context);

        return _trainingHistoryRepository;
      }
    }
    
    public IPlannedTrainingRepository plannedTrainingRepository
    {
      get
      {
        if (_plannedTrainingRepository == null)
          _plannedTrainingRepository = new PlannedTrainingRepository(_context);

        return _plannedTrainingRepository;
      }
    }

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