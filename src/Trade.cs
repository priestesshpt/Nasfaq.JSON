namespace Nasfaq.JSON
{
    //api/trade
    public class Trade
    {
        public Trade_Coin[] orders { get; set; }
    }

    public class Trade_Coin
    {
        public string coins { get; set; }
        public TradeType type { get; set; }
    }

    public enum TradeType
    {
        Buy = 0,
        Sell = 1
    }
}