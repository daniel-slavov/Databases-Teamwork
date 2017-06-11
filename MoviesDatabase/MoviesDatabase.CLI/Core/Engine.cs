﻿using System;
using System.Collections.Generic;
using MoviesDatabase.CLI.Commands.Contracts;
using MoviesDatabase.CLI.Core.Contracts;
using MoviesDatabase.CLI.Providers.Contracts;

namespace MoviesDatabase.CLI.Core
{
    public class Engine : IEngine
    {
        private const string TerminationCommand = "exit";
        private const string LogoutCommand = "logout";
        private const string HelpCommand = "help";

        private const string Help = @"Help:
    Commands:
        - Add - Adds a new movie in the database.
        - Delete Sample_Movie_Title - Deletes the movie from the database.
        - Exit - Closes the application.
        - GenerateReport ./folder/subfolder - Generates a report with all movies in the database and exports a PDF file in the provided location.
        - ImportJSON ./folder/sampleFile.json - Imports the provided JSON file in the database.
        - ImportXML ./folder/sampleFile.json - Imports the provided XML file in the database.
        - ListAll - Lists all movies in the console.
        - ListByGenre sampleGenre - Lists all movies with the provided genre in the console.
        - ListByStar FirstName_LastName - Lists all movies with the provided star in the console.
        - Login username password - Logs you in.
        - Logout - Logs you out.

All commands are case insensitive.
You should be logged in to use database functionalities.
";

        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly ICommandParser parser;

        private bool isLoggedIn = false;

        public Engine(IReader consoleReader, IWriter consoleWriter, ICommandParser commandParser)
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
            while (true)
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

                if (currentCommand.ToLower() == LogoutCommand)
                {
                    this.isLoggedIn = false;
                    this.writer.WriteLine("Logout successful.");
                    continue;
                }

                if (currentCommand.ToLower() == HelpCommand)
                {
                    this.writer.WriteLine(Help);
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
            if (this.isLoggedIn)
            {
                if (command.GetType().Name == "LoginCommand")
                {
                    this.writer.WriteLine("You are already logged in.");
                }
                else
                {
                    IList<string> parameters = this.parser.ParseParameters(fullCommand);
                    string executionResult = command.Execute(parameters);
                    this.writer.WriteLine(executionResult);
                }
            }
            else
            {
                if (command.GetType().Name == "LoginCommand")
                {
                    IList<string> parameters = this.parser.ParseParameters(fullCommand);
                    string executionResult = command.Execute(parameters);
                    if (executionResult == "Login successful.")
                    {
                        this.isLoggedIn = true;
                    }

                    this.writer.WriteLine(executionResult);
                }
                else
                {
                    this.writer.WriteLine("Plaese log in to use this command.");
                }
            }
        }
    }
}
