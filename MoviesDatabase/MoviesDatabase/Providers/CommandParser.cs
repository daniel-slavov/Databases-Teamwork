using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using MoviesDatabase.CLI.Commands.Contracts;
using MoviesDatabase.CLI.Core.Contracts;
using MoviesDatabase.CLI.Providers.Contracts;

namespace MoviesDatabase.CLI.Providers
{
    public class CommandParser : ICommandParser
    {
		private readonly ICommandFactory commandFactory;

		public CommandParser(ICommandFactory commandFactory)
		{
			this.commandFactory = commandFactory;
		}

		public ICommand ParseCommand(string fullCommand)
		{
			string commandName = fullCommand.Split(' ')[0] + "Command";
            TypeInfo commandTypeInfo = this.FindCommand(commandName);
            ICommand command = this.commandFactory.GetCommand(commandTypeInfo);

			return command;
		}

		public IList<string> ParseParameters(string fullCommand)
		{
            IList<string> commandParts = fullCommand.Split(' ').ToList();
			commandParts.RemoveAt(0);

			if (commandParts.Count() == 0)
			{
				return null;
			}

			return commandParts;
		}

		private TypeInfo FindCommand(string commandName)
		{
            Assembly currentAssembly = this.GetType().GetTypeInfo().Assembly;
            TypeInfo commandTypeInfo = currentAssembly.DefinedTypes
				.Where(type => type.ImplementedInterfaces.Any(inter => inter == typeof(ICommand)))
                .Where(type => type.Name.ToLower().Contains(commandName.ToLower()))
				.SingleOrDefault();

			if (commandTypeInfo == null)
			{
				throw new ArgumentException("Command is not found!");
			}

			return commandTypeInfo;
		}
    }
}
