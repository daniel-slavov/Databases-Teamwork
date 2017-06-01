using System;
namespace MoviesDatabase.Providers.Contracts
{
    public interface IConsoleWriter
    {
        void Write(string message);
        void WriteLine(string message);
    }
}
