using System;
using System.Collections.Generic;
using MoviesDatabase.CLI.Commands.Contracts;
using MoviesDatabase.CLI.Providers.Contracts;

namespace MoviesDatabase.CLI.Commands.Abstracts
{
    public abstract class Command : ICommand
    {
        protected readonly IMovieService service;

	    public Command(IMovieService service)
	    {
            if (service == null)
            {
                throw new ArgumentNullException("Database provider cannnot be null.");
            }

            this.service = service;
	    }

        public abstract string Execute(IList<string> parameters);
    }
}
