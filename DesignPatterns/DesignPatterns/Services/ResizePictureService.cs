using DesignPatterns.ChainOfResponsibility;
using System.Collections.Generic;
using System.Drawing.Imaging;

namespace DesignPatterns.Services
{
    public class ResizePictureService : IResizePictureService
    {
        private IFileService fileService;

        public ResizePictureService(IFileService fileService)
        {
            this.fileService = fileService;
        }

        public void ReducePictures(IList<string> paths, int times)
        {
            var resizer = InitializeChainOfResponsibility();

            foreach (var path in paths)
            {
                var originalImage = this.fileService.GetImageAsBitmap(path);
                var imageFormat = fileService.GetImageFormatFromPath(path);

                var reducedImage = resizer.ProcessImage(originalImage, imageFormat, times);

                var reducedImagePath = this.GetReducedImagePath(path, times, imageFormat);
                fileService.SaveBitmapToFile(reducedImagePath, reducedImage, imageFormat);
            }
        }

        private ImageResizer InitializeChainOfResponsibility()
        {
            ImageResizer classicResizer = new ClassicResizer();
            ImageResizer smallBitmapResizer = new SmallBitmapResizer();
            ImageResizer bigImageResizer = new BigImageResizer();

            classicResizer.SetSuccessor(smallBitmapResizer);
            smallBitmapResizer.SetSuccessor(bigImageResizer);

            return classicResizer;
        }

        private string GetReducedImagePath(string path, int times, ImageFormat format)
        {
            var originalFileName = fileService.GetFileNameWithoutExtension(path);
            var originalFileDirectory = fileService.GetFolderPath(path);

            return string.Format("{0}{1}-{2}-times.{3}", originalFileDirectory, originalFileName, times, format.ToString().ToLower());
        }
    }
}