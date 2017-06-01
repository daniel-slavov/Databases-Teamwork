using System;
using System.Collections.Generic;
using MoviesDatabase.Commands.Contracts;
using MoviesDatabase.Providers.Contracts;

namespace MoviesDatabase.Commands
{
    public class AddCommand : ICommand
    {
        
        private readonly IDatabaseProvider dbProvider;

        public AddCommand(IDatabaseProvider databaseProvider)
        {
			this.dbProvider = databaseProvider ?? throw new ArgumentNullException("Databse provider cannnot be null.");

		}

        public string Execute(IList<string> parameters)
        {
            return "Add command.";
        }
    }
}
