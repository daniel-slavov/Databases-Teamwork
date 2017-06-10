using System;
using MoviesDatabase.CLI.Providers.Contracts;

namespace MoviesDatabase.CLI.Providers
{
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
