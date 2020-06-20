using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymNotes.Service.ViewModels
{
  public class ApiResponse
  {
    public bool IsSuccessful { get; set; }

    [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string Message { get; private set; }

    public ApiResponse(bool isSuccessfull, string message)
        : this(isSuccessfull)
    {
      this.Message = message;
    }

    public ApiResponse(bool isSuccessfull)
    {
      this.IsSuccessful = isSuccessfull;
    }
  }
}