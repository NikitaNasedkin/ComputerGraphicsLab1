using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComputerGraphicsLab1
{
    class DilationFilter : MathMorphologyFilter
    {
        public DilationFilter()
        {
            kernel = new int[3, 3] { { 0, 1, 0 }, { 1, 1, 1 }, { 0, 1, 0 } };
            radius = kernel.GetLength(0) / 2;
        }
        public DilationFilter(int[,] kernel)
        {
            this.kernel = kernel;
            radius = kernel.GetLength(0) / 2;
        }

        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {

            Color max = Color.FromArgb(0, 0, 0);
            for (int i = -radius; i <= radius; i++)
            {
                for (int j = -radius; j <= radius; j++)
                {
                    if ((kernel[i + radius, j + radius] == 1) && (sourceImage.GetPixel(x + i, y + j).GetBrightness() > max.GetBrightness()))
                    {
                        max = sourceImage.GetPixel(x + i, y + j);
                    }
                }
            }
            return max;
        }
    }
}
