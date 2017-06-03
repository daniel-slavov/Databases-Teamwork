using System;
using MoviesDatabase.CLI.Commands.Contracts;

namespace MoviesDatabase.CLI.Core.Contracts
{
    public interface ICommandFactory
    {
        ICommand GetCommand(Type type);
    }
}
