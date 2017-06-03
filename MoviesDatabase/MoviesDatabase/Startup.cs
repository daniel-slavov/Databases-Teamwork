using System;
using MoviesDatabase.CLI.Core.Contracts;
using Ninject;

namespace MoviesDatabase.CLI
{
    public class MainClass
    {
        public static void Main()
        {
            IKernel kernel = new StandardKernel(new MoviesDatabaseModule());

            IEngine engine = kernel.Get<IEngine>();
            engine.Start();
        }
    }
}
