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
            var resizePictureService = container.Resolve<IResizePictureService>();

            if(!validationService.IsArgumentValid(args))
            {
                Console.ReadKey();
                return;
            }

////            resizePictureService.SetStrategy(new PrimitiveResamplingStrategy());
            resizePictureService.SetStrategy(new BicubicDownsamplingStrategy());
            ////resizePictureService.SetStrategy(new AverageDownsamplingStrategy());
            resizePictureService.ReducePicture(args[0], 40, ImageFormat.Png);

            Console.ReadKey();
        }
    }
}
