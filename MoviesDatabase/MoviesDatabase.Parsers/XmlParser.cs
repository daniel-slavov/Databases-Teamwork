using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using MoviesDatabase.Models;
using MoviesDatabase.Parsers.Contracts;

namespace MoviesDatabase.Parsers
{
    public class XMLParser : IXMLParser
    {
        public List<Movie> ParseMovies(string filePath)
        {
            var reader = XmlReader.Create(filePath);

            var movies = new List<Movie>();

            using (reader)
            {
                var movie = this.ReadNextMovie(reader);
                while (movie != null)
                {
                    movies.Add(movie);
                    movie = this.ReadNextMovie(reader);
                }
            }

            return movies;
        }

        private Movie ReadNextMovie(XmlReader node)
        {
            var movie = new Movie();
            var isIdRead = false;
            var isTitleRead = false;
            var isYearRead = false;
            var isDescriptionRead = false;
            var isLengthRead = false;
            var isProducerIDRead = false;
            var isStudioIDRead = false;
            var isBookIDRead = false;

            while ((!isIdRead || !isTitleRead || !isYearRead || !isDescriptionRead || !isLengthRead ||
                    !isProducerIDRead || !isStudioIDRead || !isBookIDRead) && node.Read())
            {
                if (node.IsStartElement() && node.Name == "movie")
                {
                    movie.MovieID = int.Parse(node.GetAttribute("id"));
                    isIdRead = true;
                }

                if (node.IsStartElement() && node.Name == "movie")
                {
                    movie.ProducerID = int.Parse(node.GetAttribute("producerId"));
                    isProducerIDRead = true;
                }

                if (node.IsStartElement() && node.Name == "movie")
                {
                    movie.BookID = int.Parse(node.GetAttribute("bookId"));
                    isBookIDRead = true;
                }

                if (node.IsStartElement() && node.Name == "movie")
                {
                    movie.StudioID = int.Parse(node.GetAttribute("studioId"));
                    isStudioIDRead = true;
                }

                if (node.IsStartElement() && node.Name == "title")
                {
                    node.Read();
                    movie.Title = node.Value;
                    isTitleRead = true;
                }

                if (node.IsStartElement() && node.Name == "year")
                {
                    node.Read();
                    movie.Year = int.Parse(node.Value);
                    isYearRead = true;
                }

                if (node.IsStartElement() && node.Name == "description")
                {
                    node.Read();
                    movie.Description = node.Value;
                    isDescriptionRead = true;
                }

                if (node.IsStartElement() && node.Name == "length")
                {
                    node.Read();
                    movie.Length = int.Parse(node.Value);
                    isLengthRead = true;
                }

            }

            if (!isIdRead || !isTitleRead || !isYearRead || !isDescriptionRead || !isLengthRead ||
                !isProducerIDRead || !isStudioIDRead || !isBookIDRead)
            {
                return null;
            }

            return movie;
        }

        public List<Genre> ParseGenres(string filePath)
        {
            var reader = XmlReader.Create(filePath);

            var genres = new List<Genre>();

            using (reader)
            {
                var genre = this.ReadNextGenre(reader);
                while (genre != null)
                {
                    genres.Add(genre);
                    genre = this.ReadNextGenre(reader);
                }
            }

            return genres;
        }

        private Genre ReadNextGenre(XmlReader node)
        {
            var genre = new Genre();
            var isIdRead = false;
            var isNameRead = false;

            while ((!isIdRead || !isNameRead) && node.Read())
            {
                if (node.IsStartElement() && node.Name == "genre")
                {
                    genre.GenreID = int.Parse(node.GetAttribute("id"));
                    isIdRead = true;
                }

                if (node.IsStartElement() && node.Name == "name")
                {
                    node.Read();
                    genre.Name = node.Value;
                    isNameRead = true;
                }
            }

            if (!isIdRead || !isNameRead)
            {
                return null;
            }

            return genre;
        }

        public List<Book> ParseBooks(string filePath)
        {
            var reader = XmlReader.Create(filePath);

            var books = new List<Book>();

            using (reader)
            {
                var book = this.ReadNextBook(reader);
                while (book != null)
                {
                    books.Add(book);
                    book = this.ReadNextBook(reader);
                }
            }

            return books;
        }

