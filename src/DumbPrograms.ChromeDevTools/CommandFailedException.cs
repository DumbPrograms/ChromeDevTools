using System;
using DumbPrograms.ChromeDevTools.Protocol;

namespace DumbPrograms.ChromeDevTools
{
    /// <summary>
    /// The invoked command returned a failure.
    /// </summary>
    [Serializable]
    public class CommandFailedException : Exception
    {
        public ICommand Command { get; }
        public int ErrorCode { get; }

        public CommandFailedException(ICommand command, int code, string message) : base(message)
        {
            Command = command;
            ErrorCode = code;
        }
    }
}
