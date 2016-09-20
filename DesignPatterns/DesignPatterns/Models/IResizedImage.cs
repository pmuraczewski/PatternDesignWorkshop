using System.Drawing;
using System.Drawing.Imaging;

namespace DesignPatterns.Models
{
    public interface IResizedImage
    {
        void SaveResizedImageToFile(string path, int times, ImageFormat imageFormat);
    }
}