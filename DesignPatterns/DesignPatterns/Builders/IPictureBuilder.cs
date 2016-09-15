using DesignPatterns.Model;
using System.Drawing;
using System.Drawing.Imaging;

namespace DesignPatterns.Builders
{
    public interface IPictureBuilder
    {
        void BuildFileName();

        void BuildResizedImageContent();

        void BuildImageFormat();

        ImageModel GetResult();
    }
}