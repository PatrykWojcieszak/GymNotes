﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GymNotes.Service.ViewModels
{
  public class NumberVm : BaseVm
  {
    [Required]
    public int Value { get; set; }
  }
}