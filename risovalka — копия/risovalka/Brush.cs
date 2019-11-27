using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace risovalka
{
    public class Brush
    {
        Color color=Color.Black;
        public Bitmap bitMapImage;


        public Brush(Bitmap b)
        {
            bitMapImage = b;
        }

        public Brush(Color color)
        {
            this.color = color;
        }

        public Bitmap DrawLine(int x1, int y1, int x2, int y2)
        {
            double speed;

            double h = y2 - y1, w = x2 - x1;

            if (Math.Abs(h) > Math.Abs(w))
            {
                speed = h != 0 ? w / h : 10;
                if (h >= 0)
                {
                    for (int i = 0; i <= h; i++)
                    {
                        int j = Convert.ToInt32(i * speed);
                        bitMapImage.SetPixel(x1 + j, y1 + i, color);
                    }
                }
                else
                {
                    for (int i = Convert.ToInt32(h); i <= 0; i++)
                    {
                        int j = Convert.ToInt32(i * speed);
                        bitMapImage.SetPixel(x1 + j, y1 + i, color);
                    }
                }

            }
            else
            {
                speed = w != 0 ? h / w : 10;
                if (w >= 0)
                {
                    for (int i = 0; i <= w; i++)
                    {
                        int j = Convert.ToInt32(i * speed);
                        bitMapImage.SetPixel(x1 + i, y1 + j, color);
                    }
                }
                else
                {
                    for (int i = Convert.ToInt32(w); i <= 0; i++)
                    {
                        int j = Convert.ToInt32(i * speed);
                        bitMapImage.SetPixel(x1 + i, y1 + j, color);
                    }
                }

            }

            return bitMapImage;
        }



        public void DrawRectangle(int x1, int y1, int x2, int y2)
        {


            DrawLine(x1,y1,x2,y1);
            DrawLine(x1,y2,x2,y2);
            DrawLine(x1,y1,x1,y2);
            DrawLine(x2,y1,x2,y2);






        }

        public void DrawSquare(int x1, int y1, int x2, int y2)
        {

            int a = x2 - x1;
            y2 = y1 + a;
            DrawLine(x1, y1, x2, y1);
            DrawLine(x2, y1, x2, y2);
            DrawLine(x2, y2, x1, y2);
            DrawLine(x1, y2, x1, y1);


        }

        public void DrawRavnoBedrTr(int x1, int y1, int x2, int y2)
        {
            int x3 = 2 * x1 - x2;
            DrawLine(x1, y1, x2, y2);
            DrawLine(x2, y2, x3, y2);
            DrawLine(x3, y2, x1, y1);
        }

        public void PryamoiTr(int x1, int y1, int x2, int y2)
        {
            
            DrawLine(x1, y1, x2, y2);
            DrawLine(x2, y2, x1, y2);
            DrawLine(x1, y2, x1, y1);

            
        }

        public void RavnoStoron(int x1, int y1, int x2, int y2)
        {


            int r = Math.Abs(x2 - x1);
            int x3 = x1 + r / 2;
            int a = r / 2;
            int b = Convert.ToInt32(Math.Sqrt(r*r-a*a));
            int y3 = y1 - b;

            DrawLine(x1, y1, x2, y1);
            DrawLine(x2, y1, x3, y3);
            DrawLine(x3, y3, x1, y1);

        }

        public void DrawCircle(int x1, int y1, int x2, int y2)
        {
            double x = Math.Abs(x2 - x1);
            double y = Math.Abs(y2 - y1);
            int r = Convert.ToInt32(Math.Sqrt(x*x + y*y));

            int xt = 0, yt =r;

            for (int i = 0; i <= r; i++)
            {
                double a = Math.Sqrt(r*r - i*i);
                

                
                DrawLine(xt + x1, yt + y1, i + x1, Convert.ToInt32(a) + y1);
                DrawLine(-xt + x1, yt + y1, -i + x1, Convert.ToInt32(a) + y1);
                DrawLine(xt + x1, -yt + y1, i + x1, -Convert.ToInt32(a) + y1);
                DrawLine(-xt + x1, -yt + y1, -i + x1,- Convert.ToInt32(a) + y1);
                xt = i;
                yt = Convert.ToInt32(a);

            }


        }




        /*
        
        public Bitmap DrawSquare(int x1, int y1, int x2, int y2)
        {
            double h = y2 - y1, w = x2 - x1;

            double side;

            if (h > w)
            {
                side = h;
            } else
            {
                side = w;
            }

            for (int i = 0; i <= side; i++)
            {
                int j = Convert.ToInt32(i);
                    bitMapImage.SetPixel(x1 + i, y1, color);
            }


            return bitMapImage;
            

        }
        */
    }
}
