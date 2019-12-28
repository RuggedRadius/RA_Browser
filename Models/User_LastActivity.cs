using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RA_API.Models
{
    public class User_LastActivity
    {
        [JsonProperty("ID")]
        public long Id { get; set; }

        [JsonProperty("timestamp")]
        public DateTimeOffset Timestamp { get; set; }

        [JsonProperty("lastupdate")]
        public DateTimeOffset Lastupdate { get; set; }

        [JsonProperty("activitytype")]
        public long Activitytype { get; set; }

        [JsonProperty("User")]
        public string User { get; set; }

        [JsonProperty("data")]
        public object Data { get; set; }

        [JsonProperty("data2")]
        public object Data2 { get; set; }
    }
}
