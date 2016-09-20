using DesignPatterns.Factories;
using DesignPatterns.Helpers;
using DesignPatterns.Models;
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

        public ResizePictureService(IFileService fileService)
        {
            this.fileService = fileService;
        }

        public void ReducePicture(string path, int times, ImageFormat format, InterpolationType type)
        {
            switch (type)
            {
                case InterpolationType.Primitive:
                    this.imageFactory = new ResizedJpegFactory(this.fileService);
                    break;
                case InterpolationType.Average:
                    this.imageFactory = new ResizedPngFactory(this.fileService);
                    break;
                case InterpolationType.Bicubic:
                    this.imageFactory = new ResizedBmpFactory(this.fileService);
                    break;
                default:
                    throw new ArgumentException();
            }

            IResizedImage resizedImage = imageFactory.CreateResizedImage();
            resizedImage.SaveResizedImageToFile(path, times, format);
        }
    }
}