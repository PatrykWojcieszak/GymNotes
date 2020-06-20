using System;
using System.Collections.Generic;
using System.Text;

namespace GymNotes.Service.Exceptions
{
  public class MyUnauthorizedException : Exception
  {
    public MyUnauthorizedException()
    {
    }

    public MyUnauthorizedException(string message)
        : base(message)
    {
    }

    public MyUnauthorizedException(string message, Exception inner)
        : base(message, inner)
    {
    }
  }
}