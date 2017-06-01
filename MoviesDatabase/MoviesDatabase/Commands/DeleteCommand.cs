using System;
using System.Collections.Generic;
using MoviesDatabase.Commands.Contracts;

namespace MoviesDatabase.Commands
{
    public class DeleteCommand : ICommand
    {
        public DeleteCommand()
        {
        }

        public string Execute(IList<string> parameters)
        {
            throw new NotImplementedException();
        }
    }
}
