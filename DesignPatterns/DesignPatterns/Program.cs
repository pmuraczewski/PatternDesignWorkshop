using DesignPatterns.App_Start;
using DesignPatterns.Helpers;
using DesignPatterns.Services;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;

namespace DesignPatterns
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var picturesPath = new List<string>
            {
                @"D:\Projekty\PatternDesignWorkshop\DesignPatterns\DesignPatterns\bin\Debug\obrazek.jpg",
                @"D:\Projekty\PatternDesignWorkshop\DesignPatterns\DesignPatterns\bin\Debug\obrazek3.bmp"
            };

            var container = Bootstrapper.Initialise();
            var resizePictureService = container.Resolve<IResizePictureService>();

            resizePictureService.ReducePicture(picturesPath, 5);

            Console.ReadKey();
        }
    }
}
