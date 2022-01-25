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
    public class Hex
    {
        float SquareHeight = 64;

        List<PointF> Squares = new List<PointF>();

        Size resolution = Screen.PrimaryScreen.Bounds.Size;

        // Return the points that define the indicated hexagon.
        public PointF[] ShapeToPoints(float height, float row, float col)
        {
            // Start with the leftmost corner of the upper left hexagon.
            float width = ShapeWidth(height);
            float y = height / 2;
            float x = 0;

            // Move down the required number of rows.
            y += row * height;

            // If the column is odd, move down half a hex more.
            if (col % 2 == 1) y += height / 2;

            // Move over for the column number.
            x += col * (width * 0.75f);

            // Generate the points.
            return new PointF[]
                {
            new PointF(x, y),
            new PointF(x + width * 0.25f, y - height / 2),
            new PointF(x + width * 0.75f, y - height / 2),
            new PointF(x + width, y),
            new PointF(x + width * 0.75f, y + height / 2),
            new PointF(x + width * 0.25f, y + height / 2),
                };
        }

        // Return the width of a hexagon.
        public float ShapeWidth(float height)
        {
            return (float)(4 * (height / 2 / Math.Sqrt(3)));
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
                if (points[4].Y > ymax) break;

                // Draw the row.
                for (int col = 0; ; col++)
                {
                    // Get the points for the row's next hexagon.
                    points = ShapeToPoints(height, row, col);

                    // If it doesn't fit horizontally,
                    // we're done with this row.
                    if (points[3].X > xmax) break;

                    // If it fits vertically, draw it.
                    if (points[4].Y <= ymax)
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
            col = (int)(x / (width * 0.75f));

            if (col % 2 != 1)
                row = (int)Math.Floor(y / height);
            else
                row = (int)Math.Floor((y - height / 2) / height);

            // Find the test area.
            float testx = col * width * 0.75f;
            float testy = row * height;
            if (col % 2 == 1) testy += height / 2;

            // See if the point is above or
            // below the test hexagon on the left.
            bool is_above = false, is_below = false;
            float dx = x - testx;
            if (dx < width / 4)
            {
                float dy = y - (testy + height / 2);
                if (dx < 0.001)
                {
                    // The point is on the left edge of the test rectangle.
                    if (dy < 0) is_above = true;
                    if (dy > 0) is_below = true;
                }
                else if (dy < 0)
                {
                    // See if the point is above the test hexagon.
                    if (-dy / dx > Math.Sqrt(3)) is_above = true;
                }
                else
                {
                    // See if the point is below the test hexagon.
                    if (dy / dx > Math.Sqrt(3)) is_below = true;
                }
            }

            // Adjust the row and column if necessary.
            if (is_above)
            {
                if (col % 2 != 1) row--;
                col--;
            }
            else if (is_below)
            {
                if (col % 2 == 1) row++;
                col--;
            }
        }
    }
}
