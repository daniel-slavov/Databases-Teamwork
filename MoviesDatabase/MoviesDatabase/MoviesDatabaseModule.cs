using System;
using System.Linq;
using MoviesDatabase.CLI.Commands;
using MoviesDatabase.CLI.Commands.Contracts;
using MoviesDatabase.CLI.Core;
using MoviesDatabase.CLI.Core.Contracts;
using MoviesDatabase.CLI.Providers;
using MoviesDatabase.CLI.Providers.Contracts;
using Ninject;
using Ninject.Extensions.Factory;
using Ninject.Modules;
using Ninject.Extensions.Conventions;
using System.IO;
using System.Reflection;

namespace MoviesDatabase.CLI
{
    public class MoviesDatabaseModule : NinjectModule
    {
        public override void Load()
        {
			Bind<IEngine>().To<Engine>().InSingletonScope();

            Bind<AddCommand>().ToSelf().InSingletonScope();
            Bind<DeleteCommand>().ToSelf().InSingletonScope();
            Bind<UpdateCommand>().ToSelf().InSingletonScope();

			Bind<IConsoleReader>().To<ConsoleReader>().InSingletonScope();
            Bind<IConsoleWriter>().To<ConsoleWriter>().InSingletonScope();
            Bind<ICommandParser>().To<CommandParser>().InSingletonScope();
            Bind<IDatabaseProvider>().To<DatabaseProvider>().InSingletonScope();

            Bind<ICommandFactory>().ToFactory().InSingletonScope();

			Bind<ICommand>().ToMethod(context =>
			{
				Type commandType = (Type)context.Parameters.Single().GetValue(context, null);
				return (ICommand)context.Kernel.Get(commandType);
			}).NamedLikeFactoryMethod((ICommandFactory commandFactory) => commandFactory.GetCommand(null));
        }
    }
}