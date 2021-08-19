namespace Nasfaq.JSON
{
    //gachaUpdate
    public class WSGachaUpdate : IWebsocket
    {
        public string[] drops { get; set; }
        public int cashDrops { get; set; }
    }
}