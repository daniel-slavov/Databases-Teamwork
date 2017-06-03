using System;
using System.Collections.Generic;

namespace MoviesDatabase.CLI.Commands.Contracts
{
    public interface ICommand
    {
        string Execute(IList<string> parameters);
    }
}
