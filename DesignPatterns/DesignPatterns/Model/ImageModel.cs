using System.Drawing;
using System.Drawing.Imaging;

namespace DesignPatterns.Model
{
    public class ImageModel
    {
        public string fileName { get; set; }
        
        public Bitmap content { get; set; }
        
        public ImageFormat imageFormat { get; set; }
    }
}
