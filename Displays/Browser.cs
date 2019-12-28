/// <summary>
/// Author: Ben Royans
/// Date: Thursday, 14 November 2019
/// Program: Retroachievements Viewer
/// Description: A windows program used to display RetroAchievements' achievements.
/// </summary>

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RA_API.Connection;
using RA_API.Displays;
using RA_API.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tulpep.NotificationWindow;

namespace RA_API
{
    public partial class Browser : Form
    {
        // ********************** GLOBAL VARIABLES ************************* //
        JObject data;
        public string mostRecentJson;

        List<Achievement> gameAchievements;

        bool formLoading = false;
               

        // ********************** MAIN ************************* //
        public Browser()
        {
            InitializeComponent();
            gameAchievements = new List<Achievement>(); //// *******************USE GAME OBJECT!!
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            formLoading = true;

            // Change DataGridView row height
            //dgvAchievements.RowTemplate.Height = 200;

            dgvAchievements.ForeColor = Color.Black;

            formLoading = false;

            // Set focus to game ID
            txtGameID.Focus();
            txtGameID.Select();
        }


        // ********************** DATA METHODS ************************* //

        // EXPORT ELSEWHERE!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        async void FetchData()
        {
            // Fetch data
            Task<JObject> fetchData = Requests.FetchData(txtGameID.Text, Constants.QueryTypes.WEB_GAME_INFO_AND_PROGRESS);
            data = await fetchData;

            // Update most recent JSON
            mostRecentJson = Requests.FetchJSON(
                    Requests.requestURL(
                        Constants.QueryTypes.WEB_GAME_INFO_AND_PROGRESS,
                        txtGameID.Text
                        ));

            // Create objects
            jsonCreateObjects(mostRecentJson);

            // Update game info
            UpdateGameInfo();
        }

