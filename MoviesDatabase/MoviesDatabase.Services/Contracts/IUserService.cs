using MoviesDatabase.Models;

namespace MoviesDatabase.Services.Contracts
{
    public interface IUserService
    {
        User GetUser(string username, string password);
    }
}
