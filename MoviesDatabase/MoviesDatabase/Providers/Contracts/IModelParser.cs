using System;
using System.Reflection;

namespace MoviesDatabase.CLI.Providers.Contracts
{
    public interface IModelParser
    {
        Type GetType(string modelName);
    }
}
