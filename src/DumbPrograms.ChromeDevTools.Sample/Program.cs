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
                              where t.Type == "page"
                              select t;

                var t0 = targets.First();

                var inspector0 = await devTools.Inspect(t0);

                await inspector0.Page.Enable();

                await inspector0.Page.Navigate("https://www.baidu.com");

                var e = await inspector0.Page.LoadEventFiredEvent();

                Console.WriteLine($"Page loaded at {e.Timestamp.Value}");

                var t1 = await devTools.NewTab("https://www.cnblogs.com");

                var inspector1 = await devTools.Inspect(t1);

                await inspector1.Page.Enable();

                Console.WriteLine("Click some links several times..");

                var i = 0;
                await inspector1.Page.LoadEventFiredEvent(_ => Task.FromResult(++i > 2));

                Console.WriteLine(i);

                await devTools.CloseTab(t0.Id);
            }
        }
    }
}
