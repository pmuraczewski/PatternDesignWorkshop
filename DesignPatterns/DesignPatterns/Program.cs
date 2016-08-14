using DesignPatterns.App_Start;
using DesignPatterns.Factories;
using DesignPatterns.Helpers;
using DesignPatterns.Services;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var container = Bootstrapper.Initialise();
            var validationService = container.Resolve<IValidationService>();
            var resizePictureService = container.Resolve<IResizePictureService>();

            if(!validationService.IsArgumentValid(args))
            {
                Console.ReadKey();
                return;
            }

            resizePictureService.ReducePicture(args[0], 70, ImageFormat.Png, InterpolationType.Primitive);

            Console.ReadKey();
        }
    }
}
