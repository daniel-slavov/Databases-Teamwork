using System.Collections.Generic;
using ConsoleTables;
using MoviesDatabase.CLI.Providers.Contracts;

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
