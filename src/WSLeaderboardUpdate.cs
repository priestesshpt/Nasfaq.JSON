namespace Nasfaq.JSON
{
    //leaderboardUpdate
    public class WSLeaderboardUpdate : IWebsocket
    {
        public Leaderboard leaderboard { get; set; }
        public Oshiboard oshiboard { get; set; }
    }
}