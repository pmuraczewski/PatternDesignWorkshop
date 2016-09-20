using DesignPatterns.Helpers;
using System.Drawing;
using System;
using DesignPatterns.Services;
using DesignPatterns.Models;

namespace DesignPatterns.Factories
{
    public class ResizedBmpFactory : IResizedImageFactory
    {
        private IFileService fileService;

        public ResizedBmpFactory(IFileService fileService)
        {
            this.fileService = fileService;
        }

        public IResizedImage CreateResizedImage()
        {
            return new ResizedBmp(this.fileService);
        }
    }
}
