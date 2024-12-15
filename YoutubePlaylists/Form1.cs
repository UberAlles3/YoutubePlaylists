using GD.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using YoutubeSharpApi.Models;

namespace YoutubePlaylists
{
    public partial class Form1 : Form
    {
        private enum WaitEnum
        {
            Show,
            Hide
        }

        private static string _channelId = "UCxMu8S3Q9Btpa56CsI58KDQ"; // https://www.youtube.com/@uberalles2/playlists
        private static string _playlistId = "";
        private static bool _cancelTask = false;

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
            picSpinner.Visible = false;
            picSpinner2.Visible = false;
            lblPlaylistName.Text = "";
            lblTaskFeedback.Text = "";
            btnCancel.Visible = false;
            exportAllToolStripMenuItem.Enabled = false;
        }


        private void Form1_Resize(object sender, EventArgs e)
        {
            panel1.Height = this.Height - 150;
            panel2.Height = this.Height - 91;
        }

        // Form Display mode, wait cursor
        private void FormDisplayWaitForTask(WaitEnum waitEnum)
        {
            //this.Cursor = (waitEnum == WaitEnum.Show) ? Cursors.Default : Cursors.WaitCursor;
            picSpinner2.Visible = (waitEnum == WaitEnum.Hide);
            lblPlaylistName.Visible = (waitEnum == WaitEnum.Show);
            lblTaskFeedback.Visible = (waitEnum == WaitEnum.Hide);
            panel1.Enabled = (waitEnum == WaitEnum.Show);
            Application.DoEvents();
        }

        #region ********************************** Playlists Panel **********************************
        private void btnGetPlaylists_Click(object sender, EventArgs e)
        {
            picSpinner.Visible = true;
            btnGetPlaylists.Enabled = false;
            exportAllToolStripMenuItem.Enabled = true;

            Playlists = _youtube.GetPlaylistsByChannelId(txtChannelId.Text.Trim());

            panel1.Controls.Clear();
            List<Label> labelList = panel1.CreateDynamicControls<Label>("lblPlaylist", Playlists.Count, 20, 0, new Rectangle(8, 12, 200, 20));

            int i = 0;
            foreach (ChannelOutput.Playlist item in Playlists)
            {
                labelList.ElementAt(i).Text = item.Title.Replace("/", " - ").Replace(",", " - ") + $"  ({item.ItemCount})";
                labelList.ElementAt(i).TextAlign = ContentAlignment.MiddleLeft;
                labelList.ElementAt(i).MouseEnter += new EventHandler(labelList_MouseEnter);
                labelList.ElementAt(i).MouseLeave += new EventHandler(labelList_MouseLeave);
                labelList.ElementAt(i).Click += new EventHandler(labelList_Click);
                i++;
            }
            picSpinner.Visible = false;
            btnGetPlaylists.Enabled = true;
        }

        private async void labelList_Click(object sender, EventArgs e)
        {
            int element = (int)((Label)sender).Tag;
            lblPlaylistName.Text = Playlists.ElementAt(element).Title.Replace("/", "-").Replace(",", "-");
            _playlistId = Playlists.ElementAt(element).PlaylistId;

            FormDisplayWaitForTask(WaitEnum.Hide);

            /////////////////////////////// Get Videos
            string playlistId = Playlists.ElementAt(element).PlaylistId;
            Videos = await _youtube.GetVideosByPlaylistId(playlistId);
            DisplayVideos(Videos);
            //\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

            FormDisplayWaitForTask(WaitEnum.Show);
        }
        #endregion

