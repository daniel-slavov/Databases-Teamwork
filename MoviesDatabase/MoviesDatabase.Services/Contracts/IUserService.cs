namespace MoviesDatabase.Services.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using MoviesDatabase.Models;

    public interface IUserService
    {
        User GetUser(string username, string password);
    }
}
