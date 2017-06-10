using MoviesDatabase.Models;

namespace MoviesDatabase.Factories
{
    public interface IStarFactory
    {
        Star CreateStar(string firstName, string lastName, int? age, string address);
    }
}
