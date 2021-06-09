using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace APMDC.Class
{
    public class WebRequest
    {
        private static readonly HttpClient client = new HttpClient();

        public async Task SearchSongAsync()
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Add("User-Agent",
                "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/91.0.4472.77 Safari/537.36");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var result = string.Empty;
            var currentTrack = Main.iTunes?.CurrentTrack;

            var request = new HttpRequestMessage(HttpMethod.Get,
                $"https://itunes.apple.com/search?term={WebUtility.UrlEncode(currentTrack.Artist)}%20{WebUtility.UrlEncode(currentTrack.Name)}&entity=song");

            await client.SendAsync(request)
                .ContinueWith(async responseTask =>
                {
                    var streamResult = new StreamReader(await responseTask.Result.Content.ReadAsStreamAsync(),
                        Encoding.UTF8);
                    result = await streamResult.ReadToEndAsync();
                    var share = JsonConvert.DeserializeObject<ShareRequest>(result);

                    if (share?.Share != null)
                        foreach (var canShare in (share?.Share).Where(canShare => canShare.TrackTimeMillis / 1000 == currentTrack.Duration))
                        {
                            Process.Start("https://song.link/i/" + canShare.TrackId);
                            return;
                        }

                    Main.taskbarNotify.ShowBalloonTip(3000, "Error", "Could not find the Song!", ToolTipIcon.Error);
                });
        }
    }
}