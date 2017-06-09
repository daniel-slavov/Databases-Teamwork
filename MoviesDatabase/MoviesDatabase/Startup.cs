using System;
using MoviesDatabase.CLI.Core.Contracts;
using MoviesDatabase.Parsers;
using MoviesDatabase.Parsers.Models;
using Ninject;
using MoviesDatabase.PostgreSQL;
using System.Linq;

namespace MoviesDatabase.CLI
{
    public class Startup
    {
        public static void Main()
        {
            IKernel kernel = new StandardKernel(new MoviesDatabaseModule());

            IEngine engine = kernel.Get<IEngine>();
            engine.Start();
        }
    }
}
