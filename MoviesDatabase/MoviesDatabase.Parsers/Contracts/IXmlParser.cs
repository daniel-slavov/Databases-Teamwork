using System.Collections.Generic;
using MoviesDatabase.Models;

namespace MoviesDatabase.Parsers.Contracts
{
    public interface IXMLParser
    {
        List<Genre> ParseGenres(string filePath);

        List<Book> ParseBooks(string filePath);

        List<Producer> ParseProducers(string filePath);

        List<Studio> ParseStudios(string filePath);
    }
}
