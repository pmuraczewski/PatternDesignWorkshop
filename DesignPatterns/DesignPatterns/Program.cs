using DesignPatterns.App_Start;
using DesignPatterns.Services;
using DesignPatterns.Strategies;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
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

            if(!validationService.IsArgumentValid(args))
            {
                Console.ReadKey();
                return;
            }

            var context = new ResizePictureContext();
            context.SetStrategy(new PrimitiveAverageStrategy());
            context.ReducePicture(args[0], 3);

            Console.ReadKey();
        }
    }
}
