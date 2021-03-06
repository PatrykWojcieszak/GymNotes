using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using GymNotes.Data;
using GymNotes.Entity.Models;
using GymNotes.ErrorHandler;
using GymNotes.Models;
using GymNotes.Repository.Base;
using GymNotes.Repository.IRepository;
using GymNotes.Repository.IRepository.Chat;
using GymNotes.Repository.IRepository.Training;
using GymNotes.Repository.IRepository.User;
using GymNotes.Repository.Repository;
using GymNotes.Repository.Repository.Chat;
using GymNotes.Repository.Repository.Training;
using GymNotes.Repository.Repository.User;
using GymNotes.Service.Chat;
using GymNotes.Service.IService;
using GymNotes.Service.Mapping;
using GymNotes.Service.Service;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Primitives;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using NETCore.MailKit.Extensions;
using NETCore.MailKit.Infrastructure.Internal;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace GymNotes
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      IdentityModelEventSource.ShowPII = true;

      services.Configure<ApplicationSettings>(Configuration.GetSection("ApplicationSettings"));

      services.AddDbContext<ApplicationDbContext>(options =>
       options.UseSqlServer(
         Configuration.GetConnectionString("DefaultConnection")));

      services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
        .AddEntityFrameworkStores<ApplicationDbContext>();

      services.AddIdentityServer()
        .AddApiAuthorization<ApplicationUser, ApplicationDbContext>();

      services.AddAutoMapper(typeof(MappingProfile));

      services.AddControllers().AddNewtonsoftJson(options =>
          options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
      );

      services.AddSingleton<IUserIdProvider, CustomUserIdProvider>();
      services.AddSignalR(options =>
      {
        options.EnableDetailedErrors = true;
      });

      services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
      {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
      }));

      var key = Encoding.UTF8.GetBytes(Configuration["ApplicationSettings:JWT_Secret"].ToString());

      services.AddAuthentication(x =>
      {
        x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
      })
            .AddJwtBearer(x =>
            {
              x.RequireHttpsMetadata = false;
              x.SaveToken = true;
              x.TokenValidationParameters = new TokenValidationParameters
              {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false,
                // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                ClockSkew = TimeSpan.Zero
              };
            });

      // In production, the Angular files will be served from this directory
      services.AddSpaStaticFiles(configuration =>
      {
        configuration.RootPath = "ClientApp/dist";
      });

      services.ConfigureApplicationCookie(options =>
      {
        options.Cookie.HttpOnly = true;
        options.ExpireTimeSpan = TimeSpan.FromDays(1);
        options.LoginPath = "/api/User/authenticate";
      });

      services.Configure<IdentityOptions>(options =>
      {
        options.Password.RequireDigit = false;
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequireLowercase = false;
        options.Password.RequireUppercase = false;
        options.Password.RequiredLength = 6;
        options.User.RequireUniqueEmail = true;
        options.SignIn.RequireConfirmedEmail = true;
      });

      var mailKitOptions = Configuration.GetSection("Email").Get<MailKitOptions>();
      services.AddMailKit(config => config.UseMailKit(mailKitOptions));

      services.AddMvc(option => option.EnableEndpointRouting = false);

      #region DependencyInjection

      #region Repositories

      services.AddScoped<IUnitOfWork, UnitOfWork>();

      //services.AddScoped<IUserRepository, UserRepository>();

      //services.AddScoped<IAchievementRepository, AchievementRepository>();
      //services.AddScoped<IAchievementDyscyplineRepository, AchievementDyscyplineRepository>();

      //services.AddScoped<ICoachingRequestRepository, CoachingRequestRepository>();
      //services.AddScoped<IPupilRepository, PupilRepository>();

      //services.AddScoped<IUserOpinionRepository, UserOpinionRepository>();
      //services.AddScoped<IUserOpinionLikesRepository, UserOpinionLikesRepository>();

      //services.AddScoped<IMessageRepository, MessageRepository>();
      //services.AddScoped<IContactRepository, ContactRepository>();

      //services.AddScoped<IStatisticsRepository, StatisticsRepository>();
      //services.AddScoped<IStatisticsExerciseRepository, StatisticsExerciseRepository>();
      //services.AddScoped<IStatisticsDisciplineRepository, StatisticsDisciplineRepository>();

      //services.AddScoped<ITrainingPlanRepository, TrainingPlanRepository>();
      //services.AddScoped<ITrainingWeekRepository, TrainingWeekRepository>();
      //services.AddScoped<ITrainingDayRepository, TrainingDayRepository>();
      //services.AddScoped<ITrainingExerciseRepository, TrainingExerciseRepository>();

      //services.AddScoped<IPlannedTrainingRepository, PlannedTrainingRepository>();
      //services.AddScoped<ITrainingHistoryRepository, TrainingHistoryRepository>();

      //services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

      //System.Reflection.Assembly.GetExecutingAssembly()
      //      .GetTypes()
      //      .Where(item => item.GetInterfaces()
      //      .Where(i => i.IsGenericType).Any(i => i.GetGenericTypeDefinition() == typeof(IBaseRepository<>)) && !item.IsAbstract && !item.IsInterface)
      //      .ToList()
      //      .ForEach(assignedTypes =>
      //      {
      //        var serviceType = assignedTypes.GetInterfaces().First(i => i.GetGenericTypeDefinition() == typeof(IBaseRepository<>));
      //        services.AddScoped(serviceType, assignedTypes);
      //      });

      #endregion Repositories

      #region Services

      services.AddScoped<IUserService, UserService>();
      services.AddScoped<IUserOpinionService, UserOpinionService>();
      services.AddScoped<IUserInfoService, UserInfoService>();
      services.AddScoped<ICoachService, CoachService>();
      services.AddScoped<IUserSettingsService, UserSettingsService>();
      services.AddScoped<IChatService, ChatService>();
      services.AddScoped<ITrainingPlanService, TrainingPlanService>();
      services.AddScoped<ITrainingHistoryService, TrainingHistoryService>();

      #endregion Services

      #endregion DependencyInjection
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
        app.UseDatabaseErrorPage();
      }
      else
      {
        app.UseExceptionHandler("/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
      }

      app.UseCors("MyPolicy");

      app.UseAuthentication();
      app.UseAuthorization();
      app.UseMiddleware(typeof(ErrorHandlingMiddleware));
      app.UseMvc();
      app.UseHttpsRedirection();
      app.UseStaticFiles();
      app.UseSpaStaticFiles();
      app.UseRouting();
      app.UseCookiePolicy();
      app.UseAuthorization();
      app.UseEndpoints(endpoints =>
      {
        endpoints.MapHub<ChatHub>("/chat");
        endpoints.MapControllerRoute(
          name: "default",
          pattern: "{controller}/{action=Index}/{id?}");
        endpoints.MapRazorPages();
      });

      //app.UseIdentityServer();

      app.UseSpa(spa =>
      {
        // To learn more about options for serving an Angular SPA from ASP.NET Core,
        // see https://go.microsoft.com/fwlink/?linkid=864501

        spa.Options.SourcePath = "ClientApp";

        if (env.IsDevelopment())
        {
          spa.UseProxyToSpaDevelopmentServer("http://localhost:4200");
          // spa.UseAngularCliServer(npmScript: "start");
        }
      });
    }
  }
}