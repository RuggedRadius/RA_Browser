using ClosedXML.Excel;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RA_API.Models;
using RA_API.Modules;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RA_API.Connection
{
    class Data
    {
        // Global Data
        public static Main main;
        public static StoredData globalData;

        public static bool receivingData;

        // Counters
        public static int GetCount_Console()
        {
            // Update games counter
            if (globalData != null)
            {
                if (globalData.consoles != null)
                {
                    return globalData.consoles.Count;
                }
            }
            return 0;
        }
        public static int GetCount_Games()
        {
            int gamesCount = 0;
            if (globalData != null)
            {
                if (globalData.consoles != null)
                {
                    foreach (SupportedConsole console in Data.globalData.consoles)
                    {
                        if (console.games != null)
                        {
                            gamesCount += console.games.Count;
                        }
                    }
                    return gamesCount;
                }
            }
            return gamesCount;
        }
        public static int GetCount_Achievements()
        {
            int achievementsCount = 0;
            if (globalData != null)
            {
                if (globalData.consoles != null)
                {
                    foreach (SupportedConsole console in Data.globalData.consoles)
                    {
                        if (console.games != null)
                        {
                            foreach (Game game in console.games)
                            {
                                if (game.Achievements != null)
                                {
                                    achievementsCount += game.Achievements.Count;
                                }
                            }
                        }
                    }
                }
            }
            return achievementsCount;
        }
        public static int GetCount_Images()
        {
            int imageCount = 0;
            if (globalData != null)
            {
                if (globalData.consoles != null)
                {
                    foreach (SupportedConsole console in Data.globalData.consoles)
                    {
                        if (console.games != null)
                        {
                            foreach (Game game in console.games)
                            {
                                if (game.imgBoxArt != null)
                                {
                                    imageCount++;
                                }
                                if (game.imgTitleScreen != null)
                                {
                                    imageCount++;
                                }
                                if (game.imgIngame != null)
                                {
                                    imageCount++;
                                }
                                if (game.imgIcon != null)
                                {
                                    imageCount++;
                                }
                            }
                        }
                    }
                }
            }
            return imageCount;
        }

        // Download
        public static void DownloadConsoleList_CreateObjects()
        {
            main.UpdateStatus("Downloading console list...");
            Console.WriteLine("Downloading console data...");

            receivingData = true;

            // Fetch console list
            string url = Requests.requestURL(Constants.QueryTypes.WEB_CONSOLE_IDs, null);
            string json = Requests.FetchJSON(url);

            // Populate list of console IDs
            dynamic data = JsonConvert.DeserializeObject(json);

            if (data["console"][0] != null)
            {
                if (globalData == null)
                {
                    globalData = new StoredData();
                }

                // Create list of consoles
                globalData.consoles = new List<SupportedConsole>();

                foreach (JObject j in data["console"][0])
                {
                    // Create console object
                    SupportedConsole sc = new SupportedConsole(j);

                    // Add console to list
                    globalData.consoles.Add(sc);

                    Console.WriteLine("Added console: " + sc.Name);
                }
            }
            else
            {
                MessageBox.Show(
                    "No data received for consoles, check your credentials in Settings.",
                    "No data received",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                    );
            }
            receivingData = false;

            main.UpdateStatus(string.Empty);

        }
        public static void DownloadGameList_CreateObjects()
        {
            Console.WriteLine("Downloading game data...");

            receivingData = true;


            // For each supported console
            foreach (SupportedConsole sc in globalData.consoles)
            {
                main.UpdateStatus("Downloading games list for" + sc.Name + "...");

                // Fetch console list
                string url = Requests.requestURL(Constants.QueryTypes.WEB_GAME_LIST, sc.ID);
                string json = Requests.FetchJSON(url);

                // Populate list of console IDs
                dynamic data = JsonConvert.DeserializeObject(json);

                // Create list of Games
                if (data["game"][0] != null)
                {
                    foreach (JObject j in data["game"][0])
                    {
                        // Create console object
                        Game newGame = new Game(j);

                        // Adds Game object to list in console's class
                        sc.games.Add(newGame);

                        Console.WriteLine("Added game: " + newGame.Title);
                    }
                }

                receivingData = false;


                main.UpdateStatus(string.Empty);

            }
        }
        public static void DownloadAchievementList()
        {
            main.UpdateStatus("Downloading all achievement data...");
            Console.WriteLine("Downloading achievement data...");

            receivingData = true;


            if (globalData != null)
            {
                if (globalData.consoles != null)
                {
                    // For each supported console
                    foreach (SupportedConsole sc in globalData.consoles)
                    {
                        foreach (Game g in sc.games)
                        {
                            // Fetch console list
                            string url = Requests.requestURL(Constants.QueryTypes.WEB_GAME_INFO_AND_PROGRESS, g.ID);
                            string json = Requests.FetchJSON(url);

                            // Populate list of console IDs
                            dynamic data = JsonConvert.DeserializeObject(json);

                            // Create list of Games
                            if (data["Achievements"] != null)
                            {
                                foreach (JProperty a in data["Achievements"])
                                {
                                    Achievement ac = new Achievement(a.Value);
                                    g.Achievements.Add(ac);
                                }
                            }
                        }
                    }
                }
            }

            receivingData = false;

        }
        public static void DownloadAllData() //async 
        {
            // New database object
            globalData = new StoredData();
            receivingData = true;

            DownloadConsoleList_CreateObjects();
            DownloadGameList_CreateObjects();
            //DownloadAchievementList();

            receivingData = false;

        }

        // Achievements
        public static void DownloadAchievements_ByGame(Game game)
        {
            // Fetch console list
            string url = Requests.requestURL(Constants.QueryTypes.WEB_GAME_INFO_AND_PROGRESS, game.ID);
            string json = Requests.FetchJSON(url);

            receivingData = true;


            // Populate list of console IDs
            dynamic data = JsonConvert.DeserializeObject(json);

            // Check list exists, if not then create one
            if (game.Achievements == null)
                game.Achievements = new List<Achievement>();

            // Create list of Games
            if (data["Achievements"] != null)
            {
                foreach (JProperty a in data["Achievements"])
                {
                    Achievement ac = new Achievement(a.Value);
                    game.Achievements.Add(ac);
                }
            }
            else
            {   // TEST WITH BREAKPOINT TO MAKE SURE THIS WORKS WITH GAME - NO ACHIEVEMENTS
                game.hasAchievements = false;
            }

            receivingData = false;

        }
        public static Achievement GetLocalAchievement_ByID(string achievementID)
        {
            if (globalData != null)
            {
                if (globalData.consoles != null)
                {
                    foreach (SupportedConsole sc in globalData.consoles)
                    {
                        foreach (Game g in sc.games)
                        {
                            if (g.Achievements != null)
                            {
                                foreach (Achievement a in g.Achievements)
                                {
                                    if (a.ID == achievementID)
                                    {
                                        return a;
                                    }
                                }
                            }
                        }
                    }
                }
                Console.WriteLine("No achievement found for ID: " + achievementID);
                return null;
            }
            else
            {
                MessageBox.Show("No global data to read.", "No global data.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        // Console
        public static SupportedConsole GetLocalConsole_byName(string consoleName)
        {
            if (globalData != null)
            {
                foreach (SupportedConsole sc in globalData.consoles)
                {
                    if (sc.Name == consoleName)
                    {
                        return sc;
                    }
                }
            }
            Console.WriteLine("No console found by that name: " + consoleName);
            return null;
        }
        public static Image getConsoleImage(SupportedConsole sc)
        {
            switch (sc.Name)
            {
                case "Mega Drive":
                    return ConsoleInformation.ConsoleImages.MegaDrive;
                case "Game Boy":
                    return ConsoleInformation.ConsoleImages.GameBoy;
                case "Game Boy Color":
                    return ConsoleInformation.ConsoleImages.GameBoyColor;
                case "Game Boy Advance":
                    return ConsoleInformation.ConsoleImages.GameBoyAdvance;
                case "SNES":
                    return ConsoleInformation.ConsoleImages.SNES;
                case "NES":
                    return ConsoleInformation.ConsoleImages.NES;
                case "Nintendo 64":
                    return ConsoleInformation.ConsoleImages.Nintendo64;
                case "Master System":
                    return ConsoleInformation.ConsoleImages.MasterSystem;
                case "PlayStation":
                    return ConsoleInformation.ConsoleImages.PlayStation;
                case "Atari Lynx":
                    return ConsoleInformation.ConsoleImages.AtariLynx;
                case "Neo Geo Pocket":
                    return ConsoleInformation.ConsoleImages.NeoGeoPocket;
                case "Game Gear":
                    return ConsoleInformation.ConsoleImages.GameGear;
                case "GameCube":
                    return ConsoleInformation.ConsoleImages.GameCube;
                case "Atari Jaguar":
                    return ConsoleInformation.ConsoleImages.AtariJaguar;
                case "Nintendo DS":
                    return ConsoleInformation.ConsoleImages.NintendoDS;
                case "Wii":
                    return ConsoleInformation.ConsoleImages.Wii;
                case "Wii U":
                    return ConsoleInformation.ConsoleImages.WiiU;
                case "PlayStation 2":
                    return ConsoleInformation.ConsoleImages.PlayStation2;
                case "Xbox":
                    return ConsoleInformation.ConsoleImages.Xbox;
                case "Pokemon Mini":
                    return ConsoleInformation.ConsoleImages.PokemonMini;
                case "Atari 2600":
                    return ConsoleInformation.ConsoleImages.Atari2600;
                case "DOS":
                    return ConsoleInformation.ConsoleImages.DOS;
                case "Arcade":
                    return ConsoleInformation.ConsoleImages.Arcade;
                case "Virtual Boy":
                    return ConsoleInformation.ConsoleImages.VirtualBoy;
                case "MSX":
                    return ConsoleInformation.ConsoleImages.MSX;
                case "Commodore 64":
                    return ConsoleInformation.ConsoleImages.Commodore64;
                case "ZX81":
                    return ConsoleInformation.ConsoleImages.ZX81;
                case "Oric":
                    return ConsoleInformation.ConsoleImages.Oric;
                case "SG-1000":
                    return ConsoleInformation.ConsoleImages.SG_1000;
                case "VIC-20":
                    return ConsoleInformation.ConsoleImages.VIC_20;
                case "Amiga":
                    return ConsoleInformation.ConsoleImages.Amiga;
                case "Atari ST":
                    return ConsoleInformation.ConsoleImages.AtariST;
                case "Amstrad CPC":
                    return ConsoleInformation.ConsoleImages.AmstradCPC;
                case "Apple II":
                    return ConsoleInformation.ConsoleImages.AppleII;
                case "Saturn":
                    return ConsoleInformation.ConsoleImages.Saturn;
                case "Dreamcast":
                    return ConsoleInformation.ConsoleImages.Dreamcast;
                case "PlayStation Portable":
                    return ConsoleInformation.ConsoleImages.PlayStationPortable;
                case "Philips CD-i":
                    return ConsoleInformation.ConsoleImages.PhilipsCD_i;
                case "3DO Interactive Multiplayer":
                    return ConsoleInformation.ConsoleImages._3DOInteractiveMultiplayer;
                case "ColecoVision":
                    return ConsoleInformation.ConsoleImages.ColecoVision;
                case "Intellivision":
                    return ConsoleInformation.ConsoleImages.Intellivision;
                case "Vectrex":
                    return ConsoleInformation.ConsoleImages.Vectrex;
                case "PC-8000/8800":
                    return ConsoleInformation.ConsoleImages.PC8000_8800;
                case "PC-9800":
                    return ConsoleInformation.ConsoleImages.PC9800;
                case "PC-FX":
                    return ConsoleInformation.ConsoleImages.PC_FX;
                case "Atari 5200":
                    return ConsoleInformation.ConsoleImages.Atari5200;
                case "Super Cassette Vision":
                    return ConsoleInformation.ConsoleImages.SuperCassetteVision;
                case "Atari 7800":
                    return ConsoleInformation.ConsoleImages.Atari7800;
                case "X68K":
                    return ConsoleInformation.ConsoleImages.X68K;
                case "WonderSwan":
                    return ConsoleInformation.ConsoleImages.WonderSwan;
                case "Cassette Vision":
                    return ConsoleInformation.ConsoleImages.CassetteVision;
                case "PC Engine":
                    return ConsoleInformation.ConsoleImages.PCEngine;
                case "Sega CD":
                    return ConsoleInformation.ConsoleImages.SegaCD;
                case "32X":
                    return ConsoleInformation.ConsoleImages._32X;








                default:
                    return null;
            }
        }

        // Game
        public static void DownloadGames_ForConsole(SupportedConsole sc)
        {
            main.UpdateStatus("Downloading games for " + sc.Name + "...");

            receivingData = true;


            // Fetch console list
            string url = Requests.requestURL(Constants.QueryTypes.WEB_GAME_LIST, sc.ID);
            string json = Requests.FetchJSON(url);

            // Populate list of console IDs
            dynamic data = JsonConvert.DeserializeObject(json);

            // Create list of Games
            if (data["game"][0] != null)
            {
                sc.games = new List<Game>();

                foreach (JObject j in data["game"][0])
                {
                    // Create console object
                    Game newGame = new Game(j);

                    // Adds Game object to list in console's class
                    sc.games.Add(newGame);

                    Console.WriteLine("Added game: " + newGame.Title);
                }
            }
            receivingData = false;

            main.UpdateStatus(string.Empty);

        }
        public static void GameData_Download(Game g)
        {

            main.UpdateStatus("Downloading data for " + g.Title);

            receivingData = true;


            string url = Requests.requestURL(Constants.QueryTypes.WEB_GAME_INFO_AND_PROGRESS, g.ID);
            string json = Requests.FetchJSON(url);
            dynamic data = JsonConvert.DeserializeObject(json);


            if (data != null)
            {
                if (g.Console == null)
                {
                    if (data["Console"] == null)
                    {
                        g.Console = "<No data>";
                    }
                    else
                    {
                        g.Console = data["Console"];
                    }
                    Console.WriteLine(g.Title + " console updated.");
                }
                if (g.Publisher == null)
                {
                    if (data["Publisher"] == null)
                    {
                        g.Publisher = "<No data>";
                    }
                    else
                    {
                        g.Publisher = data["Publisher"];
                    }
                    Console.WriteLine(g.Title + " publisher updated.");
                }
                if (g.Developer == null)
                {
                    if (data["Developer"] == null)
                    {
                        g.Developer = "<No data>";
                    }
                    else
                    {
                        g.Developer = data["Developer"];
                    }
                    Console.WriteLine(g.Title + " developer updated.");
                }
                if (g.Released == null)
                {
                    if (data["Released"] == null)
                    {
                        g.Released = "<No data>";
                    }
                    else
                    {
                        g.Released = data["Released"];
                    }
                    Console.WriteLine(g.Title + " release date updated.");
                }
                if (g.imgBoxArt == null)
                {
                    if (data["ImageBoxArt"] == null)
                    {
                        g.imgBoxArt = Properties.Resources.maxresdefault;
                    }
                    else
                    {
                        g.imgBoxArt = Requests.DownloadImageFromUrl(Requests.GetImageURL_byGameObject(g, 3));
                    }
                }
                if (g.imgTitleScreen == null)
                {
                    if (data["ImageTitle"] == null)
                    {
                        g.imgTitleScreen = Properties.Resources.maxresdefault;
                    }
                    else
                    {
                        try
                        {
                            g.imgTitleScreen = Requests.DownloadImageFromUrl(Requests.GetImageURL_byGameObject(g, 1));
                        }
                        catch (Exception ex)
                        { }
                    }
                }
                if (g.imgIngame == null)
                {
                    if (data["ImageIngame"] == null)
                    {
                        g.imgIngame = Properties.Resources.maxresdefault;
                    }
                    else
                    {
                        try
                        {
                            g.imgIngame = Requests.DownloadImageFromUrl(Requests.GetImageURL_byGameObject(g, 2));
                        }
                        catch (Exception ex)
                        { }
                    }
                }
                if (g.Achievements == null)
                {
                    if (data["Achievements"] == null)
                    {
                        g.hasAchievements = false;
                    }
                    else
                    {
                        g.Achievements = new List<Achievement>();

                        foreach (JProperty a in data["Achievements"])
                        {
                            Achievement ac = new Achievement(a.Value);
                            g.Achievements.Add(ac);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Could not download data.", "Error downloading data", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            receivingData = false;

            main.UpdateStatus(string.Empty);

        }
        public static Game CreateGame_fromIDQuery(int id)
        {
            // Fetch console list
            string url = Requests.requestURL(Constants.QueryTypes.WEB_GAME_INFO_AND_PROGRESS, id.ToString());
            string json = Requests.FetchJSON(url);

            // Populate list of console IDs
            dynamic data = JsonConvert.DeserializeObject(json);
            
            // Create game object
            Game newGame = new Game(data);
            return newGame;            
        }
        public static Game GetLocalGame_byID(int id)
        {
            if (globalData != null)
            {
                if (globalData.consoles != null)
                {
                    Console.WriteLine("Searching consoles for game ID:" + id);
                    foreach (SupportedConsole sc in globalData.consoles)
                    {
                        foreach (Game g in sc.games)
                        {
                            if (g.ID == id.ToString())
                            {
                                return g;
                            }
                        }
                    }
                }
                Console.WriteLine("No game found for ID: " + id);
                return null;
            }
            else
            {
                MessageBox.Show("No global data to read.", "No global data.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        public static Game GetLocalGame_byIDandConsole(SupportedConsole sc, string id)
        {

            if (globalData != null)
            {
                if (sc.games != null)
                {
                    foreach (Game game in sc.games)
                    {
                        if (game.ID == id)
                        {
                            return game;
                        }
                    }
                }
            }
            return null;
        }
        public static Game GetLocalGame_byAchievement(Achievement achievement)
        {
            if (globalData != null)
            {
                foreach (SupportedConsole console in globalData.consoles)
                {
                    foreach (Game game in console.games)
                    {
                        foreach (Achievement a in game.Achievements)
                        {
                            if (a.ID == achievement.ID)
                            {
                                return game;
                            }
                        }
                    }
                }
        

            }
            return null;
        }

        public static Game CreateGame_LastPlayedGame(dynamic data)
        {
            main.UpdateStatus("Creating last played game..");
            try
            {
                // Extract achievements from gameObject into individual objects
                if (data["LastGameID"] != null)
                {
                    return Data.CreateGame_fromIDQuery(data["LastGameID"]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error creating Last Played Game.\n\n" + ex.ToString(),
                    "Error creating Game",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                    );
            }
            main.UpdateStatus(string.Empty);

            return null;
        }
        public static List<Game> createObjects_RecentlyPlayedGames(dynamic data)
        {
            main.UpdateStatus("Creating recently played games...");
            // Create new list of objects
            List<Game> recentlyPlayedGames = new List<Game>();
            try
            {
                // Extract achievements from gameObject into individual objects
                if (data["RecentlyPlayed"] != null)
                {
                    foreach (JObject g in data["RecentlyPlayed"])
                    {
                        Game rpg = new Game(g);
                        recentlyPlayedGames.Add(rpg);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error creating Recently Played Games.\n\n" + ex.ToString(),
                    "Error creating Game",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                    );
            }
            main.UpdateStatus(string.Empty);

            return recentlyPlayedGames;
        }
        public static List<Game> GetRecentlyPlayedGames(dynamic data)
        {
            main.UpdateStatus("Fetching recently played games");

            // New list
            List<Game> recentlyPlayedGames = new List<Game>();

            // For each game in results
            foreach (JObject jo in data["RecentlyPlayed"])
            {
                // Get game
                string gameID = jo["GameID"].ToString();
                string consoleID = jo["ConsoleID"].ToString();
                string consoleName = jo["ConsoleName"].ToString();
                SupportedConsole currentConsole = GetLocalConsole_byName(consoleName);
                Game game = GetLocalGame_byIDandConsole(currentConsole, gameID);

                // Check if found local game
                if (game == null)
                {
                    // If not, download individual game
                    Console.WriteLine("No local game found for Game ID: " + gameID);

                    // Download game
                    game = DownloadGame_ByID(gameID);

                    // Add game to it's console
                    currentConsole.games.Add(game);
                }
                // Add game to return list
                recentlyPlayedGames.Add(game);
            }
            main.UpdateStatus(string.Empty);
            return recentlyPlayedGames;
        }
        public static Game DownloadGame_ByID(string id)
        {
            receivingData = true;

            string url = Requests.requestURL(Constants.QueryTypes.WEB_GAME_INFO_AND_PROGRESS, id);
            string json = Requests.FetchJSON(url);
            dynamic data = JsonConvert.DeserializeObject(json);
            receivingData = false;

            return new Game(data);
        }
        // Image Downloading
        public static Image gameImage_DownloadTitleScreen(Game game)
        {
            receivingData = true;

            string imgURL = Requests.GetImageURL_TitleScreenbyID(Int32.Parse(game.ID));
            game.imgTitleScreen = Requests.DownloadImageFromUrl(imgURL);
            receivingData = false;

            return game.imgTitleScreen;
        }
        public static Image gameImage_DownloadInGame(Game game)
        {
            string imgURL = Requests.GetImageURL_InGamebyID(Int32.Parse(game.ID));
            game.imgIngame = Requests.DownloadImageFromUrl(imgURL);
            receivingData = false;

            return game.imgIngame;
        }
        public static Image gameImage_DownloadBoxArt(Game game)
        {
            receivingData = true;

            string imgURL = Requests.GetImageURL_BoxArtbyID(Int32.Parse(game.ID));
            game.imgBoxArt = Requests.DownloadImageFromUrl(imgURL);
            receivingData = false;

            return game.imgBoxArt;
        }

        // User Data
        public static dynamic User_FetchData()
        {
            //receivingData = true;

            string url = Requests.requestURL(Constants.QueryTypes.WEB_USER_SUMMARY, Properties.Settings.Default.Credential_Username);
            string mostRecentJson = Requests.FetchJSON(url);
            //receivingData = false;

            return JsonConvert.DeserializeObject(mostRecentJson);
        }
        
    }
}
