using Newtonsoft.Json;

namespace DumbPrograms.ChromeDevTools.Generator
{
    public class TypeDescriptor
    {
        [JsonProperty("id")]
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Experimental { get; set; }
        public bool Deprecated { get; set; }
        public JsonTypes Type { get; set; }
        public string[] Enum { get; set; }
        public PropertyDescriptor[] Properties { get; set; }
    }
}