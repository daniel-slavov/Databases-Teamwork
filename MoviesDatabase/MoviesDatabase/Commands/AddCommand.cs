using System;
using System.Collections.Generic;
using MoviesDatabase.CLI.Commands.Abstracts;
using MoviesDatabase.CLI.Commands.Contracts;
using MoviesDatabase.CLI.Providers.Contracts;
using MoviesDatabase.Services.Contracts;
using MoviesDatabase.Models;

namespace MoviesDatabase.CLI.Commands
{
    public class AddCommand : Command
    {
        public AddCommand(IMovieService service) : base(service)
        {
        }

        public override string Execute(IList<string> parameters)
        {
            this.service.CreateMovie("title", 2000, "test", 120, new Producer(), new Studio(), new Book());

            return "Command executed successfully.";
        }
    }
}
