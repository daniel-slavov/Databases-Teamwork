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
using MoviesDatabase.Services.Contracts;
using MoviesDatabase.Services;
using MoviesDatabase.Parsers.Contracts;
using MoviesDatabase.Parsers;
using MoviesDatabase.Factories;
using MoviesDatabase.Data.Contracts;
using MoviesDatabase.Data;
using System.Data.Entity;
using MoviesDatabase.Models;
using MoviesDatabase.PostgreSQL;

namespace MoviesDatabase.CLI
{
    public class MoviesDatabaseModule : NinjectModule
    {
        public override void Load()
        {
			Bind<IEngine>().To<Engine>().InSingletonScope();

            //Bind<AddCommand>().ToSelf().InSingletonScope();
            //Bind<DeleteCommand>().ToSelf().InSingletonScope();
            //Bind<UpdateCommand>().ToSelf().InSingletonScope();

			Bind<IReader>().To<ConsoleReader>().InSingletonScope();
            Bind<IWriter>().To<ConsoleWriter>().InSingletonScope();
            Bind<ICommandParser>().To<CommandParser>().InSingletonScope();

            Bind<IJSONParser>().To<JSONParser>();
            Bind<IXMLParser>().To<XMLParser>();

			Bind<IMovieService>().To<MovieService>();
            Bind<IProducerService>().To<ProducerService>();
            Bind<IBookService>().To<BookService>();
            Bind<IGenreService>().To<GenreService>();
            Bind<IStarService>().To<StarService>();
            Bind<IStudioService>().To<StudioService>();
            Bind<IUserService>().To<UserService>();

			Bind<ICommandFactory>().ToFactory().InSingletonScope();

			Bind<ICommand>().ToMethod(context =>
			{
				Type commandType = (Type)context.Parameters.Single().GetValue(context, null);
				return (ICommand)context.Kernel.Get(commandType);
			}).NamedLikeFactoryMethod((ICommandFactory commandFactory) => commandFactory.GetCommand(null));

            Bind(typeof(IRepository<>)).To(typeof(Repository<>));
            Bind<IUnitOfWork>().To<UnitOfWork>();
            Bind<DbContext>().To<UsersDbContext>().WhenInjectedInto<Repository<User>>();
            Bind<DbContext>().To<MoviesDbContext>().InThreadScope(); // DON'T CHANGE it!!!


            Bind<IBookFactory>().ToFactory().InSingletonScope();
            Bind<IGenreFactory>().ToFactory().InSingletonScope();
            Bind<IMovieFactory>().ToFactory().InSingletonScope();
            Bind<IProducerFactory>().ToFactory().InSingletonScope();
            Bind<IStarFactory>().ToFactory().InSingletonScope();
            Bind<IStudioFactory>().ToFactory().InSingletonScope(); 
        }
    }
}