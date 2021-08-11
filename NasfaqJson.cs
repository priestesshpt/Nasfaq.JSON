using System;
using System.Collections.Generic;
using Nasfaq.JSON.ChildJSON;

namespace Nasfaq
{
    namespace JSON
    {
        #region APIs
        /*
        /destroySession
        /getCooldown
        /updateFilters
        /buySuperchat
        /getSuperchats
        */
        
        //Not doing unless I can deal with the captcha
        /*
        /deleteOwnAccount
        /login
        /register
        /verifyEmail
        /setPasswordResetCode
        /resetPassword
        /sendAuthCode
        */

        //Admin stuff
        /*
        /deleteAccountAdmin
        /setAdjustmentToggles
        /getDataFile
        /getAdminInfo
        /setMarketSwitch
        /loginAdmin
        /deleteReport
        /deleteMessage
        /deleteMessage
        /updateUserMuted
        /removeRoom
        */
        #endregion

        #region Coin names
        public static class CoinName
        {
            public static readonly string Hololive = "hololive";

            public static readonly string Sora = "sora";
            public static readonly string Roboco = "roboco";
            public static readonly string Miko = "miko";
            public static readonly string Suisei = "suisei";
            public static readonly string Azki = "azki";

            public static readonly string Mel = "mel";
            public static readonly string Fubuki = "fubuki";
            public static readonly string Matsuri = "matsuri";
            public static readonly string Aki = "aki";
            public static readonly string Haato = "haato";
            
            public static readonly string Aqua = "aqua";
            public static readonly string Shion = "shion";
            public static readonly string Ayame = "ayame";
            public static readonly string Choco = "choco";
            public static readonly string Subaru = "subaru";

            public static readonly string Mio = "mio";
            public static readonly string Okayu = "okayu";
            public static readonly string Korone = "korone";

            public static readonly string Pekora = "pekora";
            public static readonly string Rushia = "rushia";
            public static readonly string Flare = "flare";
            public static readonly string Noel = "noel";
            public static readonly string Marine = "marine";

            public static readonly string Kanata = "kanata";
            public static readonly string Coco = "coco";
            public static readonly string Watame = "watame";
            public static readonly string Towa = "towa";
            public static readonly string Luna = "himemoriluna";

            public static readonly string Lamy = "lamy";
            public static readonly string Nene = "nene";
            public static readonly string Botan = "botan";
            public static readonly string Polka = "polka";

            public static readonly string Risu = "risu";
            public static readonly string Moona = "moona";
            public static readonly string Iofi = "iofi";

            public static readonly string Mori = "calliope";
            public static readonly string Kiara = "kiara";
            public static readonly string Ina = "inanis";
            public static readonly string Gura = "gura";
            public static readonly string Amelia = "amelia";

            public static readonly string IRyS = "irys";

            public static readonly string Ollie = "ollie";
            public static readonly string Anya = "melfissa";
            public static readonly string Reine = "reine";

            public static readonly string Ui = "ui";
            public static readonly string Nana = "nana";
            public static readonly string Pochi = "pochimaru";
            public static readonly string Ayamy = "ayamy";
            public static readonly string Nabi = "nabi";

            public static readonly string Civia = "civia";
        }

        #endregion

        #region Buy/Sell Coin
        //api/buyCoin
        public class BuyCoin
        {
            public string coin { get; set; }
        }

        //api/sellCoin
        public class SellCoin
        {
            public string coin { get; set; }
        }
        #endregion

        #region Websocket

        public static class WebsocketUtils
        {

        }

        //coinPriceUpdate
        public class WSCoinPriceUpdate
        {
            public string coin { get; set; }
            public WSCoinPriceUpdateInfo info { get; set; }
        }

        namespace ChildJSON
        {
            public class WSCoinPriceUpdateInfo
            {
                public double price { get; set; }
                public double saleValue { get; set; }
                public int inCirculation { get; set; }
            }
        }

