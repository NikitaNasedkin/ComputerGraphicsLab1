﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.ComponentModel;
using System.Windows.Forms;

namespace ComputerGraphicsLab1
{
   abstract class Filters
    {
        public virtual Bitmap processImage(Bitmap sourceImage, BackgroundWorker worker, Stack<Bitmap> bitmaps)
        {
            if (sourceImage == null)
            {
                MessageBox.Show("Откройте изображение");
                return null;
            }
            bitmaps.Push(sourceImage);

            Bitmap resultImage = new Bitmap(sourceImage.Width, sourceImage.Height);

            for(int i = 0; i < sourceImage.Width; i++)
            {
                worker.ReportProgress((int)((float)i / resultImage.Width * 100));
                if (worker.CancellationPending)
                    return null;

                for(int j = 0; j< sourceImage.Height; j++)
                {
                    resultImage.SetPixel(i, j, calculateNewPixelColor(sourceImage, i, j));
                }
            }

            return resultImage;
        }
        protected abstract Color calculateNewPixelColor(Bitmap sourceImage, int i, int j);
        public int Clamp(int value, int min, int max)
        {
            if (value < min)
                return min;
            if (value > max)
                return max;
            return value;

        }
    }
}
