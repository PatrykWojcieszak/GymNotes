﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GymNotes.Entity.Models.TrainingHistory
{
  public class PlannedTraining
  {
    [Key]
    public int Id { get; set; }

    [Required]
    public int TrainingPlanId { get; set; }

    [Required]
    public int TrainingWeekId { get; set; }

    [Required]
    public int TrainingDayId { get; set; }
  }
}
