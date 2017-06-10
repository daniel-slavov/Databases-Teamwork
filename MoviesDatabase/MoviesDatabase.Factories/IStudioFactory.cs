using MoviesDatabase.Models;

namespace MoviesDatabase.Factories
{
    public interface IStudioFactory
    {
        Studio CreateStudio(string name, string address);
    }
}
