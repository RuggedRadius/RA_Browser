using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RA_API.Connection;
using RA_API.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RA_API.Displays
{
    public partial class GameDisplay : Form
    {
        Game game;

        public GameDisplay()
        {

        }

        public GameDisplay(Game g)
        {
            InitializeComponent();
            game = g;
        }

        private void GameDisplay_Load(object sender, EventArgs e)
        {
            // Update form title
            Text = game.Title;

            // Game title label
            lblGameTitle.Text = game.Title;

            // Fetch missing data
            Task.Run(new Action(() => {
                FetchMissingData();
            }));

            // Load images
            loadImages();


        }

        void displayAchievements()
        {
            flpAchievements.AutoScroll = true;
            int counter = 0;
            foreach (Achievement a in game.Achievements)
            {
                

                PictureBox newIcon = new PictureBox();
                Task.Run(new Action(() =>
                {
                    newIcon.LoadAsync(Requests.GetBadgeUrlFromAchievement(a));
                }));
                
                newIcon.SizeMode = PictureBoxSizeMode.StretchImage;
                newIcon.Size = new Size(50, 50);
                newIcon.Cursor = Cursors.Hand;
                newIcon.Tag = counter;
                newIcon.Click += this.PictureClick;
                flpAchievements.Invoke(new Action(() => { flpAchievements.Controls.Add(newIcon); } ));
                counter++;
            }

        }

        private void PictureClick(object sender, EventArgs e)
        {
            var pb = (PictureBox)sender;
            int index = Int16.Parse(pb.Tag.ToString());
            Achievement achievement = game.Achievements[index];
            AchievementDisplay display = new AchievementDisplay(achievement);
            display.Show();
        }


        private MouseEventHandler showAchievementBrowser(Achievement a)
        {
            AchievementDisplay display = new AchievementDisplay(a);
            display.Show();
            return null;
            throw new NotImplementedException();
        }

        void updateLabels()
        {
            // Info
            lblID.Invoke(new Action(() => { lblID.Text = game.ID; }));
            lblConsole.Invoke(new Action(() => { lblConsole.Text = game.Console; }));
            lblDeveloper.Invoke(new Action(() => { lblDeveloper.Text = game.Developer; }));
            lblPublisher.Invoke(new Action(() => { lblPublisher.Text = game.Publisher; }));
            lblReleased.Invoke(new Action(() => { lblReleased.Text = game.Released; })); 
        }

        void loadImages()
        {
            // Box art
            Task.Run(new Action(() => {
                string url = Requests.GetImageURL_BoxArtbyID(Int16.Parse(game.ID));
                pbBoxArt.LoadAsync(url);
            }));
            // In-game screenshot
            Task.Run(new Action(() => {
                string url = Requests.GetImageURL_InGamebyID(Int16.Parse(game.ID));
                pbInGame.LoadAsync(url);
            }));
            // Title menu
            Task.Run(new Action(() => {
                string url = Requests.GetImageURL_TitleScreenbyID(Int16.Parse(game.ID));
                pbTitleScreen.LoadAsync(url);
            }));
        }

        void FetchMissingData()
        {
            // Fetch game data
            string url = Requests.requestURL(Constants.QueryTypes.WEB_GAME_INFO_EXTENDED, game.ID);
            string json = Requests.FetchJSON(url);
            dynamic data = JsonConvert.DeserializeObject(json);

            // Add game data to object
            game.Console = data["ConsoleName"];
            game.Publisher = data["Publisher"];
            game.Developer = data["Developer"];
            game.Released = data["Released"];

            // Create Achievement objects
            if (data["Achievements"] != null)
            {
                game.Achievements = new List<Achievement>();

                foreach (JProperty a in data["Achievements"])
                {
                    Achievement ac = new Achievement(a.Value);
                    game.Achievements.Add(ac);
                }
            }

            // Label info
            updateLabels();

            // Load and display achievements
            displayAchievements();
        }
    }
}
