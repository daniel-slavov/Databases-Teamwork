using System;
namespace MoviesDatabase.CLI.Providers.Contracts
{
    public interface IConsoleWriter
    {
        void WriteLine(string message);
    }
}
