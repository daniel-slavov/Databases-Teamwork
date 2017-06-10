using System;
using System.Collections.Generic;
using MoviesDatabase.CLI.Commands.Contracts;
using MoviesDatabase.Models;
using MoviesDatabase.Parsers.Contracts;
using MoviesDatabase.Services.Contracts;

namespace MoviesDatabase.CLI.Commands
{
    public class ImportXMLCommand : ICommand
    {
		private readonly IBookService BookService;
        private readonly IGenreService GenreService;
        private readonly IProducerService ProducerService;
		private readonly IStudioService StudioService;
		private readonly IXMLParser XMLParser;

		public ImportXMLCommand(IBookService bookService, IGenreService genreService, IProducerService producerService, IStudioService studioService, IXMLParser xmlParser)
        {
			if (bookService == null)
			{
				throw new ArgumentNullException("Book service cannnot be null.");
			}

			if (genreService == null)
			{
				throw new ArgumentNullException("Genre service cannnot be null.");
			}

			if (producerService == null)
			{
				throw new ArgumentNullException("Studio service cannnot be null.");
			}

			if (studioService == null)
			{
				throw new ArgumentNullException("Studio service cannnot be null.");
			}

			if (xmlParser == null)
			{
				throw new ArgumentNullException("XML parser cannnot be null.");
			}
			
            this.BookService = bookService;
            this.GenreService = genreService;
            this.ProducerService = producerService;
			this.StudioService = studioService;
			this.XMLParser = xmlParser;
		}

        public string Execute(IList<string> parameters)
        {
            string model = parameters[0];
            string path = parameters[1];

            switch (model.ToLower())
            {
				case "book":
					List<Book> books = this.XMLParser.ParseBooks(path);
					this.BookService.AddBooks(books);
					break;
                case "genre":
                    List<Genre> genres = this.XMLParser.ParseGenres(path);
                    this.GenreService.AddGenres(genres);
                    break;
				case "producer":
					List<Producer> producers = this.XMLParser.ParseProducers(path);
					this.ProducerService.AddProducers(producers);
					break;
                case "studio":
                    List<Studio> studios = this.XMLParser.ParseStudios(path);
                    this.StudioService.AddStudios(studios);
                    break;
                default:
                    throw new ArgumentException($"{model}s are not supported.");
            }
            return "XML file imported successfully.";
        }
    }
}
// Sample command:
// ImportXML Producer ./sample.xml