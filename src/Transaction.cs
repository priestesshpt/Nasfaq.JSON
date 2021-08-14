namespace Nasfaq.JSON
{
    public class Transaction
    {
        public string coin { get; set; }
        public int type { get; set; }
        public string userid { get; set; }
        public long timestamp { get; set; }
        public bool completed { get; set; }
        public float price { get; set; }
    }
}