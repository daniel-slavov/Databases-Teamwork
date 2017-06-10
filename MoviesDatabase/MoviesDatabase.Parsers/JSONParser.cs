using System.Collections.Generic;
using System.IO;
using MoviesDatabase.Parsers.Contracts;
using Newtonsoft.Json;

namespace MoviesDatabase.Parsers
{
    public class JSONParser : IJSONParser
    {
        private StreamReader reader;

        public List<T> Parse<T>(string filePath)
        {
            var collection = new List<T>();
            this.reader = new StreamReader(filePath);
            var json = this.reader.ReadToEnd();

            collection = JsonConvert.DeserializeObject<List<T>>(json);
            return collection;
        }
    }
}