        //historyUpdate
        public class WSHistoryUpdate : Transaction { }

        //todayPricesUpdate
        public class WSTodayPricesUpdate
        {
            public string coin { get; set; }
            public WSTodayPriceStamp priceStamp { get; set; }
        }

        namespace ChildJSON
        {
            public class WSTodayPriceStamp
            {
                public long timestamp { get; set; }
                public double price { get; set; }
                public int inCirculation { get; set; }
            }
        }

        //transactionUpdate
        public class WSTransactionUpdate
        {
            public string @event { get; set; }
            public Transaction[] transactions { get; set; }
            public UserWallet wallet { get; set; }
        }

        //gachaUpdate
        public class WSGachaUpdate
        {
            public string[] drops { get; set; }
            public int cashDrops { get; set; }
        }

        //floorUpdate
        public class WSFloorUpdate
        {
            public int postCount { get; set; }
            public FloorUpdateRoom[] rooms { get; set; }
        }

        namespace ChildJSON
        {
            public class FloorUpdateRoom
            {
                public string id { get; set; }
                public long timestamp { get; set; }
                public string subject { get; set; }
                public string opening { get; set; }
                public string creator { get; set; }
                public int posts { get; set; }
                public string[] posters { get; set; }
            }
        }

        //roomUpdate
        public class WSRoomUpdate
        {
            public RoomUpdate[] roomUpdate { get; set; }
        }

        namespace ChildJSON
        {
            public class RoomUpdate
            {
                public int id { get; set; }
                public long timestamp { get; set; }
                public string username { get; set; }
                public string text { get; set; }
                public int[] mentions { get; set; }
            }
        }

        #endregion

        #region GetUserWallet

        //api/getUserWallet?userid=id
        public class GetUserWallet
        {
            public bool success { get; set; }
            public UserWallet wallet { get; set; }
        }

        #endregion

        #region User Info

        //api/getUserInfo
        public class GetUserInfo
        {
            public bool loggedout { get; set; }
            public string username { get; set; }
            public string id { get; set; }
            public string email  { get; set; }
            public UserPerformanceTick[] performance { get; set; }
            public bool verified { get; set; }
            public UserWallet wallet { get; set; }
            public string icon { get; set; }
            public bool admin { get; set; }
            public UserSettings settings { get; set; }
            public UserMuted muted { get; set; }
            public Dictionary<string, UserItems> items { get; set; }
        }

        public class UserWallet
        {
            public double balance { get; set; }
            public Dictionary<string, UserWalletCoin> coins { get; set; }
            public string predicted { get; set; }
        }

        //api/updateSettings
        public class UserSettings
        {
            public bool walletIsPublic { get; set; }
        }

        namespace ChildJSON
        {
            public class UserPerformanceTick
            {
                public long timestamp { get; set; }
                public double worth { get; set; }
            }

            public class UserWalletCoin
            {
                public int amt { get; set; }
                public long timestamp { get; set; }
                public double meanPurchasePrice { get; set; }
            }

            public class UserMuted
            {
                public bool muted { get; set; }
                public long until { get; set; }
                public string message { get; set; }
            }

            public class UserItems
            {
                public string itemType { get; set; }
                public long acquiredTimestamp { get; set; }
                public double lastPurchasePrice { get; set; }
                public int quantity { get; set; }
            }
        }


        #endregion

        #region SetIcon

        //api/setIcon
        public class SetIcon
        {
            public string icon { get; set; }
        }

        #endregion

        #region ChangeUsername

        //api/changeUsername
        public class ChangeUsername
        {
            public string username { get; set; }
        }

        #endregion

        #region ChangeEmail

        //api/changeEmail
        public class ChangeEmail
        {
            public string email { get; set; }
        }

        #endregion

