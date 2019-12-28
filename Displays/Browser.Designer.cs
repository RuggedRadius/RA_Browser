namespace RA_API
{
    partial class Browser
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Browser));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recentQueriesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewCurrentJSONDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.documentationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contactMeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.slblCurrentAction = new System.Windows.Forms.ToolStripStatusLabel();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDetailsTitle = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDetailsConsole = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnFetchData = new System.Windows.Forms.Button();
            this.txtDetailsPublisher = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDetailsDeveloper = new System.Windows.Forms.TextBox();
            this.txtGameID = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtDetailsGenre = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtDetailsReleased = new System.Windows.Forms.TextBox();
            this.btnRandom = new System.Windows.Forms.Button();
            this.btnOpenGamePageWebBrowser = new System.Windows.Forms.Button();
            this.imgBoxArt = new System.Windows.Forms.PictureBox();
            this.grpGameDetails = new System.Windows.Forms.GroupBox();
            this.dgvAchievements = new System.Windows.Forms.DataGridView();
            this.colBadge = new System.Windows.Forms.DataGridViewImageColumn();
            this.colAchieved = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AchievementDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AchievementTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AchID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grpAchievements = new System.Windows.Forms.GroupBox();
            this.imgTitle = new System.Windows.Forms.PictureBox();
            this.imgInGame = new System.Windows.Forms.PictureBox();
            this.grpArtwork = new System.Windows.Forms.GroupBox();
            this.lblAchievements = new System.Windows.Forms.Label();
            this.lblNormalPercent = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblHardcorePercent = new System.Windows.Forms.Label();
            this.progAchievements = new System.Windows.Forms.ProgressBar();
            this.progAchievementsHardcore = new System.Windows.Forms.ProgressBar();
            this.lblAchievementProgress = new System.Windows.Forms.Label();
            this.lblAchievementHardcoreProgress = new System.Windows.Forms.Label();
            this.grpAchievementProgress = new System.Windows.Forms.GroupBox();
            this.menuStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgBoxArt)).BeginInit();
            this.grpGameDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAchievements)).BeginInit();
            this.grpAchievements.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgInGame)).BeginInit();
            this.grpArtwork.SuspendLayout();
            this.grpAchievementProgress.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.documentationToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1432, 24);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.recentQueriesToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // recentQueriesToolStripMenuItem
            // 
            this.recentQueriesToolStripMenuItem.Name = "recentQueriesToolStripMenuItem";
            this.recentQueriesToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.recentQueriesToolStripMenuItem.Text = "Recent Queries";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.userDetailsToolStripMenuItem,
            this.viewCurrentJSONDataToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // userDetailsToolStripMenuItem
            // 
            this.userDetailsToolStripMenuItem.Name = "userDetailsToolStripMenuItem";
            this.userDetailsToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.userDetailsToolStripMenuItem.Text = "User Details";
            // 
            // viewCurrentJSONDataToolStripMenuItem
            // 
            this.viewCurrentJSONDataToolStripMenuItem.Name = "viewCurrentJSONDataToolStripMenuItem";
            this.viewCurrentJSONDataToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.viewCurrentJSONDataToolStripMenuItem.Text = "View Current JSON Data";
            this.viewCurrentJSONDataToolStripMenuItem.Click += new System.EventHandler(this.viewCurrentJSONDataToolStripMenuItem_Click);
            // 
            // documentationToolStripMenuItem
            // 
            this.documentationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem,
            this.aboutToolStripMenuItem,
            this.contactMeToolStripMenuItem});
            this.documentationToolStripMenuItem.Name = "documentationToolStripMenuItem";
            this.documentationToolStripMenuItem.Size = new System.Drawing.Size(102, 20);
            this.documentationToolStripMenuItem.Text = "Documentation";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.helpToolStripMenuItem.Text = "Help";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // contactMeToolStripMenuItem
            // 
            this.contactMeToolStripMenuItem.Name = "contactMeToolStripMenuItem";
            this.contactMeToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.contactMeToolStripMenuItem.Text = "Contact Me";
            this.contactMeToolStripMenuItem.Click += new System.EventHandler(this.contactMeToolStripMenuItem_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Retro Achievements Browser";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.Click += new System.EventHandler(this.notifyIcon1_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showToolStripMenuItem,
            this.exitToolStripMenuItem1,
            this.exitToolStripMenuItem2});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(189, 70);
            this.contextMenuStrip1.Text = "RA";
            // 
            // showToolStripMenuItem
            // 
            this.showToolStripMenuItem.Name = "showToolStripMenuItem";
            this.showToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.showToolStripMenuItem.Text = "Show";
            this.showToolStripMenuItem.Click += new System.EventHandler(this.showToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem1
            // 
            this.exitToolStripMenuItem1.Name = "exitToolStripMenuItem1";
            this.exitToolStripMenuItem1.Size = new System.Drawing.Size(188, 22);
            this.exitToolStripMenuItem1.Text = "Open RA in browser...";
            this.exitToolStripMenuItem1.Click += new System.EventHandler(this.exitToolStripMenuItem1_Click);
            // 
            // exitToolStripMenuItem2
            // 
            this.exitToolStripMenuItem2.Name = "exitToolStripMenuItem2";
            this.exitToolStripMenuItem2.Size = new System.Drawing.Size(188, 22);
            this.exitToolStripMenuItem2.Text = "Exit";
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.Transparent;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.slblCurrentAction});
            this.statusStrip1.Location = new System.Drawing.Point(0, 890);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1432, 22);
            this.statusStrip1.TabIndex = 13;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // slblCurrentAction
            // 
            this.slblCurrentAction.Name = "slblCurrentAction";
            this.slblCurrentAction.Size = new System.Drawing.Size(42, 17);
            this.slblCurrentAction.Text = "Ready.";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label4.Location = new System.Drawing.Point(40, 283);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Title";
            // 
            // txtDetailsTitle
            // 
            this.txtDetailsTitle.Location = new System.Drawing.Point(73, 280);
            this.txtDetailsTitle.Name = "txtDetailsTitle";
            this.txtDetailsTitle.Size = new System.Drawing.Size(511, 20);
            this.txtDetailsTitle.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label5.Location = new System.Drawing.Point(22, 309);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Console";
            // 
            // txtDetailsConsole
            // 
            this.txtDetailsConsole.Location = new System.Drawing.Point(73, 306);
            this.txtDetailsConsole.Name = "txtDetailsConsole";
            this.txtDetailsConsole.Size = new System.Drawing.Size(511, 20);
            this.txtDetailsConsole.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label6.Location = new System.Drawing.Point(17, 335);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Publisher";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(11, 207);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Game ID";
            // 
            // btnFetchData
            // 
            this.btnFetchData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(65)))));
            this.btnFetchData.ForeColor = System.Drawing.SystemColors.Control;
            this.btnFetchData.Location = new System.Drawing.Point(34, 234);
            this.btnFetchData.Name = "btnFetchData";
            this.btnFetchData.Size = new System.Drawing.Size(90, 34);
            this.btnFetchData.TabIndex = 1;
            this.btnFetchData.Text = "Fetch Data";
            this.btnFetchData.UseVisualStyleBackColor = false;
            this.btnFetchData.Click += new System.EventHandler(this.btnFetchData_Click);
            // 
            // txtDetailsPublisher
            // 
            this.txtDetailsPublisher.Location = new System.Drawing.Point(73, 332);
            this.txtDetailsPublisher.Name = "txtDetailsPublisher";
            this.txtDetailsPublisher.Size = new System.Drawing.Size(511, 20);
            this.txtDetailsPublisher.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label7.Location = new System.Drawing.Point(11, 361);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Developer";
            // 
            // txtDetailsDeveloper
            // 
            this.txtDetailsDeveloper.Location = new System.Drawing.Point(73, 358);
            this.txtDetailsDeveloper.Name = "txtDetailsDeveloper";
            this.txtDetailsDeveloper.Size = new System.Drawing.Size(511, 20);
            this.txtDetailsDeveloper.TabIndex = 1;
            // 
            // txtGameID
            // 
            this.txtGameID.Location = new System.Drawing.Point(73, 204);
            this.txtGameID.Name = "txtGameID";
            this.txtGameID.Size = new System.Drawing.Size(44, 20);
            this.txtGameID.TabIndex = 4;
            this.txtGameID.Text = "1738";
            this.txtGameID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtGameID_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label8.Location = new System.Drawing.Point(31, 387);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(36, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Genre";
            // 
            // txtDetailsGenre
            // 
            this.txtDetailsGenre.Location = new System.Drawing.Point(73, 384);
            this.txtDetailsGenre.Name = "txtDetailsGenre";
            this.txtDetailsGenre.Size = new System.Drawing.Size(511, 20);
            this.txtDetailsGenre.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label9.Location = new System.Drawing.Point(15, 413);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(52, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "Released";
            // 
            // txtDetailsReleased
            // 
            this.txtDetailsReleased.Location = new System.Drawing.Point(73, 410);
            this.txtDetailsReleased.Name = "txtDetailsReleased";
            this.txtDetailsReleased.Size = new System.Drawing.Size(511, 20);
            this.txtDetailsReleased.TabIndex = 1;
            // 
            // btnOpenGamePageWebBrowser
            // 
            this.btnOpenGamePageWebBrowser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(65)))));
            this.btnOpenGamePageWebBrowser.ForeColor = System.Drawing.SystemColors.Control;
            this.btnOpenGamePageWebBrowser.Location = new System.Drawing.Point(485, 234);
            this.btnOpenGamePageWebBrowser.Name = "btnOpenGamePageWebBrowser";
            this.btnOpenGamePageWebBrowser.Size = new System.Drawing.Size(99, 34);
            this.btnOpenGamePageWebBrowser.TabIndex = 6;
            this.btnOpenGamePageWebBrowser.Text = "Open game page in browser";
            this.btnOpenGamePageWebBrowser.UseVisualStyleBackColor = false;
            this.btnOpenGamePageWebBrowser.Click += new System.EventHandler(this.btnOpenGamePageWebBrowser_Click);
            // 
            // imgBoxArt
            // 
            this.imgBoxArt.Location = new System.Drawing.Point(205, 19);
            this.imgBoxArt.Name = "imgBoxArt";
            this.imgBoxArt.Size = new System.Drawing.Size(197, 249);
            this.imgBoxArt.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgBoxArt.TabIndex = 3;
            this.imgBoxArt.TabStop = false;
            // 
            // grpGameDetails
            // 
            this.grpGameDetails.Controls.Add(this.imgBoxArt);
            this.grpGameDetails.Controls.Add(this.btnOpenGamePageWebBrowser);
            this.grpGameDetails.Controls.Add(this.btnRandom);
            this.grpGameDetails.Controls.Add(this.txtDetailsReleased);
            this.grpGameDetails.Controls.Add(this.label9);
            this.grpGameDetails.Controls.Add(this.txtDetailsGenre);
            this.grpGameDetails.Controls.Add(this.label8);
            this.grpGameDetails.Controls.Add(this.txtGameID);
            this.grpGameDetails.Controls.Add(this.txtDetailsDeveloper);
            this.grpGameDetails.Controls.Add(this.label7);
            this.grpGameDetails.Controls.Add(this.txtDetailsPublisher);
            this.grpGameDetails.Controls.Add(this.btnFetchData);
            this.grpGameDetails.Controls.Add(this.label3);
            this.grpGameDetails.Controls.Add(this.label6);
            this.grpGameDetails.Controls.Add(this.txtDetailsConsole);
            this.grpGameDetails.Controls.Add(this.label5);
            this.grpGameDetails.Controls.Add(this.txtDetailsTitle);
            this.grpGameDetails.Controls.Add(this.label4);
            this.grpGameDetails.ForeColor = System.Drawing.SystemColors.Control;
            this.grpGameDetails.Location = new System.Drawing.Point(12, 27);
            this.grpGameDetails.Name = "grpGameDetails";
            this.grpGameDetails.Size = new System.Drawing.Size(590, 446);
            this.grpGameDetails.TabIndex = 5;
            this.grpGameDetails.TabStop = false;
            this.grpGameDetails.Text = "Game Details";
            // 
            // dgvAchievements
            // 
            this.dgvAchievements.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvAchievements.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAchievements.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(65)))));
            this.dgvAchievements.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAchievements.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.AchID,
            this.AchievementTitle,
            this.AchievementDescription,
            this.colAchieved,
            this.colBadge});
            this.dgvAchievements.Location = new System.Drawing.Point(6, 19);
            this.dgvAchievements.Name = "dgvAchievements";
            this.dgvAchievements.RowTemplate.Height = 100;
            this.dgvAchievements.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvAchievements.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAchievements.Size = new System.Drawing.Size(804, 835);
            this.dgvAchievements.TabIndex = 2;
            this.dgvAchievements.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvAchievements_CellMouseClick);
            this.dgvAchievements.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgvAchievements_RowsAdded);
            // 
            // colBadge
            // 
            this.colBadge.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colBadge.FillWeight = 15F;
            this.colBadge.HeaderText = "Badge";
            this.colBadge.MinimumWidth = 150;
            this.colBadge.Name = "colBadge";
            this.colBadge.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colBadge.Width = 150;
            // 
            // colAchieved
            // 
            this.colAchieved.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colAchieved.FillWeight = 10F;
            this.colAchieved.HeaderText = "Achieved";
            this.colAchieved.MinimumWidth = 50;
            this.colAchieved.Name = "colAchieved";
            this.colAchieved.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colAchieved.Width = 62;
            // 
            // AchievementDescription
            // 
            this.AchievementDescription.FillWeight = 60F;
            this.AchievementDescription.HeaderText = "Achievement Description";
            this.AchievementDescription.Name = "AchievementDescription";
            // 
            // AchievementTitle
            // 
            this.AchievementTitle.FillWeight = 40F;
            this.AchievementTitle.HeaderText = "Title";
            this.AchievementTitle.Name = "AchievementTitle";
            // 
            // AchID
            // 
            this.AchID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.AchID.FillWeight = 5F;
            this.AchID.HeaderText = "ID";
            this.AchID.MinimumWidth = 50;
            this.AchID.Name = "AchID";
            this.AchID.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.AchID.Width = 50;
            // 
            // grpAchievements
            // 
            this.grpAchievements.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpAchievements.Controls.Add(this.dgvAchievements);
            this.grpAchievements.ForeColor = System.Drawing.Color.White;
            this.grpAchievements.Location = new System.Drawing.Point(608, 27);
            this.grpAchievements.Name = "grpAchievements";
            this.grpAchievements.Size = new System.Drawing.Size(816, 860);
            this.grpAchievements.TabIndex = 6;
            this.grpAchievements.TabStop = false;
            this.grpAchievements.Text = "Achievements";
            // 
            // imgTitle
            // 
            this.imgTitle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.imgTitle.Location = new System.Drawing.Point(6, 24);
            this.imgTitle.Name = "imgTitle";
            this.imgTitle.Size = new System.Drawing.Size(286, 201);
            this.imgTitle.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgTitle.TabIndex = 3;
            this.imgTitle.TabStop = false;
            // 
            // imgInGame
            // 
            this.imgInGame.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.imgInGame.Location = new System.Drawing.Point(298, 24);
            this.imgInGame.Name = "imgInGame";
            this.imgInGame.Size = new System.Drawing.Size(286, 201);
            this.imgInGame.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgInGame.TabIndex = 3;
            this.imgInGame.TabStop = false;
            // 
            // grpArtwork
            // 
            this.grpArtwork.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.grpArtwork.Controls.Add(this.imgInGame);
            this.grpArtwork.Controls.Add(this.imgTitle);
            this.grpArtwork.ForeColor = System.Drawing.SystemColors.Control;
            this.grpArtwork.Location = new System.Drawing.Point(12, 652);
            this.grpArtwork.Name = "grpArtwork";
            this.grpArtwork.Size = new System.Drawing.Size(590, 235);
            this.grpArtwork.TabIndex = 10;
            this.grpArtwork.TabStop = false;
            this.grpArtwork.Text = "Artwork";
            this.grpArtwork.Visible = false;
            // 
            // lblAchievements
            // 
            this.lblAchievements.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblAchievements.Location = new System.Drawing.Point(6, 76);
            this.lblAchievements.Name = "lblAchievements";
            this.lblAchievements.Size = new System.Drawing.Size(144, 35);
            this.lblAchievements.TabIndex = 0;
            this.lblAchievements.Text = "Achievements";
            this.lblAchievements.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblNormalPercent
            // 
            this.lblNormalPercent.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblNormalPercent.Location = new System.Drawing.Point(531, 76);
            this.lblNormalPercent.Name = "lblNormalPercent";
            this.lblNormalPercent.Size = new System.Drawing.Size(53, 35);
            this.lblNormalPercent.TabIndex = 0;
            this.lblNormalPercent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Location = new System.Drawing.Point(6, 121);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 35);
            this.label1.TabIndex = 0;
            this.label1.Text = "Hardcore Achievements";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblHardcorePercent
            // 
            this.lblHardcorePercent.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblHardcorePercent.Location = new System.Drawing.Point(531, 121);
            this.lblHardcorePercent.Name = "lblHardcorePercent";
            this.lblHardcorePercent.Size = new System.Drawing.Size(53, 35);
            this.lblHardcorePercent.TabIndex = 0;
            this.lblHardcorePercent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // progAchievements
            // 
            this.progAchievements.Location = new System.Drawing.Point(156, 86);
            this.progAchievements.Name = "progAchievements";
            this.progAchievements.Size = new System.Drawing.Size(369, 16);
            this.progAchievements.Step = 1;
            this.progAchievements.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progAchievements.TabIndex = 1;
            // 
            // progAchievementsHardcore
            // 
            this.progAchievementsHardcore.Location = new System.Drawing.Point(156, 131);
            this.progAchievementsHardcore.Name = "progAchievementsHardcore";
            this.progAchievementsHardcore.Size = new System.Drawing.Size(369, 16);
            this.progAchievementsHardcore.Step = 1;
            this.progAchievementsHardcore.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progAchievementsHardcore.TabIndex = 1;
            // 
            // lblAchievementProgress
            // 
            this.lblAchievementProgress.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAchievementProgress.Location = new System.Drawing.Point(6, 16);
            this.lblAchievementProgress.Name = "lblAchievementProgress";
            this.lblAchievementProgress.Size = new System.Drawing.Size(578, 26);
            this.lblAchievementProgress.TabIndex = 2;
            this.lblAchievementProgress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAchievementHardcoreProgress
            // 
            this.lblAchievementHardcoreProgress.Location = new System.Drawing.Point(6, 42);
            this.lblAchievementHardcoreProgress.Name = "lblAchievementHardcoreProgress";
            this.lblAchievementHardcoreProgress.Size = new System.Drawing.Size(578, 26);
            this.lblAchievementHardcoreProgress.TabIndex = 2;
            this.lblAchievementHardcoreProgress.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // grpAchievementProgress
            // 
            this.grpAchievementProgress.Controls.Add(this.lblAchievementHardcoreProgress);
            this.grpAchievementProgress.Controls.Add(this.lblAchievementProgress);
            this.grpAchievementProgress.Controls.Add(this.progAchievementsHardcore);
            this.grpAchievementProgress.Controls.Add(this.progAchievements);
            this.grpAchievementProgress.Controls.Add(this.lblHardcorePercent);
            this.grpAchievementProgress.Controls.Add(this.label1);
            this.grpAchievementProgress.Controls.Add(this.lblNormalPercent);
            this.grpAchievementProgress.Controls.Add(this.lblAchievements);
            this.grpAchievementProgress.ForeColor = System.Drawing.SystemColors.Control;
            this.grpAchievementProgress.Location = new System.Drawing.Point(12, 479);
            this.grpAchievementProgress.Name = "grpAchievementProgress";
            this.grpAchievementProgress.Size = new System.Drawing.Size(590, 167);
            this.grpAchievementProgress.TabIndex = 12;
            this.grpAchievementProgress.TabStop = false;
            this.grpAchievementProgress.Text = "Achievement Progress";
            this.grpAchievementProgress.Visible = false;
            // 
            // Browser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(65)))));
            this.ClientSize = new System.Drawing.Size(1432, 912);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.grpAchievementProgress);
            this.Controls.Add(this.grpArtwork);
            this.Controls.Add(this.grpAchievements);
            this.Controls.Add(this.grpGameDetails);
            this.Controls.Add(this.menuStrip1);
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximumSize = new System.Drawing.Size(1920, 1055);
            this.MinimumSize = new System.Drawing.Size(950, 605);
            this.Name = "Browser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Retro Achievements";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgBoxArt)).EndInit();
            this.grpGameDetails.ResumeLayout(false);
            this.grpGameDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAchievements)).EndInit();
            this.grpAchievements.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imgTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgInGame)).EndInit();
            this.grpArtwork.ResumeLayout(false);
            this.grpAchievementProgress.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem recentQueriesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem userDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem documentationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewCurrentJSONDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem contactMeToolStripMenuItem;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem showToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem2;
        private System.Windows.Forms.StatusStrip statusStrip1;
        public System.Windows.Forms.ToolStripStatusLabel slblCurrentAction;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDetailsTitle;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDetailsConsole;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnFetchData;
        private System.Windows.Forms.TextBox txtDetailsPublisher;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtDetailsDeveloper;
        private System.Windows.Forms.TextBox txtGameID;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtDetailsGenre;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtDetailsReleased;
        private System.Windows.Forms.Button btnRandom;
        private System.Windows.Forms.Button btnOpenGamePageWebBrowser;
        private System.Windows.Forms.PictureBox imgBoxArt;
        private System.Windows.Forms.GroupBox grpGameDetails;
        private System.Windows.Forms.DataGridView dgvAchievements;
        private System.Windows.Forms.DataGridViewTextBoxColumn AchID;
        private System.Windows.Forms.DataGridViewTextBoxColumn AchievementTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn AchievementDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAchieved;
        private System.Windows.Forms.DataGridViewImageColumn colBadge;
        private System.Windows.Forms.GroupBox grpAchievements;
        private System.Windows.Forms.PictureBox imgTitle;
        private System.Windows.Forms.PictureBox imgInGame;
        private System.Windows.Forms.GroupBox grpArtwork;
        private System.Windows.Forms.Label lblAchievements;
        private System.Windows.Forms.Label lblNormalPercent;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblHardcorePercent;
        private System.Windows.Forms.ProgressBar progAchievements;
        private System.Windows.Forms.ProgressBar progAchievementsHardcore;
        private System.Windows.Forms.Label lblAchievementProgress;
        private System.Windows.Forms.Label lblAchievementHardcoreProgress;
        private System.Windows.Forms.GroupBox grpAchievementProgress;
    }
}

