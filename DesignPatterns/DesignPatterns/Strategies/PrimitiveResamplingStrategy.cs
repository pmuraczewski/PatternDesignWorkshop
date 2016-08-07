using DesignPatterns.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Strategies
{
    public class PrimitiveResamplingStrategy : IResizeStrategy
    {
        public Bitmap ReduceImage(Bitmap image, int times)
        {
            var width = image.Width;
            var height = image.Height;

            var newWidth = width/times;
            var newHeight = height/times;

            var result = new Bitmap(newWidth, newHeight);

            for (int i = 0; i < newWidth; i++)
            {
                for (int j = 0; j < newHeight; j++)
                {
                    var horizontalIndex = i * times;
                    var verticalIndex = j * times;

                    var pixel = image.GetPixel(horizontalIndex, verticalIndex);
                    result.SetPixel(i, j, pixel);
                }
            }

            return result;
        }
    }
}
