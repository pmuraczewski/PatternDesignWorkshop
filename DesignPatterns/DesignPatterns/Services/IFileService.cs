using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Services
{
    public interface IFileService
    {
        bool IsFileExists(string path);

        string GetFileName(string path);

        string GetFileNameWithoutExtension(string path);

        string GetFolderPath(string path);

        Bitmap GetImageAsBitmap(string path);

        void SaveBitmapToFile(string path, Bitmap image, ImageFormat imageFormat);
    }
}