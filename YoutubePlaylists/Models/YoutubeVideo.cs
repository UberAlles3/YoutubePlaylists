using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace YoutubePlaylists
{
    public class YoutubeVideo
    {
        public string PlaylistId { get; set; }
        public string PlaylistTitle { get; set; }
        public string PlaylistVideoId { get; set; }
        public string VideoId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUri { get; set; }

        public static List<YoutubeVideo> LoadFromCsvFile(string path)
        {
            List<YoutubeVideo> values = File.ReadAllLines(path)
                                               .Select(v => YoutubeVideo.FromCsv(v))
                                               .ToList();
            return values;
        }

        public static YoutubeVideo FromCsv(string csvLine)
        {
            string[] values = csvLine.Split(',');
            YoutubeVideo youtubeVideo = new YoutubeVideo();
            youtubeVideo.PlaylistId = values[0];
            youtubeVideo.PlaylistTitle = values[1];
            youtubeVideo.PlaylistVideoId = values[2];
            youtubeVideo.VideoId = values[3];
            youtubeVideo.Title = values[4];
            youtubeVideo.Description = values[5];
            youtubeVideo.ImageUri = values[6];
            return youtubeVideo;
        }

        public override string ToString()
        {
            return $"PlaylistId: {PlaylistId}  PlaylistTitle: {PlaylistTitle} VideoId: {VideoId} Title: {Title}";
        }
    }
}
