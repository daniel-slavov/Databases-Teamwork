using System.Collections.Generic;
using MoviesDatabase.CLI.Commands.Contracts;

namespace MoviesDatabase.CLI.Providers.Contracts
{
    public interface ICommandParser
    {
        ICommand ParseCommand(string fullCommand);

        IList<string> ParseParameters(string fullCommand);
    }
}
