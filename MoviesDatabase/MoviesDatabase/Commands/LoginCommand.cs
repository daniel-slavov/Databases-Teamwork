using System;
using System.Collections.Generic;
using MoviesDatabase.CLI.Commands.Contracts;

namespace MoviesDatabase.CLI.Commands
{
    public class LoginCommand : ICommand
    {
        public string Execute(IList<string> parameters)
        {
            return "Login successful.";
        }
    }
}