        #region ********************************** Video Panel List **********************************
        private void DisplayVideos(List<PlaylistOutput.Videos> videos)
        {
            panel2.Controls.Clear();
            txtDeletedVideos.Text = "";
            List<PictureBox> pictureList = panel2.CreateDynamicControls<PictureBox>("picVideo", videos.Count, 80, 0, 12, 10, 60, 100);
            List<Label> labelList = panel2.CreateDynamicControls<Label>("lblVideo", videos.Count, 80, 0, 12, 120, 18, 350);
            List<Label> labelDescList = panel2.CreateDynamicControls<Label>("lblVideoDesc", videos.Count, 80, 0, 32, 120, 16, 360);
            List<Label> labelVideoIdList = panel2.CreateDynamicControls<Label>("lblVideoID", videos.Count, 80, 0, 52, 120, 20, 160);
            List<Button> btnRemoveList = panel2.CreateDynamicControls<Button>("btnRemove", videos.Count, 80, 0, 12, 480, 24, 60);

            int i = 0;
            foreach (PlaylistOutput.Videos item in videos)
            {
                Application.DoEvents();
                string description = item.Description;
                string title = item.Title;

                if (item.Description.Contains("video is unavailable") || item.Description.Contains("video is private") || item.Title.Contains("Deleted video"))
                {
                    txtDeletedVideos.Text += item.VideoId + Environment.NewLine;
                    labelList.ElementAt(i).Text = item.Title;
                    labelDescList.ElementAt(i).Text = item.Description;
                    //labelVideoIdList.ElementAt(i).Font = new Font("Courier New", 7.0F, FontStyle.Regular);
                    if(lblPlaylistName.Text.Contains("Compared."))
                        labelVideoIdList.ElementAt(i).Text = $"{item.PlaylistTitle}     Id: {item.VideoId}";
                    else
                        labelVideoIdList.ElementAt(i).Text = $"Id: {item.VideoId}";
                    
                    //btnRemoveList.ElementAt(i).Visible = true;
                    btnRemoveList.ElementAt(i).Click += new EventHandler(btnRemove_Click);
                }
                else
                {
                    pictureList.ElementAt(i).SizeMode = PictureBoxSizeMode.CenterImage;


                    try
                    {
                        pictureList.ElementAt(i).Load(item.ThumbnailsData[0].ImageUri.ToString());
                    }
                    catch {} // do nothing
                                            
                    pictureList.ElementAt(i).MouseEnter += new EventHandler(pictureList_MouseEnter);
                    pictureList.ElementAt(i).MouseLeave += new EventHandler(pictureList_MouseLeave);
                    pictureList.ElementAt(i).Click += new EventHandler(pictureList_Click);
                    labelList.ElementAt(i).Text = item.Title;
                    labelDescList.ElementAt(i).Text = item.Description;
                    //labelVideoIdList.ElementAt(i).Font = new Font("Courier New", 6.0F, FontStyle.Regular);
                    if (string.IsNullOrEmpty(item.PlaylistTitle))
                        labelVideoIdList.ElementAt(i).Text = $"Id: {item.VideoId}";
                    else
                        labelVideoIdList.ElementAt(i).Text = $"Playlist: {item.PlaylistTitle}";

                    //btnRemoveList.ElementAt(i).Visible = true;
                    btnRemoveList.ElementAt(i).Text = "Remove";
                    //btnRemoveList.ElementAt(i).Visible = true;
                    btnRemoveList.ElementAt(i).Click += new EventHandler(btnRemove_Click);
                }
                i++;
            }
        }
        #endregion

        #region ******************************* Video Panel Control Events ******************************
        private void pictureList_Click(object sender, EventArgs e)
        {
            int element = (int)((PictureBox)sender).Tag;
            string VideoId = Videos.ElementAt(element).VideoId;

            try
            {
                Process.Start("cmd", "/c start https://www.youtube.com/watch?v=" + VideoId);
            }
            catch (Win32Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void pictureList_MouseEnter(object sender, EventArgs e)
        {
            ((PictureBox)sender).Cursor = Cursors.Hand;
        }
        private void pictureList_MouseLeave(object sender, EventArgs e)
        {
            ((PictureBox)sender).Cursor = Cursors.Default;
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
        #endregion

        #region ************************************ Form Button Events **************************************
        private void btnSearch_Click(object sender, EventArgs e)
        {
            txtSearch.Text = txtSearch.Text.Trim();

            if (txtSearch.Text.Length < 3)
            {
                MessageBox.Show("Enter a search term with at least 2 characters.");
                return;
            }

            lblPlaylistName.Text = "Search Results";

            Videos = ApplicationPlaylistExport.SearchPlaylists(txtSearch.Text);

            DisplayVideos(Videos);
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            _cancelTask = true;
        }
        #endregion

        #region ****************************** Menu Items Events ************************************
        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void exportCurrentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormDisplayWaitForTask(WaitEnum.Hide);
            ApplicationPlaylistExport.ExportPlaylist(Videos, _playlistId, lblPlaylistName.Text);
            FormDisplayWaitForTask(WaitEnum.Show);
        }
        #endregion

        private async void exportAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormDisplayWaitForTask(WaitEnum.Hide);
            txtSearch.Visible = false;
            btnSearch.Visible = false;
            btnCancel.Visible = true;

            foreach (ChannelOutput.Playlist playlist in Playlists)
            {
                lblTaskFeedback.Text = $"Exporting {playlist.Title}...";
                Videos = await _youtube.GetVideosByPlaylistId(playlist.PlaylistId);
                ApplicationPlaylistExport.ExportPlaylist(Videos, _playlistId, playlist.Title);
                if (_cancelTask) break;
            }

            lblTaskFeedback.Text = "";
            lblPlaylistName.Text = "";
            panel2.Controls.Clear();
            FormDisplayWaitForTask(WaitEnum.Show);
            txtSearch.Visible = true;
            btnSearch.Visible = true;
            btnCancel.Visible = false;
            _cancelTask = false;
        }

        // Merge the individual exported playlists into one excel file.
        private void mergeAllExportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormDisplayWaitForTask(WaitEnum.Hide);
            ApplicationPlaylistExport.MergeAllPlaylists();
            FormDisplayWaitForTask(WaitEnum.Show);
        }

