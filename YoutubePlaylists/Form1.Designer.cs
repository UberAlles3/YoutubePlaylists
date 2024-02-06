
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtChannelId = new System.Windows.Forms.TextBox();
            this.btnGetPlaylists = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtDeletedVideos = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblPlaylistName = new System.Windows.Forms.Label();
            this.btnExport = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(12, 78);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(305, 486);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Channel Id:";
            // 
            // txtChannelId
            // 
            this.txtChannelId.Location = new System.Drawing.Point(87, 12);
            this.txtChannelId.Name = "txtChannelId";
            this.txtChannelId.Size = new System.Drawing.Size(230, 23);
            this.txtChannelId.TabIndex = 2;
            // 
            // btnGetPlaylists
            // 
            this.btnGetPlaylists.Location = new System.Drawing.Point(87, 41);
            this.btnGetPlaylists.Name = "btnGetPlaylists";
            this.btnGetPlaylists.Size = new System.Drawing.Size(230, 23);
            this.btnGetPlaylists.TabIndex = 3;
            this.btnGetPlaylists.Text = "Get Playlists";
            this.btnGetPlaylists.UseVisualStyleBackColor = true;
            this.btnGetPlaylists.Click += new System.EventHandler(this.btnGetPlaylists_Click);
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Location = new System.Drawing.Point(354, 78);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(530, 486);
            this.panel2.TabIndex = 1;
            // 
            // txtDeletedVideos
            // 
            this.txtDeletedVideos.Location = new System.Drawing.Point(910, 95);
            this.txtDeletedVideos.Multiline = true;
            this.txtDeletedVideos.Name = "txtDeletedVideos";
            this.txtDeletedVideos.Size = new System.Drawing.Size(162, 383);
            this.txtDeletedVideos.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(910, 76);
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
            this.lblPlaylistName.Location = new System.Drawing.Point(355, 48);
            this.lblPlaylistName.Name = "lblPlaylistName";
            this.lblPlaylistName.Size = new System.Drawing.Size(121, 21);
            this.lblPlaylistName.TabIndex = 6;
            this.lblPlaylistName.Text = "lblPlaylistName";
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(539, 41);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(82, 27);
            this.btnExport.TabIndex = 7;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1094, 626);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.lblPlaylistName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDeletedVideos);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnGetPlaylists);
            this.Controls.Add(this.txtChannelId);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
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
        private System.Windows.Forms.Button btnExport;
    }
}

