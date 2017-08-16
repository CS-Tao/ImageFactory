using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageFactory
{
    class CDOG
    {
        private int w = 0;
        private int h = 0;
        public double[,] values = new double[0, 0];

        public CDOG(int width, int height)
        {
            w = width;
            h = height;
            values = new double[width, height];
        }

        public double GetPixel(int x,int y)
        {
            return values[x, y];
        }

        public void SetPixel(int x, int y, double value)
        {
            values[x, y] = value;
        }

        public int GetWidth()
        {
            return w;
        }

        public int GetHeight()
        {
            return h;
        }

        public Bitmap ToBitmap()
        {
            int width = this.GetWidth();
            int height = this.GetHeight();

            Bitmap output = new Bitmap(width, height);

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    output.SetPixel(j, i, Color.FromArgb(Get0To255(this.GetPixel(j, i)), Get0To255(this.GetPixel(j, i)), Get0To255(this.GetPixel(j, i))));
                }
            }

            return output;
        }

        private byte Get0To255(double input1)
        {
            int input = (int)input1;
            int output = input > 255 ? 255 : (input < 0 ? 0 : input);
            return (byte)output;
        }
    }
}
