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
        private readonly IBookService bookService;
        private readonly IGenreService genreService;
        private readonly IProducerService producerService;
        private readonly IStudioService studioService;
        private readonly IXMLParser xMLParser;

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

            this.bookService = bookService;
            this.genreService = genreService;
            this.producerService = producerService;
            this.studioService = studioService;
            this.xMLParser = xmlParser;
        }

        public string Execute(IList<string> parameters)
        {
            string model = parameters[0];
            string path = parameters[1];

            switch (model.ToLower())
            {
                case "book":
                    List<Book> books = this.xMLParser.ParseBooks(path);
                    this.bookService.AddBooks(books);
                    break;
                case "genre":
                    List<Genre> genres = this.xMLParser.ParseGenres(path);
                    this.genreService.AddGenres(genres);
                    break;
                case "producer":
                    List<Producer> producers = this.xMLParser.ParseProducers(path);
                    this.producerService.AddProducers(producers);
                    break;
                case "studio":
                    List<Studio> studios = this.xMLParser.ParseStudios(path);
                    this.studioService.AddStudios(studios);
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