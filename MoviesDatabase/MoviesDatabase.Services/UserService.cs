using System;
using System.Linq;
using MoviesDatabase.Data.Contracts;
using MoviesDatabase.Models;
using MoviesDatabase.Services.Contracts;

namespace MoviesDatabase.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> userRepository;

        public UserService(IRepository<User> userRepository)
        {
            if (userRepository == null)
            {
                throw new ArgumentNullException("User repository cannot be null!");
            }

            this.userRepository = userRepository;
        }

        public User GetUser(string username, string password)
        {
            var user = this.userRepository.Entities
                .FirstOrDefault(u => u.Username == username && u.PassHash == password);

            return user;
        }
    }
}
