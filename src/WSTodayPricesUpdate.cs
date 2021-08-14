namespace Nasfaq.JSON
{
    //todayPricesUpdate
    public class WSTodayPricesUpdate
    {
        public string coin { get; set; }
        public WSTodayPricesUpdate_Stamp priceStamp { get; set; }
    }

    public class WSTodayPricesUpdate_Stamp
    {
        public long timestamp { get; set; }
        public double price { get; set; }
        public int inCirculation { get; set; }
    }
}