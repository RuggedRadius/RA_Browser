using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RA_API.Connection;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RA_API.Models
{
    [Serializable]
    public class Game
    {
        [JsonProperty("ID")]
        public string ID { get; set; }
        [JsonProperty("Title")]
        public string Title { get; set; }
        [JsonProperty("ForumTopicID")]
        public string ForumTopicID { get; set; }
        [JsonProperty("ConsoleID")]
        public string ConsoleID { get; set; }
        [JsonProperty("ConsoleName")]
        public string ConsoleName { get; set; }
        [JsonProperty("Flags")]
        public object Flags { get; set; }
        [JsonProperty("ImageIcon")]
        public string ImageIcon { get; set; }
        [JsonProperty("GameIcon")]
        public string GameIcon { get; set; }
        [JsonProperty("ImageTitle")]
        public string ImageTitle { get; set; }
        [JsonProperty("ImageIngame")]
        public string ImageIngame { get; set; }
        [JsonProperty("ImageBoxArt")]
        public string ImageBoxArt { get; set; }
        [JsonProperty("Publisher")]
        public string Publisher { get; set; }
        [JsonProperty("Developer")]
        public string Developer { get; set; }
        [JsonProperty("Genre")]
        public string Genre { get; set; }
        [JsonProperty("Released")]
        public string Released { get; set; }
        [JsonProperty("GameTitle")]
        public string GameTitle { get; set; }
        [JsonProperty("Console")]
        public string Console { get; set; }

        [JsonProperty("Achievements")]
        public List<Achievement> Achievements { get; set; }

        [JsonProperty("LastPlayed")]
        public string LastPlayed { get; set; }
        

        public bool hasAchievements = true;

        public Image imgTitleScreen;
        public Image imgIngame;
        public Image imgBoxArt;
        public Image imgIcon;
        
        public Game()
        {
            Achievements = new List<Achievement>();
        }

        public Game(JToken j)
        {
            // Assign Values
            if (j["Title"] != null)
                Title = (string)j["Title"];
            if (j["ID"] != null)
                ID = (string)j["ID"];
            if (j["ConsoleID"] != null)
                ConsoleID = (string)j["ConsoleID"];
            if (j["ConsoleName"] != null)
                Console = (string)j["ConsoleName"];
            if (j["ForumTopicID"] != null)
                ForumTopicID = (string)j["ForumTopicID"];
            if (j["ConsoleName"] != null)
                ConsoleName = (string)j["ConsoleName"];
            if (j["Flags"] != null)
                Flags = (string)j["Flags"];
            if (j["ImageIcon"] != null)
                ImageIcon = (string)j["ImageIcon"];
            if (j["GameIcon"] != null)
                GameIcon = (string)j["GameIcon"];
            if (j["ImageTitle"] != null)
                ImageTitle = (string)j["ImageTitle"];
            if (j["ImageIngame"] != null)
                ImageIngame = (string)j["ImageIngame"];
            if (j["ImageBoxArt"] != null)
                ImageBoxArt = (string)j["ImageBoxArt"];
            if (j["Publisher"] != null)
                Publisher = (string)j["Publisher"];
            if (j["Developer"] != null)
                Developer = (string)j["Developer"];
            if (j["Genre"] != null)
                Genre = (string)j["Genre"];
            if (j["Released"] != null)
                Released = (string)j["Released"];



            // Create new list of achievements
            Achievements = new List<Achievement>();

            // Extra attributes from other queries
            if (j["LastPlayed"] != null)
            {
                LastPlayed = (string)j["LastPlayed"];
            }
            if (j["GameID"] != null)
            {
                ID = (string)j["GameID"];
            }
        }

        //public void AutoFill()
        //{
        //    //// Get data
        //    //string gameURL = Requests.requestURL(Constants.QueryTypes.WEB_GAME_INFO_AND_PROGRESS, ID);
        //    //string json = Requests.FetchJSON(gameURL);
        //    //dynamic data = JsonConvert.DeserializeObject(json);

        //    //// Assign values
        //    //ForumTopicID data
        //    //ConsoleID 
        //    //ConsoleName 
        //    //Flags 
        //    //ImageIcon 
        //    //GameIcon 
        //    //ImageTitle 
        //    //ImageIngame 
        //    //ImageBoxArt 
        //    //Publisher 
        //    //Developer 
        //    //Genre 
        //    //Released 
        //    //Console 

        //}

      
    }
}
