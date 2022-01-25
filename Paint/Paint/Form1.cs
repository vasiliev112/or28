using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            SetSize();
        }
        private class ArroyPoints 
        {
            private int index = 0;
            private Point[] points;

            public ArroyPoints(int size)
            {
                if (size <= 0)
                    size = 2;

                points = new Point[size];
            }

            public void SetPoint(int x, int y)
            {
                if (index >= points.Length)
                    index = 0;

                points[index] = new Point(x,y);
                index++;
            }

            public void ResetPoints()
            {
                index = 0;
            }

            public int GetCountPoints()
            {
                 return index;
            }

            public Point[] GetPoints()
            {
                return points;
            }
        }

        private bool isMause = false;
        private ArroyPoints arroyPoints = new ArroyPoints(2);

        Bitmap map = new Bitmap(100, 100);
        Graphics graphics;
        Pen pen = new Pen(Color.Black, 3f);

        private void SetSize()
        {
            Rectangle rectangle = Screen.PrimaryScreen.Bounds;
            map = new Bitmap(rectangle.Width, rectangle.Height);
            graphics = Graphics.FromImage(map);

            pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
        }
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            isMause = true;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            isMause = false;
            arroyPoints.ResetPoints();
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (!isMause)
                return;

            arroyPoints.SetPoint(e.X, e.Y);

            if (arroyPoints.GetCountPoints() >= 2)
            {
                graphics.DrawLines(pen, arroyPoints.GetPoints());
                pictureBoxPaint.Image = map;
                // Если закомментировать то линия в  виде штриха
                arroyPoints.SetPoint(e.X, e.Y);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            pen.Color = ((Button)sender).BackColor;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                pen.Color = colorDialog1.Color;
                ((Button)sender).BackColor = colorDialog1.Color;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            graphics.Clear(pictureBoxPaint.BackColor);
            pictureBoxPaint.Image = map;
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            pen.Width = trackBar1.Value;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //savedialog.Filter = "Image Files(*.PNG)|*.PNG|*.BMP|Image Files(*.JPG)|*.JPG|Image Files(*.GIF)|*.GIF|Image Files(*.BMP)|All files (*.*)|*.*";

            if (pictureBoxPaint.Image != null) //если в pictureBox есть изображение
            {
                //создание диалогового окна "Сохранить как..", для сохранения изображения
                SaveFileDialog savedialog = new SaveFileDialog();
                savedialog.Title = "Сохранить картинку как...";
                //отображать ли предупреждение, если пользователь указывает имя уже существующего файла
                savedialog.OverwritePrompt = true;
                //отображать ли предупреждение, если пользователь указывает несуществующий путь
                savedialog.CheckPathExists = true;
                //список форматов файла, отображаемый в поле "Тип файла"
                savedialog.Filter = "Image Files(*.PNG)|*.PNG|Image Files(*.JPG)|*.JPG|All files (*.*)|*.*";
                //отображается ли кнопка "Справка" в диалоговом окне
                savedialog.ShowHelp = true;
                if (savedialog.ShowDialog() == DialogResult.OK) //если в диалоговом окне нажата кнопка "ОК"
                {
                    try
                    {
                        pictureBoxPaint.Image.Save(savedialog.FileName, System.Drawing.Imaging.ImageFormat.Png);
                    }
                    catch
                    {
                        MessageBox.Show("Невозможно сохранить изображение", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else if (pictureBoxPaint.Image == null)
                MessageBox.Show("Поле не содержит изображения");
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Bitmap image; //Bitmap для открываемого изображения

            OpenFileDialog open_dialog = new OpenFileDialog(); //создание диалогового окна для выбора файла
            open_dialog.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG|All files (*.*)|*.*"; //формат загружаемого файла
            if (open_dialog.ShowDialog() == DialogResult.OK) //если в окне была нажата кнопка "ОК"
            {
                try
                {
                    image = new Bitmap(open_dialog.FileName);
                    this.pictureBoxPaint.Size = image.Size;
                    pictureBoxPaint.SizeMode = PictureBoxSizeMode.Zoom;                    
                    pictureBoxPaint.Image = image;
                    pictureBoxPaint.Invalidate();
                }
                catch
                {
                    DialogResult rezult = MessageBox.Show("Невозможно открыть выбранный файл",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
    }
}
