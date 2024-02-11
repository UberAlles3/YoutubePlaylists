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
using System.IO;
using System.Text.RegularExpressions;
using GD.Extensions;

namespace YoutubePlaylists
{
    public partial class Form1 : Form
    {
        //private static string _playlistId = "PLd4S0e5MPnVi3fD3O0VKFLyUwbiNrsHRF"; // https://www.youtube.com/playlist?list=PLzByySESNL7GKiOXOs7ew5vEFBxuJvf0D
        private static string _channelId = "UCxMu8S3Q9Btpa56CsI58KDQ"; // https://www.youtube.com/@uberalles2/playlists
        private static string _playlistId = "";

        YoutubeSharpApiInterface _youtube = new YoutubeSharpApiInterface();
        List<ChannelOutput.Playlist> Playlists;
        List<PlaylistOutput.Videos> Videos = new List<PlaylistOutput.Videos>();

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
            List<Label> labelList = panel1.CreateDynamicControls<Label>("lblPlaylist", Playlists.Count, 20, 0, 12, 8, 20, 200);

            int i = 0;
            foreach (ChannelOutput.Playlist item in Playlists)
            {
                //checkboxlList.ElementAt(i).CheckedChanged += new EventHandler(chkboxPlaylist_CheckedChanged);
                labelList.ElementAt(i).Text = item.Title.Replace("/", " - ").Replace(",", " - ") + $"  ({item.ItemCount})";
                labelList.ElementAt(i).TextAlign = ContentAlignment.MiddleLeft;
                labelList.ElementAt(i).MouseEnter += new EventHandler(labelList_MouseEnter);
                labelList.ElementAt(i).MouseLeave += new EventHandler(labelList_MouseLeave);
                labelList.ElementAt(i).Click += new EventHandler(labelList_Click);
                i++;
            }
        }

        private void labelList_Click(object sender, EventArgs e)
        {
            int element = (int)((Label)sender).Tag;
            lblPlaylistName.Text = Playlists.ElementAt(element).Title.Replace("/", " - ").Replace(",", " - ");
            _playlistId = Playlists.ElementAt(element).PlaylistId;

            // Get videos
            string playlistId = Playlists.ElementAt(element).PlaylistId;
            Videos = _youtube.GetVideosByPlaylistId(playlistId);

            DisplayVideos(Videos);
        }

        private void DisplayVideos(List<PlaylistOutput.Videos> videos)
        {
            panel2.Controls.Clear();
            txtDeletedVideos.Text = "";
            List<PictureBox> pictureList = panel2.CreateDynamicControls<PictureBox>("picVideo", videos.Count, 80, 0, 12, 10, 60, 100);
            List<Label> labelList = panel2.CreateDynamicControls<Label>("lblVideo", videos.Count, 80, 0, 12, 120, 18, 360);
            List<Label> labelDescList = panel2.CreateDynamicControls<Label>("lblVideoDesc", videos.Count, 80, 0, 32, 120, 16, 360);
            List<Label> labelVideoIdList = panel2.CreateDynamicControls<Label>("lblVideoID", videos.Count, 80, 0, 52, 120, 20, 160);
            List<Button> btnGetInfoList = panel2.CreateDynamicControls<Button>("btnGetInfo", videos.Count, 80, 0, 48, 350, 24, 80);
            List<Button> btnRemoveList = panel2.CreateDynamicControls<Button>("btnRemove", videos.Count, 80, 0, 48, 440, 24, 60);

            int i = 0;
            foreach (PlaylistOutput.Videos item in videos)
            {
                string description = item.Description;
                string title = item.Title;

                if (item.Description.Contains("video is unavailabel") || item.Description.Contains("video is private") || item.Title.Contains("Deleted video"))
                {
                    txtDeletedVideos.Text += item.VideoId + Environment.NewLine;
                    labelList.ElementAt(i).Text = item.Title;
                    labelDescList.ElementAt(i).Text = item.Description;
                    //labelVideoIdList.ElementAt(i).Font = new Font("Courier New", 7.0F, FontStyle.Regular);
                    labelVideoIdList.ElementAt(i).Text = $"Id: {item.VideoId}";
                    btnGetInfoList.ElementAt(i).Text = "Remove";
                    //btnRemoveList.ElementAt(i).Visible = true;
                    btnRemoveList.ElementAt(i).Click += new EventHandler(btnRemove_Click);
                }
                else
                {
                    pictureList.ElementAt(i).SizeMode = PictureBoxSizeMode.CenterImage;
                    pictureList.ElementAt(i).Load(item.ThumbnailsData[0].ImageUri.ToString());
                    pictureList.ElementAt(i).MouseEnter += new EventHandler(pictureList_MouseEnter);
                    pictureList.ElementAt(i).MouseLeave += new EventHandler(pictureList_MouseLeave);
                    pictureList.ElementAt(i).Click += new EventHandler(pictureList_Click);
                    labelList.ElementAt(i).Text = item.Title;
                    labelDescList.ElementAt(i).Text = item.Description;
                    //labelVideoIdList.ElementAt(i).Font = new Font("Courier New", 6.0F, FontStyle.Regular);
                    if(string.IsNullOrEmpty(item.PlaylistTitle))
                        labelVideoIdList.ElementAt(i).Text = $"Id: {item.VideoId}";
                    else
                        labelVideoIdList.ElementAt(i).Text = $"Playlist: {item.PlaylistTitle}";

                    btnGetInfoList.ElementAt(i).Text = "Get Info";
                    //btnRemoveList.ElementAt(i).Visible = true;
                    btnGetInfoList.ElementAt(i).Click += new EventHandler(btnGetInfo_Click);
                    btnRemoveList.ElementAt(i).Text = "Remove";
                    //btnRemoveList.ElementAt(i).Visible = true;
                    btnRemoveList.ElementAt(i).Click += new EventHandler(btnRemove_Click);
                }
                i++;
            }
        }

