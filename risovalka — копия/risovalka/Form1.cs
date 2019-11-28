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
        Color color = Color.Black;


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
                    Brush b = new Brush(bbb, color);
                    b.DrawRectangle(x, y, e.X, e.Y);

                    pictureBox1.Image = b.bitMapImage;

                }
                else if (SquareDraw)
                {
                    Rectangle r = new Rectangle(0, 0, pictureBox1.Width - 1, pictureBox1.Height - 1);
                    bbb = bitMapImage.Clone(r, System.Drawing.Imaging.PixelFormat.DontCare);
                    Brush b = new Brush(bbb, color);
                    b.DrawSquare(x, y, e.X, e.Y);

                    pictureBox1.Image = b.bitMapImage;
                }

                else if (CircleDraw)
                {
                    Rectangle r = new Rectangle(0, 0, pictureBox1.Width - 1, pictureBox1.Height - 1);
                    bbb = bitMapImage.Clone(r, System.Drawing.Imaging.PixelFormat.DontCare);
                    Brush b = new Brush(bbb,color);
                    b.DrawCircle(x, y, e.X, e.Y);

                    pictureBox1.Image = b.bitMapImage;
                }

                else if (TriangleDraw)
                {
                    if (Control.ModifierKeys == Keys.Shift)
                    {
                        Rectangle r = new Rectangle(0, 0, pictureBox1.Width - 1, pictureBox1.Height - 1);
                        bbb = bitMapImage.Clone(r, System.Drawing.Imaging.PixelFormat.DontCare);
                        Brush b = new Brush(bbb,color);
                        b.PryamoiTr(x, y, e.X, e.Y);

                        pictureBox1.Image = b.bitMapImage;
                    }
                    else if (Control.ModifierKeys ==Keys.Control)
                    {
                        Rectangle r = new Rectangle(0, 0, pictureBox1.Width - 1, pictureBox1.Height - 1);
                        bbb = bitMapImage.Clone(r, System.Drawing.Imaging.PixelFormat.DontCare);
                        Brush b = new Brush(bbb, color);
                        b.DrawRavnoBedrTr(x, y, e.X, e.Y);

                        pictureBox1.Image = b.bitMapImage;


                    }
                    else
                    {
                        Rectangle r = new Rectangle(0, 0, pictureBox1.Width - 1, pictureBox1.Height - 1);
                        bbb = bitMapImage.Clone(r, System.Drawing.Imaging.PixelFormat.DontCare);
                        Brush b = new Brush(bbb, color);
                        b.RavnoStoron(x, y, e.X, e.Y);

                        pictureBox1.Image = b.bitMapImage;
                    }

                }

                else
                {
/*
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
                    {*/
                        Rectangle r = new Rectangle(0, 0, pictureBox1.Width - 1, pictureBox1.Height - 1);
                        bbb = bitMapImage.Clone(r, System.Drawing.Imaging.PixelFormat.DontCare);
                        Brush b = new Brush(bitMapImage,color);
                        b.DrawLine(x, y, e.Location.X, e.Location.Y);
                        x = e.X;
                        y = e.Y;
                        
                        pictureBox1.Image = b.bitMapImage;
                    //}

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

        }

        private void Square_Click(object sender, EventArgs e)
        {
            SquareDraw = true;
            RectDraw = false;
            CircleDraw = false;
            TriangleDraw = false;

        }

        private void Circle_Click(object sender, EventArgs e)
        {
            CircleDraw = true;
            RectDraw = false;
            SquareDraw = false;
            TriangleDraw = false;

        }

        private void Brush_Click(object sender, EventArgs e)
        {
            
            RectDraw = false;
            SquareDraw = false;
            CircleDraw = false;
            TriangleDraw = false;
        }


        private void Triangle_Click(object sender, EventArgs e)
        {
            TriangleDraw = true;
            RectDraw = false;
            SquareDraw = false;
            CircleDraw = false;
        }

        private void button_Red_Click(object sender, EventArgs e)
        {
            this.color = Color.Red;
        }

        private void button_Blue_Click(object sender, EventArgs e)
        {
            this.color = Color.Blue;
        }

        private void button_LimeGreen_Click(object sender, EventArgs e)
        {
            this.color = Color.LimeGreen;
        }

        private void button_Yellow_Click(object sender, EventArgs e)
        {
            this.color = Color.Yellow;
        }

        private void button_White_Click(object sender, EventArgs e)
        {
            this.color = Color.White;
        }

        private void button_MediumPurple_Click(object sender, EventArgs e)
        {
            this.color = Color.MediumPurple;
        }

        private void button_DarkGray_Click(object sender, EventArgs e)
        {
            this.color = Color.DarkGray;
        }

        private void button_Pulm_Click(object sender, EventArgs e)
        {
            this.color = Color.Purple;
        }

        private void button_DarkGreen_Click(object sender, EventArgs e)
        {
            this.color = Color.DarkGreen;
        }

        private void button_Magenta_Click(object sender, EventArgs e)
        {
            this.color = Color.Magenta;
        }

        private void button_DarkGoldenrod_Click(object sender, EventArgs e)
        {
            this.color = Color.DarkGoldenrod;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            FmouseLeft = false;
            bitMapImage = bbb;
        }
    }
}
