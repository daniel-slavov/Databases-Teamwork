using System;
using MoviesDatabase.CLI.Providers.Contracts;

namespace MoviesDatabase.CLI.Providers
{
    public class ConsoleWriter : IConsoleWriter
    {
        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }
    }
}
