using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RA_API.Modules;
using RA_API.Displays;
using RA_API.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using RA_API.Properties;
using RA_API.Connection;

namespace RA_API
{
    public partial class Main : Form
    {

        #region // Global Variables
        // !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!SHOULDNT NEED THIS, START BY COMMENTING THIS AND FIXING FOLLOW-ON ERRORS
        dynamic data;

        public List<PictureBox> recentlyPlayedCovers;
        //List<RecentlyPlayedGame> recentlyPlayedGames;
        List<User> top10Users;
        
        //public static string statusText;
        #endregion

        #region // MAIN

        // LOADING & SAVING
        public Main()
        {
            InitializeComponent();
        }
        private void User_Load(object sender, EventArgs e)
        {
            // TEMP!!!
            //string hm = Requests.requestURL(Constants.QueryTypes.WEB_USER_USER_ACHIEVEMENTS_BY_DATE_RANGE, "7");

            Form_Format();


            Data.main = this;

            // First time startup check
            if (Settings.Default.Credential_Username == string.Empty || Settings.Default.Credential_APIKey == string.Empty)
            {

            }
            // Go ahead with data requests
            else
            {
                // Load settings into controls
                LoadSettings();

                // Load saved data
                if (Settings.Default.onStartUp_LoadData)
                {
                    FileHandling.LoadAllData();
                    updateCounters();
                    PopulateMenu_Consoles();
                    statLblStatus.Text = "Data loaded.";
                }
                else
                {
                    Data.globalData = new StoredData();
                }

                // Fetch User summary
                if (Settings.Default.onStartUp_LoadUserProfile)
                {
                    // Show user profile
                    Task.Run(() => ShowUserData());

                }

                // Populate leaderboard
                if (Settings.Default.onStartUp_PopulateLeaderBoard)
                {
                    Task.Run(() => PopulateLeaderBoard());
                }
            }

            // Launch stats timer
            LaunchStatisticsTimer();
        }

        private void Form_Format()
        {
            //var grpBoxes = tabsMain. Controls.OfType<GroupBox>();
            var grpBoxes = GetAll(tabsMain, typeof(GroupBox));

            // Groupboxes
            foreach (GroupBox gb in grpBoxes)
            {
                gb.Font = new Font("Verdana", 16, FontStyle.Bold);
                Console.WriteLine("Formatted " + gb.Name);
            }

            var labels = GetAll(tabsMain, typeof(Label));

            foreach (Label l in labels)
            {
                l.Font = new Font("Verdana", 12, FontStyle.Regular);
            }



        }

        public IEnumerable<Control> GetAll(Control control, Type type)
        {
            var controls = control.Controls.Cast<Control>();

            return controls.SelectMany(ctrl => GetAll(ctrl, type))
                                      .Concat(controls)
                                      .Where(c => c.GetType() == type);
        }

        private void LoadSettings()
        {
            // Credentials
            txtUsername.Text = Settings.Default.Credential_Username;
            txtAPIKey.Text = Settings.Default.Credential_APIKey;

            // Load settings values and populate controls for UI
            cbSettings_OnstartUp_LoadData.Checked = Settings.Default.onStartUp_LoadData;
            cbSettings_OnStartUp_LoadUserProfile.Checked = Settings.Default.onStartUp_LoadUserProfile;
            cbSettings_onStartUp_PopulateLeaderBoard.Checked = Settings.Default.onStartUp_PopulateLeaderBoard;
            cbSettings_OnExit_SaveDataToFile.Checked = Settings.Default.onExit_SaveDataToFile;
            statLblStatus.Text = "Settings loaded.";
        }
        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings.Default.Save();
        }

        // TAB NAVIGATION
        private void tabsMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Stop fetching data if leaving a page
            if (tabsMain.SelectedIndex != 2 && gameBrowser_Fetching)
            {
                btnGameBrowser_FetchToggle_Click(sender, e);
            }


