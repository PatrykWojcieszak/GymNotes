using System;
using System.Collections.Generic;
using System.Text;

namespace GymNotes.Service.Exceptions
{
  public class MyException : Exception
  {
    public MyException()
    {
    }

    public MyException(string message)
        : base(message)
    {
    }

    public MyException(string message, Exception inner)
        : base(message, inner)
    {
    }
  }
}