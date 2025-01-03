﻿
namespace YoutubePlaylists
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtChannelId = new System.Windows.Forms.TextBox();
            this.btnGetPlaylists = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtDeletedVideos = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblPlaylistName = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.exportingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportCurrentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mergeAllExportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openExportedFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backupMergedPlaylistToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sttingsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSearch = new System.Windows.Forms.Button();
            this.picSpinner = new System.Windows.Forms.PictureBox();
            this.picSpinner2 = new System.Windows.Forms.PictureBox();
            this.lblTaskFeedback = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.ComparetoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSpinner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSpinner2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(12, 95);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(273, 486);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Channel Id:";
            // 
            // txtChannelId
            // 
            this.txtChannelId.Location = new System.Drawing.Point(87, 29);
            this.txtChannelId.Name = "txtChannelId";
            this.txtChannelId.Size = new System.Drawing.Size(198, 23);
            this.txtChannelId.TabIndex = 2;
            // 
            // btnGetPlaylists
            // 
            this.btnGetPlaylists.Location = new System.Drawing.Point(87, 58);
            this.btnGetPlaylists.Name = "btnGetPlaylists";
            this.btnGetPlaylists.Size = new System.Drawing.Size(198, 23);
            this.btnGetPlaylists.TabIndex = 3;
            this.btnGetPlaylists.Text = "Get Playlists";
            this.btnGetPlaylists.UseVisualStyleBackColor = true;
            this.btnGetPlaylists.Click += new System.EventHandler(this.btnGetPlaylists_Click);
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Location = new System.Drawing.Point(319, 36);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(562, 545);
            this.panel2.TabIndex = 1;
            // 
            // txtDeletedVideos
            // 
            this.txtDeletedVideos.Location = new System.Drawing.Point(899, 58);
            this.txtDeletedVideos.Multiline = true;
            this.txtDeletedVideos.Name = "txtDeletedVideos";
            this.txtDeletedVideos.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDeletedVideos.Size = new System.Drawing.Size(174, 206);
            this.txtDeletedVideos.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(933, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Deleted Video Ids";
            // 
            // lblPlaylistName
            // 
            this.lblPlaylistName.AutoSize = true;
            this.lblPlaylistName.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblPlaylistName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblPlaylistName.Location = new System.Drawing.Point(319, 9);
            this.lblPlaylistName.Name = "lblPlaylistName";
            this.lblPlaylistName.Size = new System.Drawing.Size(121, 21);
            this.lblPlaylistName.TabIndex = 6;
            this.lblPlaylistName.Text = "lblPlaylistName";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(625, 7);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(174, 23);
            this.txtSearch.TabIndex = 10;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.MenuBar;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem,
            this.exportingToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.ComparetoolStripMenuItem,
            this.sttingsMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1085, 24);
            this.menuStrip1.TabIndex = 11;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem1});
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.exitToolStripMenuItem.Text = "&File";
            // 
            // exitToolStripMenuItem1
            // 
            this.exitToolStripMenuItem1.Name = "exitToolStripMenuItem1";
            this.exitToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.exitToolStripMenuItem1.Text = "&Exit        Alt+F4";
            this.exitToolStripMenuItem1.Click += new System.EventHandler(this.exitToolStripMenuItem1_Click);
            // 
            // exportingToolStripMenuItem
            // 
            this.exportingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportCurrentToolStripMenuItem,
            this.exportAllToolStripMenuItem,
            this.mergeAllExportsToolStripMenuItem});
            this.exportingToolStripMenuItem.Name = "exportingToolStripMenuItem";
            this.exportingToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.exportingToolStripMenuItem.Text = "&Export";
            // 
            // exportCurrentToolStripMenuItem
            // 
            this.exportCurrentToolStripMenuItem.Name = "exportCurrentToolStripMenuItem";
            this.exportCurrentToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.exportCurrentToolStripMenuItem.Text = "Export &Current Playlist";
            this.exportCurrentToolStripMenuItem.Click += new System.EventHandler(this.exportCurrentToolStripMenuItem_Click);
            // 
            // exportAllToolStripMenuItem
            // 
            this.exportAllToolStripMenuItem.Name = "exportAllToolStripMenuItem";
            this.exportAllToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.exportAllToolStripMenuItem.Text = "Export &All Playlists";
            this.exportAllToolStripMenuItem.Click += new System.EventHandler(this.exportAllToolStripMenuItem_Click);
            // 
            // mergeAllExportsToolStripMenuItem
            // 
            this.mergeAllExportsToolStripMenuItem.Name = "mergeAllExportsToolStripMenuItem";
            this.mergeAllExportsToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.mergeAllExportsToolStripMenuItem.Text = "&Merge All Exports";
            this.mergeAllExportsToolStripMenuItem.Click += new System.EventHandler(this.mergeAllExportsToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openExportedFileToolStripMenuItem,
            this.backupMergedPlaylistToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(94, 20);
            this.settingsToolStripMenuItem.Text = "Export &Output";
            // 
            // openExportedFileToolStripMenuItem
            // 
            this.openExportedFileToolStripMenuItem.Name = "openExportedFileToolStripMenuItem";
            this.openExportedFileToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.openExportedFileToolStripMenuItem.Text = "&Open Exported File";
            this.openExportedFileToolStripMenuItem.Click += new System.EventHandler(this.openExportedFileToolStripMenuItem_Click);
            // 
            // backupMergedPlaylistToolStripMenuItem
            // 
            this.backupMergedPlaylistToolStripMenuItem.Name = "backupMergedPlaylistToolStripMenuItem";
            this.backupMergedPlaylistToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.backupMergedPlaylistToolStripMenuItem.Text = "&Backup Merged Playlist";
            this.backupMergedPlaylistToolStripMenuItem.Click += new System.EventHandler(this.backupMergedPlaylistToolStripMenuItem_Click);
            // 
            // sttingsMenuItem
            // 
            this.sttingsMenuItem.Name = "sttingsMenuItem";
            this.sttingsMenuItem.Size = new System.Drawing.Size(61, 20);
            this.sttingsMenuItem.Text = "&Settings";
            this.sttingsMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(806, 7);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 12;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // picSpinner
            // 
            this.picSpinner.BackColor = System.Drawing.Color.Transparent;
            this.picSpinner.Image = ((System.Drawing.Image)(resources.GetObject("picSpinner.Image")));
            this.picSpinner.Location = new System.Drawing.Point(50, 56);
            this.picSpinner.Name = "picSpinner";
            this.picSpinner.Size = new System.Drawing.Size(25, 25);
            this.picSpinner.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picSpinner.TabIndex = 14;
            this.picSpinner.TabStop = false;
            // 
            // picSpinner2
            // 
            this.picSpinner2.BackColor = System.Drawing.Color.Transparent;
            this.picSpinner2.Image = ((System.Drawing.Image)(resources.GetObject("picSpinner2.Image")));
            this.picSpinner2.Location = new System.Drawing.Point(319, 5);
            this.picSpinner2.Name = "picSpinner2";
            this.picSpinner2.Size = new System.Drawing.Size(25, 25);
            this.picSpinner2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picSpinner2.TabIndex = 15;
            this.picSpinner2.TabStop = false;
            // 
            // lblTaskFeedback
            // 
            this.lblTaskFeedback.AutoSize = true;
            this.lblTaskFeedback.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTaskFeedback.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblTaskFeedback.Location = new System.Drawing.Point(350, 9);
            this.lblTaskFeedback.Name = "lblTaskFeedback";
            this.lblTaskFeedback.Size = new System.Drawing.Size(54, 21);
            this.lblTaskFeedback.TabIndex = 16;
            this.lblTaskFeedback.Text = "label3";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(806, 7);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 17;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // ComparetoolStripMenuItem
            // 
            this.ComparetoolStripMenuItem.Name = "ComparetoolStripMenuItem";
            this.ComparetoolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.ComparetoolStripMenuItem.Text = "Compare";
            this.ComparetoolStripMenuItem.Click += new System.EventHandler(this.compareToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AcceptButton = this.btnSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1085, 597);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblTaskFeedback);
            this.Controls.Add(this.picSpinner2);
            this.Controls.Add(this.picSpinner);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.lblPlaylistName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDeletedVideos);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnGetPlaylists);
            this.Controls.Add(this.txtChannelId);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Youtube Playlist Manager";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSpinner)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSpinner2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtChannelId;
        private System.Windows.Forms.Button btnGetPlaylists;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtDeletedVideos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblPlaylistName;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportCurrentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mergeAllExportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.PictureBox picSpinner;
        private System.Windows.Forms.PictureBox picSpinner2;
        private System.Windows.Forms.ToolStripMenuItem sttingsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openExportedFileToolStripMenuItem;
        private System.Windows.Forms.Label lblTaskFeedback;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ToolStripMenuItem backupMergedPlaylistToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ComparetoolStripMenuItem;
    }
}

