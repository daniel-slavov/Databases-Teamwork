using System;
using System.Collections.Generic;
using MoviesDatabase.Models;

namespace MoviesDatabase.CLI.Providers.Contracts
{
    public interface IMoviesConverter
    {
        string ToString(IEnumerable<Movie> movies);
    }
}
