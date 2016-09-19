using System.Collections.Generic;

namespace DesignPatterns.Services
{
    public interface IResizePictureService
    {
        void ReducePictures(IList<string> paths, int times);
    }
}