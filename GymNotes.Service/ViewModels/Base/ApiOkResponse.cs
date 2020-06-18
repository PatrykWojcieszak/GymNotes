using System;
using System.Collections.Generic;
using System.Text;

namespace GymNotes.Service.ViewModels.Base
{
  public class ApiOkResponse : ApiResponse
  {
    public object Result { get; set; }

    public ApiOkResponse(object result) : base(200)
    {
      Result = result;
    }
  }
}