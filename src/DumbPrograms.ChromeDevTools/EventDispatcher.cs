using System;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace DumbPrograms.ChromeDevTools
{
    abstract class EventDispatcher
    {
        public abstract void Dispatch(JObject eventArgs);
    }

    class EventDispatcher<TEvent> : EventDispatcher
    {
        public event Func<TEvent, Task> Handlers;

        public override void Dispatch(JObject eventArgs)
        {
            DispatchEvent(eventArgs == null ? default : eventArgs.ToObject<TEvent>());
        }

        public void DispatchEvent(TEvent e)
        {
            SynchronizationContext.Current.Post(s =>
            {
                var (handlers, args) = ((Func<TEvent, Task> handlers, TEvent args))s;
                handlers?.Invoke(args);
            }
            , (Handlers, e));
        }
    }
}