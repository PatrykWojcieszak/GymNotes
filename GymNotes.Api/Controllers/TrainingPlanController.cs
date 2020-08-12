using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GymNotes.Filters;
using GymNotes.Service.IService;
using GymNotes.Service.Utils;
using GymNotes.Service.ViewModels.Training;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GymNotes.Controllers
{
  [Authorize]
  [Route("api/[controller]")]
  [ApiController]
  public class TrainingPlanController : ControllerBase
  {
    private readonly ITrainingPlanService _trainingPlanService;

    public TrainingPlanController(ITrainingPlanService trainingPlanService)
    {
      _trainingPlanService = trainingPlanService;
    }

    #region POST

    [ApiValidationFilter]
    [HttpPost("edit/{id}")]
    public async Task<IActionResult> EditTrainingPlan(string Id, [FromBody] TrainingPlanVm trainingPlanVm) => 
      Ok(await _trainingPlanService.EditTrainingPlan(trainingPlanVm));

    [ApiValidationFilter]
    [HttpPost("create")]
    public async Task<IActionResult> CreateTrainingPlan([FromBody] TrainingPlanVm trainingPlanVm) =>
      Ok(await _trainingPlanService.CreateTrainingPlan(trainingPlanVm));

    [HttpPost("search/{id}")]
    public async Task<IActionResult> GetAllTrainingPlan(string id, [FromBody] PageQuery pageQuery) =>
      Ok(await _trainingPlanService.Search(id, pageQuery));

    [HttpPost("favorite/{id}/{flag}")]
    public async Task<IActionResult> ToggleFavorite(int id, bool flag) =>
      Ok(await _trainingPlanService.ToggleFavorite(id, flag));

    [HttpPost("main/{userId}/{id}/{flag}")]
    public async Task<IActionResult> ToggleMain(string userId, int id, bool flag) =>
      Ok(await _trainingPlanService.ToggleMain(userId, id, flag));

    #endregion POST

    #region GET

    [HttpGet("get/{id}")]                          
    public IActionResult GetTrainingPlan(int id) =>
      Ok(_trainingPlanService.GetTrainingPlan(id));

    [HttpGet("getExercise/{id}")]
    public IActionResult GetExercises(int id) =>
      Ok(_trainingPlanService.GetTrainingExercise(id));

    #endregion GET

    #region DELETE

    [HttpPost("delete/{userId}/{id}")]
    public async Task<IActionResult> Delete(string userId, int id) =>
      Ok(await _trainingPlanService.Delete(userId, id));

    #endregion DELETE
  }
}
