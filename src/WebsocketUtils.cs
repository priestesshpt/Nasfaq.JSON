using System;
using System.Text.Json;
using System.Collections.Generic;
using System.IO;

namespace Nasfaq.JSON
{
    public static class WebsocketReader
    {
        public static IWebsocketData Read(string content)
        {
            content = content.Substring(2);
            JsonDocument jsonDocument = JsonDocument.Parse(content);
            string websocketName = jsonDocument.RootElement[0].GetString();
            JsonElement jsonElement = jsonDocument.RootElement[1];

            try
            {
                switch(websocketName)
                {
                    case "coinPriceUpdate": return ReadStandard<WSCoinPriceUpdate>(jsonElement);
                    case "dividendUpdate": return ReadDividendUpdate(jsonElement);
                    case "floorUpdate": return ReadStandard<WSFloorUpdate>(jsonElement);
                    case "gachaUpdate": return ReadStandard<WSGachaUpdate>(jsonElement);
                    case "historyUpdate": return ReadStandard<WSHistoryUpdate>(jsonElement);
                    case "leaderboardUpdate": return ReadStandard<WSLeaderboardUpdate>(jsonElement);
                    case "oshiboardUpdate": return ReadOshiboardUpdate(jsonElement);
                    case "todayPricesUpdate": return ReadStandard<WSTodayPricesUpdate>(jsonElement);
                    case "transactionUpdate": return ReadStandard<WSTransactionUpdate>(jsonElement);
                    case "marketSwitch": return ReadMarketSwitch(jsonElement);
                    case "superchatUpdate": return ReadStandard<WSSuperChatUpdate>(jsonElement);
                    case "statisticsUpdate": return ReadStatisticsUpdate(jsonElement);
                    case "coinHistoryUpdate": return ReadStandard<WSCoinHistoryUpdate>(jsonElement);
                }
                throw new KeyNotFoundException($"Websocket '{websocketName}' not handled, data: {jsonElement.ToString()}");
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                File.AppendAllText("websocketerrors.txt", e.Message + "\n\n\n\n");
            }
            return null;
        }

        private static T ReadStandard<T>(JsonElement element) where T : IWebsocketData
        {
            return JsonSerializer.Deserialize<T>(element.ToString());
        }

        private static WSDividendUpdate ReadDividendUpdate(JsonElement element)
        {
            return new WSDividendUpdate() { wallet = JsonSerializer.Deserialize<UserWallet>(element.ToString())};
        }

        private static WSStatisticsUpdate ReadStatisticsUpdate(JsonElement element)
        {
            return new WSStatisticsUpdate() { stats = JsonSerializer.Deserialize<Dictionary<string, Stats> >(element.ToString())};
        }

        private static WSOshiboardUpdate ReadOshiboardUpdate(JsonElement element)
        {
            return new WSOshiboardUpdate() { oshiboard = JsonSerializer.Deserialize<Oshiboard>(element.ToString())};
        }

        private static WSRoomUpdate ReadRoomUpdate(JsonElement element)
        {
            return new WSRoomUpdate() { roomUpdate = JsonSerializer.Deserialize<WSRoomUpdate_Update[]>(element.ToString())};
        }

        private static WSMarketSwitch ReadMarketSwitch(JsonElement element)
        {
            return new WSMarketSwitch() { marketSwitch = JsonSerializer.Deserialize<bool>(element.ToString())};
        }
    }
}