using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ComputerGraphicsLab1
{
    class GlassFilter : Filters
    {

        Random random;
        public GlassFilter()
        {
            random = new Random();
        }
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int resultX = (int)(x + (random.NextDouble() - 0.5) * 10);
            int resultY = (int)(y + (random.NextDouble() - 0.5) * 10);
            Color resultColor = sourceImage.GetPixel(Clamp(resultX, 0, sourceImage.Width - 1), Clamp(resultY, 0, sourceImage.Height - 1));
            return resultColor;
        }
    }
}
