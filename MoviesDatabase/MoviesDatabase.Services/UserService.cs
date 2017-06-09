using MoviesDatabase.Data.Contracts;
using MoviesDatabase.Models;
using MoviesDatabase.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesDatabase.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> userRepository;

        public UserService(IRepository<User> userRepository)
        {
            if(userRepository == null)
            {
                throw new ArgumentNullException("User repository cannot be null!");
            }

            this.userRepository = userRepository;
        }

        public User GetUser(string username, string password)
        {
            var user = this.userRepository.Entities
                .Include(u => u.Username)
                .FirstOrDefault(u => u.Username == username && u.PassHash == password);
            Console.WriteLine(user.ToString());
            return user;
        }
    }
}
