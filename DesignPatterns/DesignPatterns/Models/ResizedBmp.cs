using DesignPatterns.Services;
using System.Drawing;
using System.Drawing.Imaging;

namespace DesignPatterns.Models
{
    public class ResizedBmp : IResizedImage
    {
        private IFileService fileService;

        public ResizedBmp(IFileService fileService)
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

            using (var graphic = Graphics.FromImage(result))
            {
                graphic.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Bicubic;

                graphic.DrawImage(image, new Rectangle(Point.Empty, result.Size));
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