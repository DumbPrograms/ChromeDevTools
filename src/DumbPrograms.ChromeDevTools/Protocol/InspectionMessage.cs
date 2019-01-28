namespace DumbPrograms.ChromeDevTools.Protocol
{
    public class InspectionMessage
    {
        public int? Id { get; set; }
        public string Method { get; set; }
        public object Params { get; set; }
        public object Result { get; set; }
        public ErrorDescription Error { get; set; }
    }
}
