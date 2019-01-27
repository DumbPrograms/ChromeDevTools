namespace DumbPrograms.ChromeDevTools.Protocol
{
    public class JSAlias<TNative>
    {
        public TNative Value { get; protected set; }

        public JSAlias(TNative value)
        {
            Value = value;
        }

        protected JSAlias() { }

        public static TAlias New<TAlias>(TNative value) where TAlias : JSAlias<TNative>, new()
        {
            return new TAlias { Value = value };
        }
    }
}
