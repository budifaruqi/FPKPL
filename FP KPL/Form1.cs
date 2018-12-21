using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FP_KPL
{
    public partial class Form1 : Form
    {
        private readonly int RECTANGLE = 1;
        private readonly int CIRCLE = 2;
        private readonly int LINE = 3;


        private readonly int OPACITY = 4;

        private int typeShape;


        private Point startPoint;
        private Point endPoint;

        private Pen pen;
        private Graphics graphics;
        private bool isPaint = false;
        private bool canPaint = false;

        private double vector = 0;
        private double angle = 0;
        Rectangle Rect;
        Point LocationXY;
        Point LocationX1Y1;
        bool IsMouseDown = false;
        public Form1()
        {
            InitializeComponent();
        }

        private Rectangle GetRect()
        {
            Rect = new Rectangle();
            Rect.X = Math.Min(LocationXY.X, LocationX1Y1.X);
            Rect.Y = Math.Min(LocationXY.Y, LocationX1Y1.Y);
            Rect.Width = Math.Abs(LocationXY.X - LocationX1Y1.X);
            Rect.Height = Math.Abs(LocationXY.Y - LocationX1Y1.Y);

            return Rect;
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            IsMouseDown = true;
            LocationXY = e.Location;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (IsMouseDown == true)
            {
                LocationX1Y1 = e.Location;
                Refresh();
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (IsMouseDown == true)
            {
                LocationX1Y1 = e.Location;
                IsMouseDown = false;
                if (Rect != null)
                {
                    Bitmap bit = new Bitmap(pictureBox1.Image, pictureBox1.Width, pictureBox1.Height);
                    Bitmap cropImg = new Bitmap(Rect.Width, Rect.Height);
                    Graphics g = Graphics.FromImage(cropImg);
                    g.DrawImage(bit, 0, 0, Rect, GraphicsUnit.Pixel);
                    pictureBox2.Image = cropImg;
                }

            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (Rect != null)
            {
                e.Graphics.DrawRectangle(Pens.Red, GetRect());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // open file dialog   
            OpenFileDialog open = new OpenFileDialog();
            // image filters  
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                // display image in picture box  
                pictureBox1.Image = Image.FromFile(open.FileName, true);

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
}
