using ConsoleTables;
using MoviesDatabase.CLI.Providers.Contracts;
using System.Collections.Generic;

namespace MoviesDatabase.CLI.Providers
{
    public class TableCreator : ITableCreator
    {
        public string CreateTable<T>(IEnumerable<T> collection)
        {
            return ConsoleTable.From<T>(collection).ToString();
        }
    }
}
