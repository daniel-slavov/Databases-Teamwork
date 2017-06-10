using Ninject;
using MoviesDatabase.CLI.Core.Contracts;

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
