#region Usings

using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using DiscordRPC;
using iTunesLib;
using Microsoft.Win32;
using static iTunesLib.ITPlayerState;
using WebRequest = APMDC.Class.WebRequest;

#endregion

namespace APMDC
{
    public partial class Main : Form
    {
        internal static iTunesApp iTunes;
        internal static NotifyIcon taskbarNotify;
        private readonly DiscordRpcClient discordRpc;
        private readonly WebRequest webRequest;

        public Main()
        {
            InitializeComponent();

            discordRpc = new DiscordRpcClient("851782639575760896");
            discordRpc.Initialize();

            iTunes = new iTunesAppClass();
            iTunes.OnPlayerPlayingTrackChangedEvent += UpdateRichPresence;
            iTunes.OnPlayerPlayEvent += UpdateRichPresence;
            iTunes.OnPlayerStopEvent += UpdateRichPresence;

            webRequest = new WebRequest();
            taskbarNotify = taskIcon;
        }

        private void UpdateRichPresence(object track)
        {
            if (discordRpc == null || track == null) return;

            var song = (IITTrack)track;

            var timestamp = new Timestamps(DateTime.UtcNow.AddSeconds(-iTunes.PlayerPosition),
                DateTime.UtcNow.AddSeconds(song.Duration - iTunes.PlayerPosition));

            var assets = new Assets();

            if (iTunes.PlayerState == ITPlayerStatePlaying)
            {
                assets.SmallImageKey = "play";
            }
            else
            {
                assets.SmallImageKey = "pause";
                timestamp = null;
            }

            assets.LargeImageKey = "music";
            discordRpc.SetPresence(new RichPresence
            {
                Details = $"{song.Artist} - {song.Name}",
                State = song.Album,
                Timestamps = timestamp,
                Assets = assets
            });
        }

        private void Main_Load(object sender, EventArgs e)
        {
            Hide();
            itunesversion.Text = $@"iTunes Version: {iTunes.Version}";
            apmdcversion.Text = $@"APMDC Version: {Application.ProductVersion}";
            discordRpc.SetPresence(new RichPresence
            {
                State = "Waiting for music 🎶"
            });
            UpdateRichPresence(iTunes?.CurrentTrack);

            //Load user settings
            var startup = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", false);
            autostart.Checked = !string.IsNullOrEmpty((string)startup.GetValue(Application.ProductName));
        }

        private void Main_Closed(object sender, EventArgs e)
        {
            discordRpc.ClearPresence();
            discordRpc?.Dispose();
            Marshal.ReleaseComObject(iTunes);
            Marshal.FinalReleaseComObject(iTunes);
        }

        private void generateIssue_Click(object sender, EventArgs e)
        {
            var iTunesProcess = Process.GetProcessesByName("itunes").FirstOrDefault();
            var iTunesPath = iTunesProcess?.MainModule?.FileName;
            var windows =
                $"{Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion", "ProductName", "")}%20{Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion", "DisplayVersion", "")}%20%28{Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion", "CurrentBuildNumber", "")}%29";
            var para =
                $"%2A%2AiTunes%20Version%3A%2A%2A%20{iTunes.Version}%0A%2A%2AWindows%3A%2A%2A%20{windows}%0A%2A%2AAPMDC%20Version%3A%2A%2A%20{Application.ProductVersion}%0A%20%20%0A%2A%2AiTunes%20location%3A%2A%2A%20{WebUtility.UrlEncode(Path.GetDirectoryName(iTunesPath))}%0A%2A%2AIs%20UWP%20iTunes%3A%2A%2A%20{iTunesPath.Contains("WindowsApps")}%0A%0A%2A%2ADescribe%20your%20problem%3A%2A%2A";
            Process.Start($"https://github.com/nils-kt/APMDC/issues/new?body={para}");
        }

        private void quit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowInTaskbar = true;
            TopMost = true;
            Show();
        }

        private void save_Click(object sender, EventArgs e)
        {
            var startup = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

            if (autostart.Checked)
                startup?.SetValue(Application.ProductName, Application.ExecutablePath);
            else
                startup?.DeleteValue(Application.ProductName, false);

            ShowInTaskbar = false;
            TopMost = false;
            Hide();
        }

        private void shareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var song = iTunes?.CurrentTrack;
            Task.Run(async () => { await webRequest.SearchSongAsync(); });
        }

        private void geniusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var song = iTunes?.CurrentTrack;
            Process.Start(
                $"https://genius.com/search?q={WebUtility.UrlEncode(song.Artist)}%20{WebUtility.UrlEncode(song.Name)}");
        }
    }
}