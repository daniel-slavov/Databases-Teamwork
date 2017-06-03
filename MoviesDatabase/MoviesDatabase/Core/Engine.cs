using System;
using System.Collections.Generic;
using MoviesDatabase.CLI.Commands.Contracts;
using MoviesDatabase.CLI.Core.Contracts;
using MoviesDatabase.CLI.Providers.Contracts;

namespace MoviesDatabase.CLI.Core
{
    public class Engine : IEngine
    {
        private const string TerminationCommand = "Exit";

        private readonly IConsoleReader reader;
        private readonly IConsoleWriter writer;
        private readonly ICommandParser parser;

        public Engine(IConsoleReader consoleReader, IConsoleWriter consoleWriter, ICommandParser commandParser, IDatabaseProvider databaseProvider)
        {
            if (consoleReader == null)
            {
                throw new ArgumentNullException("Reader cannot be null.");
            }

            if (consoleWriter == null)
			{
                throw new ArgumentNullException("Writer cannot be null.");
			}

            if (commandParser == null)
			{
                throw new ArgumentNullException("Parser cannot be null.");
			}

            this.reader = consoleReader;
            this.writer = consoleWriter;
            this.parser = commandParser;
		}

        public void Start()
        {
            while(true)
            {
                string currentCommand = this.reader.ReadLine();

                if (currentCommand == TerminationCommand)
                {
                    break;
                }

                if (string.IsNullOrWhiteSpace(currentCommand))
                {
                    continue;
                }

                try
                {
                    this.ProcessCommand(currentCommand);
                }
                catch (Exception exception)
                {
                    this.writer.WriteLine(exception.Message);
                }
            }
        }

        private void ProcessCommand(string fullCommand)
        {
            ICommand command = this.parser.ParseCommand(fullCommand);
            IList<string> parameters = this.parser.ParseParameters(fullCommand);
            string executionResult = command.Execute(parameters);
            this.writer.WriteLine(executionResult);
        }
    }
}
