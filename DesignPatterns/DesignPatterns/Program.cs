using DesignPatterns.Builders;
using DesignPatterns.Resizers;
using DesignPatterns.Services;
using Microsoft.Practices.Unity;
using System;

namespace DesignPatterns
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var container = Bootstrapper.Initialise();
            var fileService = container.Resolve<IFileService>();
            var resizedImageCreator = container.Resolve<IResizedImageCreator>();

            var pictureBuilder = container.Resolve<IPictureBuilder>("large");
            
            var resizedImage = resizedImageCreator.Construct(pictureBuilder);

            fileService.SaveBitmapToFile(resizedImage.fileName, resizedImage.content, resizedImage.imageFormat);

            Console.ReadKey();
        }
    }
}