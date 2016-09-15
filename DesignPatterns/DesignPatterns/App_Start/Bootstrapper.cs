using DesignPatterns.Builders;
using DesignPatterns.Resizers;
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
            container.RegisterType<IResizedImageCreator, ResizedImageCreator>();

            container.RegisterType<ISmallImageResizer, SmallImageResizer>();
            container.RegisterType<IMediumImageResizer, MediumImageResizer>();
            container.RegisterType<ILargeImageResizer, LargeImageResizer>();

            container.RegisterType<IPictureBuilder, SmallPictureBuilder>("small");
            container.RegisterType<IPictureBuilder, MediumPictureBuilder>("medium");
            container.RegisterType<IPictureBuilder, LargePictureBuilder>("large");

            return container;
        }
    }
}