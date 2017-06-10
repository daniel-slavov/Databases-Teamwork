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

		private const string Help = @"Help:"; // to be filled

        private readonly IConsoleReader reader;
        private readonly IConsoleWriter writer;
        private readonly ICommandParser parser;

        private bool isLoggedIn = false;

        public Engine(IConsoleReader consoleReader, IConsoleWriter consoleWriter, ICommandParser commandParser)
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

                if (currentCommand.ToLower() == LogoutCommand)
                {
                    isLoggedIn = false;
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
            if (isLoggedIn)
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
                        isLoggedIn = true;
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
