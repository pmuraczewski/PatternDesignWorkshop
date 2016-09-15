using DesignPatterns.Services;
using System.Drawing;

namespace DesignPatterns.Resizers
{
    public class MediumImageResizer : IMediumImageResizer
    {
        private IFileService fileService;

        public MediumImageResizer(IFileService fileService)
        {
            this.fileService = fileService;
        }

        public Bitmap ResizeImage()
        {
            var filePath = "obrazek.jpg";
            var times = 25;
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

            using (var graphic = Graphics.FromImage(result))
            {
                graphic.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Bicubic;

                graphic.DrawImage(image, new Rectangle(Point.Empty, result.Size));
            }

            return result;
        }
    }
}
