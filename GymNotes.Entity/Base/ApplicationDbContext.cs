﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GymNotes.Entity.Models;
using GymNotes.Entity.Models.NewFolder;
using GymNotes.Models;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace GymNotes.Data
{
  public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
  {
    public ApplicationDbContext(
      DbContextOptions options,
      IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions) { }

    public DbSet<ApplicationUser> ApplicationUsers { get; set; }
    public DbSet<AchievementDyscypline> AchievementDyscyplines { get; set; }
    public DbSet<Achievement> Achievements { get; set; }
    public DbSet<Statistics> Statistics { get; set; }
    public DbSet<StatisticsDyscypline> StatisticsDyscyplines { get; set; }
    public DbSet<StatisticsExercise> StatisticsExercises { get; set; }
    public DbSet<CoachingRequest> CoachingRequests { get; set; }
    public DbSet<Pupil> Pupils { get; set; }
    public DbSet<Message> Messages { get; set; }
    public DbSet<Contact> Contacts { get; set; }
    public DbSet<UserOpinion> UserOpinions { get; set; }
    public DbSet<UserOpinionLikes> UserOpinionLikes { get; set; }
    public DbSet<TrainingPlan> TrainingPlans{ get; set; }
    public DbSet<TrainingWeek> TrainingWeeks { get; set; }
    public DbSet<TrainingDay> TrainingDays { get; set; }
    public DbSet<TrainingExercise> TrainingExercises { get; set; }
  }
}