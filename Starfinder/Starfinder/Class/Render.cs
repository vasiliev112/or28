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
using System.Threading;

namespace Starfinder
{
    public class Render
    {
        // Отрисовка зон коробля
        #region
        public void PainterLeftUp(object sender, PaintEventArgs e, Pen p, int Xsize, int weight, int height)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.DrawLine(p, Xsize * weight, Xsize * height, 0 + (weight * Xsize - (192 - 8)), 0);
            /*
            // Тест заливка треугольника
            Color brushColor = Color.FromArgb(250 / 100 * 25, 0, 255, 0);
            SolidBrush brush = new SolidBrush(brushColor);
            e.Graphics.FillPolygon(brush, new Point[]
            {
            new Point(0, 0),
            new Point(Xsize * weight, Xsize * height), 
            new Point(0 + (weight * Xsize - (192 - 8)),0), 
            new Point(0,Xsize * height)
            });
            */
        }

        public void PainterRightUp(object sender, PaintEventArgs e, Pen p, int Xsize, int weight, int height)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.DrawLine(p, 0, 0 + height * Xsize, 0 + (weight * Xsize) - ((weight * Xsize) - 192 + 8), 0);
        }

        public void PainterLeftDawn(object sender, PaintEventArgs e, Pen p, int Xsize, int weight, int height)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.DrawLine(p, 0 + (weight * Xsize), 0, 0 + (weight * Xsize - (192 - 8)), 0 + Xsize * height);
        }

        public void PainterRightDawn(object sender, PaintEventArgs e, Pen p, int Xsize, int weight, int height)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.DrawLine(p, 0, 0, 0 + (weight * Xsize) - ((weight * Xsize) - 192 + 8), 0 + height * Xsize);
        }
        public void PainterLeftFlat(object sender, PaintEventArgs e, Pen p, int Xsize, int weight, int height)
        {
            p.Width *= 2;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.DrawLine(p, 0, Xsize * height, 0 + Xsize * weight, 0 + Xsize * height);
        }
        public void PainterRightFlat(object sender, PaintEventArgs e, Pen p, int Xsize, int weight, int height)
        {
            p.Width *= 2;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.DrawLine(p, 0, 0, 0 + weight * Xsize, 0);
        }
        #endregion

        // Отрисовка квадратов
        public void PaintEarsMap(object sender, PaintEventArgs e, Pen p, int x, int y, int sizeW, int sizeH, int ScreenWidth, int ScreenHeight)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            for (int i = 0; i < Math.Ceiling(Convert.ToDouble(ScreenWidth) / sizeW); i++)
            {
                for (int j = 0; j < Math.Ceiling(Convert.ToDouble(ScreenHeight) / sizeH); j++)
                {
                    e.Graphics.DrawRectangle(p, x + i * sizeW, y + j * sizeH, 64, 64);
                }
                    
            }

            /*
            // Вертикальные линии
            for (int i = 0; i < Math.Ceiling(Convert.ToDouble(ScreenWidth) / sizeW); i++)
            {
                e.Graphics.DrawLine(p, x + i * sizeW, y, x + i * sizeW, y + ScreenHeight);
            }
            // Горизонтальные линии
            for (int i = 0; i < Math.Ceiling(Convert.ToDouble(ScreenHeight) / sizeH); i++)
            {
                e.Graphics.DrawLine(p, x, y + i * sizeH, x + ScreenWidth, y + i * sizeH);
            } 
            */
        }

        // Отрисовка гексов
    }
}
