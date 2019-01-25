namespace DumbPrograms.ChromeDevTools.Protocol
{
    public interface ICommand
    {
        string Name { get; }
    }

    public interface ICommand<TResponse> : ICommand
    {
    }
}
