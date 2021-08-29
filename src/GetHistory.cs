namespace Nasfaq.JSON
{
    //api/getHistory
    //api/getHistory?timestamp={date timestamp in ms}
    public class GetHistory
    {
        public bool success { get; set; }
        public History history { get; set; }
    }

    public class History
    {
        public long timestamp { get; set; }
        public Transaction[] transactions { get; set; }
    }
}