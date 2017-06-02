using System;
using System.Collections.Generic;
using MoviesDatabase.Commands.Abstracts;
using MoviesDatabase.Providers.Contracts;

namespace MoviesDatabase.Commands
{
    public class GenerateReportCommand : Command
    {
        public GenerateReportCommand(IDatabaseProvider databaseProvider) : base(databaseProvider)
        {
        }

        public override string Execute(IList<string> parameters)
        {
            throw new NotImplementedException();
        }
    }
}
