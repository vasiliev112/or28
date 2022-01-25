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
    public class Squ
    {
        float SquareHeight = 64;

        List<PointF> Squares = new List<PointF>();

        Size resolution = Screen.PrimaryScreen.Bounds.Size;

        // Redraw the grid.
        public void SquPicGrid_Paint(object sender, PaintEventArgs e)
        {

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Draw the selected hexagons.
            foreach (PointF point in Squares)
            {
                e.Graphics.FillPolygon(Brushes.LightBlue,
                    ShapeToPoints(SquareHeight, point.X, point.Y));
            }

            // Draw the grid.√
            DrawShapeGrid(e.Graphics, Pens.Black,
                0, resolution.Width - 500,  /////////////////////////////////////////////
                0, resolution.Height,
                SquareHeight);

        }


        // Return the points that define the indicated hexagon.
        public PointF[] ShapeToPoints(float height, float row, float col)
        {
            // Start with the leftmost corner of the upper left hexagon.
            float width = ShapeWidth(height);
            float y = 0;
            float x = 0;

            // Move down the required number of rows.
            y += row * height;

            // Move over for the column number.
            x += col * width;

            // Generate the points.
            return new PointF[]
                {
            new PointF(x, y),
            new PointF(x + width, y),
            new PointF(x + width, y + height),
            new PointF(x,  y + height),
                };
        }

        // Return the width of a hexagon.
        public float ShapeWidth(float height)
        {
            return height;
        }

        // Draw a hexagonal grid for the indicated area.
        // (You might be able to draw the hexagons without
        // drawing any duplicate edges, but this is a lot easier.)

        public void DrawShapeGrid(Graphics gr, Pen pen,
            float xmin, float xmax, float ymin, float ymax,
            float height)
        {
            // Loop until a hexagon won't fit.
            for (int row = 0; ; row++)
            {
                // Get the points for the row's first hexagon.
                PointF[] points = ShapeToPoints(height, row, 0);

                // If it doesn't fit, we're done.
                if (points[2].Y > ymax) break;

                // Draw the row.
                for (int col = 0; ; col++)
                {
                    // Get the points for the row's next hexagon.
                    points = ShapeToPoints(height, row, col);

                    // If it doesn't fit horizontally,
                    // we're done with this row.
                    if (points[1].X > xmax) break;

                    // If it fits vertically, draw it.
                    if (points[2].Y <= ymax)
                    {
                        gr.DrawPolygon(pen, points);
                    }
                }
            }
        }


        // Return the row and column of the hexagon at this point.
        public void PointToShape(float x, float y, float height,
            out int row, out int col)
        {
            // Find the test rectangle containing the point.
            float width = ShapeWidth(height);
            col = (int)(x / (width));
            row = (int)(y / (height));
        }
    }
}
