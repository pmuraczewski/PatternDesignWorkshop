using DesignPatterns.Helpers;
using System.Drawing;
using System;
using DesignPatterns.Services;
using DesignPatterns.Models;

namespace DesignPatterns.Factories
{
    public class ResizedPngFactory : IResizedImageFactory
    {
        private IFileService fileService;

        public ResizedPngFactory(IFileService fileService)
        {
            this.fileService = fileService;
        }

        public IResizedImage CreateResizedImage()
        {
            return new ResizedPng(this.fileService);
        }
    }
}
