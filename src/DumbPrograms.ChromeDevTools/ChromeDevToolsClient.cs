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

        public Task<BrowserVersion> GetBrowserVersion() => Get<BrowserVersion>("/json/version");

        public Task<InspectionTarget[]> GetInspectableTargets() => Get<InspectionTarget[]>("/json");

        public Task<InspectionTarget> NewTab(string url) => Get<InspectionTarget>($"/json/new?url={Uri.EscapeDataString(url)}");

        public Task<string> ActivateTab(string id) => HttpClient.GetStringAsync($"/json/activate/{Uri.EscapeUriString(id)}");

        public Task<string> CloseTab(string id) => HttpClient.GetStringAsync($"/json/close/{Uri.EscapeUriString(id)}");

        private async Task<T> Get<T>(string url) => JsonConvert.DeserializeObject<T>(await HttpClient.GetStringAsync(url));

        public async Task<InspectionClient> StartInspectionSession(InspectionTarget target)
        {
            var client = new InspectionClient(target);

            await client.Start();

            return client;
        }
    }
}
