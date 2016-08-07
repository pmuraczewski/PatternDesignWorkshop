using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Services
{
    public class FileService : IFileService
    {
        public bool IsFileExists(string path)
        {
            if(string.IsNullOrEmpty(path))
            {
                return false;
            }

            return File.Exists(path);
        }

        public string GetFileName(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                return null;
            }

            return Path.GetFileName(path);
        }

        public string GetFileNameWithoutExtension(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                return null;
            }

            return Path.GetFileNameWithoutExtension(path);
        }

        public string GetFolderPath(string path)
        {
            if (string.IsNullOrEmpty(path) || !path.Contains('\\'))
            {
                return null;
            }

            var fileName = GetFileName(path).ToArray();

            return path.TrimEnd(fileName);
        }

        public Bitmap GetImageAsBitmap(string path)
        {
            Bitmap image;

            try
            {
                image = (Bitmap)Image.FromFile(path);
            }
            catch
            {
                return null;
            }

            return image;
        }

        public void SaveBitmapToFile(string path, Bitmap image, ImageFormat imageFormat)
        {
            image.Save(path, imageFormat);
        }
    }
}
