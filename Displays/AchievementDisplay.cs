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



namespace RA_API
{
    public partial class AchievementDisplay : Form
    {
        Achievement achMnt;
        WebBrowser wb;
        bool achievementEarned = false;

        Image trophy = Properties.Resources.Trophy_Icon_PNG_02;

        public AchievementDisplay()
        {
            InitializeComponent();
        }

        public AchievementDisplay(Achievement a)
        {
            InitializeComponent();
            achMnt = a;

            if (a.DateEarned != null)
            {
                imgAchievement.ImageLocation = String.Format(Constants.BaseURLs.BADGE_IMAGE_UNLOCKED, a.BadgeName);
            }
            else
            {
                imgAchievement.ImageLocation = String.Format(Constants.BaseURLs.BADGE_IMAGE_LOCKED, a.BadgeName);
            }
        }

        private void AchievementDisplay_Load(object sender, EventArgs e)
        {
            lblTitle.Text = achMnt.Title;
            lblDescription.Text = achMnt.Description;

            txtAuthor.Text = achMnt.Author;
            txtBadgeName.Text = achMnt.BadgeName;
            txtDateCreated.Text = achMnt.DateCreated;
            txtDateModified.Text = achMnt.DateModified;
            txtDescription.Text = achMnt.Description;
            txtDisplayOrder.Text = achMnt.DisplayOrder;
            txtID.Text = achMnt.ID;
            txtMemAddr.Text = achMnt.MemAddr;
            txtNumAwarded.Text = achMnt.NumAwarded;
            txtNumAwardedHardcore.Text = achMnt.NumAwardedHardcore;
            txtPoints.Text = achMnt.Points;
            txtTitle.Text = achMnt.Title;
            txtTrueRatio.Text = achMnt.TrueRatio;

            if (achMnt.DateEarned != null)
            {
                achievementEarned = true;
                grpEarned.Visible = true;
                lblDateEarned.Text = achMnt.DateEarned;

                if (achMnt.DateEarnedHardCore != null)
                {
                    lblDateEarnedHardcore.Text = achMnt.DateEarnedHardCore;
                }
                else
                {
                    lblDateEarnedHardcore.Text = string.Empty;
                }
            }
            else
            {
                lblDateEarned.Text = string.Empty;
            }

        }

        private void btnOpenInBrowser_Click(object sender, EventArgs e)
        {
            string url = String.Format(Constants.BaseURLs.PAGE_ACHIEVEMENT, achMnt.ID);
            System.Diagnostics.Process.Start(url);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
