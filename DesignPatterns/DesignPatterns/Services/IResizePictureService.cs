using System.Collections.Generic;

namespace DesignPatterns.Services
{
    public interface IResizePictureService
    {
        void ReducePicture(IList<string> paths, int times);
    }
}