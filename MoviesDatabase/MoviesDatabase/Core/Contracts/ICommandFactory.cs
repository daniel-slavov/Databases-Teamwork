using System;
using MoviesDatabase.Commands.Contracts;

namespace MoviesDatabase.Core.Contracts
{
    public interface ICommandFactory
    {
        ICommand GetCommand(Type type);
    }
}
