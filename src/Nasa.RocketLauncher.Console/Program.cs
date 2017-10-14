using SimpleInjector;
using Nasa.RocketLauncher.Common.Src;

namespace Nasa.RocketLauncher.Application
{
    static class Program
    {
        static readonly Container container;

        /// <summary>
        /// Default constructor used to configure DI
        /// </summary>
        static Program()
        {
            //Inject dependencies
            container = DependencyInjection.Configure();
            container.Register<CommandCentre>();
            //Verify container
            container.Verify();
        }

        /// <summary>
        /// Main method/Entry point
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            var CommandCentre = container.GetInstance<CommandCentre>();
            CommandCentre.Start();
        }

    }
}
