using DesignPatterns.Strategies;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Services
{
    public class ResizePictureService : IResizePictureService
    {
        private IResizeStrategy resizeStrategy;
        private IFileService fileService;

        public void SetStrategy(IResizeStrategy resizeStrategy)
        {
            this.resizeStrategy = resizeStrategy;
            this.fileService = new FileService();
        }

        public void ReducePicture(string path, int times, ImageFormat format)
        {
            var image = fileService.GetImageAsBitmap(path);
            var reducedImage = this.resizeStrategy.ReduceImage(image, times);
            var reducedImagePath = this.GetReducedImagePath(path, times, format);

            fileService.SaveBitmapToFile(reducedImagePath, reducedImage, format);
        }

        private string GetReducedImagePath(string path, int times, ImageFormat format)
        {
            var originalFileName = fileService.GetFileNameWithoutExtension(path);
            var originalFileDirectory = fileService.GetFolderPath(path);

            return string.Format("{0}{1}-{2}-times.{3}", originalFileDirectory, originalFileName, times, format.ToString().ToLower());
        }
    }
}