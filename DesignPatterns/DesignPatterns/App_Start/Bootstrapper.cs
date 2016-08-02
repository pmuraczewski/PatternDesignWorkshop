using DesignPatterns.Services;
using Microsoft.Practices.Unity;

namespace DesignPatterns.App_Start
{
    public static class Bootstrapper
    {
        public static IUnityContainer Initialise()
        {
            var container = new UnityContainer();
            container.RegisterType<IFileService, FileService>();

            return container;
        }
    }
}