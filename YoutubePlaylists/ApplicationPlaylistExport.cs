using GD.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using YoutubeSharpApi.Models;

namespace YoutubePlaylists
{
    public static class ApplicationPlaylistExport
    {
        public static void ExportPlaylist(List<PlaylistOutput.Videos> videos, string playlistId, string playlistName)
        {
            playlistName = playlistName.Replace("/", "-");
            string path = Path.Combine(Settings.ExportPath, "Playlist." + playlistName + ".csv");

            using (var file = File.CreateText(path))
            {
                foreach (var data in videos)
                {
                    string line = $"{playlistId},{playlistName},{data.PlaylistVideoId},{data.VideoId}";
                    line += $",{data.Title.Replace(",", " - ")._Truncate(60)},{data.Description.Replace(",", " - ").Replace("\n", " ").Replace("\r", " ").Replace("\"", "*")._Truncate(100)},{((data.ThumbnailsData == null) ? "" : data.ThumbnailsData[0].ImageUri.ToString())}";

                    line = Regex.Replace(line, @"[^\u0000-\u007F]+", " "); // get rid of funky characters

                    file.WriteLine(line);
                }
            }
        }

        public static List<PlaylistOutput.Videos> FindInPlaylists(string searchTerm)
        {
            List<PlaylistOutput.Videos> videos = new List<PlaylistOutput.Videos>();

            string path = Path.Combine(Settings.ExportPath, "Playlists.AllPlaylists.csv");

            searchTerm = searchTerm.ToLower();


            List<YoutubeVideo> youtubeVideos = YoutubeVideo.LoadFromCsvFile(path);
            List<YoutubeVideo> foundVideos = youtubeVideos.Where(x => x.Title.ToLower().Contains(searchTerm) || x.Description.ToLower().Contains(searchTerm)).ToList();

            foreach (YoutubeVideo item in foundVideos)
            {
                List<Thumbnails> t = new List<Thumbnails>();
                t.Add(new Thumbnails() { ImageUri = new Uri(item.ImageUri) });

                videos.Add(new PlaylistOutput.Videos
                {
                    PlaylistVideoId = item.PlaylistVideoId,
                    PlaylistTitle = item.PlaylistTitle,
                    VideoId = item.VideoId,
                    Title = item.Title,
                    Description = item.Description,
                    ThumbnailsData = t
                });
            }

            return videos;
        }
    }
}
