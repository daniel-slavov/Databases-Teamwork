using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesDatabase.Parsers.Contracts
{
    public interface IJSONParser
    {
        List<T> Parse<T>(string filePath);
    }
}
