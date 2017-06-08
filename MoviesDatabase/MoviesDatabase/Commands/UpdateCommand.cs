using System;
using System.Collections.Generic;
using System.Reflection;
using MoviesDatabase.CLI.Commands.Contracts;
using MoviesDatabase.Models;
using MoviesDatabase.Services.Contracts;

namespace MoviesDatabase.CLI.Commands
{
    public class UpdateCommand : ICommand
    {
		private readonly IBookService BookService;
		private readonly IStarService StarService;
		private readonly IStudioService StudioService;

        public UpdateCommand(IBookService bookService, IStarService starService, IStudioService studioService)
        {
			if (bookService == null)
			{
				throw new ArgumentNullException("Book service cannot be null.");
			}

			if (starService == null)
			{
				throw new ArgumentNullException("Star service cannot be null.");
			}

			if (studioService == null)
			{
				throw new ArgumentNullException("Studio service cannot be null.");
			}

			this.BookService = bookService;
			this.StarService = starService;
			this.StudioService = studioService;
        }

        public string Execute(IList<string> parameters)
        {
            string model = parameters[0];

            parameters.RemoveAt(0);

			switch (model.ToLower())
			{
				case "book":
					string bookName = parameters[0];

					parameters.RemoveAt(0);

					Book currentBook = this.BookService.GetBookByTitle(bookName);

				    if (currentBook == null)
				    {
				        return "There is not such book in database.";
				    }

					foreach (string parameter in parameters)
					{
						KeyValuePair<string, string> update = new KeyValuePair<string, string>(parameter.Split(':')[0], parameter.Split(':')[1]);

						PropertyInfo propertyInfo = currentBook.GetType().GetProperty(update.Key);
                        propertyInfo.SetValue(currentBook, Convert.ChangeType(update.Value, (propertyInfo.PropertyType.IsGenericType && propertyInfo.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>)) ? (Nullable.GetUnderlyingType(propertyInfo.PropertyType)) : (propertyInfo.PropertyType)), null);
					}

					this.BookService.UpdateBook(currentBook);

					return $"Book {bookName} was updated successfully.";
				case "star":
					string firstName = parameters[0];
					string lastName = parameters[1];

					parameters.RemoveAt(0);
					parameters.RemoveAt(0);

					Star currentStar = this.StarService.GetStarByName(firstName, lastName);
				    if (currentStar == null)
				    {
				        return "There is not such star in database.";
				    }

                    foreach (string parameter in parameters)
                    {
                        KeyValuePair<string, string> update = new KeyValuePair<string, string>(parameter.Split(':')[0], parameter.Split(':')[1]);

                        PropertyInfo propertyInfo = currentStar.GetType().GetProperty(update.Key);
                        propertyInfo.SetValue(currentStar, Convert.ChangeType(update.Value, (propertyInfo.PropertyType.IsGenericType && propertyInfo.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>)) ? (Nullable.GetUnderlyingType(propertyInfo.PropertyType)) : (propertyInfo.PropertyType)),null);
                    }

                    this.StarService.UpdateStar(currentStar);

                    return $"Star {firstName} {lastName} was updated successfully.";
				case "studio":
					string studioName = parameters[0];

					parameters.RemoveAt(0);

                    Studio currentStudio = this.StudioService.GetStudioByName(studioName);
				    if (currentStudio == null)
				    {
				        return "There is not such studio in database.";
				    }

                    foreach (string parameter in parameters)
					{
						KeyValuePair<string, string> update = new KeyValuePair<string, string>(parameter.Split(':')[0], parameter.Split(':')[1]);

						PropertyInfo propertyInfo = currentStudio.GetType().GetProperty(update.Key);
						propertyInfo.SetValue(currentStudio, Convert.ChangeType(update.Value, (propertyInfo.PropertyType.IsGenericType && propertyInfo.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>)) ? (Nullable.GetUnderlyingType(propertyInfo.PropertyType)) : (propertyInfo.PropertyType)), null);
					}

                    this.StudioService.UpdateStudio(currentStudio);

                    return $"Studio {studioName} was updated successfully.";
				default:
                    throw new ArgumentException($"Model {model} cannot be updated.");
			}
        }
    }
}
// Sample command:
// Update Star Ivan Ivanov age:20 address:Sofia