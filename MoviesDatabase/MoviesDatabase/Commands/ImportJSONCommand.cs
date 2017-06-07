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
        private readonly IJSONParser JSONParser;
		private readonly IMovieService MovieService;
		private readonly IStarService StarService;

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

            this.JSONParser = jsonParser;
			this.MovieService = movieService;
			this.StarService = starService;
        }

        public string Execute(IList<string> parameters)
        {
            string model = parameters[0];
            string path = parameters[1];

            switch (model.ToLower())
            {
                case "movie":
                    IList<MovieModel> movies = this.JSONParser.Parse<MovieModel>(path);
                    this.MovieService.AddMovies(movies);
                    break;
				case "star":
                    IList<Star> stars = this.JSONParser.Parse<Star>(path);
                    this.StarService.AddStars(stars);
					break;
                default:
                    throw new ArgumentException($"Model type {model} is not supported.");
            }

            return $"{model} JSON file imported successfully.";
        }
    }
}
// Sample command:
// ImportJSON Movie ./sample.json