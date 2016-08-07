using DesignPatterns.App_Start;
using DesignPatterns.Services;
using DesignPatterns.Strategies;
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
            var fileService = container.Resolve<IFileService>();

            if(!validationService.IsArgumentValid(args))
            {
                Console.ReadKey();
                return;
            }

            var context = new ResizePictureContext();
////            context.SetStrategy(new PrimitiveResamplingStrategy(), fileService);
            context.SetStrategy(new AverageDownsamplingStrategy(), fileService);
            context.ReducePicture(args[0], 4, ImageFormat.Png);

            Console.ReadKey();
        }
    }
}
