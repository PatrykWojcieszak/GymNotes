﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GymNotes.Service.IService;
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

    #endregion GET

    #region DELETE


    #endregion DELETE
  }
}