        private void labelList_MouseEnter(object sender, EventArgs e)
        {
            ((Label)sender).BackColor = Color.LightBlue;
            ((Label)sender).Cursor = Cursors.Hand;
        }
        private void labelList_MouseLeave(object sender, EventArgs e)
        {
            ((Label)sender).BackColor = panel1.BackColor;
            ((Label)sender).Cursor = Cursors.Default;
        }
        private void pictureList_MouseEnter(object sender, EventArgs e)
        {
            ((PictureBox)sender).Cursor = Cursors.Hand;
        }
        private void pictureList_MouseLeave(object sender, EventArgs e)
        {
            ((PictureBox)sender).Cursor = Cursors.Default;
        }
        private void pictureList_Click(object sender, EventArgs e)
        {
            int element = (int)((PictureBox)sender).Tag;
            string VideoId = Videos.ElementAt(element).VideoId;

            try
            {
                System.Diagnostics.Process.Start("cmd", "/c start https://www.youtube.com/watch?v=" + VideoId);
            }
            catch (Win32Exception ex)
            {
               MessageBox.Show(ex.Message);
            }
        }

        private void btnGetInfo_Click(object sender, EventArgs e)
        {
            int element = (int)((Button)sender).Tag;
            string playlistVideoId = Videos.ElementAt(element).PlaylistVideoId;
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

        private void btnMerge_Click(object sender, EventArgs e)
        {
            const int chunkSize = 2 * 1024; // 2KB
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            string[] inputFiles = Directory.GetFiles(path, "Playlist.*.csv");

            using (var output = File.Create(Path.Combine(path, "Playlists.AllPlaylists.csv")))
            {
                foreach (var file in inputFiles)
                {
                    using (var input = File.OpenRead(file))
                    {
                        var buffer = new byte[chunkSize];
                        int bytesRead;
                        while ((bytesRead = input.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            output.Write(buffer, 0, bytesRead);
                        }
                    }
                }
            }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            if(txtSearch.Text.Trim().Length < 3)
            {
                MessageBox.Show("Enter a search term with at least 2 characters.");
                return;
            }

            lblPlaylistName.Text = "Search results for: " + txtSearch.Text.Trim();

            List<YoutubeVideo> youtubeVideos = YoutubeVideo.LoadFromCsvFile(Path.Combine(path, "Playlists.AllPlaylists.csv"));
            List<YoutubeVideo> foundVideos = youtubeVideos.Where(x => x.Title.ToLower().Contains(txtSearch.Text.ToLower()) || x.Description.ToLower().Contains(txtSearch.Text.ToLower())).ToList();

            Videos.Clear();
            foreach(YoutubeVideo item in foundVideos)
            {
                List<Thumbnails> t = new List<Thumbnails>();
                t.Add(new Thumbnails() { ImageUri = new Uri(item.ImageUri) });

                Videos.Add(new PlaylistOutput.Videos
                {
                    PlaylistVideoId = item.PlaylistVideoId,
                    PlaylistTitle = item.PlaylistTitle,
                    VideoId = item.VideoId,
                    Title = item.Title,
                    Description = item.Description,
                    ThumbnailsData = t
                });
            }

            DisplayVideos(Videos);
        }

        public List<Thumbnails> AddOne(string imageUri)
        {
            List<Thumbnails> thumbnails = new List<Thumbnails>();
            Uri uri = new Uri(imageUri);
            thumbnails.Add(new Thumbnails() { ImageUri = uri });

            return thumbnails;
        }

        public string Truncate(string value, int maxLength)
        {
            if (string.IsNullOrEmpty(value)) return value;
            return value.Length <= maxLength ? value : value.Substring(0, maxLength);
        }

        // ****************************** M E N U ************************************
        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void exportCurrentToolStripMenuItem_Click(object sender, EventArgs e)
        {
           ApplicationYoutube.ExportPlaylist(Videos, _playlistId, lblPlaylistName.Text);
        }
    }
}
