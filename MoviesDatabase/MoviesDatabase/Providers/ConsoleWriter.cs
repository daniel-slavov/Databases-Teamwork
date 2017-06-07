using System;
using System.Collections.Generic;
using System.Text;
using MoviesDatabase.CLI.Providers.Contracts;
using MoviesDatabase.Models;

namespace MoviesDatabase.CLI.Providers
{
    public class ConsoleWriter : IConsoleWriter
    {
        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }

        //public void PrintMovies(IEnumerable<Movie> movies)
        //{
        //    StringBuilder builder = new StringBuilder();

        //    builder.AppendLine("");
        //}
    }
}
