using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace ComputerGraphicsLab1
{
    class Sharpness2Filter : MatrixFilter
    {
        public Sharpness2Filter()
            {
                kernel = new float[3, 3] { { -1, -1, -1 }, { -1, 9, -1 }, { -1, -1, -1 } };
            }
    }
}
