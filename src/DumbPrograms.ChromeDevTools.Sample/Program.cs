using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DumbPrograms.ChromeDevTools.Sample
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var psi = new ProcessStartInfo(@"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe", "--remote-debugging-port=9222");
            var process = Process.Start(psi);

            var client = new ChromeDevToolsClient(9222);

            var targets = from t in await client.GetInspectableTargets()
                          where t.Title == "New Tab"
                          select t;

            var inspector = await client.Inspect(targets.First());

            //await inspector.Page.Enable();
            var p = await inspector.Page.Navigate("https://www.baidu.com");
        }
    }
}
