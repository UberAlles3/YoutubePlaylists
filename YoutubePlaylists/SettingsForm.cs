using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YoutubePlaylists
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            lblExportPath.Text = Settings.ExportPath;
            txtExportPath.Text = Settings.ExportPath;
        }

        private void btnSaveExportPath_Click(object sender, EventArgs e)
        {
            if(lblExportPath.Text != txtExportPath.Text)
            {
                try
                {
                    Directory.CreateDirectory(txtExportPath.Text);
                    Settings.ExportPath = txtExportPath.Text;
                    lblExportPath.Text = txtExportPath.Text;
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Invalid path. Setting was not saved.");
                }
            }
        }
    }
}
