using System;
using System.Collections.Generic;
using MoviesDatabase.Models;

namespace MoviesDatabase.CLI.Providers.Contracts
{
    public interface IConsoleWriter
    {
        void Write(string message);

        void WriteLine(string message);
    }
}