        #region Leaderboard
        //api/getLeaderboard
        public class GetLeaderboard
        {
            public ChildJSON.Leaderboard leaderboard {get; set;}
            public ChildJSON.Oshiboard oshiboard {get; set;}
        }

        namespace ChildJSON
        {
            public class Leaderboard
            {
                public long timestamp {get; set;}
                public LeaderboardUser[] leaderboard { get; set; }
            }

            public class LeaderboardUser
            {
                public string userid { get; set; }
                public string username { get; set; }
                public string icon { get; set; }
                public double networth { get; set; }
                public bool walletIsPublic { get; set; }
                public bool hasItems { get; set; }
            }

            public class Oshiboard
            {
                public long timestamp { get; set; }
                public Dictionary<string, OshiboardBoard> coins { get; set; }
            }
            public class OshiboardBoard
            {
                public int totalOwned { get; set; }
                public OshiboardDirector[] directors { get; set; }
            }

            public class OshiboardDirector
            {
                public string username { get; set; }
                public string icon { get; set; }
                public int amtOwned { get; set; }
            }
        }

        #endregion

        #region GetGachaboard
        //api/getGachaboard
        public class GetGachaboard
        {
            public ChildJSON.GachaboardPlayer[] gachaboard { get; set; }
        }

        namespace ChildJSON
        {
            public class GachaboardPlayer
            {
                public string username { get; set; }
                public double spentAmt { get; set; }
            }
        }

        #endregion

        #region GetItemCatalogue

        //api/getCatalogue
        public class GetItemCatalogue
        {
            public bool success { get; set; }
            public ItemCatalogueEntry[] catalogue { get; set; }
        }

        namespace ChildJSON
        {
            public class ItemCatalogueEntry
            {
                public string name { get; set; }
                public string description { get; set; }
                public string modifier { get; set; }
                public double modifierMult { get; set; }
            }
        }

        #endregion

        #region Transaction

        public class Transaction
        {
            public string coin { get; set; }
            public int type { get; set; }
            public string userid { get; set; }
            public long timestamp { get; set; }
            public bool completed { get; set; }
            public float price { get; set; }
        }

        #endregion

        #region GetHistory

        //api/getHistory
        //api/getHistory?timestamp={date timestamp in ms}
        public class GetHistory
        {
            bool success { get; set; }

        }

        namespace ChildJSON
        {
            public class History
            {
                public long timestamp { get; set; }
                public Transaction[] transactions { get; set; }
            }
        }

        #endregion

        #region GetAllArchivedHistory
        //https://anonfiles.com/F4IdAd7eue/getAllArchivedHistory_json
        public class GetAllArchivedHistory
        {
            public History[] archive { get; set; }
        }

        #endregion
        
        #region MarketInfo

        //api/getMarketInfo
        public class GetMarketInfo
        {
            public ChildJSON.MarketCoinsInfo coinInfo { get; set; }
            public bool marketSwitch { get; set; }
        }

        namespace ChildJSON
        {
            public class MarketCoinsInfo
            {
                public Dictionary<string, CoinInfo> data { get; set; }
                public long timestamp { get; set; }
            }

            public class CoinInfo
            {
                public string coin { get; set; }
                public double price { get; set; }
                public double saleValue { get; set; }
                public int inCirculation { get; set; }
                public CoinInfoHistoryTick[] history { get; set; }
            }

            public class CoinInfoHistoryTick
            {
                public long timestamp { get; set; }
                public double price { get; set; }
                public int inCirculation { get; set; }
            }
        }

        #endregion

        #region Dividends
        //api/getDividends
        public class GetDividends
        {
            public bool success { get; set; }
            public ChildJSON.Dividends dividends { get; set; }

        }
        namespace ChildJSON
        {
            public class Dividends
            {
                public long timestamp { get; set; }
                public Dictionary<string, double> payouts { get; set; }
            }
        }
        #endregion

        #region Stats

