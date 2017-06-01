using System;
using System.Collections.Generic;

namespace MoviesDatabase.Commands.Contracts
{
    public interface ICommand
    {
        string Execute(IList<string> parameters);
    }
}
