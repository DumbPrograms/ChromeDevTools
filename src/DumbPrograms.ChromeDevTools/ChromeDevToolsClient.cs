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

        public async Task<BrowserVersion> GetBrowserVersion()
        {
            return JsonConvert.DeserializeObject<BrowserVersion>(await HttpClient.GetStringAsync("/json/version"));
        }

        public IEnumerable<InspectionTarget> GetInspectionTargets()
        {
            throw new NotImplementedException();
        }
    }
}
