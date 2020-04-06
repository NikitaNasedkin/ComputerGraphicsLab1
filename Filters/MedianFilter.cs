﻿using System;
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
    class MedianFilter : Filters
    {
        int size, rad;
        Color[,] _colors;
        Color[] colors;
        float[,] _R, _G, _B;
        float[] R, G, B;

        public MedianFilter(int s = 3)
        {
            size = s;
            _colors = new Color[s, s];
            colors = new Color[s * s];
            _R = new float[s, s];
            _G = new float[s, s];
            _B = new float[s, s];
            R = new float[s * s];
            G = new float[s * s];
            B = new float[s * s];
            rad = size / 2;
        }

        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            float resultR, resultB, resultG;
            int index = 0;
            for (int k = -rad; k <= rad; k++)
                for (int l = -rad; l <= rad; l++)
                {
                    
                    R[index] = sourceImage.GetPixel(x + k, y + l).R;
                    G[index] = sourceImage.GetPixel(x + k, y + l).G;
                    B[index] = sourceImage.GetPixel(x + k, y + l).B;
                    index++;
                }
            
            Array.Sort(R);
            Array.Sort(G);
            Array.Sort(B);
            resultR = R[(size * size + 1) / 2];
            resultG = G[(size * size + 1) / 2];
            resultB = B[(size * size + 1) / 2];
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
            for (int i = size / 2; i < sourceImage.Width - size / 2; i++)
            {
                worker.ReportProgress((int)((float)i / resultImage.Width * 100));
                if (worker.CancellationPending)
                    return null;
                for (int j = size / 2; j < sourceImage.Height - size / 2; j++)
                {
                    resultImage.SetPixel(i, j, calculateNewPixelColor(sourceImage, i, j));
                }
            }
            return resultImage;
        }

    }
}
