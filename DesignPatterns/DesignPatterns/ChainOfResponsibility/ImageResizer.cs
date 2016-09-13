using System.Drawing;
using System.Drawing.Imaging;

namespace DesignPatterns.ChainOfResponsibility
{
    public abstract class ImageResizer
    {
        protected ImageResizer successor;

        public void SetSuccessor(ImageResizer successor)
        {
            this.successor = successor;
        }

        public abstract Bitmap ProcessImage(Bitmap image, ImageFormat format, int times);
    }
}