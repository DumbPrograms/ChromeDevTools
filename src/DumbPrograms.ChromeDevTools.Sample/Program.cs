using System;
using System.Linq;
using System.Threading.Tasks;

namespace DumbPrograms.ChromeDevTools.Sample
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var client = new ChromeDevToolsClient(9222);

            var targets = from t in await client.GetInspectableTargets()
                          where t.Title == "New Tab"
                          select t;

            var inspector = await client.Inspect(targets.First());
            var p = await inspector.Page.Navigate("https://www.baidu.com");
        }
    }
}
