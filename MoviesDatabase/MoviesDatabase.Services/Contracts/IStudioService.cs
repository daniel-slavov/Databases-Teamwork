using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoviesDatabase.Models;

namespace MoviesDatabase.Services.Contracts
{
    public interface IStudioService
    {
        void AddStudios();

        Studio CreateStudio(string name, string address);

        Studio GetStudioBy(string name);
    }
}
