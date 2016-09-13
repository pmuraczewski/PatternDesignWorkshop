using DesignPatterns.Helpers;
using System.Drawing;
using System.Drawing.Imaging;

namespace DesignPatterns.ChainOfResponsibility
{
    public class BigImageResizer : ImageResizer
    {
        public override Bitmap ProcessImage(Bitmap image, ImageFormat format, int times)
        {
            if (image.GetSize() > 2000000 && image.GetSize() < 100000000)
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