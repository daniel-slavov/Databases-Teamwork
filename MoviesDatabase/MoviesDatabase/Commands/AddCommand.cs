using System;
using System.Collections.Generic;
using MoviesDatabase.CLI.Commands.Contracts;
using MoviesDatabase.CLI.Providers.Contracts;
using MoviesDatabase.Services.Contracts;
using MoviesDatabase.Models;

namespace MoviesDatabase.CLI.Commands
{
    public class AddCommand : ICommand
    {
        private readonly IMovieService MovieService;
		private readonly IConsoleReader Reader;
		private readonly IConsoleWriter Writer;

		public AddCommand(IMovieService movieService, IConsoleReader reader, IConsoleWriter writer)
        {
            if (movieService == null)
            {
                throw new ArgumentNullException("Movie service cannot be null.");
            }

            if (reader == null)
			{
				throw new ArgumentNullException("Console reader cannot be null.");
			}

			if (writer == null)
			{
				throw new ArgumentNullException("Console writer cannot be null.");
			}

            this.MovieService = movieService;
			this.Reader = reader;
            this.Writer = writer;
		}

        public string Execute(IList<string> parameters)
        {
   //         this.Writer.Write("Title: ");
   //         string title = this.Reader.ReadLine();
   //         this.Writer.Write("Year: ");
   //         int year = int.Parse(this.Reader.ReadLine()); 
			//this.Writer.Write("Description: ");
   //         string description = this.Reader.re
			//string studioName = this.Reader.ReadLine();
			//this.Writer.Write("Title: ");
			//IList<string> producers = this.Reader.ReadLine();
			//this.Writer.Write("Title: ");
			

            //this.service.CreateMovie("title", 2000, "test", 120, new Producer(), new Studio(), new Book());

            //var testMovie = new Movie("testtittle", 2000, "test", 120, new Producer(), new Studio(), new Book(), new List<Genre>(), new List<Star>());
            //Console.WriteLine(testMovie.GetType().GetProperty("Title").GetValue(testMovie, null));

            return "Command executed successfully.";
        }
    }
}
