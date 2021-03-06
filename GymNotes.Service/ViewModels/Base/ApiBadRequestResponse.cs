﻿using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GymNotes.Service.ViewModels.Base
{
  public class ApiBadRequestResponse
  {
    public IEnumerable<string> Errors { get; }

    public ApiBadRequestResponse(ModelStateDictionary modelState)
    {
      if (modelState.IsValid)
      {
        throw new ArgumentException("ModelState must be invalid", nameof(modelState));
      }

      Errors = modelState.SelectMany(x => x.Value.Errors)
          .Select(x => x.ErrorMessage).ToArray();
    }
  }
}