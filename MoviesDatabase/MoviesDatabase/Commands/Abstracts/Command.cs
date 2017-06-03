using System;
using System.Collections.Generic;
using MoviesDatabase.CLI.Commands.Contracts;
using MoviesDatabase.CLI.Providers.Contracts;

namespace MoviesDatabase.CLI.Commands.Abstracts
{
    public abstract class Command : ICommand
    {
        protected readonly IDatabaseProvider dbProvider;

	    public Command(IDatabaseProvider databaseProvider)
	    {
            if (databaseProvider == null)
            {
                throw new ArgumentNullException("Database provider cannnot be null.");
            }

            this.dbProvider = databaseProvider;
	    }

        public abstract string Execute(IList<string> parameters);
    }
}
