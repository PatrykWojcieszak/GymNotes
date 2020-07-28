using System.Collections.Generic;

namespace GymNotes.Service.Utils {
  public class PageQuery {

    public List<int> Filterby { get; set; }

    public int Page { get; set; } = 1;

    public int Pagesize { get; set; } = 10;

    public string Search { get; set; }

    public PageQuery()
    {
      Filterby = new List<int>();
    }
  }
}