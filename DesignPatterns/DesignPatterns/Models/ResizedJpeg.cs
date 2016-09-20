using DesignPatterns.Services;
using System.Drawing;
using System.Drawing.Imaging;

namespace DesignPatterns.Models
{
    public class ResizedJpeg : IResizedImage
    {
        private IFileService fileService;

        public ResizedJpeg(IFileService fileService)
        {
            this.fileService = fileService;
        }

        public void SaveResizedImageToFile(string path, int times, ImageFormat imageFormat)
        {
            var originalImage = this.fileService.GetImageAsBitmap(path);
            var reducedImage = ReduceImage(originalImage, times);
            var reducedImagePath = GetReducedImagePath(path, times, imageFormat);

            this.fileService.SaveBitmapToFile(reducedImagePath, reducedImage, imageFormat);
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

        private string GetReducedImagePath(string path, int times, ImageFormat format)
        {
            var originalFileName = fileService.GetFileNameWithoutExtension(path);
            var originalFileDirectory = fileService.GetFolderPath(path);

            return string.Format("{0}{1}-{2}-times.{3}", originalFileDirectory, originalFileName, times, format.ToString().ToLower());
        }
    }
}