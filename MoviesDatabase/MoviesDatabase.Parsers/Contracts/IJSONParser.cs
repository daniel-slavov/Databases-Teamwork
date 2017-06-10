using System.Collections.Generic;

namespace MoviesDatabase.Parsers.Contracts
{
    public interface IJSONParser
    {
        List<T> Parse<T>(string filePath);
    }
}
