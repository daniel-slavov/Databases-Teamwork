using System;
using System.Collections.Generic;
using MoviesDatabase.Commands.Contracts;

namespace MoviesDatabase.Commands
{
    public class UpdateCommand : ICommand
    {
        public UpdateCommand()
        {
        }

        public string Execute(IList<string> parameters)
        {
            throw new NotImplementedException();
        }
    }
}