        private Book ReadNextBook(XmlReader node)
        {
            var book = new Book();
            var isIdRead = false;
            var isTitleRead = false;
            var isYearRead = false;
            var isAuthorRead = false;

            while ((!isIdRead || !isTitleRead || !isYearRead || !isAuthorRead) && node.Read())
            {
                if (node.IsStartElement() && node.Name == "book")
                {
                    book.BookID = int.Parse(node.GetAttribute("id"));
                    isIdRead = true;
                }

                if (node.IsStartElement() && node.Name == "title")
                {
                    node.Read();
                    book.Title = node.Value;
                    isTitleRead = true;
                }

                if (node.IsStartElement() && node.Name == "author")
                {
                    node.Read();
                    book.Author = node.Value;
                    isAuthorRead = true;
                }

                if (node.IsStartElement() && node.Name == "year")
                {
                    node.Read();
                    book.Year = int.Parse(node.Value);
                    isYearRead = true;
                }
            }

            if (!isIdRead || !isTitleRead || !isYearRead || !isAuthorRead)
            {
                return null;
            }

            return book;
        }

        public List<Producer> ParseProducers(string filePath)
        {
            var reader = XmlReader.Create(filePath);

            var producers = new List<Producer>();

            using (reader)
            {
                var producer = this.ReadNextProducer(reader);
                while (producer != null)
                {
                    producers.Add(producer);
                    producer = this.ReadNextProducer(reader);
                }
            }

            return producers;
        }

        private Producer ReadNextProducer(XmlReader node)
        {
            var producer = new Producer();
            var isIdRead = false;
            var isNameRead = false;

            while ((!isIdRead || !isNameRead) && node.Read())
            {
                if (node.IsStartElement() && node.Name == "producer")
                {
                    producer.ProducerID = int.Parse(node.GetAttribute("id"));
                    isIdRead = true;
                }

                if (node.IsStartElement() && node.Name == "name")
                {
                    node.Read();
                    producer.Name = node.Value;
                    isNameRead = true;
                }
            }

            if (!isIdRead || !isNameRead)
            {
                return null;
            }

            return producer;
        }

        public List<Studio> ParseStudios(string filePath)
        {
            var reader = XmlReader.Create(filePath);

            var studios = new List<Studio>();

            using (reader)
            {
                var studio = this.ReadNextStudio(reader);
                while (studio != null)
                {
                    studios.Add(studio);
                    studio = this.ReadNextStudio(reader);
                }
            }

            return studios;
        }

        private Studio ReadNextStudio(XmlReader node)
        {
            var studio = new Studio();
            var isIdRead = false;
            var isNameRead = false;
            var isAddressRead = false;

            while ((!isIdRead || !isNameRead || !isAddressRead) && node.Read())
            {
                if (node.IsStartElement() && node.Name == "studio")
                {
                    studio.StudioID = int.Parse(node.GetAttribute("id"));
                    isIdRead = true;
                }

                if (node.IsStartElement() && node.Name == "name")
                {
                    node.Read();
                    studio.Name = node.Value;
                    isNameRead = true;
                }

                if (node.IsStartElement() && node.Name == "address")
                {
                    node.Read();
                    studio.Address = node.Value;
                    isNameRead = true;
                }
            }

            if (!isIdRead || !isNameRead || !isAddressRead)
            {
                return null;
            }

            return studio;
        }

        public List<Star> ParseStars(string filePath)
        {
            var reader = XmlReader.Create(filePath);

            var stars = new List<Star>();

            using (reader)
            {
                var star = this.ReadNextStar(reader);
                while (star != null)
                {
                    stars.Add(star);
                    star = this.ReadNextStar(reader);
                }
            }

            return stars;
        }

        private Star ReadNextStar(XmlReader node)
        {
            var star = new Star();
            var isIdRead = false;
            var isFirstNameRead = false;
            var isLastNameRead = false;
            var isAgeRead = false;
            var isAddressRead = false;

            while ((!isIdRead || !isFirstNameRead || !isLastNameRead || !isAgeRead || !isAddressRead) && node.Read())
            {
                if (node.IsStartElement() && node.Name == "star")
                {
                    star.StarID = int.Parse(node.GetAttribute("id"));
                    isIdRead = true;
                }

                if (node.IsStartElement() && node.Name == "firstName")
                {
                    node.Read();
                    star.FirstName = node.Value;
                    isFirstNameRead = true;
                }

                if (node.IsStartElement() && node.Name == "lastName")
                {
                    node.Read();
                    star.LastName = node.Value;
                    isLastNameRead = true;
                }

                if (node.IsStartElement() && node.Name == "age")
                {
                    node.Read();
                    star.Age = int.Parse(node.Value);
                    isAgeRead = true;
                }

                if (node.IsStartElement() && node.Name == "address")
                {
                    node.Read();
                    star.Address = node.Value;
                    isAddressRead = true;
                }

            }

            if (!isIdRead || !isFirstNameRead || !isLastNameRead || !isAddressRead || !isAgeRead)
            {
                return null;
            }

            return star;
        }
    }
}
