using System;
using System.Collections.Generic;
using MoviesDatabase.CLI.Commands.Contracts;
using MoviesDatabase.Services.Contracts;

namespace MoviesDatabase.CLI.Commands
{
    public class LoginCommand : ICommand
    {
        private readonly IUserService userService;

        public LoginCommand(IUserService userService)
        {
            if (userService == null)
            {
                throw new ArgumentNullException("User service cannot be null.");
            }

            this.userService = userService;
        }

        public string Execute(IList<string> parameters)
        {
            if (parameters == null || parameters.Count < 2)
            {
                throw new ArgumentException("Missing username and/or password.");
            }

            var username = parameters[0];
            var password = parameters[1];

            var user = this.userService.GetUser(username, password);

            if (user == null)
            {
                throw new NullReferenceException("There is no user with these credentials.");
            }

            return "Login successful.";
        }
    }
}
