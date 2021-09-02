namespace Nasfaq.JSON
{
    //api/setUserLeaderboardColor
    public class SetUserLeaderboardColor
    {
        public SetUserLeaderboardColor(string color)
        {
            this.color = color;
        }

        //"red", "pink", "lime", blue", "purple", "orange", "yellow", "green", "magenta", "gray"
        public string color { get; set; }
    }
}