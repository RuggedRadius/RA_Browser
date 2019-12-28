namespace RA_API.Displays
{
    partial class GameDisplay
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameDisplay));
            this.pbBoxArt = new System.Windows.Forms.PictureBox();
            this.lblGameTitle = new System.Windows.Forms.Label();
            this.grpAchievements = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pbInGame = new System.Windows.Forms.PictureBox();
            this.pbTitleScreen = new System.Windows.Forms.PictureBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lblID = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblConsole = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblPublisher = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblDeveloper = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblReleased = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.flpAchievements = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.pbBoxArt)).BeginInit();
            this.grpAchievements.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbInGame)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTitleScreen)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbBoxArt
            // 
            this.pbBoxArt.Image = global::RA_API.Properties.Resources.loading;
            this.pbBoxArt.Location = new System.Drawing.Point(6, 19);
            this.pbBoxArt.Name = "pbBoxArt";
            this.pbBoxArt.Size = new System.Drawing.Size(252, 343);
            this.pbBoxArt.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbBoxArt.TabIndex = 0;
            this.pbBoxArt.TabStop = false;
            // 
            // lblGameTitle
            // 
            this.lblGameTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGameTitle.ForeColor = System.Drawing.Color.Coral;
            this.lblGameTitle.Location = new System.Drawing.Point(13, 16);
            this.lblGameTitle.Name = "lblGameTitle";
            this.lblGameTitle.Size = new System.Drawing.Size(510, 49);
            this.lblGameTitle.TabIndex = 1;
            this.lblGameTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grpAchievements
            // 
            this.grpAchievements.Controls.Add(this.flpAchievements);
            this.grpAchievements.ForeColor = System.Drawing.Color.White;
            this.grpAchievements.Location = new System.Drawing.Point(283, 96);
            this.grpAchievements.Name = "grpAchievements";
            this.grpAchievements.Size = new System.Drawing.Size(536, 284);
            this.grpAchievements.TabIndex = 14;
            this.grpAchievements.TabStop = false;
            this.grpAchievements.Text = "Achievements";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblGameTitle);
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(282, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(537, 78);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Title";
            // 
            // pbInGame
            // 
            this.pbInGame.Image = ((System.Drawing.Image)(resources.GetObject("pbInGame.Image")));
            this.pbInGame.Location = new System.Drawing.Point(271, 19);
            this.pbInGame.Name = "pbInGame";
            this.pbInGame.Size = new System.Drawing.Size(252, 176);
            this.pbInGame.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbInGame.TabIndex = 1;
            this.pbInGame.TabStop = false;
            // 
            // pbTitleScreen
            // 
            this.pbTitleScreen.Image = ((System.Drawing.Image)(resources.GetObject("pbTitleScreen.Image")));
            this.pbTitleScreen.Location = new System.Drawing.Point(13, 19);
            this.pbTitleScreen.Name = "pbTitleScreen";
            this.pbTitleScreen.Size = new System.Drawing.Size(252, 176);
            this.pbTitleScreen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbTitleScreen.TabIndex = 1;
            this.pbTitleScreen.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.pbTitleScreen);
            this.groupBox3.Controls.Add(this.pbInGame);
            this.groupBox3.ForeColor = System.Drawing.Color.White;
            this.groupBox3.Location = new System.Drawing.Point(12, 386);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(537, 210);
            this.groupBox3.TabIndex = 17;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Screenshots";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.pbBoxArt);
            this.groupBox4.ForeColor = System.Drawing.Color.White;
            this.groupBox4.Location = new System.Drawing.Point(12, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(264, 368);
            this.groupBox4.TabIndex = 18;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Box Art";
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(103, 36);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(10, 13);
            this.lblID.TabIndex = 0;
            this.lblID.Text = "-";
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Location = new System.Drawing.Point(14, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblConsole
            // 
            this.lblConsole.AutoSize = true;
            this.lblConsole.Location = new System.Drawing.Point(103, 61);
            this.lblConsole.Name = "lblConsole";
            this.lblConsole.Size = new System.Drawing.Size(10, 13);
            this.lblConsole.TabIndex = 0;
            this.lblConsole.Text = "-";
            // 
            // label3
            // 
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label3.Location = new System.Drawing.Point(14, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 25);
            this.label3.TabIndex = 0;
            this.label3.Text = "Console";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPublisher
            // 
            this.lblPublisher.AutoSize = true;
            this.lblPublisher.Location = new System.Drawing.Point(103, 86);
            this.lblPublisher.Name = "lblPublisher";
            this.lblPublisher.Size = new System.Drawing.Size(10, 13);
            this.lblPublisher.TabIndex = 0;
            this.lblPublisher.Text = "-";
            // 
            // label4
            // 
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label4.Location = new System.Drawing.Point(14, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 25);
            this.label4.TabIndex = 0;
            this.label4.Text = "Publisher";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDeveloper
            // 
            this.lblDeveloper.AutoSize = true;
            this.lblDeveloper.Location = new System.Drawing.Point(103, 111);
            this.lblDeveloper.Name = "lblDeveloper";
            this.lblDeveloper.Size = new System.Drawing.Size(10, 13);
            this.lblDeveloper.TabIndex = 0;
            this.lblDeveloper.Text = "-";
            // 
            // label5
            // 
            this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label5.Location = new System.Drawing.Point(14, 105);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 25);
            this.label5.TabIndex = 0;
            this.label5.Text = "Developer";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblReleased
            // 
            this.lblReleased.AutoSize = true;
            this.lblReleased.Location = new System.Drawing.Point(103, 136);
            this.lblReleased.Name = "lblReleased";
            this.lblReleased.Size = new System.Drawing.Size(10, 13);
            this.lblReleased.TabIndex = 0;
            this.lblReleased.Text = "-";
            // 
            // label7
            // 
            this.label7.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label7.Location = new System.Drawing.Point(14, 130);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 25);
            this.label7.TabIndex = 0;
            this.label7.Text = "Released";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.lblReleased);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.lblDeveloper);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.lblPublisher);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.lblConsole);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lblID);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(555, 386);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(264, 210);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Game Details";
            // 
            // flpAchievements
            // 
            this.flpAchievements.Location = new System.Drawing.Point(6, 19);
            this.flpAchievements.Name = "flpAchievements";
            this.flpAchievements.Size = new System.Drawing.Size(524, 259);
            this.flpAchievements.TabIndex = 1;
            // 
            // GameDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(65)))));
            this.ClientSize = new System.Drawing.Size(832, 609);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.grpAchievements);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "GameDisplay";
            this.Text = "GameDisplay";
            this.Load += new System.EventHandler(this.GameDisplay_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbBoxArt)).EndInit();
            this.grpAchievements.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbInGame)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTitleScreen)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbBoxArt;
        private System.Windows.Forms.Label lblGameTitle;
        private System.Windows.Forms.GroupBox grpAchievements;
        private System.Windows.Forms.PictureBox pbInGame;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.PictureBox pbTitleScreen;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblConsole;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblPublisher;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblDeveloper;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblReleased;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.FlowLayoutPanel flpAchievements;
    }
}