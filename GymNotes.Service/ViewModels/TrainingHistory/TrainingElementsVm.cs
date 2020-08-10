using System;
using System.Collections.Generic;
using System.Text;

namespace GymNotes.Service.ViewModels.TrainingHistory
{
  public class TrainingElementsVm
  {
    public List<string> ElementName { get; set; }
    public List<int> ElementId { get; set; }

    public TrainingElementsVm()
    {
      ElementName = new List<string>();
      ElementId = new List<int>();
    }
  }
}
