using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Starfinder
{
    public partial class MapsForm : Form
    {
        //private object currentobject = null;
        public int numbE = 0;
        public int numbH = 0;
        public bool povorot = false;
        public string fname;
        string pathxml = @"\xml\";

        public int sizeH = 64;
        public int sizeW = 64;

        Size resolution = Screen.PrimaryScreen.Bounds.Size;

        public List<Hero> Heroes = new List<Hero>();
        public List<PictureBox> idboxH = new List<PictureBox>();
        public List<Enemy> Enemys = new List<Enemy>();
        public List<PictureBox> idbox = new List<PictureBox>();
        public List<PictureBox> idboxEdop = new List<PictureBox>();
        private IconMapsForm f2;
        private Info inf = new Info();

        public MapsForm()
        {
            InitializeComponent();

            this.f2 = new IconMapsForm(this);
            this.f2.Show();

            if (Global.Gmapears)
            {
                this.Paint += PaintEarsMap;
                Global.Gmapears = false;
            }

            if (Global.Gmaspaсe)
            {
                this.Paint += PaintSpaceMap;
                Global.Gmaspaсe = false;
            }
        }

        public void PaintEarsMap(object sender, PaintEventArgs e)
        {
            Render r = new Render();

            Pen p = new Pen(Color.Red, 2);

            r.PaintEarsMap(sender, e, p, 0, 0, sizeW, sizeH, resolution.Width, resolution.Width);
        }

        public void PaintSpaceMap(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            double mod = 0;
            int x = 0;
            int y = 0;
            int a = 19 + Convert.ToInt32(Math.Ceiling(Convert.ToDouble(19) * mod));
            int b = 36 + Convert.ToInt32(Math.Ceiling(Convert.ToDouble(36) * mod));
            int allwidht = 74 + Convert.ToInt32(Math.Ceiling(Convert.ToDouble(74) * mod));
            int allheight = 64 + Convert.ToInt32(Math.Ceiling(Convert.ToDouble(64) * mod));

            //Pen p = new Pen(Color.FromArgb(92, 0, 165), 2);
            Pen p = new Pen(Color.White, 2);

            // Линия слева вверху "/"
            for (int j = 0; j < Math.Ceiling(Convert.ToDouble(resolution.Height) / allheight); j++)
            {
                for (int i = 0; i < Math.Ceiling(Convert.ToDouble(resolution.Width) / allwidht); i++)
                {
                    e.Graphics.DrawLine(p, x + i * (allwidht + b), y + (allheight/2) + j * allheight, x + a + i * (allwidht + b), y + j * allheight);
                }
            }

            // Линия слева вверху первого ряда "_"
            for (int j = 0; j < Math.Ceiling(Convert.ToDouble(resolution.Height) / allheight); j++)
            {
                for (int i = 0; i < Math.Ceiling(Convert.ToDouble(resolution.Width) / allwidht); i++)
                {
                    e.Graphics.DrawLine(p, x + a + i * (allwidht + b), y + j * allheight, x + a + b + i * (allwidht + b), y + j * allheight);
                }
            }

            // Линия справа вверху "\"
            for (int j = 0; j < Math.Ceiling(Convert.ToDouble(resolution.Height) / allheight); j++)
            {
                for (int i = 0; i < Math.Ceiling(Convert.ToDouble(resolution.Width) / allwidht); i++)
                {
                    e.Graphics.DrawLine(p, x + a + b + i * (allwidht + b), y + j * allheight, x + allwidht + i * (allwidht + b), y + (allheight / 2) + j * allheight);
                }
            }

            // Линия слева внизу "\"
            for (int j = 0; j < Math.Ceiling(Convert.ToDouble(resolution.Height) / allheight); j++)
            {
                for (int i = 0; i < Math.Ceiling(Convert.ToDouble(resolution.Width) / allwidht); i++)
                {
                    e.Graphics.DrawLine(p, x + i * (allwidht + b), y + (allheight / 2) + j * allheight, x + a + i * (allwidht + b), y + allheight + j * allheight);
                }
            }

            // Линия справа снизу "/"
            for (int j = 0; j < Math.Ceiling(Convert.ToDouble(resolution.Height) / allheight); j++)
            {
                for (int i = 0; i < Math.Ceiling(Convert.ToDouble(resolution.Width) / allwidht); i++)
                {
                    e.Graphics.DrawLine(p, x + a + b + i * (allwidht + b), y + allheight + j * allheight, x + allwidht + i * (allwidht + b), y + (allheight / 2) + j * allheight);
                }
            }
            
            // Линия слева вверху второго ряда "_"
            for (int j = 0; j < Math.Ceiling(Convert.ToDouble(resolution.Height) / allheight); j++)
            {
                for (int i = 0; i < Math.Ceiling(Convert.ToDouble(resolution.Width) / allwidht); i++)
                {
                    e.Graphics.DrawLine(p, x + allwidht + i * (allwidht + b), y + (allheight / 2) + j * allheight, x + allwidht + b + i * (allwidht + b), y + (allheight / 2) + j * allheight);
                }
            }
        }

        private void buttonLoadEarsMap_Click(object sender, EventArgs e)
        {
            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                    return;
                // получаем выбранный файл
                string filename = openFileDialog1.FileName;
                // читаем файл в строку
                this.BackgroundImage = Image.FromFile(filename); 
            }
            catch
            {
                inf.messageerrorfile();
            }

            
        }
        private void HeroesCreate_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.f2 != null)
                {

                    var pbHero = new PictureBox() { Parent = this };

                    {
                        if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                            return;
                        // получаем выбранный файл
                        string filename = openFileDialog1.FileName;
                        // читаем файл в строку
                        pbHero.Image = Image.FromFile(filename);
                    }
                    //Путь к файлу
                    //pb.Image = Image.FromFile(@"E:/ВТВ/Images/1.png");

                    pbHero.SizeMode = PictureBoxSizeMode.Zoom;
                    pbHero.Size = new Size(sizeH, sizeW);
                    pbHero.Location = new Point(109, 55);
                    pbHero.BackColor = Color.Transparent;
                    pbHero.BringToFront();
                    ControlMover.Add(pbHero);

                    idboxH.Add(pbHero);

                    Hero tomHero = new Hero();
                    Heroes.Add(tomHero);
                    f2.NameBoxH.Items.Add(Heroes[numbH].name + "-" + numbH);
                    f2.InitiativeBoxH.Items.Add(Heroes[numbH].init);
                    f2.KacBoxH.Items.Add(Heroes[numbH].kac);
                    f2.EacBoxH.Items.Add(Heroes[numbH].eac);
                    f2.MaxXPBoxH.Items.Add(Heroes[numbH].maxhp);
                    f2.CurXPBoxH.Items.Add(Heroes[numbH].curhp);

                    Heroes[numbE].width = sizeW;
                    Heroes[numbE].height = sizeH;

                    numbH += 1;
                }
            }

            catch
            {
                inf.messageerror();
            }
        }

        private void EnemiesCreate_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.f2 != null)
                {
                    
                    var pb = new PictureBox() { Parent = this };

                    if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                        return;
                    // получаем выбранный файл
                    string filename = openFileDialog1.FileName;
                    // читаем файл в строку
                    pb.Image = Image.FromFile(filename);
                    // Убирает расширение картинки, добавляет расширение .xml
                    fname = Path.GetFileNameWithoutExtension(filename) + ".xml";
                    // Путь - директория программы + папка + имя картинки.xml
                    string path = Directory.GetCurrentDirectory() + pathxml + fname;

                    if (File.Exists(path))
                    {
                        Enemy tom = new Enemy();
                        Enemys.Add(tom);

                        XmlSerializer formatter = new XmlSerializer(typeof(Enemy[]));
                        using (FileStream fs = new FileStream(path, FileMode.Open))
                        {
                            Enemy[] newenemy = (Enemy[])formatter.Deserialize(fs);

                            Dice d = new Dice();
                            //IFormatProvider formatterr = new NumberFormatInfo { NumberDecimalSeparator = "." };
                            foreach (Enemy p in newenemy)
                            {
                                Enemys[numbE].name = p.name;
                                Enemys[numbE].cat = p.cat;
                                Enemys[numbE].cr = p.cr;
                                //Enemys[numb].cr = double.Parse(p.cr.ToString(), formatterr);
                                Enemys[numbE].exp = p.exp;
                                Enemys[numbE].init = (Convert.ToDouble(p.init) + d.D20()).ToString();
                                Enemys[numbE].speed = p.speed;
                                Enemys[numbE].kac = p.kac;
                                Enemys[numbE].eac = p.eac;
                                Enemys[numbE].fortitude = p.fortitude;
                                Enemys[numbE].reflex = p.reflex;
                                Enemys[numbE].will = p.will;
                                Enemys[numbE].maxhp = p.maxhp;
                                Enemys[numbE].curhp = p.maxhp;

                                switch (p.cat)
                                {
                                    case "Крошеччный":
                                        Enemys[numbE].width = sizeW / 2;
                                        Enemys[numbE].height = sizeH / 2;
                                        break;
                                    case "Миниатюрный":
                                        Enemys[numbE].width = sizeW / 2;
                                        Enemys[numbE].height = sizeH / 2;
                                        break;
                                    case "Маленький":
                                        Enemys[numbE].width = sizeW / 2;
                                        Enemys[numbE].height = sizeH / 2;
                                        break;
                                    case "Небольшой":
                                        Enemys[numbE].width = sizeW;
                                        Enemys[numbE].height = sizeH;
                                        break;
                                    case "Средний":
                                        Enemys[numbE].width = sizeW;
                                        Enemys[numbE].height = sizeH;
                                        break;
                                    case "Крупный":
                                        Enemys[numbE].width = sizeW * 2;
                                        Enemys[numbE].height = sizeH * 2;
                                        break;
                                    case "Огромный":
                                        Enemys[numbE].width = sizeW * 3;
                                        Enemys[numbE].height = sizeH * 3;
                                        break;
                                    case "Гигантский":
                                        Enemys[numbE].width = sizeW * 4;
                                        Enemys[numbE].height = sizeH * 4;
                                        break;
                                    case "Коллосальный":
                                        Enemys[numbE].width = sizeW * 6;
                                        Enemys[numbE].height = sizeH * 6;
                                        break;
                                    default:
                                        MessageBox.Show("Не правильная категория размера");
                                        break;
                                }
                            }
                        }

                        f2.NameBoxE.Items.Add(Enemys[numbE].name + "-" + numbE);
                        f2.InitiativeBoxE.Items.Add(Enemys[numbE].init);
                        f2.KacBoxE.Items.Add(Enemys[numbE].kac);
                        f2.EacBoxE.Items.Add(Enemys[numbE].eac);
                        f2.MaxXPBoxE.Items.Add(Enemys[numbE].maxhp);
                        f2.CurXPBoxE.Items.Add(Enemys[numbE].curhp);

                        //Путь к файлу
                        //pb.Image = Image.FromFile(@"E:/ВТВ/Images/1.png");                    

                        pb.SizeMode = PictureBoxSizeMode.Zoom;
                        pb.Size = new Size(Enemys[numbE].width, Enemys[numbE].height);
                        pb.Location = new Point((74*4) + 5 + (36 * 4), 64 * 4);
                        pb.BackgroundImage = imageList1.Images[0];
                        pb.BackgroundImageLayout = ImageLayout.Center;
                        pb.BackColor = Color.FromName("Green");
                        //pb.BackColor = Color.Transparent;  
                        ControlMover.Add(pb);

                        idbox.Add(pb);
                        pb.BringToFront();
                        numbE++;

                    }

                    else
                    {
                        pb.Dispose();
                        MessageBox.Show("Отсутствует xml файл с таким именем");
                    }
                }
            
            }
            
            catch
            {
                inf.messageerror();
            }
            
        }

        //Dop

        public void button3_Click(object sender, EventArgs e)
        {
            
            try
            {
                //listBox_1.Items.Add(idbox.Count);
                if (this.f2 == null)
                {
                    this.f2 = new IconMapsForm(this);
                    f2.FormClosed += new FormClosedEventHandler(FormClosed_1);
                }

                this.f2.Show();
            }

            catch
            {
                inf.messageerror();
            }
            
        }

        private void FormClosed_1(object sender, FormClosedEventArgs e)
        {
            this.f2 = null;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (idbox.Count !=0)
                {
                    for (int i = idbox.Count - 1; i >= 0; i--)
                    {                        
                        idbox[i].Dispose();
                        Enemys.RemoveAt(i);
                        idbox.RemoveAt(i);
                        f2.NameBoxE.Items.RemoveAt(i);
                        f2.InitiativeBoxE.Items.RemoveAt(i);
                        f2.KacBoxE.Items.RemoveAt(i);
                        f2.EacBoxE.Items.RemoveAt(i);
                        f2.MaxXPBoxE.Items.RemoveAt(i);
                        f2.CurXPBoxE.Items.RemoveAt(i);
                    }
                    
                    //MessageBox.Show("idbox: " + idbox.Count.ToString());
                    //MessageBox.Show("Enemys: " + Enemys.Count.ToString());
                }

                numbE = 0;
                
            }

            catch
            {
                inf.messageerror();
            }
        }

        private void buttonClearH_Click(object sender, EventArgs e)
        {
            try
            {
                
                if (idboxH.Count != 0)
                {
                    for (int i = idboxH.Count - 1; i >= 0; i--)
                    {
                        idboxH[i].Dispose();
                        Heroes.RemoveAt(i);
                        idboxH.RemoveAt(i);
                        f2.NameBoxH.Items.RemoveAt(i);
                        f2.InitiativeBoxH.Items.RemoveAt(i);
                        f2.KacBoxH.Items.RemoveAt(i);
                        f2.EacBoxH.Items.RemoveAt(i);
                        f2.MaxXPBoxH.Items.RemoveAt(i);
                        f2.CurXPBoxH.Items.RemoveAt(i);
                    }

                    //MessageBox.Show("idbox: " + idbox.Count.ToString());
                    //MessageBox.Show("Enemys: " + Enemys.Count.ToString());
                }

                numbH = 0;
            }

            catch
            {
                inf.messageerror();
            }
        }

        
        public static Image resizeImage(Image imgToResize, Size size)
        {
            return (Image)(new Bitmap(imgToResize, size));
        }

        public void pictureBox_PaintH(object sender, PaintEventArgs e)
        {
            e.Graphics.TranslateTransform(idboxH[f2.nH].Width / 2, idboxH[f2.nH].Height / 2);
            e.Graphics.RotateTransform(Heroes[f2.nH].angle);
            e.Graphics.DrawImage(resizeImage(idboxH[f2.nH].Image, new Size(idboxH[f2.nH].Width, idboxH[f2.nH].Height)), -idboxH[f2.nH].Width / 2, -idboxH[f2.nH].Height / 2);
            e.Graphics.RotateTransform(-Heroes[f2.nE].angle);
            e.Graphics.TranslateTransform(-idboxH[f2.nH].Width / 2, -idboxH[f2.nH].Height / 2);
        }

        public void pictureBox_PaintE(object sender, PaintEventArgs e)
        {
            e.Graphics.TranslateTransform(idbox[f2.nE].Width / 2, idbox[f2.nE].Height / 2);
            e.Graphics.RotateTransform(Enemys[f2.nE].angle);
            e.Graphics.DrawImage(resizeImage(idbox[f2.nE].Image, new Size(idbox[f2.nE].Width, idbox[f2.nE].Height)), -idbox[f2.nE].Width / 2, -idbox[f2.nE].Height / 2);
            e.Graphics.RotateTransform(-Enemys[f2.nE].angle);
            e.Graphics.TranslateTransform(-idbox[f2.nE].Width / 2, -idbox[f2.nE].Height / 2);
        }

        private void MapsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Global.GopenForms = false;
            if (f2 != null)
            f2.Close();
        }
    }
}
