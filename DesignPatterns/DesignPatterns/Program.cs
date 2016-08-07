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
        public static void Main()
        {
            var context = new ResizePictureContext();

            IResizeStrategy strategy = new PrimitiveResamplingStrategy();
            ////IResizeStrategy strategy = new AverageDownsamplingStrategy();
            
            context.SetStrategy(strategy);
            context.ReducePicture(@"D:\Projekty\PatternDesignWorkshop\DesignPatterns\DesignPatterns\bin\Debug\obrazek.jpg", 4, ImageFormat.Png);

            Console.ReadKey();
        }
    }
}
