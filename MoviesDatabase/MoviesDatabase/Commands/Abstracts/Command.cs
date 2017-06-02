using System;
using System.Collections.Generic;
using MoviesDatabase.Commands.Contracts;
using MoviesDatabase.Providers.Contracts;

namespace MoviesDatabase.Commands.Abstracts
{
    public abstract class Command : ICommand
    {
        protected readonly IDatabaseProvider dbProvider;

	    public Command(IDatabaseProvider databaseProvider)
	    {
		    this.dbProvider = databaseProvider ?? throw new ArgumentNullException("Database provider cannnot be null.");
	    }

        public abstract string Execute(IList<string> parameters);
    }
}
