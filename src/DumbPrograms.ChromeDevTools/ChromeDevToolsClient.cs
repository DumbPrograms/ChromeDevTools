using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DumbPrograms.ChromeDevTools
{
    public class ChromeDevToolsClient
    {
        readonly HttpClient HttpClient;

        public ChromeDevToolsClient(int port)
        {
            HttpClient = new HttpClient
            {
                BaseAddress = new Uri($"http://localhost:{port}")
            };
        }

        public async Task<BrowserVersion> GetBrowserVersion() => await Get<BrowserVersion>("/json/version");

        public async Task<InspectionTarget[]> GetInspectableTargets() => await Get<InspectionTarget[]>("/json");

        public async Task<InspectionTarget> NewTab(string url) => await Get<InspectionTarget>($"/json/new?url={Uri.EscapeDataString(url)}");

        public async Task<string> ActivateTab(string id) => await HttpClient.GetStringAsync($"/json/activate/{Uri.EscapeUriString(id)}");

        public async Task<string> CloseTab(string id) => await HttpClient.GetStringAsync($"/json/close/{Uri.EscapeUriString(id)}");

        private async Task<T> Get<T>(string url) => JsonConvert.DeserializeObject<T>(await HttpClient.GetStringAsync(url));
    }
}
