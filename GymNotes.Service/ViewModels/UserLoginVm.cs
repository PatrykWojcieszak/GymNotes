﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GymNotes.Service.ViewModels
{
  public class UserLoginVm
  {
    public string Email { get; set; }

    public string Password { get; set; }

    public bool isPersistent { get; set; }
  }
}