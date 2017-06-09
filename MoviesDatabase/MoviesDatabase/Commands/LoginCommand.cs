using System;
using System.Collections.Generic;
using MoviesDatabase.CLI.Commands.Contracts;
using MoviesDatabase.Services.Contracts;

namespace MoviesDatabase.CLI.Commands
{
    public class LoginCommand : ICommand
    {
        private readonly IUserService UserService;

        public LoginCommand(IUserService userService)
        {
            if(userService == null)
            {
                throw new ArgumentException("User service cannot be null.");
            }

            this.UserService = userService;
        }

        public string Execute(IList<string> parameters)
        {
            var username = parameters[0];
            var password = parameters[1];

            var user = this.UserService.GetUser(username, password);

            if(user == null)
            {
                throw new NullReferenceException("There is no user with these credentials.");
            }

            return "Login successful.";
        }
    }
}
