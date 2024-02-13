using System;
using System.IO;

namespace YoutubePlaylists
{
    public static class Settings
    {
        private static string _exportPath;

        public static string ExportPath
        {
            get
            {
                if (string.IsNullOrEmpty(Properties.Settings.Default.ExportsFolder))
                {
                    _exportPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "YoutubePlaylists");
                    Properties.Settings.Default.ExportsFolder = _exportPath;
                    Properties.Settings.Default.Save();
                }
                else
                {
                    _exportPath = Properties.Settings.Default.ExportsFolder;
                }

                // Make sure path exists
                Directory.CreateDirectory(_exportPath);

                return _exportPath;
            }
            set
            {
                _exportPath = value;
                Properties.Settings.Default.ExportsFolder = _exportPath;
                Properties.Settings.Default.Save();
            }
        }
        public override string ToString()
        {
            return $"ExportPath: {ExportPath}";
        }
    }
}
