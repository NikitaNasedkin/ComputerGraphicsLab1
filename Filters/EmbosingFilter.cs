﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ComputerGraphicsLab1
{
    class EmbosingFilter : MatrixFilter
    {
        public EmbosingFilter()
        {
            kernel = new float[3, 3] { { 0, 1, 0 }, { 1, 0, -1 }, { 0, -1, 0 } };
        }

        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {

            int radiusX = kernel.GetLength(0) / 2;
            int radiusY = kernel.GetLength(1) / 2;
            float resultR = 0;
            float resultG = 0;
            float resultB = 0;
            for (int l = -radiusY; l <= radiusY; l++)
                for (int k = -radiusX; k <= radiusX; k++)
                {
                    int idX = Clamp(x + k, 0, sourceImage.Width - 1);
                    int idY = Clamp(y + l, 0, sourceImage.Height - 1);
                    Color neighborColor = sourceImage.GetPixel(idX, idY);
                    resultR += (neighborColor.R * kernel[k + radiusX, l + radiusY]);
                    resultG += (neighborColor.G * kernel[k + radiusX, l + radiusY]);
                    resultB += (neighborColor.B * kernel[k + radiusX, l + radiusY]);
                }
            resultR = (resultR + 128);
            resultG = (resultG + 128);
            resultB = (resultB + 128);
            return Color.FromArgb(
                Clamp((int)resultR, 0, 255),
                Clamp((int)resultG, 0, 255),
                Clamp((int)resultB, 0, 255)
                );
        }
    }
}