        // Open an exported playlist excel file.
        private void openExportedFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Open Exported Output File";
            ofd.Filter = "Exported Files|*.csv|All Files|*.*";
            ofd.DefaultExt = "cvs";
            ofd.InitialDirectory = Settings.ExportPath;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                var p = new Process();
                p.StartInfo = new ProcessStartInfo(ofd.FileName)
                {
                    UseShellExecute = true
                };
                p.Start();
            }
        }

        private void backupMergedPlaylistToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ApplicationPlaylistExport.BackupMergedPlaylists();
        }
 
        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingsForm f = new SettingsForm();
            f.ShowDialog();
        }

        private void compareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<YoutubeVideo> backupVideos = new List<YoutubeVideo>();
            List<YoutubeVideo> deletedVideos = new List<YoutubeVideo>();
            List<YoutubeVideo> addedVideos = new List<YoutubeVideo>();
            List<YoutubeVideo> movedVideos = new List<YoutubeVideo>();

            // Load current all videos list
            string path = Path.Combine(Settings.ExportPath, "Playlists.AllPlaylists.csv");
            List<YoutubeVideo> currentVideos = ApplicationPlaylistExport.LoadPlaylist(path);

            //// load into playlist collection the backup of all videos  (if exists)
            string backupPath = Path.Combine(Settings.ExportPath, "Backups");
            // Make sure path exists
            Directory.CreateDirectory(backupPath);

            string[] inputFiles = Directory.GetFiles(backupPath, "Playlists.AllPlaylists*.csv");
            if (inputFiles.Length == 0) // No backups yet
            {
                MessageBox.Show("No backups to compare. Exiting.");
                return;
            }
            else
            {
                if (inputFiles.Length == 1)
                {
                    backupPath = Path.Combine(backupPath, inputFiles[0]);
                }
                else
                {
                    string highest = ApplicationPlaylistExport.GetLatestBackupFilename(ref backupPath, ref inputFiles);
                    backupPath = backupPath.Replace("|increment|", $"({highest})");
                }
                backupVideos = ApplicationPlaylistExport.LoadPlaylist(backupPath);
            }

            // sort the playlists
            currentVideos = currentVideos.OrderBy(x => x.PlaylistTitle).ThenBy(x => x.Title).ToList();
            int backupVideoIndex = 0;
            int currentVideoIndex = 0;
            YoutubeVideo backup = null;
            YoutubeVideo current = null;
            backupVideos = backupVideos.OrderBy(x => x.PlaylistTitle).ThenBy(x => x.Title).ToList();


            // interate thru the backup and the current
            while (backupVideoIndex < backupVideos.Count() - 1)
            {
                backup = backupVideos[backupVideoIndex];
                if (currentVideoIndex < currentVideos.Count)
                   current = currentVideos[currentVideoIndex];

                if (string.Compare($"{backup.PlaylistTitle}{backup.Title}", $"{current.PlaylistTitle}{current.Title}") == 0)
                {   // found
                    backupVideoIndex++;
                    currentVideoIndex++;
                    continue;
                }
                else if (string.Compare($"{backup.PlaylistTitle}{backup.Title}", $"{current.PlaylistTitle}{current.Title}") < 0)
                {   //deleted
                    // backup is less than current meaning a backup video is not found in current list
                    backupVideoIndex++;

                    // Try to find if it was moved to another playlist
                    List<YoutubeVideo> foundVideos = currentVideos.Where(x => x.VideoId == backup.VideoId).ToList();

                    if (foundVideos.Count > 0) // moved 
                        movedVideos.Add(foundVideos[0]);
                    else
                    {
                        if (backup.Title == "Deleted video")
                            backup.Description = "(Deleted video) " + backup.Description;

                        deletedVideos.Add(backup);
                    }
                }
                else 
                {   // new added
                    currentVideoIndex++;
                    addedVideos.Add(current);
                }
            }

            // Display deleted videos
            if(deletedVideos.Count() == 0)
                lblPlaylistName.Text = "Compared. No deleted found.";
            else

            lblPlaylistName.Text = "Compared. Showing deleted.";
            List<PlaylistOutput.Videos> deleted = YoutubeVideo.ConvertYoutubeVideoList(deletedVideos);
            DisplayVideos(deleted);
        }
    }
}

