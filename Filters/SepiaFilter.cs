using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ComputerGraphicsLab1
{
    class SepiaFilter : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color sourceColor = sourceImage.GetPixel(x, y);
            int k = 25;
            int intensity = (int)(sourceColor.R * 0.299) + (int)(sourceColor.G * 0.587) + (int)(sourceColor.B * 0.114);
            int R = intensity + 2 * k;
            int G = (int)(intensity + 0.5 * k);
            int B = intensity - 1 * k;
            Color resultColor = Color.FromArgb(Clamp(R, 0, 255), Clamp(G, 0, 255), Clamp(B, 0, 255));
            return resultColor;
        }
    }
}