            // Check internet connection
            if (Utilities.InternetConnected())
            {
                // Don't action anything if populating data
                if (!Data.receivingData)
                {
                    switch (tabsMain.SelectedIndex)
                    {
                        // User Profile
                        case 0:
                            //ShowUserData();
                            break;

                        // Console Browser
                        case 1:
                            dgvConsoleBrowser.Rows.Clear();
                            populateConsoleBrowser();
                            if (Data.globalData != null)
                            {
                                SupportedConsole sc = Data.GetLocalConsole_byName(dgvConsoleBrowser.SelectedRows[0].Cells[1].Value.ToString());
                                populateConsoleInformation(sc);
                            }
                            break;

                        // Game Browser
                        case 2:
                            // Initiliase Game Browser
                            populateConsoleSelectionList();
                            Populate_SearchByOptions();
                            break;
                        // Achievement Browser
                        case 3:
                            break;

                        // Leaderboard
                        case 4:
                            dgvLeaderboard.Rows.Clear();
                            Task.Run(() => PopulateLeaderBoard());
                            break;

                        // Settings
                        case 5:
                            break;

                        default:
                            break;


                    }
                }
            }
            else
            {
                MessageBox.Show(
                    "No internet connection. Check connection and firewall settings.",
                    "No internet connection",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                    );
            }

        }

        // STATS
        public void updateCounters()
        {
            tsslConsoleCount.Text = Data.GetCount_Console().ToString();
            tsslGameCount.Text = Data.GetCount_Games().ToString();
            tsslAchievementCount.Text = Data.GetCount_Achievements().ToString();
            tsslImageCount.Text = Data.GetCount_Images().ToString();
        }

        // Event Handlers
        private void txtAPIKey_TextChanged(object sender, EventArgs e)
        {
            //Properties.Settings.Default.Credential_APIKey = txtAPIKey.Text;
        }
        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            //Properties.Settings.Default.Credential_Username = txtUsername.Text;
        }
        #endregion

        #region // MENUS
        private void downloadConsolesGamesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.Credential_Username != string.Empty && Properties.Settings.Default.Credential_APIKey != string.Empty)
            {
                Task.Run(new Action(() =>
                {
                    statLblStatus.Text = "Downloading data...";
                    Data.DownloadConsoleList_CreateObjects();
                    updateCounters();
                    PopulateMenu_Consoles();
                    statLblStatus.Text = "Data downloaded.";
                }));
            }
            else
            {
                MessageBox.Show(
                    "Enter username and API key in the settings tab.",
                    "No credentials entered",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                    );
            }
        }

        private void loadDataToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void saveLocalDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Task.Run(new Action(() => {
                statLblStatus.Text = "Saving local data. Please wait...";
                FileHandling.SaveAllData();
                statLblStatus.Text = "Local data saved.";
            }));
        }

        private void deleteLocalDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Task.Run(new Action(() => {
                statLblStatus.Text = "Deleting local data...";
                if (FileHandling.DeleteAllData())
                {
                    updateCounters();
                    statLblStatus.Text = "Local data deleted.";
                }
            }));
        }

        private void loadLocalDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Task.Run(new Action(() => {
                statLblStatus.Text = "Loading local data.";
                FileHandling.LoadAllData();
                updateCounters();
                PopulateMenu_Consoles();
                statLblStatus.Text = "Local data loaded.";
            }));
        }

        private void PopulateMenu_Consoles()
        {
            // Populate menu with console items
            msMain.Invoke(new Action(() => {
                if (Data.globalData != null)
                {
                    foreach (SupportedConsole sc in Data.globalData.consoles)
                    {
                        ToolStripMenuItem newMenuItem = new ToolStripMenuItem(sc.Name, null, DownloadGamesForConsole_Click, sc.Name);
                        downloadGamesForConsoleToolStripMenuItem.DropDownItems.Add(newMenuItem);
                    }
                }
            }));
        }

        #endregion

        // TAB PAGES
        #region //  USER PROFILE

        void ShowUserData()
        {
            // Get user data
            dynamic data = Data.User_FetchData();

            if (data["ID"] != null)
            {

                // Create user object
                User currentUser = new User(data);

                // Create list of recent games from user and display
                List<Game> recentlyPlayedGames = Data.GetRecentlyPlayedGames(data);

                populateRecentlyPlayedGames(recentlyPlayedGames); // Recently played Games Box Arts


                populateLastPlayedGame(currentUser); // Last played Game

                // Summary
                updateUserSummaryInfo(data);
            }
        }

        private void pbRecentGame_Click(object sender, EventArgs e)
        {
            // Chnage page to game browser
            tabsMain.SelectedIndex = 3;

            // get game ID from pb tag
            int gameID = Int32.Parse(((PictureBox)sender).Tag.ToString());

            // Find game
            Game game = Data.GetLocalGame_byID(gameID);

            // Clear achievement flow layout panel
            flpAchievements.Controls.Clear();

            // Populate browser with game details
            AchievementBrowser_PopulateGameDetails(game);

            // Check achievements have been downloaded if required
            if (game.hasAchievements)
            {
                if (game.Achievements.Count == 0)
                {
                    Data.DownloadAchievements_ByGame(game);
                }
            }

            // Populate achievement tiles
            PopulateAchievementsForGame(game);
        }

        private void updateUserSummaryInfo(dynamic d)
        {

            // Info to labels
            lblUserName.Invoke(new Action(() => { lblUserName.Text = Properties.Settings.Default.Credential_Username; }));
            lblPointsTotal.Invoke(new Action(() => { lblPointsTotal.Text = d["TotalPoints"]; }));
            lblMemberSince.Invoke(new Action(() => { lblMemberSince.Text = d["MemberSince"]; }));
            lblUserRank.Invoke(new Action(() => { lblUserRank.Text = d["Rank"]; }));

            // User Pic
            string userPicURL = "https://retroachievements.org/" + d["UserPic"];
            pbUserPic.Invoke(new Action(() => { pbUserPic.LoadAsync(userPicURL); }));
            //pbUserPic.LoadAsync(userPicURL);
        }

        private void populateLastPlayedGame(User u)
        {
            // Get game
            Game lastGame = Data.GetLocalGame_byID(u.LastGameId);
            if (lastGame == null)
            {
                lastGame = Data.CreateGame_fromIDQuery(u.LastGameId);
            }

            if (lastGame != null)
            {
                // Details
                lblUser_LastGameID.Invoke(new Action(() => { lblUser_LastGameID.Text = lastGame.ID; } ));
                lblUser_Title.Invoke(new Action(() => { lblUser_Title.Text = lastGame.Title; }));
                lblUser_Console.Invoke(new Action(() => { lblUser_Console.Text = lastGame.Console; }));
                lblUser_Publisher.Invoke(new Action(() => { lblUser_Publisher.Text = lastGame.Publisher; }));
                lblUser_Developer.Invoke(new Action(() => { lblUser_Developer.Text = lastGame.Developer; }));
                lblUser_Released.Invoke(new Action(() => { lblUser_Released.Text = lastGame.Released; }));

                // Check game objects have images
                if (lastGame.imgBoxArt == null)
                    lastGame.imgBoxArt = Data.gameImage_DownloadBoxArt(lastGame); 

                if (lastGame.imgTitleScreen == null)
                    lastGame.imgTitleScreen = Data.gameImage_DownloadTitleScreen(lastGame);

                if (lastGame.imgIngame == null)
                    lastGame.imgIngame = Data.gameImage_DownloadInGame(lastGame);
                
                // Assign images
                pbLastGamePlayed.Image = lastGame.imgBoxArt;
                pbLastGameTitle.Image = lastGame.imgTitleScreen;
                pbLastGameIngame.Image = lastGame.imgIngame;
            }
        }

        private void populateRecentlyPlayedGames(List<Game> rpgs)
        {
            // Add games tiles to flow layout panel
            foreach (Game game in rpgs)
            {
                // Create tile
                PictureBox gameTile_Recent = createGameTile_RecentlyPlayed(game);

                // Load box art async
                loadGameTileBoxArt(gameTile_Recent, game);

                // Add tile
                flpRecentlyPlayedGames.Invoke(new Action(() => { flpRecentlyPlayedGames.Controls.Add(gameTile_Recent); })); 
            }
        }

        private PictureBox createGameTile_RecentlyPlayed(Game g)
        {
            PictureBox newGameTile = new PictureBox();
            newGameTile.SizeMode = PictureBoxSizeMode.StretchImage;
            newGameTile.Size = new Size(150, 210);
            newGameTile.Image = Properties.Resources.loading;
            newGameTile.Cursor = Cursors.Hand;
            newGameTile.Tag = g.ID;
            newGameTile.Click += pbRecentGame_Click;
            //newGameTile.DoubleClick += pbRecentGame_Click;
            return newGameTile;
        }
        #endregion

        #region //  CONSOLE BROWSER
        private void dgvConsoleBrowser_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvConsoleBrowser.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvConsoleBrowser.SelectedRows[0];
                if (selectedRow.Cells[1].Value != null)
                {
                    SupportedConsole sc = Data.GetLocalConsole_byName(selectedRow.Cells[1].Value.ToString());
                    populateConsoleInformation(sc);
                }
            }
        }

        private void dgvConsoleBrowser_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // Get console name from row clicked
            string consoleName = dgvConsoleBrowser.Rows[e.RowIndex].Cells[1].Value.ToString();

            // Change tabs page
            tabsMain.SelectedIndex = 2;

            // Change combo box
            cmbConsoleSelection.SelectedIndex = cmbConsoleSelection.FindString(consoleName);
        }

        private void dgvConsoleBrowser_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                SupportedConsole sc = Data.GetLocalConsole_byName(dgvConsoleBrowser.Rows[e.RowIndex].Cells[1].Value.ToString());
                populateConsoleInformation(sc);
            }
        }

        private void populateConsoleInformation(SupportedConsole sc)
        {
            // Populate console details
            lblConsoleBrowser_ConsoleName.Text = sc.Name;
            lblCB_ReleaseDate.Text = sc.released;

            pbConsoleBrowser_ConsoleImage.Image = Data.getConsoleImage(sc);
        }

        private void populateConsoleBrowser()
        {
            if (!Data.receivingData)
            {
                if (Data.globalData != null)
                {
                    foreach (SupportedConsole sc in Data.globalData.consoles)
                    {
                        if (sc.Name != "Hubs" && sc.Name != "Events" && sc.Name != "[Unused]")
                        {
                            DataGridViewRow newRow = new DataGridViewRow();
                            newRow.CreateCells(dgvConsoleBrowser);
                            newRow.Cells[0].Value = sc.ID;
                            newRow.Cells[1].Value = sc.Name;
                            newRow.Cells[2].Value = sc.games.Count;
                            dgvConsoleBrowser.Rows.Add(newRow);
                        }
                    }
                }
                else
                {
                    MessageBox.Show(
                        "No console data. Download console list from top menu.",
                        "No console data",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                        );
                }
            }
            else
            {
                MessageBox.Show(
                    "Will not populate data until the download is completed. Wait for download to complete.",
                    "Please wait",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                    );
            }
        }
        #endregion

        #region //  GAME BROWSER
        public SupportedConsole currentConsole;
        public Game currentGame;
        private void cmbConsoleSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            //populateGamesBrowser(cmbConsoleSelection.SelectedIndex);
        }


        private void populateGamesBrowser(SupportedConsole sc)
        {
            statLblStatus.Text = "Updating game browser...";

            Task.Run(new Action(() => 
            {
                // Get list of games from global data
                List<Game> games = sc.games;

                if (games.Count > 0)
                {
                    // Boxart view
                    if (rdoGameBrowserArt.Checked)
                    {
                        // Clear browser
                        flpGamesBrowser.Invoke(new Action(() => { flpGamesBrowser.Controls.Clear(); }));

                        // Create icons
                        for (int i = 0; i < games.Count; i++)
                        {
                            if (!gameBrowser_Fetching)
                            {
                                break;
                            }
                            // Get game object
                            Game curGame = sc.games[i];

                            // Create picture box
                            PictureBox pbGame = createGameTile(curGame);

                            // Load box art
                            loadGameTileBoxArt(pbGame, curGame);

                            // Add to flow layout panel
                            flpGamesBrowser.Invoke(new Action(() => { flpGamesBrowser.Controls.Add(pbGame); }));
                        }
                    }
                    // Grid view
                    else
                    {
                        // Clear datagridview
                        dgvGameBrowser.Invoke(new Action(() => { dgvGameBrowser.Rows.Clear(); } ));

                        // Create row style
                        DataGridViewCellStyle cellStyle = new DataGridViewCellStyle();
                        cellStyle.Font = new Font("Verdana", 12, FontStyle.Regular);

                        // Create datagrid rows
                        for (int i = 0; i < games.Count; i++)
                        {
                            if (!gameBrowser_Fetching)
                            {
                                break;
                            }
                            // Get game object
                            Game curGame = sc.games[i];

                            // Create DataGridViewRow
                            var newRow = new DataGridViewRow();
                            dgvGameBrowser.Invoke(new Action(() => { newRow.CreateCells(dgvGameBrowser); }));
                            newRow.Cells[0].Value = curGame.ID;
                            newRow.Cells[1].Value = curGame.Title;
                            newRow.Cells[2].Value = curGame.Publisher;
                            newRow.Cells[3].Value = curGame.Developer;
                            newRow.Cells[4].Value = curGame.Released;
                            newRow.DefaultCellStyle = cellStyle;
                            dgvGameBrowser.Invoke(new Action(() => { dgvGameBrowser.Rows.Add(newRow); }));
                        }
                    }
                }
                else
                {
                    MessageBox.Show(
                        "Download games for this console first.",
                        "No games downloaded for this console",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                        );
                }

                // Toggle back off
                gameBrowser_Fetching = false;
                btnGameBrowser_FetchToggle.Invoke(new Action(() => { btnGameBrowser_FetchToggle.Text = "Start"; })); 
                statLblStatus.Text = "Game browser updated.";
            }));


        }

        private PictureBox createGameTile(Game g)
        {
            PictureBox newGameTile = new PictureBox();
            newGameTile.SizeMode = PictureBoxSizeMode.StretchImage;
            newGameTile.Size = new Size(100, 140);
            newGameTile.Image = Properties.Resources.loading;
            newGameTile.Cursor = Cursors.Hand;
            newGameTile.Tag = g.ID;
            newGameTile.Click += PbGame_Click;
            newGameTile.DoubleClick += PbGame_DoubleClick;
            return newGameTile;
        }

        private void loadGameTileBoxArt(PictureBox gameTile, Game game)
        {
            if (game.ID == null)
            {

            }
            if (game.imgBoxArt == null)
            {
                // Downloads box art, saves to game object and assigns it to game tile
                gameTile.Image = Data.gameImage_DownloadBoxArt(game);
            }
            else
            {
                gameTile.Image = game.imgBoxArt;
            }
        }
        
        private void PbGame_DoubleClick(object sender, EventArgs e)
        {
            tabsMain.SelectedIndex = 3;
            AchievementBrowser_PopulateGameDetails(currentGame);
        }

        private void PbGame_Click(object sender, EventArgs e)
        {
            // Clear current details
            GameBrowser_ClearAllDetails();

            string selectedConsoleName = cmbConsoleSelection.SelectedItem.ToString();

            Task.Run(new Action(() => 
            {
                SupportedConsole currentConsole = Data.GetLocalConsole_byName(selectedConsoleName);
                int gameID = Int32.Parse(((PictureBox)sender).Tag.ToString());
                Game game = Data.GetLocalGame_byIDandConsole(currentConsole, gameID.ToString());
                currentGame = game;

                if (game.Achievements.Count == 0)
                {
                    if (game.hasAchievements)
                    {
                        Data.DownloadAchievements_ByGame(game);
                    }
                }

                if (currentConsole != null && game != null)
                {
                    GameBrowser_PopulateGameDetails(currentConsole, game);
                }
                else
                {
                    MessageBox.Show("Could not find console and/or game.", "Error populating game", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }));
        }

        private void GameBrowser_ClearAllDetails()
        {
            // Details
            lblGameDetailsID.Text = "";
            lblGameDetailsConsole.Text = "";
            lblGameDetailsPublisher.Text = "";
            lblGameDetailsDeveloper.Text = "";
            lblGameDetailsReleased.Text = "";

            // Title
            lblGameBrowserTitle.Text = "";

            // Achievements counter
            lblAchievementsCount.Text = "";

            // Images
            pbGameDetailsBoxArt.Image = Properties.Resources.loading;
            pbGameBrowser_TitleScreen.Image = Properties.Resources.loading;
            pbGameBrowser_Ingame.Image = Properties.Resources.loading;
        }

        private bool GameBrowser_GameIsMissingDetail(Game game)
        {
            if (game.Title == null)
                return true;
            if (game.Console != null)
                return true;
            if (game.Publisher != null)
                return true;
            if (game.Developer != null)
                return true;
            if (game.Released != null)
                return true;
            else
                return false;
        }

        private void GameBrowser_PopulateGameDetails(SupportedConsole curConsole, Game game)
        {
            //Console.WriteLine("Populating game: " + game.Title + "\tID: " + game.ID + "\tConsole: " + game.Console);
            PopulateGameData_GlobalData(game);

            bool missingData = false;
            if (game != null)
            {
                // If missing a detail
                if (GameBrowser_GameIsMissingDetail(game))
                {
                    Data.GameData_Download(game);
                    //missingData = false;
                    PopulateGameData_GlobalData(game);
                }

                // Set labels
                Invoke(new Action(() => {
                    lblGameBrowserTitle.Text = game.Title;
                    lblGameDetailsConsole.Text = game.Console;
                    lblUser_Publisher.Text = game.Publisher;
                    lblUser_Developer.Text = game.Developer;
                    lblUser_Released.Text = game.Released;
                }));

                #region old code
                // Check all fields are populated
                //Title
                if (game.Title != null)
                {

                }
                else
                {
                    Console.WriteLine("Game missing title data: [ID:" + game.ID + "]");
                    missingData = true;
                }
                //Console
                if (game.Console != null)
                {

                }
                else
                {
                    Console.WriteLine("Game missing console data: [ID:" + game.ID + " Title: " + game.Title + "]");
                    game.Console = curConsole.Name;
                    missingData = true;
                }
                //Publisher
                if (game.Publisher != null)
                {
                    lblUser_Publisher.Text = game.Publisher;
                }
                else
                {
                    Console.WriteLine("Game missing publisher data: [ID:" + game.ID + " Title: " + game.Title + "]");
                    missingData = true;
                }
                //Developer
                if (game.Developer != null)
                {
                    lblUser_Developer.Text = game.Developer;
                }
                else
                {
                    Console.WriteLine("Game missing developer data: [ID:" + game.ID + " Title: " + game.Title + "]");
                    missingData = true;
                }
                // Released
                if (game.Released != null)
                {
                    lblUser_Released.Text = game.Released;
                }
                else
                {
                    Console.WriteLine("Game missing release date data: [ID:" + game.ID + " Title: " + game.Title + "]");
                    missingData = true;
                }

                #endregion



                // Achievements count
                if (game.Achievements != null)
                {
                    lblAchievementsCount.Invoke(new Action(() => { lblAchievementsCount.Text = game.Achievements.Count.ToString(); })); 
                }
                else if (game.hasAchievements && game.Achievements == null)
                {
                    Console.WriteLine("Game missing achievements data: [ID:" + game.ID + " Title: " + game.Title + "]");
                }
                else
                {
                    lblAchievementsCount.Invoke(new Action(() => { lblAchievementsCount.Text = "0"; }));
                    Console.WriteLine("Game has no achievements data: [ID:" + game.ID + " Title: " + game.Title + "]");
                }
            }
            else
            {
                MessageBox.Show("No game object found.", "Loading game error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PopulateGameData_GlobalData(Game game)
        {
            // Written Data
            lblGameDetailsID.Invoke(new Action(() => { lblGameDetailsID.Text = game.ID; })); 
            lblGameDetailsConsole.Invoke(new Action(() => { lblGameDetailsConsole.Text = game.Console; }));
            lblGameDetailsPublisher.Invoke(new Action(() => { lblGameDetailsPublisher.Text = game.Publisher; }));
            lblGameDetailsDeveloper.Invoke(new Action(() => { lblGameDetailsDeveloper.Text = game.Developer; }));
            lblGameDetailsReleased.Invoke(new Action(() => { lblGameDetailsReleased.Text = game.Released; }));
            pbGameDetailsBoxArt.Invoke(new Action(() => { pbGameDetailsBoxArt.Image = game.imgBoxArt; }));

            // Title Screen Image
            if (game.imgTitleScreen == null)
            {
                Image downloadImage = Data.gameImage_DownloadTitleScreen(game);
                game.imgTitleScreen = downloadImage;
            }
            pbGameBrowser_TitleScreen.Invoke(new Action(() => { pbGameBrowser_TitleScreen.Image = game.imgTitleScreen; }));

            // In-Game Image
            if (game.imgIngame == null)
            {
                Image downloadImage = Data.gameImage_DownloadInGame(game);
                game.imgTitleScreen = downloadImage;
            }
            pbGameBrowser_Ingame.Invoke(new Action(() => { pbGameBrowser_Ingame.Image = game.imgIngame; }));

        }

        private void rdoGameBrowserArt_CheckedChanged(object sender, EventArgs e)
        {
            toggleGameBrowserView();
            flpGamesBrowser.Controls.Clear();
            dgvConsoleBrowser.Rows.Clear();
        }

        private void toggleGameBrowserView()
        {
            if (rdoGameBrowserArt.Checked)
            {
                dgvGameBrowser.Visible = false;
                flpGamesBrowser.Visible = true;
            }
            else
            {
                dgvGameBrowser.Visible = true;
                flpGamesBrowser.Visible = false;
            }

            // Populate new view
            //populateGamesBrowser(cmbConsoleSelection.SelectedIndex);
        }

        public bool gameBrowser_Fetching = false;
        private void btnGameBrowser_FetchToggle_Click(object sender, EventArgs e)
        {
            if (gameBrowser_Fetching)
            {
                // Stop fetching
                gameBrowser_Fetching = false;
                btnGameBrowser_FetchToggle.Text = "Fetch";
            }
            else
            {
                // Start fetching
                gameBrowser_Fetching = true;
                btnGameBrowser_FetchToggle.Text = "Stop";

                SupportedConsole curConsole = getConsoleFromCurrentComboSelection();
                if (curConsole != null)
                {
                    populateGamesBrowser(curConsole);
                }
            }
        }

        private SupportedConsole getConsoleFromCurrentComboSelection()
        {
            if (Data.globalData != null)
            {
                string consoleName = string.Empty;
                try
                {
                    consoleName = cmbConsoleSelection.SelectedItem.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Select a console.", "No console selected", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }


                if (Data.globalData.consoles != null && consoleName != string.Empty)
                {
                    if (Data.globalData.consoles.Count > 0)
                    {
                        foreach (SupportedConsole sc in Data.globalData.consoles)
                        {
                            if (sc.Name == consoleName)
                            {
                                return sc;
                            }
                        }
                        // If not found, show error
                        MessageBox.Show("Console not found.", "Fetch error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show(
                    "No consoles loaded, sync the database.",
                    "Fetch error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                    );
                
            }
            return null;
        }

        private void btnViewGameAchievements_Click(object sender, EventArgs e)
        {
            tabsMain.SelectedIndex = 3;
            AchievementBrowser_PopulateGameDetails(currentGame);
        }

        private void InitTabPage_GameBrowser()
        {
            // Populate console list
            foreach (SupportedConsole sc in Data.globalData.consoles)
            {
                cmbConsoleSelection.Items.Add(sc.Name);
            }
        }

        private void populateConsoleSelectionList()
        {
            if (!Data.receivingData)
            {
                if (
                    cmbConsoleSelection.Items.Count < 1 &&
                    Data.globalData != null &&
                    Data.globalData.consoles != null
                    )
                {
                    // Clear list
                    cmbConsoleSelection.Items.Clear();

                    // Populate list
                    foreach (SupportedConsole sc in Data.globalData.consoles)
                    {
                        cmbConsoleSelection.Items.Add(sc.Name);
                    }
                }
                //else
                //{
                //    //No console data
                //    MessageBox.Show(
                //        "No consoles to populate. Please download consoles data.",
                //        "No console data",
                //        MessageBoxButtons.OK,
                //        MessageBoxIcon.Error
                //        );
                //}
            }
            else
            {
                MessageBox.Show(
                    "Will not populate data until the download is completed. Wait for download to complete.",
                    "Please wait",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                    );
            }
        }

        private void rdoGameBrowserGrid_CheckedChanged(object sender, EventArgs e)
        {
            toggleGameBrowserView();
            flpGamesBrowser.Controls.Clear();
            dgvConsoleBrowser.Rows.Clear();
        }

        private void dgvGameBrowser_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                SupportedConsole sc = getConsoleFromCurrentComboSelection();
                int gameID = Int32.Parse(dgvGameBrowser.Rows[e.RowIndex].Cells[0].Value.ToString());
                currentGame = Data.GetLocalGame_byID(gameID);
                GameBrowser_ClearAllDetails();
                GameBrowser_PopulateGameDetails(sc, currentGame);
            }
        }

        private void Populate_SearchByOptions()
        {
            foreach(DataGridViewColumn col in dgvGameBrowser.Columns)
            {
                cmbSearchByField.Items.Add(col.Name);
            }
        }
        #endregion

        #region //  ACHIEVEMENT BROWSER
        private void AchievementBrowser_PopulateGameDetails(Game game)
        {
            try
            {
                // Game Details
                lblGameTitle.Text = game.Title;
                lbl_AB_ID.Text = game.ID;
                lbl_AB_Console.Text = game.ConsoleName;
                lbl_AB_Developer.Text = game.Developer;
                lbl_AB_Publisher.Text = game.Publisher;
                lbl_AB_Released.Text = game.Released;

                // Box Art
                bool missingData = false;
                if (game.imgBoxArt != null)
                {
                    pbBoxArt.Image = game.imgBoxArt;
                }
                else
                {
                    Console.WriteLine("Missing image for Box Art");
                    missingData = true;
                }

                // Screenshots
                if (game.imgTitleScreen != null)
                {
                    pbTitleScreen.Image = game.imgTitleScreen;
                }
                else
                {
                    Console.WriteLine("Missing image for Title Screen");
                    missingData = true;
                }

                if (game.imgIngame != null)
                {
                    pbInGame.Image = game.imgIngame;
                }
                else
                {
                    Console.WriteLine("Missing image for In-Game");
                    missingData = true;
                }

                

                // Achievements 
                PopulateAchievementsForGame(game);

                // Update progress bars
                UpdateProgressBars(game);

                if (missingData)
                {
                    Data.GameData_Download(game);
                    missingData = false;
                    AchievementBrowser_PopulateGameDetails(game);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Incomplete game for ID: " + game.ID + " Title: " + game.Title);

            }
        }

        private void PopulateAchievementsForGame(Game game)
        {
            // Clear browser
            flpAchievements.Controls.Clear(); 

            if (game.hasAchievements)
            {
                // Download achievements
                if (game.Achievements == null)
                {
                    Data.DownloadAchievements_ByGame(game);
                }

                Task.Run(new Action(() =>
                {
                    // Create tiles for each achievement
                    //for (int i = 0; i < game.Achievements.Count; i++)
                    //{
                    //    PictureBox pbAchievement = createAchievementTile(game.Achievements[i]);
                    //    flpAchievements.Invoke(new Action(() => { flpAchievements.Controls.Add(pbAchievement); }));
                    //}
                    foreach (Achievement a in game.Achievements)
                    {
                        PictureBox pbAchievement = createAchievementTile(a);
                        flpAchievements.Invoke(new Action(() => { flpAchievements.Controls.Add(pbAchievement); }));
                    }

                }));
            }
            else
            {
                Console.WriteLine("No achievements for " + game.Title);
            }
            
        }
     
        private void UpdateProgressBars(Game game)
        {
            // Set maximums
            progAchievements_Normal.Maximum = game.Achievements.Count;
            progAchievements_Hardcore.Maximum = game.Achievements.Count;

            progAchievements_Normal.Value = 0;
            progAchievements_Hardcore.Value = 0;

            // Count each
            foreach (Achievement a in game.Achievements)
            {
                if (a.DateEarned !=  null)
                {
                    progAchievements_Normal.Value++;

                    if (a.DateEarnedHardCore != null)
                    {
                        progAchievements_Hardcore.Value++;
                    }
                }
            }
        }

        private PictureBox createAchievementTile(Achievement a)
        {
            PictureBox achievementTile = new PictureBox();
            achievementTile.SizeMode = PictureBoxSizeMode.StretchImage;
            achievementTile.Size = new Size(100, 100);
            achievementTile.Image = Properties.Resources.loading;
            achievementTile.Cursor = Cursors.Hand;
            achievementTile.Tag = a.ID;
            achievementTile.Click += PbAchievement_Click;

            if (a.badge == null)
            {
                string url = Requests.GetBadgeUrlFromAchievement(a);
                a.badge = Requests.DownloadImageFromUrl(url);
                achievementTile.Image = a.badge;
            }
            else
            {
                achievementTile.Image = a.badge;
            }
            return achievementTile;
        }

        private void PbAchievement_Click(object sender, EventArgs e)
        {
            // Get achievement, game and console
            string achievementID = ((PictureBox)sender).Tag.ToString();
            Achievement achievement = Data.GetLocalAchievement_ByID(achievementID);

            try
            {
                //Game game = Data.GetLocalGame_byAchievement(achievement);
                //SupportedConsole console = Data.GetLocalConsole_byName(game.Console);
                AchievementBrowser_PopulateAchievementDetails(achievement);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error populating game", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AchievementBrowser_PopulateAchievementDetails(Achievement a)
        {
            // Details
            lbl_AB_Details_ID.Text = a.ID;
            lbl_AB_Details_Author.Text = a.Author;
            lbl_AB_Details_BadgeName.Text = a.BadgeName;
            lbl_AB_Details_DateCreated.Text = a.DateCreated;
            lbl_AB_Details_DateModified.Text = a.DateModified;
            lbl_AB_Details_Description.Text = a.Description;
            lbl_AB_Details_DisplayOrder.Text = a.DisplayOrder;
            lbl_AB_Details_MemAddr.Text = a.MemAddr;
            lbl_AB_Details_NumAwarded.Text = a.NumAwarded;
            lbl_AB_Details_NumAwardedHardcore.Text = a.NumAwardedHardcore;
            lbl_AB_Details_Points.Text = a.Points;
            lbl_AB_Details_Title.Text = a.Title;

            // Badge
            pb_AB_Badge.Image = a.badge;

            // Achievement status
            if (a.DateEarned != null)
            {
                grpEarned.Visible = true;
                lbl_AB_Details_DateEarned.Text = a.DateEarned;
                if (a.DateEarnedHardCore != null)
                {
                    lbl_AB_Details_DateEarnedHardcore.Text = a.DateEarnedHardCore;
                }
                else
                {
                    lbl_AB_Details_DateEarnedHardcore.Text = string.Empty;
                }
            }
            else
            {
                grpEarned.Visible = false;
                lbl_AB_Details_DateEarned.Text = string.Empty;
            }
        }

        private void flpAchievements_ControlAdded(object sender, ControlEventArgs e)
        {
            grpAchievements.Text = "Achievements [" + flpAchievements.Controls.Count + "]";
        }

        private void flpAchievements_ControlRemoved(object sender, ControlEventArgs e)
        {
            grpAchievements.Text = "Achievements [" + flpAchievements.Controls.Count + "]";
        }

        #endregion

        #region //  LEADERBOARD
        void PopulateLeaderBoard()
        {
            string url = Requests.requestURL(Constants.QueryTypes.WEB_TOP_TEN_USERS, null);
            string json = Requests.FetchJSON(url);

            // Create user objects
            createObjects_Top10Users(json);

            for (int i = 0; i < top10Users.Count; i++)
            {
                DataGridViewRow newRow = new DataGridViewRow();
                newRow.CreateCells(dgvLeaderboard);
                newRow.Height = 50;
                newRow.Cells[0].Value = i + 1;
                newRow.Cells[1].Value = top10Users[i].user;
                newRow.Cells[2].Value = top10Users[i].score;
                newRow.Cells[3].Value = top10Users[i].trueratio;
                dgvLeaderboard.Invoke(new Action(() => { dgvLeaderboard.Rows.Add(newRow); }));
            }
        }
        #endregion

        #region //  SETTINGS
        private void btnSettings_Load_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Implement me");
        }

        private void btnSettings_Save_Click(object sender, EventArgs e)
        {
            Console.WriteLine("***********SETTINGS UPDATED*****************");

            // On Startup
            Settings.Default.onStartUp_LoadUserProfile = cbSettings_OnStartUp_LoadUserProfile.Checked;
            Settings.Default.onStartUp_LoadData = cbSettings_OnstartUp_LoadData.Checked;
            Settings.Default.onStartUp_PopulateLeaderBoard = cbSettings_onStartUp_PopulateLeaderBoard.Checked;
            Settings.Default.onExit_SaveDataToFile = cbSettings_OnExit_SaveDataToFile.Checked;

            // Credentials
            Settings.Default.Credential_Username = txtUsername.Text;
            Settings.Default.Credential_APIKey= txtAPIKey.Text;

            // Save updated settings
            Settings.Default.Save();
            statLblStatus.Text = "Settings saved.";
        }

        private void btnSettings_DownloadData_Click(object sender, EventArgs e)
        {
            statLblStatus.Text = "Syncing Database: Downloading data...";
            Data.DownloadAllData();
            updateCounters();
            statLblStatus.Text = "Database synced";
        }
        #endregion


        public void UpdateStatus(string status)
        {
            statusStrip1.Invoke(new Action(() => { statLblStatus.Text = status; })); 
        }

        #region // TIMER
        public void LaunchStatisticsTimer()
        {
            Timer statisticsTimer = new Timer();
            statisticsTimer.Interval = 1000;
            statisticsTimer.Tick += StatsTimer_Tick;
            statisticsTimer.Start();
        }

        private void StatsTimer_Tick(object sender, EventArgs e)
        {
            updateCounters();
        }
        #endregion






        // FIX THIS CODE 
        // Create Objects ------- MOVE TO DATA and instead of void, return a list of users.
        void createObjects_Top10Users(string json)
        {
            // Create new list of objects
            top10Users = new List<User>();

            try
            {
               // Create object
               dynamic gameObject = JsonConvert.DeserializeObject(json);

                // Extract achievements from gameObject into individual objects
                if (gameObject["top10"] != null)
                {
                    for (int i = 1; i <= 10; i++) //(JObject u in )
                    {
                        User user = new User(gameObject["top10"]["place_" + i]);
                        top10Users.Add(user);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error converting received data.\n\n" + ex.ToString(),
                    "Error creating objects",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                    );
            }
        }

        private void DownloadGamesForConsole_Click(object sender, EventArgs e)
        {            
            string consoleName = ((ToolStripMenuItem)sender).Name;            
            statLblStatus.Text = "Downloading " + consoleName + " game data...";
            SupportedConsole sc = Data.GetLocalConsole_byName(consoleName);
            //Task.Run(new Action(() => {
                Data.DownloadGames_ForConsole(sc);
                updateCounters();
                statLblStatus.Text = consoleName + " game data downloaded.";
            //}));
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.onExit_SaveDataToFile)
            {
                statLblStatus.Text = "Saving local data. Please wait...";
                FileHandling.SaveAllData();
                statLblStatus.Text = "Local data saved.";
            }

            Application.Exit();
        }

        private void dgvGameBrowser_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            SupportedConsole sc = getConsoleFromCurrentComboSelection();
            int gameID = Int32.Parse(dgvGameBrowser.Rows[e.RowIndex].Cells[0].Value.ToString());
            currentGame = Data.GetLocalGame_byID(gameID);
            tabsMain.SelectedIndex = 3;
            AchievementBrowser_PopulateGameDetails(currentGame);
        }

        private void btnGB_SearchGames_Click(object sender, EventArgs e)
        {
            int searchColumn = cmbSearchByField.SelectedIndex;
            int rowIndex = GB_GetRowIndexOfSearchQuery(searchColumn, txtGB_SearchQuery.Text);
            if (rowIndex >= 0)
            {
                dgvGameBrowser.Rows[rowIndex].Selected = true;
                dgvGameBrowser.CurrentCell = dgvGameBrowser.Rows[rowIndex].Cells[0];
                dgvGameBrowser.Focus();
            }
            else
            {
                MessageBox.Show(
                    "Could not find anything containing '" + txtGB_SearchQuery.Text + "'.",
                    "No search results",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                    );
            }
        }

        private int GB_GetRowIndexOfSearchQuery(int col, string query)
        {
            foreach (DataGridViewRow row in dgvGameBrowser.Rows)
            {
                if (row.Cells[col] != null)
                {
                    if (row.Cells[col].Value != null)
                    {
                        string cellVal = row.Cells[col].Value.ToString();
                        if (cellVal.ToLower().Contains(query.ToLower()))
                        {
                            return row.Index;
                        }
                    }
                }
            }
            return -1;
        }
    }
}
