using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RA_API.Connection;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RA_API.Models
{
    [Serializable]
    public class SupportedConsole
    {
        [JsonProperty("ID")]
        public string ID { get; set; }
        [JsonProperty("Name")]
        public string Name { get; set; }

        public List<Game> games;

        // Console Info
        public Image consoleImage { get; set; }
        public string released { get; set; }



        public SupportedConsole(JToken j)
        {
            games = new List<Game>();

            ID = (string)j["ID"];
            Name = (string)j["Name"];

            // Fetch games for console
            string url = Requests.requestURL(Constants.QueryTypes.WEB_GAME_LIST, ID);
            string json = Requests.FetchJSON(url);

            // Create object
            dynamic data = JsonConvert.DeserializeObject(json);

            // Extract achievements from gameObject into individual objects
            if (data["Games"] != null)
            {
                foreach (JObject g in data["Games"])
                {
                    Game newGame = new Game(g);
                    games.Add(newGame);
                }
            }
        }
    }
}
