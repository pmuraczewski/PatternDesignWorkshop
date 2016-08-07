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
            var resizePictureService = new ResizePictureService();

            IResizeStrategy strategy = new PrimitiveResamplingStrategy();
            ////IResizeStrategy strategy = new AverageDownsamplingStrategy();

            resizePictureService.SetStrategy(strategy);
            resizePictureService.ReducePicture(@"D:\Projekty\PatternDesignWorkshop\DesignPatterns\DesignPatterns\bin\Debug\obrazek.jpg", 4, ImageFormat.Png);

            Console.ReadKey();
        }
    }
}
