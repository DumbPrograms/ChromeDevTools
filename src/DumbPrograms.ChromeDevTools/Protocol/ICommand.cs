namespace DumbPrograms.ChromeDevTools.Protocol
{
    public interface ICommand
    {
        string Name { get; }
    }

    interface ICommand<TResponse> : ICommand
    {
    }
}
