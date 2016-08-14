using DesignPatterns.Helpers;
using System.Drawing;

namespace DesignPatterns.Factories
{
    public interface IResizedImageFactory
    {
        Bitmap CreateReducedImage(InterpolationType type, string path, int times);
    }
}
