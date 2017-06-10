using System;
using System.Collections.Generic;
using MoviesDatabase.CLI.Commands.Contracts;
using MoviesDatabase.Models;
using MoviesDatabase.Parsers.Contracts;
using MoviesDatabase.Parsers.Models;
using MoviesDatabase.Services.Contracts;

namespace MoviesDatabase.CLI.Commands
{
    public class ImportJSONCommand : ICommand
    {
        private readonly IJSONParser jsonParser;
        private readonly IMovieService movieService;
        private readonly IStarService starService;

        public ImportJSONCommand(IJSONParser jsonParser, IMovieService movieService, IStarService starService)
        {
            if (jsonParser == null)
            {
                throw new ArgumentNullException("JSON parser cannnot be null.");
            }

            if (movieService == null)
            {
                throw new ArgumentNullException("Movie service cannnot be null.");
            }

            if (starService == null)
            {
                throw new ArgumentNullException("Star service cannnot be null.");
            }

            this.jsonParser = jsonParser;
            this.movieService = movieService;
            this.starService = starService;
        }

        public string Execute(IList<string> parameters)
        {
            string model = parameters[0];
            string path = parameters[1];

            switch (model.ToLower())
            {
                case "movie":
                    IList<MovieModel> movies = this.jsonParser.Parse<MovieModel>(path);
                    this.movieService.AddMovies(movies);
                    break;
                case "star":
                    IList<Star> stars = this.jsonParser.Parse<Star>(path);
                    this.starService.AddStars(stars);
                    break;
                default:
                    throw new ArgumentException($"{model}s are not supported.");
            }

            return "JSON file imported successfully.";
        }
    }
}

// Sample command:
// ImportJSON Movie ./sample.json