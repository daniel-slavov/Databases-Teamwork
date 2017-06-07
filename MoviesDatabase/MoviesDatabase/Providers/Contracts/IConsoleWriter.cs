using System;
using System.Collections.Generic;
using MoviesDatabase.Models;

namespace MoviesDatabase.CLI.Providers.Contracts
{
    public interface IConsoleWriter
    {
        void WriteLine(string message);

        //void Print(Movie movie);

        //void PrintMovies(IEnumerable<Movie> movies);
    }
}
