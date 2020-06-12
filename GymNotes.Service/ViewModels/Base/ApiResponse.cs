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
    public string StatusDescription { get; private set; }

    [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string Message { get; private set; }

    [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
    public object Result { get; private set; }

    public ApiResponse(int statusCode, string statusDescription)
    {
      this.StatusCode = statusCode;
      this.StatusDescription = statusDescription;
    }

    public ApiResponse(int statusCode, string statusDescription, string message)
        : this(statusCode, statusDescription)
    {
      this.Message = message;
    }

    public ApiResponse(int statusCode, object result)
    {
      this.StatusCode = statusCode;
      this.Result = result;
    }
  }
}