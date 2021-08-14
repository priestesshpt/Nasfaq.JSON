namespace Nasfaq.JSON
{
    //transactionUpdate
    public class WSTransactionUpdate
    {
        public string @event { get; set; }
        public Transaction[] transactions { get; set; }
        public UserWallet wallet { get; set; }
    }
}