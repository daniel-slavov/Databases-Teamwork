using System;
using MoviesDatabase.CLI.Providers.Contracts;

namespace MoviesDatabase.CLI.Providers
{
    public class ConsoleReader : IConsoleReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
