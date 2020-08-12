using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GymNotes.Filters;
using GymNotes.Service.IService;
using GymNotes.Service.ViewModels.TrainingHistory;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GymNotes.Controllers
{
  [Authorize]
  [Route("api/[controller]")]
  [ApiController]
  public class TrainingHistoryController : ControllerBase
  {
    private readonly ITrainingHistoryService _trainingHistoryService;

    public TrainingHistoryController(ITrainingHistoryService trainingHistoryService)
    {
      _trainingHistoryService = trainingHistoryService;
    }

    #region POST

    [ApiValidationFilter]
    [HttpPost("add")]
    public async Task<IActionResult> AddFinishedWorkout([FromBody] TrainingHistoryVm trainingHistoryVm) => 
      Ok(await _trainingHistoryService.AddFinishedWorkout(trainingHistoryVm));

    #endregion POST

    #region GET

    [HttpGet("getPlans/{id}")]                         
    public IActionResult GetTrainingPlans(string id) =>
      Ok(_trainingHistoryService.GetTrainingPlans(id));

    [HttpGet("getWeeks/{id}")]
    public IActionResult GetTrainingWeeks(int id) =>
      Ok(_trainingHistoryService.GetTrainingWeeks(id));

    [HttpGet("getDays/{id}")]
    public IActionResult GetTrainingDays(int id) =>
      Ok(_trainingHistoryService.GetTrainingDays(id));

    [HttpGet("history/{id}")]
    public IActionResult GetWorkoutHistory(string id) =>
      Ok(_trainingHistoryService.GetWorkoutHistory(id));

    #endregion GET

    #region DELETE

    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> DeletetWorkoutHistory(int id) =>
      Ok(await _trainingHistoryService.DeleteWorkoutHistory(id));

    #endregion DELETE
  }
}
