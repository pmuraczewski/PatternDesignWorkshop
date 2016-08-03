using DesignPatterns.Strategies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Services
{
    public class ResizePictureContext
    {
        private IResizeStrategy resizeStrategy;

        public void SetStrategy(IResizeStrategy resizeStrategy)
        {
            this.resizeStrategy = resizeStrategy;
        }

        public void ReducePicture(string path, int times)
        {
            this.resizeStrategy.ReduceImage(path, times);
        }
    }
}