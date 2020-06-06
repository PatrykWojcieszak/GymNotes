namespace GymNotes.Service.Utils {
    public class PageQuery {
        public string Orderby { get; set; }
        public int Page { get; set; } = 1;
        public int Pagesize { get; set; } = 10;
    }
}