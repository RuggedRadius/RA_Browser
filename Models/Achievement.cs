using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RA_API.Models
{
    [Serializable]
    public class Achievement
    {
        [JsonProperty("ID")]
        public string ID { get; set; }
        [JsonProperty("NumAwarded")]
        public string NumAwarded { get; set; }
        [JsonProperty("NumAwardedHardcore")]
        public string NumAwardedHardcore { get; set; }
        [JsonProperty("Title")]
        public string Title { get; set; }
        [JsonProperty("Description")]
        public string Description { get; set; }
        [JsonProperty("Points")]
        public string Points { get; set; }
        [JsonProperty("TrueRatio")]
        public string TrueRatio { get; set; }
        [JsonProperty("Author")]
        public string Author { get; set; }
        [JsonProperty("DateModified")]
        public string DateModified { get; set; }
        [JsonProperty("DateCreated")]
        public string DateCreated { get; set; }
        [JsonProperty("BadgeName")]
        public string BadgeName { get; set; }
        [JsonProperty("DisplayOrder")]
        public string DisplayOrder { get; set; }
        [JsonProperty("MemAddr")]
        public string MemAddr { get; set; }
        [JsonProperty("DateEarned")]
        public string DateEarned { get; set; }
        [JsonProperty("DateEarnedHardCore")]
        public string DateEarnedHardCore { get; set; }

        public Image badge;

        public Achievement ()
        {

        }
        
        public Achievement (JToken jo)
        {
            ID = (string)jo["ID"];
            NumAwarded = (string)jo["NumAwarded"];
            NumAwardedHardcore = (string)jo["NumAwardedHardcore"];
            Title = (string)jo["Title"];
            Description = (string)jo["Description"];
            Points = (string)jo["Points"];
            TrueRatio = (string)jo["TruePoints"];
            Author = (string)jo["Author"];
            DateModified = (string)jo["DateModified"];
            DateCreated = (string)jo["DateCreated"];
            BadgeName = (string)jo["BadgeName"];
            DisplayOrder = (string)jo["DisplayOrder"];
            MemAddr = (string)jo["MemAddr"];

            try
            {
                DateEarned = (string)jo["DateEarned"];

                try
                {
                    DateEarnedHardCore = (string)jo["DateEarnedHardCore"];                    
                }
                catch (Exception ex) {}
            }
            catch (Exception ex) {}
        }

        public string GetAchievementBadgeImage()
        {
            return String.Format("http://retroachievements.org/Badge/{0}.png", BadgeName);
        }
    }
}
