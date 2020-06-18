using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymNotes.Service.ViewModels
{
  public class ApiResponse
  {
    public int StatusCode { get; private set; }

    [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string Message { get; private set; }

    [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
    public object Result { get; private set; }

    public ApiResponse(int statusCode, string message)
        : this(statusCode)
    {
      this.Message = message;
    }

    public ApiResponse(object result) :
      this(200)
    {
      Result = result;
    }

    public ApiResponse(int statusCode)
    {
      this.StatusCode = statusCode;
    }
  }
}