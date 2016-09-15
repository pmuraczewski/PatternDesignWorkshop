using DesignPatterns.Services;
using System.Drawing;

namespace DesignPatterns.Resizers
{
    public class LargeImageResizer : ILargeImageResizer
    {
        private IFileService fileService;

        public LargeImageResizer(IFileService fileService)
        {
            this.fileService = fileService;
        }

        public Bitmap ResizeImage()
        {
            var filePath = "obrazek.jpg";
            var times = 3;
            var image = this.fileService.GetImageAsBitmap(filePath);

            return ReduceImage(image, times);
        }

        private Bitmap ReduceImage(Bitmap image, int times)
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
