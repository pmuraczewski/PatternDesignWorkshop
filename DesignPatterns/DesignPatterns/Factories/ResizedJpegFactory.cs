using DesignPatterns.Helpers;
using System.Drawing;
using System;
using DesignPatterns.Services;
using DesignPatterns.Models;

namespace DesignPatterns.Factories
{
    public class ResizedJpegFactory : IResizedImageFactory
    {
        private IFileService fileService;

        public ResizedJpegFactory(IFileService fileService)
        {
            this.fileService = fileService;
        }

        public IResizedImage CreateResizedImage()
        {
            return new ResizedJpeg(this.fileService);
        }
    }
}