using DesignPatterns.Model;
using DesignPatterns.Resizers;
using DesignPatterns.Services;
using System.Drawing.Imaging;

namespace DesignPatterns.Builders
{
    public class SmallPictureBuilder : IPictureBuilder
    {
        private ISmallImageResizer smallImageResizer;

        private ImageModel imageModel;

        public SmallPictureBuilder(ISmallImageResizer smallImageResizer)
        {
            this.smallImageResizer = smallImageResizer;

            imageModel = new ImageModel();
        }

        public void BuildFileName()
        {
            imageModel.fileName = "small-picture";
        }

        public void BuildImageFormat()
        {
            imageModel.imageFormat = ImageFormat.Bmp;
        }

        public void BuildResizedImageContent()
        {
            imageModel.content = smallImageResizer.ResizeImage(); 
        }

        public ImageModel GetResult()
        {
            return imageModel;
        }
    }
}
