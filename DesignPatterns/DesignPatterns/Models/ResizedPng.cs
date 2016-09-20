using DesignPatterns.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Models
{
    public class ResizedPng : IResizedImage
    {
        private IFileService fileService;

        public ResizedPng(IFileService fileService)
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

                    var pixel = AverageNeighboringPixels(image, horizontalIndex, verticalIndex, times);

                    result.SetPixel(i, j, pixel);
                }
            }

            return result;
        }

        private Color AverageNeighboringPixels(Bitmap image, int startHorizontalIndex, int startVerticalIndex, int times)
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

        private string GetReducedImagePath(string path, int times, ImageFormat format)
        {
            var originalFileName = fileService.GetFileNameWithoutExtension(path);
            var originalFileDirectory = fileService.GetFolderPath(path);

            return string.Format("{0}{1}-{2}-times.{3}", originalFileDirectory, originalFileName, times, format.ToString().ToLower());
        }
    }
}