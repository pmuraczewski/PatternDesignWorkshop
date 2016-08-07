using DesignPatterns.Strategies;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Services
{
    public interface IResizePictureService
    {
        void SetStrategy(IResizeStrategy resizeStrategy);

        void ReducePicture(string path, int times, ImageFormat format);
    }
}