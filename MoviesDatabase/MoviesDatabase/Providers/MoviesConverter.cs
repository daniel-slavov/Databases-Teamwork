using System;
using System.Collections.Generic;
using MoviesDatabase.CLI.Providers.Contracts;
using MoviesDatabase.Models;

namespace MoviesDatabase.CLI.Providers
{
    public class MoviesConverter : IMoviesConverter
    {
        public string ToString(IEnumerable<Movie> movies)
        {
            throw new NotImplementedException();
        }

		public string ToString(Movie movies)
		{
			throw new NotImplementedException();
		}
    }
}
