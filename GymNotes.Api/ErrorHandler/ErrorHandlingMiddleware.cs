using GymNotes.Service.Exceptions;
using GymNotes.Service.ViewModels;
using GymNotes.Service.ViewModels.Base;
using IdentityServer4.Events;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace GymNotes.ErrorHandler
{
  public class ErrorHandlingMiddleware
  {
    private readonly RequestDelegate _next;
    //private readonly ILoggerManager _logger;

    //public ErrorHandlingMiddleware(RequestDelegate next, ILoggerManager logger)
    public ErrorHandlingMiddleware(RequestDelegate next)
    {
      // _logger = logger;
      _next = next;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
      try
      {
        await _next(httpContext);
      }
      catch (Exception ex)
      {
        //_logger.LogError($"Something went wrong: {ex}");
        await HandleExceptionAsync(httpContext, ex);
      }
    }

    private Task HandleExceptionAsync(HttpContext context, Exception ex)
    {
      var code = HttpStatusCode.InternalServerError; // 500 if unexpected

      if (ex is MyNotFoundException) code = HttpStatusCode.NotFound;
      else if (ex is MyUnauthorizedException) code = HttpStatusCode.Unauthorized;
      else if (ex is MyException) code = HttpStatusCode.BadRequest;

      context.Response.ContentType = "application/json";
      context.Response.StatusCode = (int)code;

      var result = JsonConvert.SerializeObject(new ErrorDetails()
      {
        StatusCode = (int)code,
        Message = ex.Message,
      });

      return context.Response.WriteAsync(result);
    }
  }
}