using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;


namespace risovalka
{
    class Ellipse
    {
        Bitmap bitMap;
        Color color;
        Brush brush;

        public Ellipse(Bitmap bitMap, Color colore)
        {
            Rectangle rec = new Rectangle(0, 0, bitMap.Width, bitMap.Height);

            this.bitMap = bitMap.Clone(rec, System.Drawing.Imaging.PixelFormat.DontCare);
            this.color = color;
        }

        private Bitmap Draw(int x1, int y1, double big, double small, bool flagVertical)
        {
            int tmpX = 0, tmpY = 0;
            for (int i = 0; i <= big; i++)
            {
                double x; double y;
                double nan = Double.NaN;

                if (flagVertical)
                {
                    y = i;
                    x = Math.Sqrt((Math.Pow(small, 2) / Math.Pow(big, 2)) * (Math.Pow(big, 2) - Math.Pow(y, 2)));
                }
                else
                {
                    x = i;
                    y = Math.Sqrt((Math.Pow(small, 2) / Math.Pow(big, 2)) * (Math.Pow(big, 2) - Math.Pow(x, 2)));
                }
                if (y.Equals(nan) || x.Equals(nan))
                {
                    break;
                }
                else
                {
                    if (i == 0)
                    {
                        bitMap.SetPixel(Convert.ToInt32(x1 + x), Convert.ToInt32(y1 + y), color);
                        bitMap.SetPixel(Convert.ToInt32(x1 + x), Convert.ToInt32(y1 - y), color);
                        bitMap.SetPixel(Convert.ToInt32(x1 - x), Convert.ToInt32(y1 - y), color);
                        bitMap.SetPixel(Convert.ToInt32(x1 - x), Convert.ToInt32(y1 + y), color);
                        tmpX = Convert.ToInt32(x);
                        tmpY = Convert.ToInt32(y);
                    }
                    else
                    {
                        brush = new Brush(bitMap);
                        brush.DrawLine((x1 + tmpX), (y1 + tmpY), Convert.ToInt32(x1 + x), Convert.ToInt32(y1 + y));
                        brush.DrawLine((x1 + tmpX), (y1 - tmpY), Convert.ToInt32(x1 + x), Convert.ToInt32(y1 - y));
                        brush.DrawLine((x1 - tmpX), (y1 - tmpY), Convert.ToInt32(x1 - x), Convert.ToInt32(y1 - y));
                        brush.DrawLine((x1 - tmpX), (y1 + tmpY), Convert.ToInt32(x1 - x), Convert.ToInt32(y1 + y));
                        tmpX = Convert.ToInt32(x);
                        tmpY = Convert.ToInt32(y);
                    }

                }
            }
            return bitMap;
        }

        public Bitmap Draw(int x1, int y1, int x2, int y2)
        {
            double w = Math.Abs(x2 - x1);
            double h = Math.Abs(y2 - y1);
            double big, small;
            bool flagVertical = false;
            if (w >= h)
            {
                big = w;
                small = h;
            }
            else
            {
                big = h;
                small = w;
                flagVertical = true;
            }
            bitMap = Draw(x1, y1, big, small, flagVertical);

            return bitMap;
        }
    }
}
