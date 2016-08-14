using DesignPatterns.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Strategies
{
    public class BicubicDownsamplingStrategy : IResizeStrategy
    {
        public Bitmap ReduceImage(Bitmap image, int times)
        {
            var originalWidth = image.Width;
            var originalHeight = image.Height;

            var newWidth = originalWidth / times;
            var newHeight = originalHeight / times;

            var result = new Bitmap(newWidth, newHeight);

            using (var graphic = Graphics.FromImage(result))
            {
                graphic.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Bicubic;

                graphic.DrawImage(image, new Rectangle(Point.Empty, result.Size));
            }

            return result;
        }
    }
}
