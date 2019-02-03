using System;
using System.Linq;
using System.Threading.Tasks;

namespace DumbPrograms.ChromeDevTools.Sample
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using (var chrome = ChromeProcessHelper.StartNew())
            {
                var devTools = await chrome.GetDevTools();

                var targets = from t in await devTools.GetInspectableTargets()
                              where t.Title == "New Tab"
                              select t;

                var inspector = await devTools.Inspect(targets.First());

                await inspector.Page.Enable();

                var p = await inspector.Page.Navigate("https://www.baidu.com");

                var e = await inspector.Page.LoadEventFiredEvent();

                Console.WriteLine($"Page loaded at {e.Timestamp.Value}");
            }
        }
    }
}
