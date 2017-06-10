using System.Collections.Generic;
using MoviesDatabase.Models;

namespace MoviesDatabase.Services.Contracts
{
    public interface IStarService
    {
        void AddStars(IList<Star> stars);

        Star CreateStar(string firstName, string lastName, int? age, string address);

        Star GetStarByName(string firstName, string lastName);

        IEnumerable<Movie> GetAllMoviesOfStar(string firstName, string lastName);

        void UpdateStar(Star star);

        void DeleteStar(string firstName, string lastName);
    }
}
