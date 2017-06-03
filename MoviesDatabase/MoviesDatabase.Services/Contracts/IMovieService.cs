using System;
using System.Collections.Generic;
using MoviesDatabase.Models;
using MoviesDatabase.Models.Contracts;

namespace MoviesDatabase.Services.Contracts
{
    public interface IMovieService
    {
        void CreateMovie(IList<IModel> collection);
    }
}
