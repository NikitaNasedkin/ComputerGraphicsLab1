using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ComputerGraphicsLab1
{
    class BrightUpFilter : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color sourceColor = sourceImage.GetPixel(x, y);
            Color resultColor = Color.FromArgb(Clamp(sourceColor.R+50, 0, 255), Clamp(sourceColor.G + 50, 0, 255), Clamp(sourceColor.B + 50, 0, 255));
            return resultColor;
        }
    }
}
