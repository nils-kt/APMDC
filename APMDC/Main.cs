using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using DiscordRPC;
using iTunesLib;
using static iTunesLib.ITPlayerState;

namespace APMDC
{
    public partial class Main : Form
    {
        private readonly DiscordRpcClient discordRpc;
        private readonly iTunesApp iTunes;

        public Main()
        {
            InitializeComponent();

            Debug.WriteLine("Discord...");
            discordRpc = new DiscordRpcClient("851782639575760896");
            discordRpc.Initialize();

            Debug.WriteLine("iTunes");
            iTunes = new iTunesAppClass();

            iTunes.OnPlayerPlayingTrackChangedEvent += UpdateRichPresence;
            iTunes.OnPlayerPlayEvent += UpdateRichPresence;
            iTunes.OnPlayerStopEvent += UpdateRichPresence;
        }

        private void UpdateRichPresence(object track)
        {
            if (discordRpc == null || track == null) return;

            var timestamp = new Timestamps(DateTime.UtcNow.AddSeconds(-iTunes.PlayerPosition),
                DateTime.UtcNow.AddSeconds(((IITTrack) track).Duration - iTunes.PlayerPosition));

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
                Details = $"{((IITTrack) track).Artist} - {((IITTrack) track).Name}",
                State = ((IITTrack) track).Album,
                Timestamps = timestamp,
                Assets = assets
            });
            discordRpc.Invoke();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            Hide();
            discordRpc.SetPresence(new RichPresence
            {
                State = "Waiting for music 🎶"
            });
            UpdateRichPresence(iTunes.CurrentTrack);
        }

        private void Main_Closed(object sender, EventArgs e)
        {
            discordRpc.Dispose();
            Marshal.ReleaseComObject(iTunes);
        }

        private void rightClick_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Text == "Quit")
            {
                Close();
            }
        }
    }
}