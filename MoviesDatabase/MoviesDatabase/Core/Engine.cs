using System;
using System.Collections.Generic;
using MoviesDatabase.Commands.Contracts;
using MoviesDatabase.Core.Contracts;
using MoviesDatabase.Providers.Contracts;

namespace MoviesDatabase.Core
{
    public class Engine : IEngine
    {
        private const string TerminationCommand = "Exit";
        private const string NullProvidersExceptionMessage = "cannot be null.";

        private readonly IConsoleReader reader;
        private readonly IConsoleWriter writer;
        private readonly ICommandParser parser;
        private readonly IDatabaseProvider dbProvider;

        public Engine(IConsoleReader consoleReader, IConsoleWriter consoleWriter, ICommandParser commandParser, IDatabaseProvider databaseProvider)
        {
            this.reader = consoleReader ?? throw new ArgumentNullException($"Reader {NullProvidersExceptionMessage}");
            this.writer = consoleWriter ?? throw new ArgumentNullException($"Writer {NullProvidersExceptionMessage}");
            this.parser = commandParser ?? throw new ArgumentNullException($"Parser {NullProvidersExceptionMessage}");
            this.dbProvider = databaseProvider ?? throw new ArgumentNullException($"Databse provider {NullProvidersExceptionMessage}");
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
