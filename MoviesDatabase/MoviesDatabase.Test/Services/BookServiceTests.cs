using Moq;
using MoviesDatabase.Data.Contracts;
using MoviesDatabase.Factories;
using MoviesDatabase.Models;
using MoviesDatabase.Services;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesDatabase.Test.Services
{
    [TestFixture]
    public class BookServiceTests
    {
        [Test]
        public void Constructor_ShouldThrowArgumentNullException_WhenBookRepositoryIsNull()
        {
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var bookFactoryMock = new Mock<IBookFactory>();

            Assert.Throws<ArgumentNullException>(
                () => new BookService(null, unitOfWorkMock.Object, bookFactoryMock.Object));
        }

        [Test]
        public void Constructor_ShouldThrowArgumentNullException_WhenUnitOfWorkIsNull()
        {
            var bookRepositoryMock = new Mock<IRepository<Book>>();
            var bookFactoryMock = new Mock<IBookFactory>();

            Assert.Throws<ArgumentNullException>(
                () => new BookService(bookRepositoryMock.Object, null, bookFactoryMock.Object));
        }

        [Test]
        public void Constructor_ShouldThrowArgumentNullException_WhenBookFactoryIsNull()
        {
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var bookRepositoryMock = new Mock<IRepository<Book>>();

            Assert.Throws<ArgumentNullException>(
                () => new BookService(bookRepositoryMock.Object, unitOfWorkMock.Object, null));
        }

        [Test]
        public void Constructor_ShouldNotThrow_WhenValidParametersPassed()
        {
            var bookRepositoryMock = new Mock<IRepository<Book>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var bookFactoryMock = new Mock<IBookFactory>();

            Assert.DoesNotThrow(
                () => new BookService(bookRepositoryMock.Object, unitOfWorkMock.Object, bookFactoryMock.Object));
        }

        [Test]
        public void AddBooks_ShouldCallRepositoryAddMethod_WhenValidListIsPassed()
        {
            var bookRepositoryMock = new Mock<IRepository<Book>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var bookFactoryMock = new Mock<IBookFactory>();
            var bookService = new BookService(
                bookRepositoryMock.Object, unitOfWorkMock.Object, bookFactoryMock.Object);
            var books = new List<Book>
            {
                new Book("Harry Potter", "J.K.Rowling", null),
                new Book("The Fault in Our Stars", "John Green", null)
            };

            bookService.AddBooks(books);

            bookRepositoryMock.Verify(b => b.Add(It.IsAny<Book>()), Times.Exactly(books.Count));
        }

        [Test]
        public void AddBooks_ShouldCallUnitOfWorkCommitMethod_WhenValidListIsPassed()
        {
            var bookRepositoryMock = new Mock<IRepository<Book>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var bookFactoryMock = new Mock<IBookFactory>();
            var bookService = new BookService(
                bookRepositoryMock.Object, unitOfWorkMock.Object, bookFactoryMock.Object);
            var books = new List<Book>
            {
                new Book("Harry Potter", "J.K.Rowling", null),
                new Book("The Fault in Our Stars", "John Green", null)
            };

            bookService.AddBooks(books);

            unitOfWorkMock.Verify(n => n.Commit(), Times.Once);
        }

        [Test]
        public void CreateBook_ShouldCallFactoryCreateBookMethod_WhenValidParametersPassed()
        {
            var bookRepositoryMock = new Mock<IRepository<Book>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var bookFactoryMock = new Mock<IBookFactory>();
            var bookService = new BookService(
                bookRepositoryMock.Object, unitOfWorkMock.Object, bookFactoryMock.Object);

            var title = "Harry Potter";
            var author = "J.K.Rowling";
            var year = 2001;

            bookService.CreateBook(title, author, year);

            bookFactoryMock.Verify(f => f.CreateBook(title, author, year), Times.Once);
        }

        [Test]
        public void CreateBook_ShouldCallRepositoryAddMethod_WhenValidParametersPassed()
        {
            var bookRepositoryMock = new Mock<IRepository<Book>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var bookFactoryMock = new Mock<IBookFactory>();
            var bookService = new BookService(
                bookRepositoryMock.Object, unitOfWorkMock.Object, bookFactoryMock.Object);

            var title = "Harry Potter";
            var author = "J.K.Rowling";
            var year = 2001;
            var book = new Book(title, author, year);
            bookFactoryMock.Setup(f => f.CreateBook(title, author, year)).Returns(book);

            bookService.CreateBook(title, author, year);

            bookRepositoryMock.Verify(r => r.Add(book), Times.Once);
        }

        [Test]
        public void CreateBook_ShouldCallUnitOfWorkCommitMethod_WhenValidParametersPassed()
        {
            var bookRepositoryMock = new Mock<IRepository<Book>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var bookFactoryMock = new Mock<IBookFactory>();
            var bookService = new BookService(
                bookRepositoryMock.Object, unitOfWorkMock.Object, bookFactoryMock.Object);

            var title = "Harry Potter";
            var author = "J.K.Rowling";
            var year = 2001;

            bookService.CreateBook(title, author, year);

            unitOfWorkMock.Verify(n => n.Commit(), Times.Once);
        }

        [Test]
        public void CreateBook_ShouldReturnCorrectBook_WhenValidParametersPassed()
        {
            var bookRepositoryMock = new Mock<IRepository<Book>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var bookFactoryMock = new Mock<IBookFactory>();
            var bookService = new BookService(
                bookRepositoryMock.Object, unitOfWorkMock.Object, bookFactoryMock.Object);

            var title = "Harry Potter";
            var author = "J.K.Rowling";
            var year = 2001;
            var book = new Book(title, author, year);
            bookFactoryMock.Setup(f => f.CreateBook(title, author, year)).Returns(book);

            var returnedBook = bookService.CreateBook(title, author, year);

            Assert.AreSame(book, returnedBook);
        }

        [Test]
        public void GetBookByTitle_ShouldCallRepository_WhenValidParametersPassed()
        {
            var title = "Harry Potter";
            var bookRepositoryMock = new Mock<IRepository<Book>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var bookFactoryMock = new Mock<IBookFactory>();
            var bookService = new BookService(
                bookRepositoryMock.Object, unitOfWorkMock.Object, bookFactoryMock.Object);

            bookService.GetBookByTitle(title);

            bookRepositoryMock.Verify(r => r.Entities, Times.Once);
        }

        [Test]
        public void GetBookByTitle_ShouldReturnCorrectBook_WhenValidParametersPassed()
        {
            var title = "Harry Potter";
            var author = "J.K.Rowling";
            var year = 2001;
            var bookRepositoryMock = new Mock<IRepository<Book>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var bookFactoryMock = new Mock<IBookFactory>();
            var book = new Book(title, author, year);
            var list = new List<Book>() { book };
            var queryableBooks = list.AsQueryable();

            bookRepositoryMock.Setup(r => r.Entities).Returns(queryableBooks);
            var bookService = new BookService(
                bookRepositoryMock.Object, unitOfWorkMock.Object, bookFactoryMock.Object);

            var returnedBook = bookService.GetBookByTitle(title);

            Assert.AreSame(book, returnedBook);
        }

        [Test]
        public void UpdateBook_ShouldCallRepositoryAddMethod_WhenValidParametersPassed()
        {
            var bookRepositoryMock = new Mock<IRepository<Book>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var bookFactoryMock = new Mock<IBookFactory>();
            var bookMock = new Mock<Book>();
            var bookService = new BookService(
                bookRepositoryMock.Object, unitOfWorkMock.Object, bookFactoryMock.Object);

            bookService.UpdateBook(bookMock.Object);

            bookRepositoryMock.Verify(r => r.Update(bookMock.Object), Times.Once);
        }

        [Test]
        public void UpdateBook_ShouldCallUnitOfWorkCommitMethod_WhenValidParametersPassed()
        {
            var bookRepositoryMock = new Mock<IRepository<Book>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var bookFactoryMock = new Mock<IBookFactory>();
            var bookMock = new Mock<Book>();
            var bookService = new BookService(
                bookRepositoryMock.Object, unitOfWorkMock.Object, bookFactoryMock.Object);

            bookService.UpdateBook(bookMock.Object);

            unitOfWorkMock.Verify(n => n.Commit(), Times.Once);
        }

        [Test]
        public void DeleteBook_ShouldCallRepositoryEntities_WhenValidParametersPassed()
        {
            //var bookRepositoryMock = new Mock<IRepository<Book>>();
            //var unitOfWorkMock = new Mock<IUnitOfWork>();
            //var bookFactoryMock = new Mock<IBookFactory>();
            //var bookMock = new Mock<Book>();
            //var bookService = new BookService(
            //    bookRepositoryMock.Object, unitOfWorkMock.Object, bookFactoryMock.Object);

            //bookService.DeleteBook(bookMock.Object);

            //bookRepositoryMock.Verify(r => r.Entities, Times.Once);
        }

        [Test]
        public void DeleteBook_ShouldThrowArgumentNullException_WhenBookIsNotFound()
        {
            var title = "Harry Potter";
            var bookRepositoryMock = new Mock<IRepository<Book>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var bookFactoryMock = new Mock<IBookFactory>();
            var list = new List<Book>();
            var queryableBooks = list.AsQueryable();
            bookRepositoryMock.Setup(r => r.Entities).Returns(queryableBooks);
            var bookService = new BookService(
                bookRepositoryMock.Object, unitOfWorkMock.Object, bookFactoryMock.Object);

            Assert.Throws<NullReferenceException>(() => bookService.DeleteBook(title));
        }

        [Test]
        public void DeleteBook_ShouldCallRepositoryDeleteMethod_WhenValidParametersPassed()
        {
            var title = "Harry Potter";
            var author = "J.K.Rowling";
            var year = 2001;
            var bookRepositoryMock = new Mock<IRepository<Book>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var bookFactoryMock = new Mock<IBookFactory>();
            var bookMock = new Book(title, author, year);
            var list = new List<Book>() { bookMock };
            var queryableBooks = list.AsQueryable();
            bookRepositoryMock.Setup(r => r.Entities).Returns(queryableBooks);
            var bookService = new BookService(
                bookRepositoryMock.Object, unitOfWorkMock.Object, bookFactoryMock.Object);

            bookService.DeleteBook(title);

            bookRepositoryMock.Verify(r => r.Delete(bookMock), Times.Once);
        }

        [Test]
        public void DeleteBook_ShouldCallUnitOfWorkCommitMethod_WhenValidParametersPassed()
        {
            var title = "Harry Potter";
            var author = "J.K.Rowling";
            var year = 2001;
            var bookRepositoryMock = new Mock<IRepository<Book>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var bookFactoryMock = new Mock<IBookFactory>();
            var bookMock = new Book(title, author, year);
            var list = new List<Book>() { bookMock };
            var queryableBooks = list.AsQueryable();
            bookRepositoryMock.Setup(r => r.Entities).Returns(queryableBooks);
            var bookService = new BookService(
                bookRepositoryMock.Object, unitOfWorkMock.Object, bookFactoryMock.Object);

            bookService.DeleteBook(title);

            unitOfWorkMock.Verify(r => r.Commit(), Times.Once);
        }
    }
}
