namespace DumbPrograms.ChromeDevTools.Generator
{
    public class DomainDescriptor
    {
        public string Domain { get; set; }
        public string Description { get; set; }
        public string[] Dependencies { get; set; }
        public bool Experimental { get; set; }
        public TypeDescriptor[] Types { get; set; }
        public CommandDescriptor[] Commands { get; set; }
        public EventDescriptor[] Events { get; set; }

        public override string ToString()
        {
            return $"{Domain}{(Experimental ? "(experimental)" : "")}";
        }
    }
}