        //api/getStats
        public class GetStats
        {   
            Dictionary<string, ChildJSON.Stats> stats { get; set; }
        }
        namespace ChildJSON
        {
            public class Stats
            {
                public StatsData subscriberCount { get; set; }
                public StatsData dailySubscriberCount { get; set; }
                public StatsData weeklySubscriberCount { get; set; }
                public StatsData viewCount { get; set; }
                public StatsData dailyViewCount { get; set; }
                public StatsData weeklyViewCount { get; set; }
            }

            public class StatsData
            {
                public string name { get; set; }
                public string[] labls { get; set; }
                public int[] data { get; set; }
            }
        }

        #endregion
    
        #region GetSuperchats

        //api/getSuperchats
        public class GetSuperchats
        {
            public bool success { get; set; }
            public Dictionary<string, SuperchatDaily> daily { get; set; }
            public Dictionary<string, SuperchatHistory> history { get; set; }
        }

        namespace ChildJSON
        {   
            public class SuperchatDaily
            {
                public double total { get; set; }
                public Dictionary<string, SuperchatUserTotal> userTotals { get; set; }
            }

            public class SuperchatUserTotal
            {
                public string username { get; set; }
                public double total { get; set; }
            }

            public class SuperchatHistory
            {
                public string coin { get; set; }
                public double total { get; set; }
                public Superchat[] superchats { get; set; }
            }

            public class Superchat
            {
                public string coin { get; set; }
                public string userid { get; set; }
                public string username { get; set; }
                public string usericon { get; set; }
                public long timestamp { get; set; }
                public long expiration { get; set; }
                public string message { get; set; }
            }
        }

        #endregion

        #region News

        //api/getNews
        public class GetNews
        {
            public bool success { get; set; }
            public News[] news { get; set; } 
        }

        namespace ChildJSON
        {
            public class News
            {
                public string date { get; set; }
                public string[] messages { get; set; }
            }
        }

        #endregion

        #region Announcement

        //api/getAnnouncement
        public class GetAnnouncement
        {
            public bool success { get; set; }
            public Announcement announcement { get; set; }
        }

        namespace ChildJSON
        {
            public class Announcement
            {
                public string message { get; set; }
                public string date { get; set; }
            }
        }

        #endregion
    
        #region AddRoom

        //api/addRoom
        public class AddRoom
        {
            public string subject { get; set; }
            public string openingText { get; set; }
        }

        #endregion

        #region AddMessage

        //api/addMessage
        public class AddMessage
        {
            public string room { get; set; }
            public string text { get; set; }
        }

        #endregion

        #region AddReport

        //api/addReport
        public class AddReport
        {
            public Report report { get; set; }
        }

        namespace ChildJSON
        {
            public class Report
            {
                public ReportMessage message { get; set; }
            }

            public class ReportMessage
            {
                public int id { get; set; }
                public string roomId { get; set; }
                public string text { get; set; }
                public long timestamp { get; set; }
                public string username { get; set; }
            }
        }

        #endregion
        
        #region GetChatLog

        //api/getChatLog
        //api/getChatLog?room={roomid}
        public class GetChatLog
        {
            public ChatLogEntry[] chatLog { get; set; }
        }

        namespace ChildJSON
        {
            public class ChatLogEntry
            {
                public int id { get; set; }
                public long timestamp { get; set; }
                public string username { get; set; }
                public string text { get; set; }
                public string[] mentions { get; set; }
            }
        }

        #endregion

        #region GetFloor

        //api/getFloor
        public class GetFloor
        {
            public int postCount { get; set; }
            public FloorRoom rooms { get; set; }
        }

        namespace ChildJSON
        {
            public class FloorRoom
            {
                public string id { get; set; }
                public long timestamp { get; set; }
                public string subject { get; set; }
                public string opening { get; set; }
                public string creator { get; set; }
                public int posts { get; set; }
                public string[] posters { get; set; }
            }
        }

        #endregion

    }
}