        void jsonCreateObjects (string json)
        {
            try
            {
                // Create object
                dynamic gameObject = JsonConvert.DeserializeObject(json);
                
                // Extract achievements from gameObject into individual objects
                // Clear list
                gameAchievements.Clear();
                if (gameObject["Achievements"] != null)
                {
                    foreach (JProperty a in gameObject["Achievements"])
                    {
                        Achievement ac = new Achievement(a.Value);
                        gameAchievements.Add(ac);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error converting received data."/* + ex.ToString()*/,
                    "Error creating objects", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error
                    );
            }
        }
        
        void UpdateGameInfo()
        {
            // Clear all fields
            ClearAllDetails();
            ClearDataGridRows();
            

            try
            {
                // Game Details
                txtDetailsTitle.Text = data.Value<JToken>("Title").ToString();
                txtDetailsConsole.Text = data.Value<JToken>("ConsoleName").ToString();
                txtDetailsDeveloper.Text = data.Value<JToken>("Developer").ToString();
                txtDetailsGenre.Text = data.Value<JToken>("Genre").ToString();
                txtDetailsReleased.Text = data.Value<JToken>("Released").ToString();
                txtDetailsPublisher.Text = data.Value<JToken>("Publisher").ToString();

                // Update image
                try
                {
                    // Image
                    UpdateImages();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(
                        "Error fetching image.\r\n\r\n"/* + ex.ToString()*/,
                        "Error extracting image data from fetched JSON",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                        );
                }
            }
            catch (Exception ex)
            {
                txtDetailsTitle.Text = "*** ERROR ***";
                txtDetailsTitle.Font = new Font(txtDetailsTitle.Font, txtDetailsTitle.Font.Style & ~FontStyle.Bold);
                txtDetailsTitle.ForeColor = Color.Red;
                //MessageBox.Show(ex.ToString(), "Error extracting data from fetched JSON", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Display achievements
            PrintAchievementsToListView();

            // Update progress bars
            UpdateProgressBars();
        }

        void UpdateProgressBars ()
        {
            Console.WriteLine("Updating progress bars...");

            if (gameAchievements.Count > 0)
            {
                // Show achievement controls
                grpAchievementProgress.Visible = true;
                grpArtwork.Visible = true;

                // Init counters
                int counter = 0;
                int hardcoreCounter = 0;

                // Populate counters
                foreach (Achievement a in gameAchievements)
                {
                    if (a.DateEarned != null)
                    {
                        counter++;
                        Console.WriteLine("Normal+");
                        if (a.DateEarnedHardCore != null)
                        {
                            hardcoreCounter++;
                            Console.WriteLine("Hardcore+");
                        }
                    }
                }
                Console.WriteLine(string.Format("Counts\nNormal: {0}\tHarcore: {1}", counter, hardcoreCounter));

                // Calculate values
                double achievementCount = (double)gameAchievements.Count;
                double achievementValue = (double)((counter / achievementCount) * 100);
                double achievementValueHardcore = (double)((hardcoreCounter / achievementCount) * 100);
                Console.WriteLine(string.Format("Values\nNormal: {0}\tHarcore: {1}", achievementValue, achievementValueHardcore));

                // Set progress bars to values
                progAchievements.Value = (int)achievementValue;
                progAchievementsHardcore.Value = (int)achievementValueHardcore;
                Console.WriteLine("Progress bars updated.");

                // Show percentage values in labels
                lblNormalPercent.Text = string.Format("{0:0.0}%", Math.Truncate(achievementValue * 10) / 10);
                lblHardcorePercent.Text = string.Format("{0:0.0}%", Math.Truncate(achievementValueHardcore * 10) / 10);

                // Update progres labels
                lblAchievementProgress.Text = string.Format("{0} of {1} achievements earned.", counter, achievementCount);
                lblAchievementHardcoreProgress.Text = string.Format("{0} of {1} hardcore achievements earned.", hardcoreCounter, achievementCount);
            }
            else
            {
                // Clear label text
                lblAchievementProgress.Text = string.Empty;
                lblAchievementHardcoreProgress.Text = string.Empty;

                // Hide achievement controls
                grpAchievementProgress.Visible = false;
                grpArtwork.Visible = false;
            }
        }


        // !!!!!!!!!! ADD IMAGE CLEARING TO THIS METHOD
        void ClearAllDetails()
        {
            // Game Details
            txtDetailsTitle.Text = string.Empty;
            txtDetailsConsole.Text = string.Empty;
            txtDetailsDeveloper.Text = string.Empty;
            txtDetailsGenre.Text = string.Empty;
            txtDetailsReleased.Text = string.Empty;
            txtDetailsPublisher.Text = string.Empty;

            // Clear images
            PictureBox[] pictureBoxes = grpArtwork.Controls.OfType<PictureBox>().ToArray<PictureBox>();
            foreach (PictureBox pb in pictureBoxes)
            {
                pb.Image = Properties.Resources.maxresdefault;
            }

            // Reset font stylings for 'title'
            txtDetailsTitle.Font = new Font(txtDetailsTitle.Font, txtDetailsTitle.Font.Style & ~FontStyle.Regular);
            txtDetailsTitle.ForeColor = Color.Black;
        }

        void PrintAchievementsToListView()
        {
            

            //Create image column
            var imgColumn = new DataGridViewImageColumn();

            // Print achievements from list to listbox
            int achievementCounter = 0;
            foreach (var a in gameAchievements)
            {
                // Details
                string achieved = "No";
                if (a.DateEarned != null)
                {
                    achieved = "Yes";

                    if (a.DateEarnedHardCore != null)
                    {
                        achieved = "Hardore";
                    }
                }

                // Create DataGrid row   
                DataGridViewRow newRow = (DataGridViewRow)dgvAchievements.Rows[0].Clone();
                newRow.Cells[0].Value = a.ID;
                newRow.Cells[1].Value = a.Title;
                newRow.Cells[2].Value = a.Description;
                newRow.Cells[3].Value = achieved;

                string badgeUrl = Requests.GetBadgeUrlFromAchievement(a);
                newRow.Cells[4].Value = Requests.DownloadImageFromUrl(badgeUrl);
                
                // Set row color according to achieved status
                newRow.DefaultCellStyle.BackColor = RowColor(achieved);


                // Add the new row
                dgvAchievements.Rows.Add(newRow);


                // Increment counter
                achievementCounter++;
            }
            grpAchievements.Text = "Achievements [" + achievementCounter + "]";
        }

        Color RowColor (string achieved)
        {
            if (achieved != "No")
            {
                return Color.LightGreen;
            }
            else
            {
                return Color.White;
            }
        }

        void ClearDataGridRows()
        {
            dgvAchievements.Rows.Clear();
        }
        
        void UpdateImages()
        {
            //imgIcon.Load(GetImageURL(0));
            imgTitle.Load(GetImageURL(1));
            imgInGame.Load(GetImageURL(2));
            imgBoxArt.Load(GetImageURL(3));
        }

        string GetImageURL(int imageSelection)
        {
            
            // Init base of image url
            string coverImgURL = "https://s3-eu-west-1.amazonaws.com/i.retroachievements.org";
            Console.WriteLine("Fetching Image URL: " + coverImgURL);
            switch (imageSelection)
            {
                case 0:
                    coverImgURL += data.Value<JToken>("ImageIcon").ToString();
                    break;
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

        void HideDataPanels()
        {
            grpAchievementProgress.Visible = false;
            grpArtwork.Visible = false;
        }

        void ShowDataPanels()
        {
            grpAchievementProgress.Visible = true;
            grpArtwork.Visible = true;
        }

        // ********************** EVENT HANDLERS ************************* //
        //private void btnRandom_Click(object sender, EventArgs e)
        //{
        //    // Get random ID
        //    Random rand = new Random();
        //    Game randomGame = Data.globalData.games[rand.Next(Data.globalData.games.Count)];
        //    txtGameID.Text = randomGame.ID;

        //    // Fetch data
        //    btnFetchData_Click(sender, e);
        //}

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void btnFetchData_Click(object sender, EventArgs e)
        {
            // Announce data fetch
            notifyIcon1.ShowBalloonTip(
                5000,
                "Retro-Achievements Browser",
                "Downloading game data...",
                ToolTipIcon.Info
                );

            slblCurrentAction.Text = "Loading data...";

            // Change box art image to loading
            imgBoxArt.Image = Properties.Resources.loading;

            // Hide panels
            HideDataPanels();

            // Reset gridview
            ClearDataGridRows();

            // Fetch data
            FetchData();

            // Add to recent queries
            ToolStripItem newSearch = new ToolStripMenuItem(txtGameID.Text + " - " + txtDetailsTitle.Text);
            recentQueriesToolStripMenuItem.DropDownItems.Add(newSearch);

            // Show panels
            ShowDataPanels();
        }



        private void contactMeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("mailto:ben.royans@gmail.com");
        }

        private void viewCurrentJSONDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (mostRecentJson != null)
            {
                var JSONViewer = new JSONDataView(data);
                JSONViewer.Show();
            }
            else
            {
                MessageBox.Show(
                    "No data is loaded.",
                    "No data",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                    );
            }
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "You're on your own for now...",
                "Ha Ha",
                MessageBoxButtons.OK,
                MessageBoxIcon.None
                );
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About abt = new About();
            abt.Show();
        }

        private void btnOpenGamePageWebBrowser_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(
                String.Format(Constants.BaseURLs.PAGE_GAME, txtGameID.Text)
                );            
        }

