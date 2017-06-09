using MoviesDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesDatabase.Services.Contracts
{
    public interface IUserService
    {
        User GetUser(string username, string password);
    }
}
