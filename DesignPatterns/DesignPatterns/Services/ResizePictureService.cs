using DesignPatterns.Factories;
using DesignPatterns.Helpers;
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
        private IFileService fileService;
        private IResizedImageFactory imageFactory;

        public ResizePictureService(IFileService fileService, IResizedImageFactory imageFactory)
        {
            this.fileService = fileService;
            this.imageFactory = imageFactory;
        }

        public void ReducePicture(string path, int times, ImageFormat format, InterpolationType type)
        {
             var reducedImage = imageFactory.CreateReducedImage(type, path, times);
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