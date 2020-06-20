using System;
using System.Collections.Generic;
using System.Text;

namespace GymNotes.Service.Exceptions
{
  public class MyNotFoundException : Exception
  {
    public MyNotFoundException()
    {
    }

    public MyNotFoundException(string message)
        : base(message)
    {
    }

    public MyNotFoundException(string message, Exception inner)
        : base(message, inner)
    {
    }
  }
}