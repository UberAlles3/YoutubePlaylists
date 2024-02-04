
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
            this.SuspendLayout();
            // 
            // panel1
            // 
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(978, 626);
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
    }
}

