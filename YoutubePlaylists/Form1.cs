using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using YoutubeSharpApi;
using YoutubeSharpApi.Models;

namespace YoutubePlaylists
{
    public partial class Form1 : Form
    {
        //private static string _playlistId = "PLd4S0e5MPnVi3fD3O0VKFLyUwbiNrsHRF"; // https://www.youtube.com/playlist?list=PLzByySESNL7GKiOXOs7ew5vEFBxuJvf0D
        private static string _channelId = "UCxMu8S3Q9Btpa56CsI58KDQ"; // https://www.youtube.com/@uberalles2/playlists

        Youtube _youtube = new Youtube();
        List<ChannelOutput.Playlist> Playlists;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtChannelId.Text = _channelId;
        }

        private void btnGetPlaylists_Click(object sender, EventArgs e)
        {
            Playlists = _youtube.GetPlaylistsByChannelId(txtChannelId.Text.Trim());

            List<CheckBox> checkboxlList = DynamicControls.CreateDynamicControls<CheckBox>(panel1, "chkboxPlaylist", Playlists.Count, 20, 0, 10, 10, 20, 20);
            List<Label> lableList = DynamicControls.CreateDynamicControls<Label>(panel1, "lblPlaylist", Playlists.Count, 20, 0, 12, 30, 20, 200);
            int i = 0;

            //.ElementAt(0);
            foreach (ChannelOutput.Playlist item in Playlists)
            {
                checkboxlList.ElementAt(i).CheckedChanged += new EventHandler(chkboxPlaylist_CheckedChanged);
                lableList.ElementAt(i).Text = item.Title + $"  ({item.ItemCount})";
                i++;
            }
        }

        private void chkboxPlaylist_CheckedChanged(object sender, EventArgs e)
        {
           if(((CheckBox)sender).Checked == true)
            {
                // Get videos
                int i = 0;

            }
        }
    }
}
