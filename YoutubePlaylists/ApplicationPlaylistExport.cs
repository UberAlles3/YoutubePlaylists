using GD.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
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

        public static void MergeAllPlaylists()
        {
            const int chunkSize = 2 * 1024; // 2KB

            string[] inputFiles = Directory.GetFiles(Settings.ExportPath, "Playlist.*.csv");

            using (var output = File.Create(Path.Combine(Settings.ExportPath, "Playlists.AllPlaylists.csv")))
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
        public static void BackupMergedPlaylists()
        {
            string sourcePath = Path.Combine(Settings.ExportPath, "Playlists.AllPlaylists.csv");
            string targetPath = Path.Combine(Settings.ExportPath, "Backups");
            // Make sure path exists
            Directory.CreateDirectory(targetPath);

            string[] inputFiles = Directory.GetFiles(targetPath, "Playlists.AllPlaylists*.csv");
            if (inputFiles.Length == 0) // No backups yet
                targetPath = Path.Combine(targetPath, "Playlists.AllPlaylists.csv");
            else
            {
                // increment the name of the backup (2), (3), etc.
                inputFiles = Directory.GetFiles(targetPath, "Playlists.AllPlaylists(*.csv");
                if (inputFiles.Length == 0) // No incremented backups, start with (2)
                    targetPath = Path.Combine(targetPath, "Playlists.AllPlaylists(2).csv");
                else
                {
                    string highest = GetLatestBackupFilename(ref targetPath, ref inputFiles);
                    int next = int.Parse(highest) + 1;
                    targetPath = targetPath.Replace("|increment|", $"({next})");
                }
            }

            File.Copy(sourcePath, targetPath);
        }

        public static string GetLatestBackupFilename(ref string targetPath, ref string[] inputFiles)
        {
            targetPath = Path.Combine(targetPath, "Playlists.AllPlaylists|increment|.csv");
            inputFiles = inputFiles.OrderBy(x => x).ToArray();
            string highest = inputFiles.Last()._Between("(", ")");
            return highest;
        }

        public static List<PlaylistOutput.Videos> SearchPlaylists(string searchTerm)
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

        public static List<YoutubeVideo> LoadPlaylist(string path)
        {
            List<YoutubeVideo> youtubeVideos = YoutubeVideo.LoadFromCsvFile(path);

            return youtubeVideos;
        }


    }
}
