using System;
using System.Linq;
using MoviesDatabase.Commands;
using MoviesDatabase.Commands.Contracts;
using MoviesDatabase.Core;
using MoviesDatabase.Core.Contracts;
using MoviesDatabase.Providers;
using MoviesDatabase.Providers.Contracts;
using Ninject;
using Ninject.Extensions.Factory;
using Ninject.Modules;

namespace MoviesDatabase
{
    public class MoviesDatabaseModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IEngine>().To<Engine>().InSingletonScope();

            //Bind<ICommand>().To<AddCommand>().Named("Add");
            //Bind<ICommand>().To<DeleteCommand>().Named("Delete");
            //Bind<ICommand>().To<UpdateCommand>().Named("Update");

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