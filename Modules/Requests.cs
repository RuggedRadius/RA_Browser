using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RA_API.Connection;
using RA_API.Models;

using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RA_API.Connection
{
    class Requests
    {
        public static async Task<JObject> FetchData(string gameID, string query)
        {
            if (Utilities.InternetConnected())
            {
                try
                {
                    // Fetch json string
                    string jsonString = FetchJSON(requestURL(query, gameID));

                    // Make JSON object from string                   
                    return JsonConvert.DeserializeObject<dynamic>(jsonString);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "Error fetching data, check credentials.\r\n\r\nDetails:\r\n" + ex.ToString(),
                        "Error fetching data",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                        );
                    return null;
                }
            }
            else
            {
                MessageBox.Show(
                    "Check internet connection and/or firewall access",
                    "Internet connection error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                    );
            }
            return null;
        }

        public static string FetchJSON (string url)
        {
            // Fetch JSON string
            var webClient = new WebClient();
            string jsonString = webClient.DownloadString(url);


            Console.WriteLine("Downloading JSON from " + url);
            return jsonString;
        }

        public static string requestURL (string query, string param)
        {
            switch (query)
            {
                case Constants.QueryTypes.WEB_TOP_TEN_USERS:
                    return String.Format(
                        "https://ra.hfc-essentials.com/{0}?user={1}&key={2}&mode=json",
                        Constants.QueryTypes.WEB_TOP_TEN_USERS,
                        Properties.Settings.Default.Credential_Username,
                        Properties.Settings.Default.Credential_APIKey
                        );

                case Constants.QueryTypes.WEB_CONSOLE_IDs:
                    return String.Format(
                        "{0}{1}?user={2}&key={3}&mode=json",
                        Constants.BASE_URL,
                        query,
                        Properties.Settings.Default.Credential_Username,
                        Properties.Settings.Default.Credential_APIKey
                        ); ;

                case Constants.QueryTypes.WEB_GAME_LIST:
                    return String.Format(
                        "{0}{1}?user={2}&key={3}&console={4}&mode=json",
                        Constants.BASE_URL,
                        query,
                        Properties.Settings.Default.Credential_Username,
                        Properties.Settings.Default.Credential_APIKey,
                        param
                        );

                case Constants.QueryTypes.WEB_GAME_INFO_BASIC:
                    return String.Format(
                        "{0}{1}?user={2}&key={3}&game={4}&mode=json",
                        Constants.BASE_URL,
                        query,
                        Properties.Settings.Default.Credential_Username,
                        Properties.Settings.Default.Credential_APIKey,
                        param
                        );

                case Constants.QueryTypes.WEB_GAME_INFO_EXTENDED:
                    return String.Format(
                        "{0}{1}?user={2}&key={3}&game={4}&mode=json",
                        Constants.BASE_URL,
                        query,
                        Properties.Settings.Default.Credential_Username,
                        Properties.Settings.Default.Credential_APIKey,
                        param
                        );

                case Constants.QueryTypes.WEB_GAME_INFO_AND_PROGRESS:
                    return String.Format(
                        "{0}{1}?user={2}&key={3}&game={4}&mode=json",
                        Constants.BASE_URL,
                        query,
                        Properties.Settings.Default.Credential_Username,
                        Properties.Settings.Default.Credential_APIKey,
                        param
                        );

                case Constants.QueryTypes.WEB_USER_RANK_AND_SCORE:
                    //https://ra.hfc-essentials.com/user_rank.php?user=+YOUR_RA_USERNAME+&key=+YOUR_API_KEY+&game=3&member=Adultery&mode=json
                    return String.Format(
                        "{0}{1}?user={2}&key={3}&member=Adultery&mode=json",
                        Constants.BASE_URL,
                        query,
                        Properties.Settings.Default.Credential_Username,
                        Properties.Settings.Default.Credential_APIKey
                        );

                case Constants.QueryTypes.WEB_USER_RECENTLY_PLAYED_GAMES:
                    return null;

                case Constants.QueryTypes.WEB_USER_PROGRESS:
                    return null;

                case Constants.QueryTypes.WEB_USER_SUMMARY:
                    return String.Format(
                        "{0}{1}?user={2}&key={3}&member=Adultery&results=10&mode=json",
                        Constants.BASE_URL,
                        query,
                        Properties.Settings.Default.Credential_Username,
                        Properties.Settings.Default.Credential_APIKey
                        );

                // looks like a useless feed
                case Constants.QueryTypes.WEB_USER_FEED:
                    return null;

                // Dates are in UNIX format... whatever the fuck that is...
                case Constants.QueryTypes.WEB_USER_ACHIEVEMENTS_BY_DATE:
                    //	https://ra.hfc-essentials.com/user_by_date.php?user=+YOUR_RA_USERNAME+&key=+YOUR_API_KEY+&member=Adultery&startdate=1576166048&enddate=1574956448&mode=json



                    // do fancy magic here param to convert to the offset for date in unix format
                    //....


                    // Make UNIX time stamps for query
                    Int32 unixTimestamp_Start = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 14))).TotalSeconds; // Set 2 two weeks? i think..
                    Int32 unixTimestamp_End = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;

                    return String.Format(
                    "{0}{1}?user={2}&key={3}&member=Adultery&startdate={4}&enddate={5}&mode=json",
                    Constants.BASE_URL,
                    query,
                    Properties.Settings.Default.Credential_Username,
                    Properties.Settings.Default.Credential_APIKey,
                    unixTimestamp_Start,
                    unixTimestamp_End
                    );

                default:
                    return null;
            }
        }


        // SLOW METHOD OVER LOTS OF GAMES
        public static string GetImageURL_BoxArtbyID(int id)
        {
            string reqURL = requestURL(Constants.QueryTypes.WEB_GAME_INFO_BASIC, id.ToString());

            // SLOW!!!!!!!!!!!!!!!!! OVER 1000's of games
            string json = FetchJSON(reqURL);

            // Init base of image url
            dynamic data = JsonConvert.DeserializeObject(json);
            string boxArtURL = "https://s3-eu-west-1.amazonaws.com/i.retroachievements.org";
            boxArtURL += data["ImageBoxArt"];
            Console.WriteLine("Fetching Box Art URL: " + boxArtURL);
            return boxArtURL;
        }

        public static string GetImageURL_InGamebyID(int id)
        {
            string reqURL = requestURL(Constants.QueryTypes.WEB_GAME_INFO_BASIC, id.ToString());
            string json = FetchJSON(reqURL);

            // Init base of image url
            dynamic data = JsonConvert.DeserializeObject(json);
            string inGameArtURL = "https://s3-eu-west-1.amazonaws.com/i.retroachievements.org";
            inGameArtURL += data["ImageIngame"];
            Console.WriteLine("Fetching Screenshot URL: " + inGameArtURL);
            return inGameArtURL;
        }

        public static string GetImageURL_TitleScreenbyID(int id)
        {
            string reqURL = requestURL(Constants.QueryTypes.WEB_GAME_INFO_BASIC, id.ToString());
            string json = FetchJSON(reqURL);

            // Init base of image url
            dynamic data = JsonConvert.DeserializeObject(json);
            string inGameArtURL = "https://s3-eu-west-1.amazonaws.com/i.retroachievements.org";
            inGameArtURL += data["ImageTitle"];
            Console.WriteLine("Fetching Screenshot URL: " + inGameArtURL);
            return inGameArtURL;
        }

        public static string GetBadgeUrlFromAchievement(Achievement achievement)
        {
            if (achievement.DateEarned != null)
            {
                return String.Format("http://retroachievements.org/Badge/{0}.png", achievement.BadgeName);
            }
            else
            {
                return String.Format("http://retroachievements.org/Badge/{0}_lock.png", achievement.BadgeName);
            }
        }

        public static Image DownloadImageFromUrl(string url)
        {
            // Create new empty image
            Image img = null;

            // Request the image through webRequest
            var webRequest = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create(url);
            webRequest.AllowWriteStreamBuffering = true;
            webRequest.Timeout = 30000;

            // Create webreponse to stream from
            System.Net.WebResponse webResponse = webRequest.GetResponse();

            // Create stream from webResponse
            Stream stream = webResponse.GetResponseStream();

            // Write stream to image
            img = Image.FromStream(stream);

            // Close webResponse
            webResponse.Close();

            // Return the new image
            return img;
        }


        // For achievements
        public static string GetImageURL(dynamic data, int imageSelection)
        {
            // Init base of image url
            string coverImgURL = "https://s3-eu-west-1.amazonaws.com/i.retroachievements.org";
            Console.WriteLine("Fetching Image URL: " + coverImgURL);
            switch (imageSelection)
            {
                case 0:
                    //coverImgURL += data["RecentlyPlayed"] .Value<JToken>("ImageIcon").ToString();
                    //break;
                case 1:
                    coverImgURL += data.Value<JToken>("ImageTitle").ToString();
                    break;
                case 2:
                    coverImgURL += data.Value<JToken>("ImageIngame").ToString();
                    break;
                case 3:
                    coverImgURL += data.Value<JToken>("ImageBoxArt").ToString();
                    break;
            }
            return coverImgURL;
        }

        public static string GetImageURL_byGameObject(Game g, int imageSelection)
        {
            // Init base of image url
            string imageURL = "https://s3-eu-west-1.amazonaws.com/i.retroachievements.org";

            string reqURL = requestURL(Constants.QueryTypes.WEB_GAME_INFO_BASIC, g.ID);
            string json = FetchJSON(reqURL);
            dynamic data = JsonConvert.DeserializeObject(json);

            //data[""]

            switch (imageSelection)
            {
                case 0:
                    imageURL += g.imgIcon;
                    imageURL += data["ImageIcon"];
                    break;
                case 1:
                    imageURL += g.imgTitleScreen;
                    imageURL += data["ImageTitle"];
                    break;
                case 2:
                    imageURL += g.imgIngame;
                    imageURL += data["ImageIngame"];
                    break;
                case 3:
                    imageURL += g.imgBoxArt;
                    imageURL += data["ImageBoxArt"];
                    break;
            }
            return imageURL;
        }
    }
}
