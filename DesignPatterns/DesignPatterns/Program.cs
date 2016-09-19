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

            ////IResizeStrategy strategy = new PrimitiveResamplingStrategy();
            ////IResizeStrategy strategy = new AverageDownsamplingStrategy();
            IResizeStrategy strategy = new BicubicDownsamplingStrategy();

            resizePictureService.SetStrategy(strategy);
            resizePictureService.ReducePicture(args[0], 40, ImageFormat.Png);

            Console.ReadKey();
        }
    }
}
