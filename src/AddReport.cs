namespace Nasfaq.JSON
{
    //api/addReport
    public class AddReport
    {
        public Report report { get; set; }
    }

    public class Report
    {
        public Report_Message message { get; set; }
    }

    public class Report_Message
    {
        public int id { get; set; }
        public string roomId { get; set; }
        public string text { get; set; }
        public long timestamp { get; set; }
        public string username { get; set; }
    }
}