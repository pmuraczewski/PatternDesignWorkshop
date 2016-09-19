using DesignPatterns.Services;
using Microsoft.Practices.Unity;

namespace DesignPatterns
{
    public static class Bootstrapper
    {
        public static IUnityContainer Initialise()
        {
            var container = new UnityContainer();
            container.RegisterType<IFileService, FileService>();
            container.RegisterType<IValidationService, ValidationService>();
            container.RegisterType<IResizePictureService, ResizePictureService>();

            return container;
        }
    }
}