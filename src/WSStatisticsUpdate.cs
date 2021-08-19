using System.Collections.Generic;

namespace Nasfaq.JSON
{
    public class WSStatisticsUpdate: IWebsocket
    {
        public Dictionary<string, Stats> stats { get; set; }
    }
}