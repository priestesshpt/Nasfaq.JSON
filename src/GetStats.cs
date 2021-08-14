using System.Collections.Generic;

namespace Nasfaq.JSON
{
    //api/getStats
    public class GetStats
    {   
        Dictionary<string, Stats> stats { get; set; }
    }
    
    public class Stats
    {
        public Stats_Data subscriberCount { get; set; }
        public Stats_Data dailySubscriberCount { get; set; }
        public Stats_Data weeklySubscriberCount { get; set; }
        public Stats_Data viewCount { get; set; }
        public Stats_Data dailyViewCount { get; set; }
        public Stats_Data weeklyViewCount { get; set; }
    }

    public class Stats_Data
    {
        public string name { get; set; }
        public string[] labls { get; set; }
        public int[] data { get; set; }
    }
}