using DesignPatterns.Model;

namespace DesignPatterns.Builders
{
    public interface IResizedImageCreator
    {
        ImageModel Construct(IPictureBuilder builder);
    }
}