using DesignPatterns.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Strategies
{
    public class AverageDownsamplingStrategy : IResizeStrategy
    {
        public Bitmap ReduceImage(Bitmap image, int times)
        {
            var width = image.Width;
            var height = image.Height;

            var newWidth = width / times;
            var newHeight = height / times;

            var result = new Bitmap(newWidth, newHeight);

            for (int i = 0; i < newWidth; i++)
            {
                for (int j = 0; j < newHeight; j++)
                {
                    var horizontalIndex = i * times;
                    var verticalIndex = j * times;

                    var pixel = AverageNeighboringPixels(image, horizontalIndex, newWidth, verticalIndex, newHeight, times);

                    result.SetPixel(i, j, pixel);
                }
            }

            return result;
        }

        private Color AverageNeighboringPixels(Bitmap image, int startHorizontalIndex, int horizontalMax, int startVerticalIndex, int verticalMax, int times)
        {
            var endHorizontalIndex = startHorizontalIndex + times;
            var endVerticalIndex = startVerticalIndex + times;
            var Avalues = new List<byte>();
            var Rvalues = new List<byte>();
            var Gvalues = new List<byte>();
            var Bvalues = new List<byte>();

            for (int x = startHorizontalIndex; x < endHorizontalIndex; x++)
            {
                for (int y = startVerticalIndex; y < endVerticalIndex; y++)
                {
                    var pixel = image.GetPixel(x, y);

                    Avalues.Add(pixel.A);
                    Rvalues.Add(pixel.R);
                    Gvalues.Add(pixel.G);
                    Bvalues.Add(pixel.B);
                }
            }

            var Aaverage = (int)Avalues.Average(i => i);
            var Raverage = (int)Rvalues.Average(i => i);
            var Gaverage = (int)Gvalues.Average(i => i);
            var Baverage = (int)Bvalues.Average(i => i);

            var newPixel = Color.FromArgb(Aaverage, Raverage, Gaverage, Baverage);

            return newPixel;
        }
    }
}
