using System;
using System.Collections.Generic;
using MoviesDatabase.Models;

namespace MoviesDatabase.CLI.Providers.Contracts
{
    public interface IWriter
    {
        void Write(string message);

        void WriteLine(string message);
    }
}
