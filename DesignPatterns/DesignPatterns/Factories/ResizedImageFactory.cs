using DesignPatterns.Helpers;
using System.Drawing;
using System;
using DesignPatterns.Services;

namespace DesignPatterns.Factories
{
    public class ResizedImageFactory : IResizedImageFactory
    {
        private IFileService fileService;
        private IResizeImageService resizeImageService;

        public ResizedImageFactory(IFileService fileService)
        {
            this.fileService = fileService;
        }

        public Bitmap CreateReducedImage(InterpolationType type, string path, int times)
        {
            switch (type)
            {
                case InterpolationType.Primitive:
                    resizeImageService = new PrimitiveResamplingService();
                    break;
                case InterpolationType.Average:
                    resizeImageService = new AverageDownsamplingService();
                    break;
                case InterpolationType.Bicubic:
                    resizeImageService = new BicubicDownsamplingService();
                    break;
                default:
                    throw new ArgumentException();
            }

            var originalImage = this.fileService.GetImageAsBitmap(path);
            return resizeImageService.ReduceImage(originalImage, times);
        }
    }
}
