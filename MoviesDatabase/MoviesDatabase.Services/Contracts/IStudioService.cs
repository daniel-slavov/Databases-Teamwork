using System.Collections.Generic;
using MoviesDatabase.Models;

namespace MoviesDatabase.Services.Contracts
{
    public interface IStudioService
    {
        void AddStudios(IList<Studio> studios);

        Studio CreateStudio(string name, string address);

        Studio GetStudioByName(string name);

        void UpdateStudio(Studio studio);

        void DeleteStudio(string name);
    }
}
