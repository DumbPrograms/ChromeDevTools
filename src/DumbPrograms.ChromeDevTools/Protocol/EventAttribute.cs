using System;

namespace DumbPrograms.ChromeDevTools.Protocol
{
    [AttributeUsage(AttributeTargets.Class)]
    public class EventAttribute : Attribute
    {
        public string Name { get; }

        public EventAttribute(string name)
        {
            Name = name;
        }
    }
}
