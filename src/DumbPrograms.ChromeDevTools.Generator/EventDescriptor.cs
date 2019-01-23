using System.Text;

namespace DumbPrograms.ChromeDevTools.Generator
{
    public class EventDescriptor
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Experimental { get; set; }
        public bool Deprecated { get; set; }
        public PropertyDescriptor[] Parameters { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder(Name);

            sb.Append(" (");

            if (Parameters != null)
            {
                foreach (var pd in Parameters)
                {
                    sb.Append(pd.Name);
                    if (pd.Optional)
                    {
                        sb.Append('?');
                    }
                    sb.Append(", ");
                }
                sb.Length -= 2;
            }

            sb.Append(") => void");

            return sb.ToString();
        }
    }
}