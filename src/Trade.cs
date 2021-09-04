namespace Nasfaq.JSON
{
    //api/trade
    public class Trade
    {
        public Trade()
        {
            
        }

        public Trade(string coin, TradeType type)
        {
            this.orders = new Trade_Coin[] { new Trade_Coin(coin, type) };
        }

        public Trade(string[] buys, string[] sells)
        {
            this.orders = new Trade_Coin[buys.Length + sells.Length];
            int j = 0;
            //important to put sells before buys in the trades
            for(int i = 0; i < sells.Length; i++)
            {
                orders[j] = new Trade_Coin(sells[i], TradeType.Sell);
                j++;
            }
            for(int i = 0; i < buys.Length; i++)
            {
                orders[j] = new Trade_Coin(buys[i], TradeType.Buy);
                j++;
            }
        }

        public Trade(Trade_Coin[] orders)
        {
            this.orders = orders;
        }

        public Trade_Coin[] orders { get; set; }
    }

    public class Trade_Coin
    {
        public Trade_Coin(string coin, TradeType type)
        {
            this.coin = coin;
            this.type = type;
        }

        public string coin { get; set; }
        public TradeType type { get; set; }
    }

    public enum TradeType
    {
        Buy = 0,
        Sell = 1
    }
}