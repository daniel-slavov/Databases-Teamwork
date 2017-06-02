using System;
using MoviesDatabase.Providers.Contracts;

namespace MoviesDatabase.Providers
{
    public class ConsoleWriter : IConsoleWriter
    {
        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }
    }
}
