﻿using System;
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
using Google.Apis.YouTube.v3;
using Google.Apis.Services;
using System.IO;

namespace YoutubePlaylists
{
    public partial class Form1 : Form
    {
        //private static string _playlistId = "PLd4S0e5MPnVi3fD3O0VKFLyUwbiNrsHRF"; // https://www.youtube.com/playlist?list=PLzByySESNL7GKiOXOs7ew5vEFBxuJvf0D
        private static string _channelId = "UCxMu8S3Q9Btpa56CsI58KDQ"; // https://www.youtube.com/@uberalles2/playlists
        private static string _playlistId = "";

        Youtube _youtube = new Youtube();
        List<ChannelOutput.Playlist> Playlists;
        List<PlaylistOutput.Videos> Videos;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtChannelId.Text = _channelId;
            lblPlaylistName.Text = "";
        }

        private void btnGetPlaylists_Click(object sender, EventArgs e)
        {
            Playlists = _youtube.GetPlaylistsByChannelId(txtChannelId.Text.Trim());

            panel1.Controls.Clear();
            List<CheckBox> checkboxlList = DynamicControls.CreateDynamicControls<CheckBox>(panel1, "chkboxPlaylist", Playlists.Count, 20, 0, 10, 10, 20, 20);
            List<Label> labelList = DynamicControls.CreateDynamicControls<Label>(panel1, "lblPlaylist", Playlists.Count, 20, 0, 12, 30, 20, 200);

            int i = 0;
            foreach (ChannelOutput.Playlist item in Playlists)
            {
                checkboxlList.ElementAt(i).CheckedChanged += new EventHandler(chkboxPlaylist_CheckedChanged);
                labelList.ElementAt(i).Text = item.Title + $"  ({item.ItemCount})";
                i++;
            }
        }

        private void chkboxPlaylist_CheckedChanged(object sender, EventArgs e)
        {
            if (((CheckBox)sender).Checked == true)
            {
                int element = (int)((CheckBox)sender).Tag;
                lblPlaylistName.Text = Playlists.ElementAt(element).Title;
                _playlistId = Playlists.ElementAt(element).PlaylistId;

                // Get videos
                string playlistId = Playlists.ElementAt(element).PlaylistId;
                Videos = _youtube.GetVideosByPlaylistId(playlistId);

                panel2.Controls.Clear();
                txtDeletedVideos.Text = "";
                List<PictureBox> pictureList = DynamicControls.CreateDynamicControls<PictureBox>(panel2, "picVideo", Videos.Count, 80, 0, 12, 10, 60, 100);
                List<Label> labelList = DynamicControls.CreateDynamicControls<Label>(panel2, "lblVideo", Videos.Count, 80, 0, 12, 120, 20, 360);
                List<Label> labelDescList = DynamicControls.CreateDynamicControls<Label>(panel2, "lblVideoDesc", Videos.Count, 80, 0, 32, 120, 16, 360);
                List<Label> labelVideoIdList = DynamicControls.CreateDynamicControls<Label>(panel2, "lblVideoID", Videos.Count, 80, 0, 52, 120, 20, 300);
                List<Button> btnRemoveList = DynamicControls.CreateDynamicControls<Button>(panel2, "btnRemove", Videos.Count, 80, 0, 48, 440, 24, 60);

                int i = 0;
                foreach (PlaylistOutput.Videos item in Videos)
                {
                    string description = item.Description;
                    string title = item.Title;

                    if (item.Description.Contains("video is unavailabel") || item.Description.Contains("video is private") || item.Title.Contains("Deleted video"))
                    {
                        txtDeletedVideos.Text += item.VideoId + Environment.NewLine;
                        labelList.ElementAt(i).Text = item.Title;
                        labelDescList.ElementAt(i).Text = item.Description;
                        labelVideoIdList.ElementAt(i).Text = $"Id: {item.VideoId} LongId: {item.PlaylistVideoId.Substring(0, 8)}";
                        btnRemoveList.ElementAt(i).Text = "Remove";
                        btnRemoveList.ElementAt(i).Visible = true;
                        btnRemoveList.ElementAt(i).Click += new EventHandler(btnRemove_Click);
                    }
                    else
                    {
                        pictureList.ElementAt(i).SizeMode = PictureBoxSizeMode.CenterImage;
                        pictureList.ElementAt(i).Load(item.ThumbnailsData[0].ImageUri.ToString());
                        labelList.ElementAt(i).Text = item.Title;
                        labelDescList.ElementAt(i).Text = item.Description;
                        labelVideoIdList.ElementAt(i).Text = $"Id: {item.VideoId} LongId: {item.PlaylistVideoId.Substring(0, 8)}";
                        btnRemoveList.ElementAt(i).Text = "Remove";
                        btnRemoveList.ElementAt(i).Visible = true;
                        btnRemoveList.ElementAt(i).Click += new EventHandler(btnRemove_Click);
                    }
                    i++;
                }
            }
        }
        
        private void btnRemove_Click(object sender, EventArgs e)
        {
            int element = (int)((Button)sender).Tag;
            string playlistVideoId = Videos.ElementAt(element).PlaylistVideoId;

            var result = _youtube.RemoveItemFromPlaylist(playlistVideoId);

            if (result.Contains("Playlist item not found."))
            {
                MessageBox.Show("Playlist item not found.");
            }
            else if (result.Contains("Errors"))
            {
                MessageBox.Show(result);
            }
            ((Button)sender).Visible = false;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), lblPlaylistName.Text.Replace("/", "-") + ".csv");

            using (var file = File.CreateText(path))
            {
                foreach (var data in Videos)
                {
                    string line = $"{_playlistId},{lblPlaylistName.Text.Replace("/", " - ")}{data.PlaylistVideoId},{data.VideoId}";
                    line += $",{Truncate(data.Title.Replace(",", " - "), 30)},{Truncate(data.Description.Replace(",", " - "), 40)},{((data.ThumbnailsData == null) ? "" : data.ThumbnailsData[0].ImageUri.ToString())}";
                    file.WriteLine(line);
                }
            }
        }
        public string Truncate(string value, int maxLength)
        {
            if (string.IsNullOrEmpty(value)) return value;
            return value.Length <= maxLength ? value : value.Substring(0, maxLength);
        }
    }
}
