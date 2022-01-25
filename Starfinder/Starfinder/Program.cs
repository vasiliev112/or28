using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Drawing;
using System.IO;

namespace Starfinder
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new StarfinderMainForm());
        }
    }

    public static class ControlMover
    {
        public static bool ChangeCursor { get; set; }
        public static bool AllowMove { get; set; }
        public static bool AllowResize { get; set; }
        public static bool BringToFront { get; set; }
        public static int ResizingMargin { get; set; }
        public static int MinSize { get; set; }

        private static Point startMouse;
        private static Point startLocation;
        private static Size startSize;
        private static bool resizing = false;
        static Cursor oldCursor;

        static ControlMover()
        {
            ResizingMargin = 5;
            MinSize = 10;
            ChangeCursor = false;
            AllowMove = true;
            AllowResize = true;
            BringToFront = true;
        }
        
        public static void Add(Control ctrl)
        {
            ctrl.MouseDown += ctrl_MouseDown;
            ctrl.MouseUp += ctrl_MouseUp;
            ctrl.MouseMove += ctrl_MouseMove;
        }
        
        private static void ctrl_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;
            var ctrl = (sender as Control);
            ctrl.Cursor = oldCursor;
        }
        
        public static void Remove(Control ctrl)
        {
            ctrl.MouseDown -= ctrl_MouseDown;
            ctrl.MouseUp -= ctrl_MouseUp;
            ctrl.MouseMove -= ctrl_MouseMove;
        }
        
        static void ctrl_MouseMove(object sender, MouseEventArgs e)
        {
            var ctrl = sender as Control;

            if (ChangeCursor)
            {
                if ((e.X >= ctrl.Width - ResizingMargin) && (e.Y >= ctrl.Height - ResizingMargin) && AllowResize)
                    ctrl.Cursor = Cursors.SizeNWSE;
                else
                if (AllowMove)
                    ctrl.Cursor = Cursors.SizeAll;
                else
                    ctrl.Cursor = Cursors.Default;
            }

            if (e.Button != MouseButtons.Left)
                return;
            //Курсор
            var l = ctrl.PointToScreen(e.Location);
            var dx = l.X - startMouse.X;
            var dy = l.Y - startMouse.Y;

            if (Math.Max(Math.Abs(dx), Math.Abs(dy)) > 1)
            {
                if (resizing)
                {
                    if (AllowResize)
                    {
                        ctrl.Size = new Size(Math.Max(MinSize, startSize.Width + dx), Math.Max(MinSize, startSize.Height + dy));
                        ctrl.Cursor = Cursors.SizeNWSE;
                        if (BringToFront) ctrl.BringToFront();
                    }
                }
                else
                {
                    if (AllowMove)
                    {
                        Point newLoc = startLocation + new Size(dx, dy);
                        if (newLoc.X < 0) newLoc = new Point(0, newLoc.Y);
                        if (newLoc.Y < 0) newLoc = new Point(newLoc.X, 0);
                        ctrl.Location = newLoc;
                        ctrl.Cursor = Cursors.SizeAll;
                        if (BringToFront) ctrl.BringToFront();
                    }
                }
            }
        }

        static void ctrl_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;

            var ctrl = sender as Control;

            resizing = (e.X >= ctrl.Width - ResizingMargin) && (e.Y >= ctrl.Height - ResizingMargin) && AllowResize;
            startSize = ctrl.Size;
            startMouse = ctrl.PointToScreen(e.Location);
            startLocation = ctrl.Location;
            oldCursor = ctrl.Cursor;
        }
    }

    static class Pr
    {
        public static List<object> idbox = new List<object>();
    }
}
