using DesignPatterns.Helpers;
using DesignPatterns.Models;
using System.Drawing;

namespace DesignPatterns.Factories
{
    public interface IResizedImageFactory
    {
        IResizedImage CreateResizedImage();
    }
}
