using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ComputerGraphicsLab1
{
    class ShiftLeftFilter : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color resultColor = sourceImage.GetPixel(Clamp(x + 50, 0, sourceImage.Width - 1), y);
            return resultColor;
        }
    }
}
