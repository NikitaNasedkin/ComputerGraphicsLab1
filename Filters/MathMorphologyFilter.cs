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
    abstract class MathMorphologyFilter : Filters
    {
        protected int radius;
        protected int[,] kernel = null;
        protected MathMorphologyFilter() { }
        public MathMorphologyFilter(int[,] kernel)
        {
            this.kernel = kernel;
            radius = kernel.GetLength(0) / 2;
        }

        public void setKernel(int[,] kernel)
        {
            this.kernel = kernel;
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
            for (int i = radius; i < sourceImage.Width - radius; i++)
            {
                worker.ReportProgress((int)((float)i / resultImage.Width * 100));
                if (worker.CancellationPending)
                    return null;
                for (int j = radius; j < sourceImage.Height - radius; j++)
                    resultImage.SetPixel(i, j, calculateNewPixelColor(sourceImage, i, j));
            }
            return resultImage;
        }
    }
}