        private void dgvAchievements_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            dgvAchievements.Rows[e.RowIndex].Height = 60;
        }

        private void dgvAchievements_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int curRow = e.RowIndex;
            string curGameID = dgvAchievements[0, curRow].Value.ToString();
            foreach (Achievement a in gameAchievements)
            {
                if (a.ID == curGameID)
                {
                    var achievementDisplay = new AchievementDisplay(a);
                    achievementDisplay.Show();
                }
            }
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
        }

        private void notifyIcon1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
        }

        private void txtGameID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                btnFetchData_Click(sender, e);
            }
        }

        //private void txtUsername_TextChanged(object sender, EventArgs e)
        //{
        //    Credentials.UserName = txtUsername.Text;
        //}

        //private void txtAPIKey_TextChanged(object sender, EventArgs e)
        //{
        //    Credentials.APIKey = txtAPIKey.Text;
        //}

        private void btnFetchData_MouseEnter(object sender, EventArgs e)
        {
            Button_Highlight((Button)sender);
        }

        private void btnFetchData_MouseLeave(object sender, EventArgs e)
        {
            Button_UnHighlight((Button)sender);
        }

        private void btnRandom_MouseEnter(object sender, EventArgs e)
        {
            Button_Highlight((Button)sender);
        }

        private void btnRandom_MouseLeave(object sender, EventArgs e)
        {
            Button_UnHighlight((Button)sender);
        }

        private void btnOpenGamePageWebBrowser_MouseLeave(object sender, EventArgs e)
        {
            Button_UnHighlight((Button)sender);
        }

        private void btnOpenGamePageWebBrowser_MouseEnter(object sender, EventArgs e)
        {
            Button_Highlight((Button)sender);
        }

        void Button_Highlight(Button btn)
        {
            btn.BackColor = Color.White;
            btn.ForeColor = Color.Black;
            Console.WriteLine(btn.ToString() + "ON");
        }

        void Button_UnHighlight(Button btn)
        {
            btnFetchData.BackColor = Color.Black;
            btnFetchData.ForeColor = Color.White;
            Console.WriteLine(btn.ToString() + "OFF");
        }

    }

}
