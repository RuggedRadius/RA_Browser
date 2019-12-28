using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RA_API.Models
{
    [Serializable]
    class User
    {
        [JsonProperty("user")]
        public string user { get; set; }

        [JsonProperty("score")]
        public string score { get; set; }

        [JsonProperty("trueratio")]
        public string trueratio { get; set; }


        [JsonProperty("ID")]
        public long Id { get; set; }
        [JsonProperty("TotalPoints")]
        public long TotalPoints { get; set; }
        [JsonProperty("TotalTruePoints")]
        public long TotalTruePoints { get; set; }
        [JsonProperty("Status")]
        public string Status { get; set; }
        [JsonProperty("Points")]
        public long Points { get; set; }
        [JsonProperty("LastGameID")]
        public int LastGameId { get; set; }
        [JsonProperty("MemberSince")]
        public DateTimeOffset MemberSince { get; set; }
        [JsonProperty("Rank")]
        public long Rank { get; set; }
        [JsonProperty("UserPic")]
        public string UserPic { get; set; }


        public List<Game> RecentlyPlayedGames;

        public User(JToken j)
        {
            user = (string)j["user"];
            score = (string)j["score"];
            trueratio = (string)j["trueratio"];

            if (j["LastGameID"] != null)
            {
                LastGameId = (int)j["LastGameID"];
            }
            
            if (j["RecentlyPlayed"] != null)
            {
                // Get recent games
                RecentlyPlayedGames = new List<Game>();
                foreach (JObject jo in j["RecentlyPlayed"])
                {
                    Game recentGame = new Game(jo);
                    RecentlyPlayedGames.Add(recentGame);
                }
            }



            

        }










    }

    //public partial class Awarded
    //{
    //    [JsonProperty("NumPossibleAchievements")]
    //    public long NumPossibleAchievements { get; set; }

    //    [JsonProperty("PossibleScore")]
    //    public long PossibleScore { get; set; }

    //    [JsonProperty("NumAchieved")]
    //    public long NumAchieved { get; set; }

    //    [JsonProperty("ScoreAchieved")]
    //    public long ScoreAchieved { get; set; }

    //    [JsonProperty("NumAchievedHardcore")]
    //    public long NumAchievedHardcore { get; set; }

    //    [JsonProperty("ScoreAchievedHardcore")]
    //    public long ScoreAchievedHardcore { get; set; }
    //}







   
    


}

