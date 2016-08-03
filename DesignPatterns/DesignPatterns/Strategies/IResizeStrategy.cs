using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Strategies
{
    public interface IResizeStrategy
    {
        void ReduceImage(string path, int times);
    }
}
