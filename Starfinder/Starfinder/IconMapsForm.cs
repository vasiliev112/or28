using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Starfinder
{

    public partial class IconMapsForm : Form
    {
        private Info inf = new Info();
        private MapsForm f1;
        private int time = 250;
        private Color changecol = Color.Gray;
        public List<double> initlist = new List<double>();
        public List<string> initlistname = new List<string>();
        public List<Control> gran = new List<Control>();
        //public string Inisiative;

        public int nE;
        public int nH;

        public IconMapsForm(MapsForm _f1)
        {
            InitializeComponent();
            openFileDialog1.Filter = "Image Files(*.BMP;*.PNG;*.JPG;*.GIF)|*.BMP;*.PNG;*.JPG;*.GIF|All files (*.*)|*.*";
            this.f1 = _f1;
            DMGcheckBox.Checked = true;

        }

        private void IconMapsForm_Load(object sender, EventArgs e)
        {

        }

        private void RenameButtonE_Click(object sender, EventArgs e)
        {
            try
            {
                if (NameBoxE.SelectedIndex != -1)
                {
                    int n = NameBoxE.SelectedIndex;
                    f1.Enemys[n].name = RenameTexboxE.Text;
                    NameBoxE.Items.RemoveAt(n);
                    NameBoxE.Items.Insert(n, f1.Enemys[n].name + NameBoxE.SelectedIndex);
                }
            }

            catch
            {
                inf.messageerror();
            }

        }

        private void InitiativeButtonE_Click(object sender, EventArgs e)
        {
            try
            {
                if (InitiativeBoxE.SelectedIndex != -1)
                {
                    int n = InitiativeBoxE.SelectedIndex;
                    f1.Enemys[n].init = InitiativeTexboxE.Text;
                    InitiativeBoxE.Items.RemoveAt(n);
                    InitiativeBoxE.Items.Insert(n, f1.Enemys[n].init);
                }
            }

            catch
            {
                inf.messageerrorint();
            }
        }

        private void KacButtonE_Click(object sender, EventArgs e)
        {
            try
            {
                if (KacBoxE.SelectedIndex != -1)
                {
                    int n = KacBoxE.SelectedIndex;
                    f1.Enemys[n].kac = Convert.ToInt32(KacTexboxE.Text);
                    KacBoxE.Items.RemoveAt(n);
                    KacBoxE.Items.Insert(n, f1.Enemys[n].kac);
                }
            }

            catch
            {
                inf.messageerrorint();
            }
        }

        private void EacButtonE_Click(object sender, EventArgs e)
        {
            try
            {
                if (EacBoxE.SelectedIndex != -1)
                {
                    int n = EacBoxE.SelectedIndex;
                    f1.Enemys[n].eac = Convert.ToInt32(EacTexboxE.Text);
                    EacBoxE.Items.RemoveAt(n);
                    EacBoxE.Items.Insert(n, f1.Enemys[n].eac);
                }
            }

            catch
            {
                inf.messageerrorint();
            }
        }

        private void MaxXPButtonE_Click(object sender, EventArgs e)
        {
            try
            {
                if (MaxXPBoxE.SelectedIndex != -1)
                {
                    int n = MaxXPBoxE.SelectedIndex;
                    f1.Enemys[n].maxhp = Convert.ToInt32(MaxXPTexboxE.Text);
                    MaxXPBoxE.Items.RemoveAt(n);
                    MaxXPBoxE.Items.Insert(n, f1.Enemys[n].maxhp);
                    f1.Enemys[n].curhp = f1.Enemys[n].maxhp;
                    CurXPBoxE.Items.RemoveAt(n);
                    CurXPBoxE.Items.Insert(n, f1.Enemys[n].maxhp);
                }
            }

            catch
            {
                inf.messageerrorint();
            }
        }

        private void CurXPButtonE_Click(object sender, EventArgs e)
        {
            try
            {
                if (CurXPBoxE.SelectedIndex != -1)
                {
                    int n = CurXPBoxE.SelectedIndex;
                    f1.Enemys[n].DMG(Convert.ToInt32(CurXPTexboxE.Text));
                    CurXPBoxE.Items.RemoveAt(n);
                    CurXPBoxE.Items.Insert(n, f1.Enemys[n].curhp);
                    double xppercent = f1.Enemys[n].curhp / (f1.Enemys[n].maxhp * 0.01);
                    if (f1.idbox.Count != 0 && DMGcheckBox.Checked == true)
                    {
                        if (xppercent >= 66)
                            f1.idbox[n].BackColor = Color.FromName("Green");
                        else if (xppercent < 66 && xppercent > 33)
                            f1.idbox[n].BackColor = Color.FromName("Orange");
                        else if (xppercent <= 33 && xppercent > 0)
                            f1.idbox[n].BackColor = Color.FromName("Red");
                        else if (xppercent <= 0)
                            f1.idbox[n].BackColor = Color.FromName("Black");
                        //f1.idbox[n].Focus();
                    }

                    //f1.idbox[n].Refresh();

                }
            }

            catch
            {
                inf.messageerrorint();
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            try
            {
                if (NameBoxH.SelectedIndex != -1)
                {
                    int n = NameBoxH.SelectedIndex;
                    f1.Heroes[n].name = RenameTexboxH.Text;
                    NameBoxH.Items.RemoveAt(n);
                    NameBoxH.Items.Insert(n, f1.Heroes[n].name);
                }
            }

            catch
            {
                inf.messageerror();
            }
        }

        private void InitiativeButtonH_Click(object sender, EventArgs e)
        {
            try
            {
                if (InitiativeBoxH.SelectedIndex != -1)
                {
                    int n = InitiativeBoxH.SelectedIndex;
                    f1.Heroes[n].init = Convert.ToDouble(InitiativeTexboxH.Text);
                    InitiativeBoxH.Items.RemoveAt(n);
                    InitiativeBoxH.Items.Insert(n, f1.Heroes[n].init);
                }
            }

            catch
            {
                inf.messageerrorint();
            }
        }

        private void KacButtonH_Click(object sender, EventArgs e)
        {
            try
            {
                if (KacBoxH.SelectedIndex != -1)
                {
                    int n = KacBoxH.SelectedIndex;
                    f1.Heroes[n].kac = Convert.ToInt32(KacTexboxH.Text);
                    KacBoxH.Items.RemoveAt(n);
                    KacBoxH.Items.Insert(n, f1.Heroes[n].kac);
                }
            }

            catch
            {
                inf.messageerrorint();
            }
        }

        private void EacButtonH_Click(object sender, EventArgs e)
        {
            try
            {
                if (EacBoxH.SelectedIndex != -1)
                {
                    int n = EacBoxH.SelectedIndex;
                    f1.Heroes[n].eac = Convert.ToInt32(EacTexboxH.Text);
                    EacBoxH.Items.RemoveAt(n);
                    EacBoxH.Items.Insert(n, f1.Heroes[n].eac);
                }
            }

            catch
            {
                inf.messageerrorint();
            }
        }

        private void MaxXPButtonH_Click(object sender, EventArgs e)
        {
            try
            {
                if (MaxXPBoxH.SelectedIndex != -1)
                {
                    int n = MaxXPBoxH.SelectedIndex;
                    f1.Heroes[n].maxhp = Convert.ToInt32(MaxXPTexboxH.Text);
                    MaxXPBoxH.Items.RemoveAt(n);
                    MaxXPBoxH.Items.Insert(n, f1.Heroes[n].maxhp);
                    f1.Heroes[n].curhp = f1.Heroes[n].maxhp;
                    CurXPBoxH.Items.RemoveAt(n);
                    CurXPBoxH.Items.Insert(n, f1.Heroes[n].maxhp);
                }
            }

            catch
            {
                inf.messageerrorint();
            }
        }

        private void CurXPButtonH_Click(object sender, EventArgs e)
        {
            try
            {
                if (CurXPBoxH.SelectedIndex != -1)
                {
                    int n = CurXPBoxH.SelectedIndex;
                    f1.Heroes[n].DMG(Convert.ToInt32(CurXPTexboxH.Text));
                    CurXPBoxH.Items.RemoveAt(n);
                    CurXPBoxH.Items.Insert(n, f1.Heroes[n].curhp);
                }
            }

            catch
            {
                inf.messageerrorint();
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (NameBoxH.SelectedIndex != -1)
                {
                    int n = NameBoxH.SelectedIndex;
                    nH = NameBoxE.SelectedIndex;

                    f1.Heroes[n].angle += 60f;

                    f1.idboxH[n].Bounds = new Rectangle(f1.idboxH[n].Location.X, f1.idboxH[n].Location.Y, f1.sizeW, f1.sizeH);
                    f1.idboxH[n].Paint += new PaintEventHandler(f1.pictureBox_PaintH);
                    f1.idboxH[n].Invalidate();
                }
            }

            catch
            {
                inf.messageerror();
            }

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (NameBoxE.SelectedIndex != -1)
                {                    
                    int n = NameBoxE.SelectedIndex;
                    nE = NameBoxE.SelectedIndex;
                    f1.Enemys[n].angle += 60f;

                    f1.idbox[n].Bounds = new Rectangle(f1.idbox[n].Location.X, f1.idbox[n].Location.Y, f1.Enemys[n].width, f1.Enemys[n].height);
                    f1.idbox[n].Paint += new PaintEventHandler(f1.pictureBox_PaintE);
                    f1.idbox[n].Invalidate();
                }
            }

            catch
            {
                inf.messageerror();
            }

        }        
        
        private void NameBoxH_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (NameBoxH.SelectedIndex != -1)
            {                
                int n = NameBoxH.SelectedIndex;

                InitiativeBoxH.SelectedIndex = n;
                KacBoxH.SelectedIndex = n;
                EacBoxH.SelectedIndex = n;
                MaxXPBoxH.SelectedIndex = n;
                CurXPBoxH.SelectedIndex = n;                 
            }
        }

        //При выборе поля из списка Enemy
        #region
        private void NameBoxE_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (NameBoxE.SelectedIndex != -1)
            {
                int n = NameBoxE.SelectedIndex;

                InitiativeBoxE.SelectedIndex = n;
                KacBoxE.SelectedIndex = n;
                EacBoxE.SelectedIndex = n;
                MaxXPBoxE.SelectedIndex = n;
                CurXPBoxE.SelectedIndex = n;
            }    
        }
        private void InitiativeBoxE_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int n = InitiativeBoxE.SelectedIndex;
                NameBoxE.SelectedIndex = n;
                KacBoxE.SelectedIndex = n;
                EacBoxE.SelectedIndex = n;
                MaxXPBoxE.SelectedIndex = n;
                CurXPBoxE.SelectedIndex = n;
            }
            catch
            {
                inf.messageerror();
            }

        }        private void KacBoxE_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int n = KacBoxE.SelectedIndex;
                NameBoxE.SelectedIndex = n;
                InitiativeBoxE.SelectedIndex = n;
                EacBoxE.SelectedIndex = n;
                MaxXPBoxE.SelectedIndex = n;
                CurXPBoxE.SelectedIndex = n;
            }
            catch
            {
                inf.messageerror();
            }
        }
        private void EacBoxE_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int n = EacBoxE.SelectedIndex;
                NameBoxE.SelectedIndex = n;
                InitiativeBoxE.SelectedIndex = n;
                KacBoxE.SelectedIndex = n;
                MaxXPBoxE.SelectedIndex = n;
                CurXPBoxE.SelectedIndex = n;
            }
            catch
            {
                inf.messageerror();
            }
        }
        private void MaxXPBoxE_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int n = MaxXPBoxE.SelectedIndex;
                NameBoxE.SelectedIndex = n;
                InitiativeBoxE.SelectedIndex = n;
                KacBoxE.SelectedIndex = n;
                EacBoxE.SelectedIndex = n;
                CurXPBoxE.SelectedIndex = n;
            }
            catch
            {
                inf.messageerror();
            }
        }
        private void CurXPBoxE_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int n = CurXPBoxE.SelectedIndex;
                NameBoxE.SelectedIndex = n;
                InitiativeBoxE.SelectedIndex = n;
                KacBoxE.SelectedIndex = n;
                EacBoxE.SelectedIndex = n;
                MaxXPBoxE.SelectedIndex = n;
            }
            catch
            {
                inf.messageerror();
            }
        }
        #endregion

        //От D4 до D100
        #region
        private void buttonD2_Click(object sender, EventArgs e)
        {
            Dice d = new Dice(); 
            buttonD2.Text = numericD2.Value + "D2: " + (Convert.ToInt32(numericD2.Value) * d.D2()).ToString();
            Color col = buttonD2.BackColor;
            buttonD2.BackColor = changecol;
            Task.Delay(time).Wait();
            buttonD2.BackColor = col;
        }

        private void buttonD4_Click(object sender, EventArgs e)
        {
            Dice d = new Dice(); 
            buttonD4.Text = numericD4.Value + "D4: " + (Convert.ToInt32(numericD4.Value) * d.D4()).ToString();
            Color col = buttonD4.BackColor;
            buttonD4.BackColor = changecol;
            Task.Delay(time).Wait();
            buttonD4.BackColor = col;
        }

        private void buttonD6_Click(object sender, EventArgs e)
        {
            Dice d = new Dice(); 
        buttonD6.Text = numericD6.Value + "D6: " + (Convert.ToInt32(numericD6.Value) * d.D6()).ToString();
            Color col = buttonD6.BackColor;
            buttonD6.BackColor = changecol;
            Task.Delay(time).Wait();
            buttonD6.BackColor = col;
        }

        private void buttonD8_Click(object sender, EventArgs e)
        {
            Dice d = new Dice(); 
        buttonD8.Text = numericD8.Value + "D8: " + (Convert.ToInt32(numericD8.Value) * d.D8()).ToString();
            Color col = buttonD8.BackColor;
            buttonD8.BackColor = changecol;
            Task.Delay(time).Wait();
            buttonD8.BackColor = col;
        }

        private void buttonD10_Click(object sender, EventArgs e)
        {
            Dice d = new Dice();
            buttonD10.Text = numericD10.Value + "D10: " + (Convert.ToInt32(numericD10.Value) * d.D10()).ToString();
            Color col = buttonD10.BackColor;
            buttonD10.BackColor = changecol;
            Task.Delay(time).Wait();
            buttonD10.BackColor = col;
        }

        private void buttonD12_Click(object sender, EventArgs e)
        {
            Dice d = new Dice();
            buttonD12.Text = numericD12.Value + "D12: " + (Convert.ToInt32(numericD12.Value) * d.D12()).ToString();
            Color col = buttonD12.BackColor;
            buttonD12.BackColor = changecol;
            Task.Delay(time).Wait();
            buttonD12.BackColor = col;
        }

        private void buttonD20_Click(object sender, EventArgs e)
        {
            Dice d = new Dice(); 
            buttonD20.Text = numericD20.Value + "D20: " + (Convert.ToInt32(numericD20.Value) * d.D20()).ToString();
            Color col = buttonD20.BackColor;
            buttonD20.BackColor = changecol;
            Task.Delay(time).Wait();
            buttonD20.BackColor = col;
        }

        private void buttonD100_Click(object sender, EventArgs e)
        {
            Dice d = new Dice();
            buttonD100.Text = numericD100.Value + "D100: " + (Convert.ToInt32(numericD100.Value) * d.D100()).ToString();
            //buttonD100.FlatAppearance.BorderColor = Color.Red;
            //Thread.Sleep(250);
            //buttonD100.FlatAppearance.BorderColor = Color.Red;
            // Text
            //buttonD100.ForeColor = Color.Red;
            // Fone
            Color col = buttonD100.BackColor;
            buttonD100.BackColor = changecol;            
            Task.Delay(time).Wait();
            buttonD100.BackColor = col;
        }
        #endregion

        private void buttonSearchH_MouseDown(object sender, MouseEventArgs e)
        {
            /*
            Pen p = new Pen(Color.FromArgb(90, 0, 165), 12);

            if (NameBoxH.SelectedIndex != -1)
            {              
                int n = NameBoxH.SelectedIndex;

                Graphics g = Graphics.FromHwnd(f1.idboxH[n].Handle);
                g.DrawRectangle(p, 0, 0, f1.idboxH[n].Width, f1.idboxH[n].Height);                            
            }
            */
            //Pen p = new Pen(Color.FromArgb(90, 0, 165), 12);
            Pen p = new Pen(Color.Red, 10);

            if (NameBoxH.SelectedIndex != -1)
            {
                int n = NameBoxH.SelectedIndex;

                // Доп квадрат LeftUp
                /*
                var pbox = new PictureBox();
                pbox.SizeMode = PictureBoxSizeMode.Zoom;
                pbox.Size = new Size(f1.Enemys[n].sizeW * 3, f1.Enemys[n].sizeH * 3);
                pbox.Location = new Point(f1.idbox[n].Location.X - f1.Enemys[n].sizeW, f1.idbox[n].Location.Y - f1.Enemys[n].sizeH);
                pbox.BackColor = Color.Transparent;
                //pbox.BackColor = Color.FromName("Green");
                f1.Controls.Add(pbox);
                f1.idboxEdop.Insert(n, pbox);
                */

                Graphics g = Graphics.FromHwnd(f1.idboxH[n].Handle);
                g.DrawRectangle(p, 0, 0, f1.idboxH[n].Width, f1.idboxH[n].Height);

                int Xsize = 5;

                // Доп квадрат LeftUp
                var pbox1 = new PictureBox();
                pbox1.SizeMode = PictureBoxSizeMode.Zoom;
                pbox1.Size = new Size(f1.Heroes[n].width * Xsize, f1.Heroes[n].height * Xsize);
                pbox1.Location = new Point(f1.idboxH[n].Location.X + (f1.Heroes[n].width / 2) - pbox1.Size.Width, f1.idboxH[n].Location.Y + (f1.Heroes[n].height / 2) - pbox1.Size.Height);
                pbox1.BackColor = Color.Transparent;
                //pbox1.BackColor = Color.Green;
                pbox1.BringToFront();
                f1.Controls.Add(pbox1);
                gran.Add(pbox1);

                // Доп квадрат RightUp
                var pbox2 = new PictureBox();
                pbox2.SizeMode = PictureBoxSizeMode.Zoom;
                pbox2.Size = new Size(f1.Heroes[n].width * Xsize, f1.Heroes[n].height * Xsize);
                pbox2.Location = new Point(pbox1.Location.X + pbox1.Width, pbox1.Location.Y);
                pbox2.BackColor = Color.Transparent;
                //pbox2.BackColor = Color.Blue;
                pbox2.BringToFront();
                f1.Controls.Add(pbox2);
                gran.Add(pbox2);

                // Доп квадрат LeftDawn
                var pbox3 = new PictureBox();
                pbox3.SizeMode = PictureBoxSizeMode.Zoom;
                pbox3.Size = new Size(f1.Heroes[n].width * Xsize, f1.Heroes[n].height * Xsize);
                pbox3.Location = new Point(pbox1.Location.X, pbox1.Location.Y + pbox1.Height);
                pbox3.BackColor = Color.Transparent;
                //pbox3.BackColor = Color.Blue;
                pbox3.BringToFront();
                f1.Controls.Add(pbox3);
                gran.Add(pbox3);

                // Доп квадрат RightDawn
                var pbox4 = new PictureBox();
                pbox4.SizeMode = PictureBoxSizeMode.Zoom;
                pbox4.Size = new Size(f1.Heroes[n].width * Xsize, f1.Heroes[n].height * Xsize);
                pbox4.Location = new Point(pbox1.Location.X + pbox1.Width, pbox1.Location.Y + pbox1.Height);
                pbox4.BackColor = Color.Transparent;
                //pbox4.BackColor = Color.Green;
                pbox4.BringToFront();
                f1.Controls.Add(pbox4);
                gran.Add(pbox4);

                switch (f1.Heroes[n].angle)
                {
                    case 0:
                        pbox1.Paint += new PaintEventHandler(PainterLeftUpH);
                        pbox2.Paint += new PaintEventHandler(PainterRightUpH);
                        pbox3.Paint += new PaintEventHandler(PainterLeftDawnH);
                        pbox4.Paint += new PaintEventHandler(PainterRightDawnH);
                        break;
                    case 180:
                        pbox1.Paint += new PaintEventHandler(PainterLeftUpH);
                        pbox2.Paint += new PaintEventHandler(PainterRightUpH);
                        pbox3.Paint += new PaintEventHandler(PainterLeftDawnH);
                        pbox4.Paint += new PaintEventHandler(PainterRightDawnH);
                        break;
                    case 360:
                        pbox1.Paint += new PaintEventHandler(PainterLeftUpH);
                        pbox2.Paint += new PaintEventHandler(PainterRightUpH);
                        pbox3.Paint += new PaintEventHandler(PainterLeftDawnH);
                        pbox4.Paint += new PaintEventHandler(PainterRightDawnH);
                        break;

                    case 60:
                        pbox1.Paint += new PaintEventHandler(PainterLeftFlatH);
                        pbox2.Paint += new PaintEventHandler(PainterRightUpH);
                        pbox3.Paint += new PaintEventHandler(PainterLeftDawnH);
                        pbox4.Paint += new PaintEventHandler(PainterRightFlatH);
                        break;
                    case 240:
                        pbox1.Paint += new PaintEventHandler(PainterLeftFlatH);
                        pbox2.Paint += new PaintEventHandler(PainterRightUpH);
                        pbox3.Paint += new PaintEventHandler(PainterLeftDawnH);
                        pbox4.Paint += new PaintEventHandler(PainterRightFlatH);
                        break;

                    case 120:
                        pbox1.Paint += new PaintEventHandler(PainterLeftUpH);
                        pbox2.Paint += new PaintEventHandler(PainterLeftFlatH);
                        pbox3.Paint += new PaintEventHandler(PainterRightFlatH);
                        pbox4.Paint += new PaintEventHandler(PainterRightDawnH);
                        break;
                    case 300:
                        pbox1.Paint += new PaintEventHandler(PainterLeftUpH);
                        pbox2.Paint += new PaintEventHandler(PainterLeftFlatH);
                        pbox3.Paint += new PaintEventHandler(PainterRightFlatH);
                        pbox4.Paint += new PaintEventHandler(PainterRightDawnH);
                        break;

                    default:
                        MessageBox.Show(f1.Heroes[n].angle.ToString());
                        break;
                }
            }
        }

        public void PainterLeftUpH(object sender, PaintEventArgs e)
        {
            int n = NameBoxH.SelectedIndex;
            //Pen p = new Pen(Color.FromArgb(90, 0, 165), 3);
            Pen p = new Pen(Color.Red, 5);
            int Xsize = 5;

            Render r = new Render();
            r.PainterLeftUp(sender, e, p, Xsize, f1.Heroes[n].width, f1.Heroes[n].height);
        }

        public void PainterRightUpH(object sender, PaintEventArgs e)
        {
            int n = NameBoxH.SelectedIndex;
            //Pen p = new Pen(Color.FromArgb(90, 0, 165), 3);
            Pen p = new Pen(Color.Red, 5);
            int Xsize = 5;

            Render r = new Render();
            r.PainterRightUp(sender, e, p, Xsize, f1.Heroes[n].width, f1.Heroes[n].height);
        }

        public void PainterLeftDawnH(object sender, PaintEventArgs e)
        {
            int n = NameBoxH.SelectedIndex;
            //Pen p = new Pen(Color.FromArgb(90, 0, 165), 3);
            Pen p = new Pen(Color.Red, 5);
            int Xsize = 5;

            Render r = new Render();
            r.PainterLeftDawn(sender, e, p, Xsize, f1.Heroes[n].width, f1.Heroes[n].height);
        }

        public void PainterRightDawnH(object sender, PaintEventArgs e)
        {
            int n = NameBoxH.SelectedIndex;
            //Pen p = new Pen(Color.FromArgb(90, 0, 165), 3);
            Pen p = new Pen(Color.Red, 5);
            int Xsize = 5;

            Render r = new Render();
            r.PainterRightDawn(sender, e, p, Xsize, f1.Heroes[n].width, f1.Heroes[n].height);
        }
        public void PainterLeftFlatH(object sender, PaintEventArgs e)
        {
            int n = NameBoxH.SelectedIndex;
            //Pen p = new Pen(Color.FromArgb(90, 0, 165), 3);
            Pen p = new Pen(Color.Red, 5);
            int Xsize = 5;

            Render r = new Render();
            r.PainterLeftFlat(sender, e, p, Xsize, f1.Heroes[n].width, f1.Heroes[n].height);
        }
        public void PainterRightFlatH(object sender, PaintEventArgs e)
        {
            int n = NameBoxH.SelectedIndex;
            //Pen p = new Pen(Color.FromArgb(90, 0, 165), 3);
            Pen p = new Pen(Color.Red, 5);
            int Xsize = 5;

            Render r = new Render();
            r.PainterRightFlat(sender, e, p, Xsize, f1.Heroes[n].width, f1.Heroes[n].height);
        }



        private void buttonSearchH_MouseUp(object sender, MouseEventArgs e)
        {
            /*
            if (NameBoxH.SelectedIndex != -1)
            {
                int n = NameBoxH.SelectedIndex;
                f1.idboxH[n].Invalidate();
            }
            */
            if (NameBoxH.SelectedIndex != -1)
            {
                int n = NameBoxH.SelectedIndex;

                f1.idboxH[n].Invalidate();
                /*
                f1.idboxEdop[n].Dispose();
                f1.idboxEdop.RemoveAt(n);  
                */
                foreach (Control i in gran)
                {
                    if (f1.Controls.Contains(i))
                        f1.Controls.Remove(i);
                }
            }
        }     

        private void buttonSearchE_MouseDown(object sender, MouseEventArgs e)
        {
            //Pen p = new Pen(Color.FromArgb(90, 0, 165), 12);
            Pen p = new Pen(Color.Red, 10);

            if (NameBoxE.SelectedIndex != -1)
            {
                int n = NameBoxE.SelectedIndex;

                // Доп квадрат LeftUp
                /*
                var pbox = new PictureBox();
                pbox.SizeMode = PictureBoxSizeMode.Zoom;
                pbox.Size = new Size(f1.Enemys[n].sizeW * 3, f1.Enemys[n].sizeH * 3);
                pbox.Location = new Point(f1.idbox[n].Location.X - f1.Enemys[n].sizeW, f1.idbox[n].Location.Y - f1.Enemys[n].sizeH);
                pbox.BackColor = Color.Transparent;
                //pbox.BackColor = Color.FromName("Green");
                f1.Controls.Add(pbox);
                f1.idboxEdop.Insert(n, pbox);
                */
                
                Graphics g = Graphics.FromHwnd(f1.idbox[n].Handle);
                g.DrawRectangle(p, 0, 0, f1.idbox[n].Width, f1.idbox[n].Height);

                int Xsize = 5;

                // Доп квадрат LeftUp
                var pbox1 = new PictureBox();
                pbox1.SizeMode = PictureBoxSizeMode.Zoom;
                pbox1.Size = new Size(f1.Enemys[n].width * Xsize, f1.Enemys[n].height * Xsize);
                pbox1.Location = new Point(f1.idbox[n].Location.X + (f1.Enemys[n].width / 2) - pbox1.Size.Width, f1.idbox[n].Location.Y + (f1.Enemys[n].height / 2) - pbox1.Size.Height);
                pbox1.BackColor = Color.Transparent;
                //pbox1.BackColor = Color.Green;
                pbox1.BringToFront();                
                f1.Controls.Add(pbox1);
                gran.Add(pbox1);

                // Доп квадрат RightUp
                var pbox2 = new PictureBox();
                pbox2.SizeMode = PictureBoxSizeMode.Zoom;
                pbox2.Size = new Size(f1.Enemys[n].width * Xsize, f1.Enemys[n].height * Xsize);
                pbox2.Location = new Point(pbox1.Location.X + pbox1.Width, pbox1.Location.Y);
                pbox2.BackColor = Color.Transparent;
                //pbox2.BackColor = Color.Blue;
                pbox2.BringToFront();
                f1.Controls.Add(pbox2);
                gran.Add(pbox2);

                // Доп квадрат LeftDawn
                var pbox3 = new PictureBox();
                pbox3.SizeMode = PictureBoxSizeMode.Zoom;
                pbox3.Size = new Size(f1.Enemys[n].width * Xsize, f1.Enemys[n].height * Xsize);
                pbox3.Location = new Point(pbox1.Location.X, pbox1.Location.Y + pbox1.Height);
                pbox3.BackColor = Color.Transparent;
                //pbox3.BackColor = Color.Blue;
                pbox3.BringToFront();
                f1.Controls.Add(pbox3);
                gran.Add(pbox3);

                // Доп квадрат RightDawn
                var pbox4 = new PictureBox();
                pbox4.SizeMode = PictureBoxSizeMode.Zoom;
                pbox4.Size = new Size(f1.Enemys[n].width * Xsize, f1.Enemys[n].height * Xsize);
                pbox4.Location = new Point(pbox1.Location.X + pbox1.Width, pbox1.Location.Y + pbox1.Height);
                pbox4.BackColor = Color.Transparent;
                //pbox4.BackColor = Color.Green;
                pbox4.BringToFront();
                f1.Controls.Add(pbox4);
                gran.Add(pbox4);

                switch (f1.Enemys[n].angle)
                {
                    case 0:
                        pbox1.Paint += new PaintEventHandler(PainterLeftUp);
                        pbox2.Paint += new PaintEventHandler(PainterRightUp);
                        pbox3.Paint += new PaintEventHandler(PainterLeftDawn);
                        pbox4.Paint += new PaintEventHandler(PainterRightDawn);
                        break;
                    case 180:
                        pbox1.Paint += new PaintEventHandler(PainterLeftUp);
                        pbox2.Paint += new PaintEventHandler(PainterRightUp);
                        pbox3.Paint += new PaintEventHandler(PainterLeftDawn);
                        pbox4.Paint += new PaintEventHandler(PainterRightDawn);
                        break;
                    case 360:
                        pbox1.Paint += new PaintEventHandler(PainterLeftUp);
                        pbox2.Paint += new PaintEventHandler(PainterRightUp);
                        pbox3.Paint += new PaintEventHandler(PainterLeftDawn);
                        pbox4.Paint += new PaintEventHandler(PainterRightDawn);
                        break;

                    case 60:
                        pbox1.Paint += new PaintEventHandler(PainterLeftFlat);
                        pbox2.Paint += new PaintEventHandler(PainterRightUp);
                        pbox3.Paint += new PaintEventHandler(PainterLeftDawn);
                        pbox4.Paint += new PaintEventHandler(PainterRightFlat);
                        break;
                    case 240:
                        pbox1.Paint += new PaintEventHandler(PainterLeftFlat);
                        pbox2.Paint += new PaintEventHandler(PainterRightUp);
                        pbox3.Paint += new PaintEventHandler(PainterLeftDawn);
                        pbox4.Paint += new PaintEventHandler(PainterRightFlat);
                        break;

                    case 120:
                        pbox1.Paint += new PaintEventHandler(PainterLeftUp);
                        pbox2.Paint += new PaintEventHandler(PainterLeftFlat);
                        pbox3.Paint += new PaintEventHandler(PainterRightFlat);
                        pbox4.Paint += new PaintEventHandler(PainterRightDawn);
                        break;
                    case 300:
                        pbox1.Paint += new PaintEventHandler(PainterLeftUp);
                        pbox2.Paint += new PaintEventHandler(PainterLeftFlat);
                        pbox3.Paint += new PaintEventHandler(PainterRightFlat);
                        pbox4.Paint += new PaintEventHandler(PainterRightDawn);
                        break;

                    default:
                        MessageBox.Show(f1.Enemys[n].angle.ToString());
                        break;
                }
            }
        }

        public void PainterLeftUp(object sender, PaintEventArgs e) 
        {
            int n = NameBoxE.SelectedIndex;
            //Pen p = new Pen(Color.FromArgb(90, 0, 165), 3);
            Pen p = new Pen(Color.Red, 5);
            int Xsize = 5;

            Render r = new Render();
            r.PainterLeftUp(sender, e, p, Xsize, f1.Enemys[n].width, f1.Enemys[n].height);
        }

        public void PainterRightUp(object sender, PaintEventArgs e)
        {
            int n = NameBoxE.SelectedIndex;
            //Pen p = new Pen(Color.FromArgb(90, 0, 165), 3);
            Pen p = new Pen(Color.Red, 5);
            int Xsize = 5;

            Render r = new Render(); 
            r.PainterRightUp(sender, e, p, Xsize, f1.Enemys[n].width, f1.Enemys[n].height);
        }

        public void PainterLeftDawn(object sender, PaintEventArgs e)
        {
            int n = NameBoxE.SelectedIndex;
            //Pen p = new Pen(Color.FromArgb(90, 0, 165), 3);
            Pen p = new Pen(Color.Red, 5);
            int Xsize = 5;

            Render r = new Render();
            r.PainterLeftDawn(sender, e, p, Xsize, f1.Enemys[n].width, f1.Enemys[n].height);
        }

        public void PainterRightDawn(object sender, PaintEventArgs e)
        {
            int n = NameBoxE.SelectedIndex;
            //Pen p = new Pen(Color.FromArgb(90, 0, 165), 3);
            Pen p = new Pen(Color.Red, 5);
            int Xsize = 5;

            Render r = new Render();
            r.PainterRightDawn(sender, e, p, Xsize, f1.Enemys[n].width, f1.Enemys[n].height);
        }
        public void PainterLeftFlat(object sender, PaintEventArgs e)
        {
            int n = NameBoxE.SelectedIndex;
            //Pen p = new Pen(Color.FromArgb(90, 0, 165), 3);
            Pen p = new Pen(Color.Red, 5);
            int Xsize = 5;

            Render r = new Render();
            r.PainterLeftFlat(sender, e, p, Xsize, f1.Enemys[n].width, f1.Enemys[n].height);
        }
        public void PainterRightFlat(object sender, PaintEventArgs e)
        {
            int n = NameBoxE.SelectedIndex;
            //Pen p = new Pen(Color.FromArgb(90, 0, 165), 3);
            Pen p = new Pen(Color.Red, 5);
            int Xsize = 5;

            Render r = new Render();
            r.PainterRightFlat(sender, e, p, Xsize, f1.Enemys[n].width, f1.Enemys[n].height);
        }

        private void buttonSearchE_MouseUp(object sender, MouseEventArgs e)
        {
            if (NameBoxE.SelectedIndex != -1)
            {
                int n = NameBoxE.SelectedIndex;
                
                f1.idbox[n].Invalidate();
                /*
                f1.idboxEdop[n].Dispose();
                f1.idboxEdop.RemoveAt(n);  
                */
                foreach (Control i in gran)
                {
                    if (f1.Controls.Contains(i))
                        f1.Controls.Remove(i);
                }    
            }
        }

        private void buttonSort_Click(object sender, EventArgs e)
        {
            try
            {
                initlist.Clear();
                initlistname.Clear();
                listBoxSort.Items.Clear();
                if (f1.Heroes.Count != 0 && f1.Enemys.Count != 0)                  

                {
                    for (int i = 0; i < f1.Heroes.Count; i++)
                    {
                        initlist.Add(f1.Heroes[i].init);
                        initlistname.Add(f1.Heroes[i].name);
                    }

                    for (int i = 0; i < f1.Enemys.Count; i++)
                    {
                        initlist.Add(Convert.ToDouble(f1.Enemys[i].init));
                        initlistname.Add(f1.Enemys[i].name);
                    }

                    // сортировка
                    double temp;
                    string tempname;
                    for (int i = 0; i < initlist.Count - 1; i++)
                    {
                        for (int j = i + 1; j < initlist.Count; j++)
                        {
                            if (initlist[i] < initlist[j])
                            {
                                temp = initlist[i];                                
                                initlist[i] = initlist[j];                                
                                initlist[j] = temp;

                                tempname = initlistname[i];
                                initlistname[i] = initlistname[j];
                                initlistname[j] = tempname;
                            }
                        }
                    }

                    for (int i = 0; i < initlist.Count; i++)
                    {
                        //listBoxSort.Items.Add(initlist[i]);
                        listBoxSort.Items.Add(initlist[i] + "-" + initlistname[i]);
                    }
                    //listBoxSort.Sorted = true;
                }

            }

            catch
            {
                inf.messageerror();
            }
        }

        private void IconMapsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            if (Global.GopenForms)
            {                
                e.Cancel = true;
                MessageBox.Show("Закройте окно карты");                
                
            }

            else if (!Global.GopenForms)
            {
                e.Cancel = false;
            }
                

        }
    }

}