using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hexagonal
{
    
    public partial class Form1 : Form
    {        
        string TextForm;

        float SquareHeight = 64;
        float HexHeight = 64;

        int key = 0;

        List<PointF> Squares = new List<PointF>();
        List<PointF> Hexagons = new List<PointF>();

        Pen shapePen = new Pen(Color.White, 3);

        Color brushColor = Color.FromArgb(250 / 100 * 75, 0, 255, 0);        

        //Squ shape = new Squ();
        //Hex shape = new Hex();

        Size resolution = Screen.PrimaryScreen.Bounds.Size;
        public Form1()
        {
            InitializeComponent();
            //xGrid = tableLayoutPanel1.Width;
            //this.Paint += picGrid_Paint;
            
            //areaGrid.Paint += picGrid_Paint;
            TextForm = this.Text;
            //this.BackgroundImage = Image.FromFile(@"E:/ВТВ/Images/Фон(серый).png");
            this.BackgroundImage = Image.FromFile(@"E:/ВТВ/Images/Rc.jpeg");
            areaGrid.BackColor = Color.Transparent;
        }

        // Redraw the grid.
        private void picGrid_Paint(object sender, PaintEventArgs e)
        {
            if (key == 1)
            {
                Squ shape = new Squ();
                SolidBrush brush = new SolidBrush(brushColor);

                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                // Draw the selected hexagons.
                foreach (PointF point in Squares)
                {
                    e.Graphics.FillPolygon(brush,
                        shape.ShapeToPoints(SquareHeight, point.X, point.Y));
                }

                // Draw the grid.√
                shape.DrawShapeGrid(e.Graphics, shapePen,
                    0, resolution.Width - tableLayoutPanel1.Width,
                    0, resolution.Height,
                    SquareHeight);
            }

            else if (key == 2)
            {
                Hex shape = new Hex();
                SolidBrush brush = new SolidBrush(brushColor);

                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                // Draw the selected hexagons.
                foreach (PointF point in Squares)
                {
                    e.Graphics.FillPolygon(brush,
                        shape.ShapeToPoints(SquareHeight, point.X, point.Y));
                }

                // Draw the grid.√
                shape.DrawShapeGrid(e.Graphics, shapePen,
                    0, resolution.Width - tableLayoutPanel1.Width,
                    0, resolution.Height,
                    SquareHeight);
            }
        }

        // Display the row and column under the mouse.
        private void SquPicGrid_MouseMove(object sender, MouseEventArgs e)
        {
            if (key == 1)
            {
                Squ shape = new Squ();

                int row, col;
                shape.PointToShape(e.X, e.Y, SquareHeight, out row, out col);
                this.Text = TextForm + ": " + "(" + row + ", " + col + ")";
            }

                else if (key == 2)
                {
                    Hex shape = new Hex();

                    int row, col;
                    shape.PointToShape(e.X, e.Y, SquareHeight, out row, out col);
                    this.Text = TextForm + ": " + "(" + row + ", " + col + ")";
                }
            }

        // Add the clicked hexagon to the Hexagons list.
        private void SquPicGrid_MouseClick(object sender, MouseEventArgs e)
        {
            if (key == 1)
            {
                Squ shape = new Squ();
                int row, col;
                shape.PointToShape(e.X, e.Y, SquareHeight, out row, out col);
                Squares.Add(new PointF(row, col));
                this.Refresh();
            }

            else if (key == 2)
            {
                Hex shape = new Hex();
                int row, col;
                shape.PointToShape(e.X, e.Y, SquareHeight, out row, out col);
                Squares.Add(new PointF(row, col));
                this.Refresh();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            key = 1;
            areaGrid.Paint += picGrid_Paint;
            this.Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            key = 2;
            areaGrid.Paint += picGrid_Paint;
            this.Refresh();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {            
            SquareHeight = (int)(numericUpDown1.Value);
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            shapePen.Width = (int)(numericUpDown2.Value);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //var pb = new PictureBox() { Parent = this };
            var pb = new PictureBox();

            pb.SizeMode = PictureBoxSizeMode.Zoom;
            pb.Size = new Size(100, 100);
            pb.Location = new Point((74 * 4) + 5 + (36 * 4), 64 * 4);
            //pb.BackgroundImage = imageList1.Images[0];
            //pb.BackgroundImageLayout = ImageLayout.Center;
            pb.BackColor = Color.FromName("Green");
            //pb.BackColor = Color.Transparent;
            pb.BringToFront();
            Controls.Add(pb);
        }
    }
}

