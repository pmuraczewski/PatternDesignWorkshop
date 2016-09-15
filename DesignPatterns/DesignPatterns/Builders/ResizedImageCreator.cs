using DesignPatterns.Model;

namespace DesignPatterns.Builders
{
    public class ResizedImageCreator : IResizedImageCreator
    {
        public ImageModel Construct(IPictureBuilder builder)
        {
            builder.BuildFileName();
            builder.BuildImageFormat();
            builder.BuildResizedImageContent();

            return builder.GetResult();
        }
    }
}