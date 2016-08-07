﻿using DesignPatterns.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Strategies
{
    public class BicubicDownsamplingStrategy : IResizeStrategy
    {
        public Bitmap ReduceImage(Bitmap image, int times)
        {
            return image;
        }
    }
}
