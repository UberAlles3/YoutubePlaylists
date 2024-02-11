using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using YoutubeSharpApi;
using YoutubeSharpApi.Models;

namespace YoutubePlaylists
{
    public class YoutubeSharpApiInterface
    {
        private static string _apiKey = "AIzaSyA1B4A-V8Dp3lFYnSQjJEoABvpPQyDraRw"; // https://developers.google.com/youtube/v3/getting-started
        //private List<ChannelOutput.Playlist> Playlists = new List<ChannelOutput.Playlist>();

        public List<ChannelOutput.Playlist> GetPlaylistsByChannelId(string channelId, bool sortByTitle = true)
        {
            var youtubeClient = new YoutubeClient(_apiKey);

            Debug.WriteLine($"--- --- --- --- Channel Playlists --- --- --- ---");
            var responseChannel = Task.Run(() => youtubeClient.GetChannelAsync(new ChannelInput
            {
                ChannelId = channelId
            }, CancellationToken.None)).Result;

            foreach (var item in responseChannel.PlaylistData)
            {
                Console.WriteLine($"{item.Position} - {item.Title} (Playlist Id : {item.PlaylistId})");
            }

            if(sortByTitle)
            {
                List<ChannelOutput.Playlist> SortedList = responseChannel.PlaylistData.OrderBy(o => o.Title).ToList();
                return SortedList;
            }

            return responseChannel.PlaylistData;
        }

        public List<PlaylistOutput.Videos> GetVideosByPlaylistId(string playlistId, bool sortByTitle = true)
        {
            var youtubeClient = new YoutubeClient(_apiKey);

            Debug.WriteLine($"--- --- --- --- Playlist Videos --- --- --- ---");
            var responsePlaylist = Task.Run(() => youtubeClient.GetPlayListAsync(new PlaylistInput
            {
                PlaylistId = playlistId
            }, CancellationToken.None)).Result;

            foreach (var item in responsePlaylist.VideosData)
            {
                Console.WriteLine($"{item.Position} - {item.Title} (Playlist Id : {item.VideoId})");
            }

            if (sortByTitle)
            {
                List<PlaylistOutput.Videos> SortedList = responsePlaylist.VideosData.OrderBy(o => o.Title).ToList();
                return SortedList;
            }

            return responsePlaylist.VideosData;
        }

        public string RemoveItemFromPlaylist(string playlistVideoId)
        {
            var youtubeClient = new YoutubeClient(_apiKey);

            var result = Task.Run(() => youtubeClient.RemovePlaylistItemAsync(playlistVideoId)).Result;

            return result;
        }
    }
}
