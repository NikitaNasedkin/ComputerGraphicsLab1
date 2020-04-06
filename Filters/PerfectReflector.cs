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
    class PerfectReflector : Filters
    {
        float Rmax = 0, Gmax = 0, Bmax = 0;

        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            float resultR = 0, resultB = 0, resultG = 0;
            resultR = sourceImage.GetPixel(x, y).R * 255 / Rmax;
            resultG = sourceImage.GetPixel(x, y).G * 255 / Gmax;
            resultB = sourceImage.GetPixel(x, y).B * 255 / Bmax;
            return Color.FromArgb(
                Clamp((int)resultR, 0, 255),
                Clamp((int)resultG, 0, 255),
                Clamp((int)resultB, 0, 255)
                );
        }

        public override Bitmap processImage(Bitmap sourceImage, BackgroundWorker worker, Stack<Bitmap> bitmaps)
        {
            if (sourceImage == null)
            {
                MessageBox.Show("Откройте изображение");
                return null;
            }
            bitmaps.Push(sourceImage);
            Bitmap resultImage = new Bitmap(sourceImage.Width, sourceImage.Height);
            for (int i = 0; i < sourceImage.Width; i++)
            {
                worker.ReportProgress((int)((float)i / resultImage.Width * 50));
                for (int j = 0; j < sourceImage.Height; j++)
                {
                    if (sourceImage.GetPixel(i, j).R > Rmax)
                        Rmax = sourceImage.GetPixel(i, j).R;
                    if (sourceImage.GetPixel(i, j).G > Gmax)
                        Gmax = sourceImage.GetPixel(i, j).G;
                    if (sourceImage.GetPixel(i, j).B > Bmax)
                        Bmax = sourceImage.GetPixel(i, j).B;
                }
            }
            for (int i = 0; i < sourceImage.Width; i++)
            {
                worker.ReportProgress((int)((float)(i + sourceImage.Width) / resultImage.Width * 50));
                if (worker.CancellationPending)
                    return null;
                for (int j = 0; j < sourceImage.Height; j++)
                {
                    resultImage.SetPixel(i, j, calculateNewPixelColor(sourceImage, i, j));
                }
            }
            return resultImage;
        }
    }
}
