using System;
using System.Collections.Generic;
using MoviesDatabase.CLI.Commands.Abstracts;
using MoviesDatabase.CLI.Commands.Contracts;
using MoviesDatabase.CLI.Providers.Contracts;
using MoviesDatabase.Services.Contracts;

namespace MoviesDatabase.CLI.Commands
{
    public class DeleteCommand : Command
    {
        public DeleteCommand(IMovieService service) : base(service)
        {
        }

        public override string Execute(IList<string> parameters)
        {
            throw new NotImplementedException();
        }
    }
}
