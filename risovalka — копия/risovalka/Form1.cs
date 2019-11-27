using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace risovalka
{

    public partial class Form1 : Form
    {
        Bitmap bitMapImage;
        Bitmap bbb;
        bool FmouseLeft = false;
        bool RectDraw = false;
        bool SquareDraw = false;
        bool CircleDraw = false;
        bool TriangleDraw = false;
        bool ColorRed = false;
        bool FatDraw = false;
        bool EllipseDraw = false;


        int x, y;
      
        public Form1()
        {
            InitializeComponent();  
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {

            if (FmouseLeft && e.Location.X < pictureBox1.Width && e.Location.Y < pictureBox1.Height
                && e.Location.X >= 0 && e.Location.Y >= 0)
            {

                if (RectDraw)
                {
                    Rectangle r = new Rectangle(0, 0, pictureBox1.Width - 1, pictureBox1.Height - 1);
                    bbb = bitMapImage.Clone(r, System.Drawing.Imaging.PixelFormat.DontCare);
                    Brush b = new Brush(bbb);
                    b.DrawRectangle(x, y, e.X, e.Y);

                    pictureBox1.Image = b.bitMapImage;

                }
                else if (SquareDraw)
                {
                    Rectangle r = new Rectangle(0, 0, pictureBox1.Width - 1, pictureBox1.Height - 1);
                    bbb = bitMapImage.Clone(r, System.Drawing.Imaging.PixelFormat.DontCare);
                    Brush b = new Brush(bbb);
                    b.DrawSquare(x, y, e.X, e.Y);

                    pictureBox1.Image = b.bitMapImage;
                }

                else if (CircleDraw)
                {
                    Rectangle r = new Rectangle(0, 0, pictureBox1.Width - 1, pictureBox1.Height - 1);
                    bbb = bitMapImage.Clone(r, System.Drawing.Imaging.PixelFormat.DontCare);
                    Brush b = new Brush(bbb);
                    b.DrawCircle(x, y, e.X, e.Y);

                    pictureBox1.Image = b.bitMapImage;
                }

                else if (TriangleDraw)
                {
                    if (Control.ModifierKeys == Keys.Shift)
                    {
                        Rectangle r = new Rectangle(0, 0, pictureBox1.Width - 1, pictureBox1.Height - 1);
                        bbb = bitMapImage.Clone(r, System.Drawing.Imaging.PixelFormat.DontCare);
                        Brush b = new Brush(bbb);
                        b.PryamoiTr(x, y, e.X, e.Y);

                        pictureBox1.Image = b.bitMapImage;
                    }
                    else if (Control.ModifierKeys == Keys.Control)
                    {
                        Rectangle r = new Rectangle(0, 0, pictureBox1.Width - 1, pictureBox1.Height - 1);
                        bbb = bitMapImage.Clone(r, System.Drawing.Imaging.PixelFormat.DontCare);
                        Brush b = new Brush(bbb);
                        b.DrawRavnoBedrTr(x, y, e.X, e.Y);

                        pictureBox1.Image = b.bitMapImage;


                    }
                    else
                    {
                        Rectangle r = new Rectangle(0, 0, pictureBox1.Width - 1, pictureBox1.Height - 1);
                        bbb = bitMapImage.Clone(r, System.Drawing.Imaging.PixelFormat.DontCare);
                        Brush b = new Brush(bbb);
                        b.RavnoStoron(x, y, e.X, e.Y);

                        pictureBox1.Image = b.bitMapImage;
                    }

                }
                else if (EllipseDraw)
                {
                    Rectangle r = new Rectangle(0, 0, pictureBox1.Width - 1, pictureBox1.Height - 1);
                    bbb = bitMapImage.Clone(r, System.Drawing.Imaging.PixelFormat.DontCare);
                    Ellipse ellipse = new Ellipse(bbb, Color.Black);
                    bbb = ellipse.Draw(x, y, e.X, e.Y);

                    pictureBox1.Image = bbb;
                }

                else
                {

                    if (FatDraw)
                    {
                        Rectangle r = new Rectangle(0, 0, pictureBox1.Width - 1, pictureBox1.Height - 1);
                        bbb = bitMapImage.Clone(r, System.Drawing.Imaging.PixelFormat.DontCare);
                        Brush b = new Brush(bitMapImage);

                        //b.DrawCircle(x, y, e.X + 1, e.Y + 1);
                        //b.DrawCircle(x, y, e.X + 2, e.Y + 2);
                        //b.DrawCircle(x, y, e.X + 3, e.Y + 3);
                        x = e.X;
                        y = e.Y;
                        b.DrawCircle(x, y, e.X, e.Y);
                        b.DrawCircle(x, y, e.X+4, e.Y+4);
                        pictureBox1.Image = b.bitMapImage;
                    }
                    else
                    {
                        Rectangle r = new Rectangle(0, 0, pictureBox1.Width - 1, pictureBox1.Height - 1);
                        bbb = bitMapImage.Clone(r, System.Drawing.Imaging.PixelFormat.DontCare);
                        Brush b = new Brush(bitMapImage);
                        b.DrawLine(x, y, e.Location.X, e.Location.Y);
                        x = e.X;
                        y = e.Y;
                        
                        pictureBox1.Image = b.bitMapImage;
                    }

                }


            }


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            bitMapImage = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Image = bitMapImage;

        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            FmouseLeft = true;
            this.x = e.X;
            this.y = e.Y;

        }

        private void Form1_MouseLeave(object sender, EventArgs e)
        {
            FmouseLeft = false;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Rectangle_Click(object sender, EventArgs e)
        {
            RectDraw = true;
            SquareDraw = false;
            CircleDraw = false;
            TriangleDraw = false;
            EllipseDraw = false;


        }

        private void Square_Click(object sender, EventArgs e)
        {
            SquareDraw = true;
            RectDraw = false;
            CircleDraw = false;
            TriangleDraw = false;
            EllipseDraw = false;


        }

        private void Circle_Click(object sender, EventArgs e)
        {
            CircleDraw = true;
            RectDraw = false;
            SquareDraw = false;
            TriangleDraw = false;
            EllipseDraw = false;


        }

        private void Brush_Click(object sender, EventArgs e)
        {
            
            RectDraw = false;
            SquareDraw = false;
            CircleDraw = false;
            TriangleDraw = false;
            EllipseDraw = false;

        }





        private void Red_Click(object sender, EventArgs e)
        {
            //Brush b = new Brush(Color.Red);
            //ColorRed = true;
        }

        private void Triangle_Click(object sender, EventArgs e)
        {
            TriangleDraw = true;
            RectDraw = false;
            SquareDraw = false;
            CircleDraw = false;
            EllipseDraw = false;

        }

        private void Fat_Click(object sender, EventArgs e)
        {
            FatDraw = true;
            RectDraw = false;
            SquareDraw = false;
            CircleDraw = false;
            TriangleDraw = false;
            EllipseDraw = false;
        }

        private void Ellipse_Click(object sender, EventArgs e)
        {
            EllipseDraw = true;
            CircleDraw = false;
            RectDraw = false;
            SquareDraw = false;
            TriangleDraw = false;

        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            FmouseLeft = false;
            bitMapImage = bbb;
        }
    }
}
