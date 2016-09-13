using DesignPatterns.Helpers;
using System.Drawing;
using System.Drawing.Imaging;

namespace DesignPatterns.ChainOfResponsibility
{
    public class ClassicResizer : ImageResizer
    {
        public override Bitmap ProcessImage(Bitmap image, ImageFormat format, int times)
        {
            if ((format == ImageFormat.Jpeg || format == ImageFormat.Bmp || format == ImageFormat.Png) && image.GetSize() > 2000 && image.GetSize() < 2000000) 
            {
                return ReduceImage(image, format, times);
            }
            else if (successor != null)
            {
                return successor.ProcessImage(image, format, times);
            }

            return null;
        }

        private Bitmap ReduceImage(Bitmap image, ImageFormat format, int times)
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