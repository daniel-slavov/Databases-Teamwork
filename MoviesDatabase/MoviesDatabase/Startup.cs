using System;
using MoviesDatabase.Core.Contracts;
using Ninject;

namespace MoviesDatabase
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
