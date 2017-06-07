using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using MoviesDatabase.CLI.Commands.Contracts;
using MoviesDatabase.CLI.Providers.Contracts;
using MoviesDatabase.Models;
using MoviesDatabase.Services.Contracts;

namespace MoviesDatabase.CLI.Commands
{
    public class UpdateCommand : ICommand
    {
        private readonly IStudioService StudioService;
		private readonly IStarService StarService;
		private readonly IBookService BookService;

        public UpdateCommand(IStudioService studioService, IStarService starService, IBookService bookService)
        {
            this.StudioService = studioService;
			this.StarService = starService;
			this.BookService = bookService;
        }

        public string Execute(IList<string> parameters)
        {
			string type = parameters[0];

            parameters.RemoveAt(0);

			switch (type.ToLower())
			{
				case "star":
					string firstName = parameters[1];
					string lastName = parameters[2];

					parameters.RemoveAt(0);
					parameters.RemoveAt(0);

					Star currentStar = this.StarService.GetStarByName(firstName, lastName);

                    foreach (string parameter in parameters)
                    {
                        KeyValuePair<string, string> update = new KeyValuePair<string, string>(parameter.Split(':')[0], parameter.Split(':')[1]);

                        PropertyInfo propertyInfo = currentStar.GetType().GetProperty(update.Key);
                        propertyInfo.SetValue(currentStar, Convert.ChangeType(update.Value, propertyInfo.PropertyType),null);
                    }

                    this.StarService.UpdateStar(currentStar);

					break;
				case "book":
                    string bookName = parameters[1];

                    parameters.RemoveAt(0);

                    Book currentBook = this.BookService.GetBookByTitle(bookName);

					foreach (string parameter in parameters)
					{
						KeyValuePair<string, string> update = new KeyValuePair<string, string>(parameter.Split(':')[0], parameter.Split(':')[1]);

						PropertyInfo propertyInfo = currentBook.GetType().GetProperty(update.Key);
						propertyInfo.SetValue(currentBook, Convert.ChangeType(update.Value, propertyInfo.PropertyType), null);
					}

                    this.BookService.UpdateBook(currentBook);

					break;
				case "studio":
					string studioName = parameters[1];

					parameters.RemoveAt(0);

                    Studio currentStudio = this.StudioService.GetStudioByName(studioName);

					foreach (string parameter in parameters)
					{
						KeyValuePair<string, string> update = new KeyValuePair<string, string>(parameter.Split(':')[0], parameter.Split(':')[1]);

						PropertyInfo propertyInfo = currentStudio.GetType().GetProperty(update.Key);
						propertyInfo.SetValue(currentStudio, Convert.ChangeType(update.Value, propertyInfo.PropertyType), null);
					}

                    this.StudioService.UpdateStudio(currentStudio);

					break;
				default:
					break;
			}
            return $"{type} updated successfully.";
        }
    }
}

//Update Star Ivan Ivanov age:20 address:Sofia