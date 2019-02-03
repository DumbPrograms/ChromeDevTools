using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DumbPrograms.ChromeDevTools
{
    public class DevToolsClient
    {
        readonly HttpClient HttpClient;

        public DevToolsClient(int port)
        {
            HttpClient = new HttpClient
            {
                BaseAddress = new Uri($"http://localhost:{port}/json/")
            };
        }

        public Task<BrowserVersion> GetBrowserVersion() => Get<BrowserVersion>("version");

        public Task<InspectionTarget[]> GetInspectableTargets() => Get<InspectionTarget[]>("list");

        public Task<InspectionTarget> NewTab(string url) => Get<InspectionTarget>($"new?{Uri.EscapeDataString(url)}");

        public Task<string> ActivateTab(string id) => HttpClient.GetStringAsync($"activate/{Uri.EscapeUriString(id)}");

        public Task<string> CloseTab(string id) => HttpClient.GetStringAsync($"close/{Uri.EscapeUriString(id)}");

        private async Task<T> Get<T>(string url) => JsonConvert.DeserializeObject<T>(await HttpClient.GetStringAsync(url));

        public async Task<InspectorClient> Inspect(InspectionTarget target)
        {
            var client = new InspectorClient(target);

            await client.Start();

            return client;
        }
    }
}
