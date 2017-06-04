using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
