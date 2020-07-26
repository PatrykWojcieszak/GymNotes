using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GymNotes.Filters;
using GymNotes.Service.IService;
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

    #endregion POST

    #region GET
    [HttpGet("{id}")]
    public IActionResult GetTrainingPlan(int id) =>
      Ok(_trainingPlanService.GetTrainingPlan(id));

    #endregion GET
  }
}
