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
        private readonly IXMLParser XMLParser;
        private readonly IGenreService GenreService;
        private readonly IStudioService StudioService;
        private readonly IProducerService ProducerService;
        private readonly IBookService BookService;

        public ImportXMLCommand(IXMLParser xmlParser, IStudioService studioService, IProducerService producerService, IBookService bookService, IGenreService genreService)
        {
            if(xmlParser == null)
            {
                throw new ArgumentNullException("XML parser cannnot be null.");
            }

			if (studioService == null)
			{
				throw new ArgumentNullException("Studio service cannnot be null.");
			}


			if (genreService == null)
			{
				throw new ArgumentNullException("Genre service cannnot be null.");
			}

			if (producerService == null)
			{
				throw new ArgumentNullException("Studio service cannnot be null.");
			}

			if (bookService == null)
			{
				throw new ArgumentNullException("Book service cannnot be null.");
			}

            this.XMLParser = xmlParser;
            this.GenreService = genreService;
            this.StudioService = studioService;
            this.ProducerService = producerService;
            this.BookService = bookService;
        }
        public string Execute(IList<string> parameters)
        {
            string model = parameters[0];
            string path = parameters[1];

            switch (model.ToLower())
            {
                case "genre":
                    List<Genre> genres = this.XMLParser.ParseGenres(path);
                    this.GenreService.AddGenres(genres);
                    break;
                case "studio":
                    List<Studio> studios = this.XMLParser.ParseStudios(path);
                    this.StudioService.AddStudios(studios);
                    break;
                case "producer":
                    List<Producer> producers = this.XMLParser.ParseProducers(path);
                    this.ProducerService.AddProducers(producers);
                    break;
                case "book":
                    List<Book> books = this.XMLParser.ParseBooks(path);
                    this.BookService.AddBooks(books);
                    break;
                default:
                    throw new ArgumentException("Model type is not supported.");
            }
            return "File imported successfully.";
        }
    }
}
