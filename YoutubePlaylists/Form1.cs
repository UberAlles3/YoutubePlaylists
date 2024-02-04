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

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtChannelId.Text = _channelId;
            
            //var youtubeClient = new YoutubeClient(_apiKey);

            //Console.WriteLine($"--- --- --- --- Channel Playlists --- --- --- ---");
            //var responseChannel = Task.Run(() => youtubeClient.GetChannelAsync(new ChannelInput
            //{
            //    ChannelId = _channelId
            //}, CancellationToken.None)).Result;

            //foreach (var item in responseChannel.PlaylistData)
            //{
            //    Debug.WriteLine($"{item.Position} - {item.Title} (Playlist Id : {item.PlaylistId})");
            //}
        }
    }
}
