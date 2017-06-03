using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoviesDatabase.Models;

namespace MoviesDatabase.Parsers.Contracts
{
    public interface IXmlParser
    {
        List<Movie> ParseMovies(string filePath);

        List<Genre> ParseGenres(string filePath);

        List<Book> ParseBooks(string filePath);

        List<Producer> ParseProducers(string filePath);

        List<Studio> ParseStudios(string filePath);

        List<Star> ParseStars(string filePath);
    }
}
