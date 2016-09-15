using DesignPatterns.Model;
using DesignPatterns.Resizers;
using System.Drawing.Imaging;

namespace DesignPatterns.Builders
{
    public class MediumPictureBuilder : IPictureBuilder
    {
        private IMediumImageResizer mediumImageResizer;

        private ImageModel imageModel;

        public MediumPictureBuilder(IMediumImageResizer mediumImageResizer)
        {
            this.mediumImageResizer = mediumImageResizer;

            imageModel = new ImageModel();
        }

        public void BuildFileName()
        {
            imageModel.fileName = "medium-picture";
        }

        public void BuildImageFormat()
        {
            imageModel.imageFormat = ImageFormat.Png;
        }

        public void BuildResizedImageContent()
        {
            imageModel.content = mediumImageResizer.ResizeImage(); 
        }

        public ImageModel GetResult()
        {
            return imageModel;
        }
    }
}
