using DesignPatterns.Model;
using DesignPatterns.Resizers;
using System.Drawing.Imaging;

namespace DesignPatterns.Builders
{
    public class LargePictureBuilder : IPictureBuilder
    {
        private ILargeImageResizer largeImageResizer;

        private ImageModel imageModel;

        public LargePictureBuilder(ILargeImageResizer largeImageResizer)
        {
            this.largeImageResizer = largeImageResizer;

            imageModel = new ImageModel();
        }

        public void BuildFileName()
        {
            imageModel.fileName = "large-picture";
        }

        public void BuildImageFormat()
        {
            imageModel.imageFormat = ImageFormat.Jpeg;
        }

        public void BuildResizedImageContent()
        {
            imageModel.content = largeImageResizer.ResizeImage(); 
        }

        public ImageModel GetResult()
        {
            return imageModel;
        }
    }
}
