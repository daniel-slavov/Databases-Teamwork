using System;
using System.Collections.Generic;
using System.Reflection;
using MoviesDatabase.CLI.Commands.Contracts;
using MoviesDatabase.CLI.Providers.Contracts;
using MoviesDatabase.Models;
using MoviesDatabase.Models.Contracts;
using MoviesDatabase.Parsers.Contracts;
using MoviesDatabase.Parsers.Models;
using MoviesDatabase.Services.Contracts;

namespace MoviesDatabase.CLI.Commands
{
    public class ImportJSONCommand : ICommand
    {
        private readonly IJSONParser JSONParser;
        private readonly IStarService StarService;
        private readonly IMovieService MovieService;

        public ImportJSONCommand(IMovieService movieService, IJSONParser jsonParser, IStarService starService)
        {
            if (jsonParser == null)
            {
                throw new ArgumentNullException("JSON parser cannnot be null.");
            }

            if (starService == null)
            {
				throw new ArgumentNullException("Star service cannnot be null.");
			}

            if (movieService == null)
			{
				throw new ArgumentNullException("Movie service cannnot be null.");
			}

            this.JSONParser = jsonParser;
            this.StarService = starService;
            this.MovieService = movieService;
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
                    throw new ArgumentException("Model type is not supported.");
            }

            return "File imported successfully.";
        }
    }
}
