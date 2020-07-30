using System;
using System.Collections.Generic;
using System.Text;

namespace GymNotes.Service.ViewModels.Training
{
  public class TrainingPlanVm
  {
    public int Id { get; set; }

    public DateTime ModifiedTime { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public List<TrainingWeekVm> TrainingWeeks  { get; set; }

    public string OwnerId { get; set; }

    public UserVm Owner { get; set; }

    public string CreatorId { get; set; }

    public UserVm Creator { get; set; }

    public bool IsMain { get; set; }

    public bool IsFavorite { get; set; }
  }
}
