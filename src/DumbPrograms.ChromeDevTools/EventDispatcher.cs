using System;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace DumbPrograms.ChromeDevTools
{
    abstract class EventDispatcher
    {
        public abstract Task Dispatch(JObject eventArgs);
    }

    class EventDispatcher<TEvent> : EventDispatcher
    {
        public event Func<TEvent, Task> Handlers;

        public override Task Dispatch(JObject eventArgs)
        {
            return DispatchEvent(eventArgs == null ? default : eventArgs.ToObject<TEvent>());
        }

        public async Task DispatchEvent(TEvent e)
        {
            var hs = Handlers;
            if (hs != null)
            {
                await hs(e).ConfigureAwait(false);
            }
        }
    }
}