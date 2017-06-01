using System;
using System.Collections.Generic;
using MoviesDatabase.Commands.Contracts;

namespace MoviesDatabase.Providers.Contracts
{
    public interface ICommandParser
    {
		ICommand ParseCommand(string fullCommand);
		IList<string> ParseParameters(string fullCommand);
    }
}
