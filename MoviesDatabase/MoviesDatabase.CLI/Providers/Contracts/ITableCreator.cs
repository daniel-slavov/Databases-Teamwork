using System.Collections.Generic;

namespace MoviesDatabase.CLI.Providers.Contracts
{
    public interface ITableCreator
    {
        string CreateTable<T>(IEnumerable<T> collection);
    }
}
