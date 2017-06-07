using System;
using System.Linq;
using System.Reflection;
using MoviesDatabase.CLI.Providers.Contracts;
using MoviesDatabase.Models.Contracts;

namespace MoviesDatabase.CLI.Providers
{
    public class ModelParser : IModelParser
    {
        public Type GetType(string modelName)
        {
            Assembly currentAssembly = this.GetType().GetTypeInfo().Assembly;
            Type modelType = currentAssembly.DefinedTypes
                .Where(type => type.ImplementedInterfaces.Any(inter => inter == typeof(IModel)))
                .SingleOrDefault(type => type.Name.ToLower().Contains(modelName.ToLower()));

            if (modelType == null)
            {
                throw new ArgumentException("Model is not found!");
            }

            return modelType;
        }
    }
}

// NOT NEEDED ANYMORE