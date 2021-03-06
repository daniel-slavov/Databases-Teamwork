﻿using System;
using System.Collections.Generic;
using System.Linq;
using MoviesDatabase.Data.Contracts;
using MoviesDatabase.Factories;
using MoviesDatabase.Models;
using MoviesDatabase.Services.Contracts;

namespace MoviesDatabase.Services
{
    public class BookService : IBookService
    {
        private readonly IRepository<Book> bookRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IBookFactory bookFactory;

        public BookService(IRepository<Book> bookRepository, IUnitOfWork unitOfWork, IBookFactory bookFactory)
        {
            if (bookRepository == null)
            {
                throw new ArgumentNullException("Book repository cannot be null!");
            }

            if (bookFactory == null)
            {
                throw new ArgumentNullException("Book factory cannot be null!");
            }

            if (unitOfWork == null)
            {
                throw new ArgumentNullException("Unit of work cannot be null!");
            }

            this.bookRepository = bookRepository;
            this.unitOfWork = unitOfWork;
            this.bookFactory = bookFactory;
        }

        public void AddBooks(IList<Book> books)
        {
            foreach (var book in books)
            {
                this.bookRepository.Add(book);
            }

            this.unitOfWork.Commit();
        }

        public Book CreateBook(string title, string author, int? year)
        {
            var book = this.bookFactory.CreateBook(title, author, year);
            this.bookRepository.Add(book);
            this.unitOfWork.Commit();

            return book;
        }

        public Book GetBookByTitle(string title)
        {
            var book = this.bookRepository.Entities
                .FirstOrDefault(b => b.Title == title);

            return book;
        }

        public void UpdateBook(Book book)
        {
            this.bookRepository.Update(book);
            this.unitOfWork.Commit();
        }

        public void DeleteBook(string title)
        {
            var book = this.GetBookByTitle(title);

            if (book == null)
            {
                throw new NullReferenceException("There is no book with this title.");
            }

            this.bookRepository.Delete(book);
            this.unitOfWork.Commit();
        }
    }
}
