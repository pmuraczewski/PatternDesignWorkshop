using System.Drawing;

namespace DesignPatterns.Helpers
{
    public static class BitmapExtensions
    {
        public static int GetSize(this Bitmap image)
        {
            var width = image.Width;
            var height = image.Height;

            return width * height;
        }
    }
}