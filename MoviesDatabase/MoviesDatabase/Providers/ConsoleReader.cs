using System;
using MoviesDatabase.Providers.Contracts;

namespace MoviesDatabase.Providers
{
    public class ConsoleReader : IConsoleReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
