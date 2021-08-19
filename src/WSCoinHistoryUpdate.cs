using System.Collections.Generic;

namespace Nasfaq.JSON
{
    public class WSCoinHistoryUpdate: IWebsocket
    {
        public Dictionary<string, WSCoinPriceUpdate> data { get; set; }
    }
}