using System;
using System.Linq;
using System.Data.Entity;
using MoviesDatabase.CLI.Commands.Contracts;
using MoviesDatabase.CLI.Core;
using MoviesDatabase.CLI.Core.Contracts;
using MoviesDatabase.CLI.Providers;
using MoviesDatabase.CLI.Providers.Contracts;
using Ninject;
using Ninject.Extensions.Factory;
using Ninject.Modules;
using MoviesDatabase.Services.Contracts;
using MoviesDatabase.Services;
using MoviesDatabase.Parsers.Contracts;
using MoviesDatabase.Parsers;
using MoviesDatabase.Factories;
using MoviesDatabase.Data.Contracts;
using MoviesDatabase.Data;
using MoviesDatabase.Models;
using MoviesDatabase.PostgreSQL;

namespace MoviesDatabase.CLI
{
    public class MoviesDatabaseModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IEngine>().To<Engine>().InSingletonScope();

            this.Bind<IReader>().To<ConsoleReader>().InSingletonScope();
            this.Bind<IWriter>().To<ConsoleWriter>().InSingletonScope();
            this.Bind<ICommandParser>().To<CommandParser>().InSingletonScope();

            this.Bind<IJSONParser>().To<JSONParser>();
            this.Bind<IXMLParser>().To<XMLParser>();

            this.Bind<IMovieService>().To<MovieService>();
            this.Bind<IProducerService>().To<ProducerService>();
            this.Bind<IBookService>().To<BookService>();
            this.Bind<IGenreService>().To<GenreService>();
            this.Bind<IStarService>().To<StarService>();
            this.Bind<IStudioService>().To<StudioService>();
            this.Bind<IUserService>().To<UserService>();

            this.Bind<ICommandFactory>().ToFactory().InSingletonScope();

            this.Bind<ICommand>().ToMethod(context =>
            {
                Type commandType = (Type)context.Parameters.Single().GetValue(context, null);
                return (ICommand)context.Kernel.Get(commandType);
            }).NamedLikeFactoryMethod((ICommandFactory commandFactory) => commandFactory.GetCommand(null));

            this.Bind(typeof(IRepository<>)).To(typeof(Repository<>));
            this.Bind<IUnitOfWork>().To<UnitOfWork>();
            this.Bind<DbContext>().To<UsersDbContext>().WhenInjectedInto<Repository<User>>();
            this.Bind<DbContext>().To<MoviesDbContext>().InThreadScope(); // DON'T CHANGE it!!!

            this.Bind<IBookFactory>().ToFactory().InSingletonScope();
            this.Bind<IGenreFactory>().ToFactory().InSingletonScope();
            this.Bind<IMovieFactory>().ToFactory().InSingletonScope();
            this.Bind<IProducerFactory>().ToFactory().InSingletonScope();
            this.Bind<IStarFactory>().ToFactory().InSingletonScope();
            this.Bind<IStudioFactory>().ToFactory().InSingletonScope();
        }
    }
}