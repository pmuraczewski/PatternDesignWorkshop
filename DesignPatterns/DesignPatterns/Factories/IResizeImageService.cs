using DesignPatterns.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Factories
{
    public interface IResizeImageService
    {
        Bitmap ReduceImage(Bitmap image, int times);
    }
}
