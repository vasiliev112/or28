using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dice
{
    public partial class DnD : Form
    {
        Gen g = new Gen();

        ToolStripLabel dateLabel;
        ToolStripLabel timeLabel;
        ToolStripLabel infoLabel;
        ToolStripLabel countLabel;
        Timer timer;
        int i = 0;

        public DnD()
        {
            InitializeComponent();
            //webBrowser1.ScriptErrorsSuppressed = false;
            textBox1.Text = Convert.ToString(webBrowser1.Url);
            SuppressScriptErrorsOnly(webBrowser1);

            //Для трея
            notifyIcon1.Visible = false;
            this.notifyIcon1.MouseDoubleClick += new MouseEventHandler(notifyIcon1_MouseDoubleClick);
            this.Resize += new System.EventHandler(this.Form1_Resize);

            //this.ShowInTaskbar = false;
            //notifyIcon1.Click += notifyIcon1_Click;         

            infoLabel = new ToolStripLabel();
            infoLabel.Text = "Текущие дата и время:";
            countLabel = new ToolStripLabel();
            countLabel.Text = Convert.ToString(i);
            dateLabel = new ToolStripLabel();
            timeLabel = new ToolStripLabel();

            statusStrip1.Items.Add(infoLabel);
            statusStrip1.Items.Add(dateLabel);
            statusStrip1.Items.Add(timeLabel);
            statusStrip1.Items.Add(countLabel);

            timer = new Timer() { Interval = 1000 };
            timer.Tick += timer_Tick;
            timer.Start();

        }
        // Hides script errors without hiding other dialog boxes.
        private void SuppressScriptErrorsOnly(WebBrowser browser)
        {
            // Ensure that ScriptErrorsSuppressed is set to false.
            browser.ScriptErrorsSuppressed = false;

            // Handle DocumentCompleted to gain access to the Document object.
            browser.DocumentCompleted +=
                new WebBrowserDocumentCompletedEventHandler(
                    browser_DocumentCompleted);
        }

        private void browser_DocumentCompleted(object sender,
            WebBrowserDocumentCompletedEventArgs e)
        {
            ((WebBrowser)sender).Document.Window.Error +=
                new HtmlElementErrorEventHandler(Window_Error);
        }

        private void Window_Error(object sender,
            HtmlElementErrorEventArgs e)
        {
            // Ignore the error and suppress the error dialog box. 
            e.Handled = true;
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void buttonHpMinusHero1_Click(object sender, EventArgs e)
        {
            try
            {
                if (HpMinusHero1.Text != "")
                {
                    HpHero1.Text = Convert.ToString(Convert.ToInt32(HpHero1.Text) - Convert.ToInt32(HpMinusHero1.Text));
                    LastHpMinusHero1.Text = HpMinusHero1.Text;
                    HpMinusHero1.Clear();
                }
            }
            catch
            {
            }
        }
                
        private void buttonHpMinusHero2_Click(object sender, EventArgs e)
        {
            try
            {
                if (HpMinusHero2.Text != "")
                {
                    HpHero2.Text = Convert.ToString(Convert.ToInt32(HpHero2.Text) - Convert.ToInt32(HpMinusHero2.Text));
                    LastHpMinusHero2.Text = HpMinusHero2.Text;
                    HpMinusHero2.Clear();
                }
            }
            catch
            {
            }
        }

        private void buttonHpMinusHero3_Click(object sender, EventArgs e)
        {
            try
            {
                if (HpMinusHero3.Text != "")
                {
                    HpHero3.Text = Convert.ToString(Convert.ToInt32(HpHero3.Text) - Convert.ToInt32(HpMinusHero3.Text));
                    LastHpMinusHero3.Text = HpMinusHero3.Text;
                    HpMinusHero3.Clear();
                }
            }
            catch
            {
            }
        }

        private void buttonHpMinusHero4_Click(object sender, EventArgs e)
        {
            try
            {
                if (HpMinusHero4.Text != "")
                {
                    HpHero4.Text = Convert.ToString(Convert.ToInt32(HpHero4.Text) - Convert.ToInt32(HpMinusHero4.Text));
                    LastHpMinusHero4.Text = HpMinusHero4.Text;
                    HpMinusHero4.Clear();
                }
            }
            catch
            {
            }
        }

        private void buttonHpMinusHero5_Click(object sender, EventArgs e)
        {
            try
            {
                if (HpMinusHero5.Text != "")
                {
                    HpHero5.Text = Convert.ToString(Convert.ToInt32(HpHero5.Text) - Convert.ToInt32(HpMinusHero5.Text));
                    LastHpMinusHero5.Text = HpMinusHero5.Text;
                    HpMinusHero5.Clear();
                }
            }
            catch
            {
            }
        }

        private void buttonHpMinusHero6_Click(object sender, EventArgs e)
        {
            try
            {
                if (HpMinusHero6.Text != "")
                {
                    HpHero6.Text = Convert.ToString(Convert.ToInt32(HpHero6.Text) - Convert.ToInt32(HpMinusHero6.Text));
                    LastHpMinusHero6.Text = HpMinusHero6.Text;
                    HpMinusHero6.Clear();
                }
            }
            catch
            {
            }
        }              
                
        // Броски костей
        #region 
        private void GenD4_Click(object sender, EventArgs e)
        {
            try
            {
                Dice4Old3.Text = Convert.ToString(Dice4Old2.Text);
                Dice4Old2.Text = Convert.ToString(Dice4Old1.Text);
                Dice4Old1.Text = Convert.ToString(Dice4.Text);

                if (NumbD4.Text == "")
                {                    
                    Dice4.Text = Convert.ToString(g.D4());
                }
                else 
                {
                    Dice4.Text = Convert.ToString(g.D4()* Convert.ToInt32(NumbD4.Text));
                }
                
            }
            catch
            {
            }
        }

        private void GenD6_Click(object sender, EventArgs e)
        {
            try
            {
                Dice6Old3.Text = Convert.ToString(Dice6Old2.Text);
                Dice6Old2.Text = Convert.ToString(Dice6Old1.Text);
                Dice6Old1.Text = Convert.ToString(Dice6.Text);

                if (NumbD6.Text == "")
                {                    
                    Dice6.Text = Convert.ToString(g.D6());
                }
                else
                {
                    Dice6.Text = Convert.ToString(g.D6() * Convert.ToInt32(NumbD6.Text));
                }

            }
            catch
            {
            }
        }

        private void GenD8_Click(object sender, EventArgs e)
        {
            try
            {
                Dice8Old3.Text = Convert.ToString(Dice8Old2.Text);
                Dice8Old2.Text = Convert.ToString(Dice8Old1.Text);
                Dice8Old1.Text = Convert.ToString(Dice8.Text);

                if (NumbD8.Text == "")
                {
                    Dice8.Text = Convert.ToString(g.D8());
                }
                else
                {
                    Dice8.Text = Convert.ToString(g.D8() * Convert.ToInt32(NumbD8.Text));
                }

            }
            catch
            {
            }
        }

        private void GenD10_Click(object sender, EventArgs e)
        {
            try
            {
                Dice10Old3.Text = Convert.ToString(Dice10Old2.Text);
                Dice10Old2.Text = Convert.ToString(Dice10Old1.Text);
                Dice10Old1.Text = Convert.ToString(Dice10.Text);

                if (NumbD10.Text == "")
                {
                    Dice10.Text = Convert.ToString(g.D10());
                }
                else
                {
                    Dice10.Text = Convert.ToString(g.D10() * Convert.ToInt32(NumbD10.Text));
                }

            }
            catch
            {
            }
        }

        private void GenD12_Click(object sender, EventArgs e)
        {
            try
            {
                Dice12Old3.Text = Convert.ToString(Dice12Old2.Text);
                Dice12Old2.Text = Convert.ToString(Dice12Old1.Text);
                Dice12Old1.Text = Convert.ToString(Dice12.Text);

                if (NumbD12.Text == "")
                {
                    Dice12.Text = Convert.ToString(g.D12());
                }
                else
                {
                    Dice12.Text = Convert.ToString(g.D12() * Convert.ToInt32(NumbD12.Text));
                }

            }
            catch
            {
            }
        }

        private void GenD20_Click(object sender, EventArgs e)
        {
            try
            {
                Dice20Old3.Text = Convert.ToString(Dice20Old2.Text);
                Dice20Old2.Text = Convert.ToString(Dice20Old1.Text);
                Dice20Old1.Text = Convert.ToString(Dice20.Text);

                if (NumbD20.Text == "")
                {
                    Dice20.Text = Convert.ToString(g.D20());
                }
                else
                {
                    Dice20.Text = Convert.ToString(g.D20() * Convert.ToInt32(NumbD20.Text));
                }

            }
            catch
            {
            }
        }

        private void GenD100_Click(object sender, EventArgs e)
        {
            try
            {
                Dice100Old3.Text = Convert.ToString(Dice100Old2.Text);
                Dice100Old2.Text = Convert.ToString(Dice100Old1.Text);
                Dice100Old1.Text = Convert.ToString(Dice100.Text);

                if (NumbD100.Text == "")
                {
                    Dice100.Text = Convert.ToString(g.D100());
                }
                else
                {
                    Dice100.Text = Convert.ToString(g.D100() * Convert.ToInt32(NumbD100.Text));
                }

            }
            catch
            {
            }
        }
        #endregion 

        private void CleaneD_Click(object sender, EventArgs e)
        {
            NumbD4.Clear();
            NumbD6.Clear();
            NumbD8.Clear();
            NumbD10.Clear();
            NumbD12.Clear();
            NumbD20.Clear();
            NumbD100.Clear();

            //pictureBox1.ImageLocation = "https://cyberstatic.net/images/cyberforum_logo.png";
            //pictureBox1.Load();            
        }

        private void HpMinusMonster1_TextChanged(object sender, EventArgs e)
        {

        }

        // Потеря HP монстрами
        #region
        private void buttonHpMinusMonster1_Click(object sender, EventArgs e)
        {
            try
            {
                if (HpMinusMonster1.Text != "")
                {
                    HpMonster1.Text = Convert.ToString(Convert.ToInt32(HpMonster1.Text) - Convert.ToInt32(HpMinusMonster1.Text));
                    LastHpMinusMonster1.Text = HpMinusMonster1.Text;
                    HpMinusMonster1.Clear();
                }
            }
            catch
            {
            }
        }                

        private void buttonHpMinusMonster2_Click(object sender, EventArgs e)
        {
            try
            {
                if (HpMinusMonster2.Text != "")
                {
                    HpMonster2.Text = Convert.ToString(Convert.ToInt32(HpMonster2.Text) - Convert.ToInt32(HpMinusMonster2.Text));
                    LastHpMinusMonster2.Text = HpMinusMonster2.Text;
                    HpMinusMonster2.Clear();
                }
            }
            catch
            {
            }
        }

        private void buttonHpMinusMonster3_Click(object sender, EventArgs e)
        {
            try
            {
                if (HpMinusMonster3.Text != "")
                {
                    HpMonster3.Text = Convert.ToString(Convert.ToInt32(HpMonster3.Text) - Convert.ToInt32(HpMinusMonster3.Text));
                    LastHpMinusMonster3.Text = HpMinusMonster3.Text;
                    HpMinusMonster3.Clear();
                }
            }
            catch
            {
            }
        }

        private void buttonHpMinusMonster4_Click(object sender, EventArgs e)
        {
            try
            {
                if (HpMinusMonster4.Text != "")
                {
                    HpMonster4.Text = Convert.ToString(Convert.ToInt32(HpMonster4.Text) - Convert.ToInt32(HpMinusMonster4.Text));
                    LastHpMinusMonster4.Text = HpMinusMonster4.Text;
                    HpMinusMonster4.Clear();
                }
            }
            catch
            {
            }
        }

        private void buttonHpMinusMonster5_Click(object sender, EventArgs e)
        {
            try
            {
                if (HpMinusMonster5.Text != "")
                {
                    HpMonster5.Text = Convert.ToString(Convert.ToInt32(HpMonster5.Text) - Convert.ToInt32(HpMinusMonster5.Text));
                    LastHpMinusMonster5.Text = HpMinusMonster5.Text;
                    HpMinusMonster5.Clear();
                }
            }
            catch
            {
            }
        }

        private void buttonHpMinusMonster6_Click(object sender, EventArgs e)
        {
            try
            {
                if (HpMinusMonster6.Text != "")
                {
                    HpMonster6.Text = Convert.ToString(Convert.ToInt32(HpMonster6.Text) - Convert.ToInt32(HpMinusMonster6.Text));
                    LastHpMinusMonster6.Text = HpMinusMonster6.Text;
                    HpMinusMonster6.Clear();
                }
            }
            catch
            {
            }
        }

        private void buttonHpMinusMonster7_Click(object sender, EventArgs e)
        {
            try
            {
                if (HpMinusMonster7.Text != "")
                {
                    HpMonster7.Text = Convert.ToString(Convert.ToInt32(HpMonster7.Text) - Convert.ToInt32(HpMinusMonster7.Text));
                    LastHpMinusMonster7.Text = HpMinusMonster7.Text;
                    HpMinusMonster7.Clear();
                }
            }
            catch
            {
            }
        }

        private void buttonHpMinusMonster8_Click(object sender, EventArgs e)
        {
            try
            {
                if (HpMinusMonster8.Text != "")
                {
                    HpMonster8.Text = Convert.ToString(Convert.ToInt32(HpMonster8.Text) - Convert.ToInt32(HpMinusMonster8.Text));
                    LastHpMinusMonster8.Text = HpMinusMonster8.Text;
                    HpMinusMonster8.Clear();
                }
            }
            catch
            {
            }
        }

        private void buttonHpMinusMonster9_Click(object sender, EventArgs e)
        {
            try
            {
                if (HpMinusMonster9.Text != "")
                {
                    HpMonster9.Text = Convert.ToString(Convert.ToInt32(HpMonster9.Text) - Convert.ToInt32(HpMinusMonster9.Text));
                    LastHpMinusMonster9.Text = HpMinusMonster9.Text;
                    HpMinusMonster9.Clear();
                }
            }
            catch
            {
            }
        }

        private void buttonHpMinusMonster10_Click(object sender, EventArgs e)
        {
            try
            {
                if (HpMinusMonster10.Text != "")
                {
                    HpMonster10.Text = Convert.ToString(Convert.ToInt32(HpMonster10.Text) - Convert.ToInt32(HpMinusMonster10.Text));
                    LastHpMinusMonster10.Text = HpMinusMonster10.Text;
                    HpMinusMonster10.Clear();
                }
            }
            catch
            {
            }
        }
        #endregion

        // Броски атаки монстрами
        #region
        private void AttacMonster1_Click(object sender, EventArgs e)
        {
            try
            {
                if (BonusAttacMonster1.Text != "")
                {
                    ResultAttac1Monster1.Text = Convert.ToString(Convert.ToInt32(BonusAttacMonster1.Text) + g.D20());
                }
                else
                    ResultAttac1Monster1.Text = Convert.ToString(g.D20());

                if (BonusAttacMonster1.Text != "")
                {
                    ResultAttac2Monster1.Text = Convert.ToString(Convert.ToInt32(BonusAttacMonster1.Text) + g.D20());
                }
                else
                    ResultAttac2Monster1.Text = Convert.ToString(g.D20());
            }
            catch
            {
            }
        }

        private void AttacMonster2_Click(object sender, EventArgs e)
        {
            try
            {
                if (BonusAttacMonster2.Text != "")
                {
                    ResultAttac1Monster2.Text = Convert.ToString(Convert.ToInt32(BonusAttacMonster2.Text) + g.D20());
                }
                else
                    ResultAttac1Monster2.Text = Convert.ToString(g.D20());

                if (BonusAttacMonster2.Text != "")
                {
                    ResultAttac2Monster2.Text = Convert.ToString(Convert.ToInt32(BonusAttacMonster2.Text) + g.D20());
                }
                else
                    ResultAttac2Monster2.Text = Convert.ToString(g.D20());
            }
            catch
            {
            }
        }

        private void AttacMonster3_Click(object sender, EventArgs e)
        {
            try
            {
                if (BonusAttacMonster3.Text != "")
                {
                    ResultAttac1Monster3.Text = Convert.ToString(Convert.ToInt32(BonusAttacMonster3.Text) + g.D20());
                }
                else
                    ResultAttac1Monster3.Text = Convert.ToString(g.D20());

                if (BonusAttacMonster3.Text != "")
                {
                    ResultAttac2Monster3.Text = Convert.ToString(Convert.ToInt32(BonusAttacMonster3.Text) + g.D20());
                }
                else
                    ResultAttac2Monster3.Text = Convert.ToString(g.D20());
            }
            catch
            {
            }
        }

        private void AttacMonster4_Click(object sender, EventArgs e)
        {
            try
            {
                if (BonusAttacMonster4.Text != "")
                {
                    ResultAttac1Monster4.Text = Convert.ToString(Convert.ToInt32(BonusAttacMonster4.Text) + g.D20());
                }
                else
                    ResultAttac1Monster4.Text = Convert.ToString(g.D20());

                if (BonusAttacMonster4.Text != "")
                {
                    ResultAttac2Monster4.Text = Convert.ToString(Convert.ToInt32(BonusAttacMonster4.Text) + g.D20());
                }
                else
                    ResultAttac2Monster4.Text = Convert.ToString(g.D20());
            }
            catch
            {
            }
        }

        private void AttacMonster5_Click(object sender, EventArgs e)
        {
            try
            {
                if (BonusAttacMonster5.Text != "")
                {
                    ResultAttac1Monster5.Text = Convert.ToString(Convert.ToInt32(BonusAttacMonster5.Text) + g.D20());
                }
                else
                    ResultAttac1Monster5.Text = Convert.ToString(g.D20());

                if (BonusAttacMonster5.Text != "")
                {
                    ResultAttac2Monster5.Text = Convert.ToString(Convert.ToInt32(BonusAttacMonster5.Text) + g.D20());
                }
                else
                    ResultAttac2Monster5.Text = Convert.ToString(g.D20());
            }
            catch
            {
            }
        }

        private void AttacMonster6_Click(object sender, EventArgs e)
        {
            try
            {
                if (BonusAttacMonster6.Text != "")
                {
                    ResultAttac1Monster6.Text = Convert.ToString(Convert.ToInt32(BonusAttacMonster6.Text) + g.D20());
                }
                else
                    ResultAttac1Monster6.Text = Convert.ToString(g.D20());

                if (BonusAttacMonster6.Text != "")
                {
                    ResultAttac2Monster6.Text = Convert.ToString(Convert.ToInt32(BonusAttacMonster6.Text) + g.D20());
                }
                else
                    ResultAttac2Monster6.Text = Convert.ToString(g.D20());
            }
            catch
            {
            }
        }

        private void AttacMonster7_Click(object sender, EventArgs e)
        {
            try
            {
                if (BonusAttacMonster7.Text != "")
                {
                    ResultAttac1Monster7.Text = Convert.ToString(Convert.ToInt32(BonusAttacMonster7.Text) + g.D20());
                }
                else
                    ResultAttac1Monster7.Text = Convert.ToString(g.D20());

                if (BonusAttacMonster7.Text != "")
                {
                    ResultAttac2Monster7.Text = Convert.ToString(Convert.ToInt32(BonusAttacMonster7.Text) + g.D20());
                }
                else
                    ResultAttac2Monster7.Text = Convert.ToString(g.D20());
            }
            catch
            {
            }
        }

        private void AttacMonster8_Click(object sender, EventArgs e)
        {
            try
            {
                if (BonusAttacMonster8.Text != "")
                {
                    ResultAttac1Monster8.Text = Convert.ToString(Convert.ToInt32(BonusAttacMonster8.Text) + g.D20());
                }
                else
                    ResultAttac1Monster8.Text = Convert.ToString(g.D20());

                if (BonusAttacMonster8.Text != "")
                {
                    ResultAttac2Monster8.Text = Convert.ToString(Convert.ToInt32(BonusAttacMonster8.Text) + g.D20());
                }
                else
                    ResultAttac2Monster8.Text = Convert.ToString(g.D20());
            }
            catch
            {
            }
        }

        private void AttacMonster9_Click(object sender, EventArgs e)
        {
            try
            {
                if (BonusAttacMonster9.Text != "")
                {
                    ResultAttac1Monster9.Text = Convert.ToString(Convert.ToInt32(BonusAttacMonster9.Text) + g.D20());
                }
                else
                    ResultAttac1Monster9.Text = Convert.ToString(g.D20());

                if (BonusAttacMonster9.Text != "")
                {
                    ResultAttac2Monster9.Text = Convert.ToString(Convert.ToInt32(BonusAttacMonster9.Text) + g.D20());
                }
                else
                    ResultAttac2Monster9.Text = Convert.ToString(g.D20());
            }
            catch
            {
            }
        }

        private void AttacMonster10_Click(object sender, EventArgs e)
        {
            try
            {
                if (BonusAttacMonster10.Text != "")
                {
                    ResultAttac1Monster10.Text = Convert.ToString(Convert.ToInt32(BonusAttacMonster10.Text) + g.D20());
                }
                else
                    ResultAttac1Monster10.Text = Convert.ToString(g.D20());

                if (BonusAttacMonster10.Text != "")
                {
                    ResultAttac2Monster10.Text = Convert.ToString(Convert.ToInt32(BonusAttacMonster10.Text) + g.D20());
                }
                else
                    ResultAttac2Monster10.Text = Convert.ToString(g.D20());
            }
            catch
            {
            }
        }
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            FightInnitiative.Items.Clear();
            string[] number = {Hero1.Text, Hero2.Text, Hero3.Text, Hero4.Text, Hero5.Text, Hero6.Text,
            Monster1.Text, Monster2.Text, Monster3.Text, Monster4.Text, Monster5.Text, Monster6.Text, Monster7.Text, Monster8.Text, Monster9.Text, Monster10.Text,};
            string[] numbers = number.Where(n => !string.IsNullOrEmpty(n)).ToArray();
            string[] numbersdel = numbers.Distinct().ToArray();

            if (numbers.Length == numbersdel.Length)
            {
                try
                {
                    Dictionary<string, decimal> dic = new Dictionary<string, decimal>();
                    
                        if (Hero1.Text != "")
                            dic.Add(Hero1.Text, InitiativeHero1.Value);
                        if (Hero2.Text != "")
                            dic.Add(Hero2.Text, InitiativeHero2.Value);
                        if (Hero3.Text != "")
                            dic.Add(Hero3.Text, InitiativeHero3.Value);
                        if (Hero4.Text != "")
                            dic.Add(Hero4.Text, InitiativeHero4.Value);
                        if (Hero5.Text != "")
                            dic.Add(Hero5.Text, InitiativeHero5.Value);
                        if (Hero6.Text != "")
                            dic.Add(Hero6.Text, InitiativeHero6.Value);

                        if (Monster1.Text != "")
                            dic.Add(Monster1.Text, InitiativeMonster1.Value);
                        if (Monster2.Text != "")
                            dic.Add(Monster2.Text, InitiativeMonster2.Value);
                        if (Monster3.Text != "")
                            dic.Add(Monster3.Text, InitiativeMonster3.Value);
                        if (Monster4.Text != "")
                            dic.Add(Monster4.Text, InitiativeMonster4.Value);
                        if (Monster5.Text != "")
                            dic.Add(Monster5.Text, InitiativeMonster5.Value);
                        if (Monster6.Text != "")
                            dic.Add(Monster6.Text, InitiativeMonster6.Value);
                        if (Monster7.Text != "")
                            dic.Add(Monster7.Text, InitiativeMonster7.Value);
                        if (Monster8.Text != "")
                            dic.Add(Monster8.Text, InitiativeMonster8.Value);
                        if (Monster9.Text != "")
                            dic.Add(Monster9.Text, InitiativeMonster9.Value);
                        if (Monster10.Text != "")
                            dic.Add(Monster10.Text, InitiativeMonster10.Value);                        

                    var sdic = dic.OrderByDescending(x => x.Value).ThenBy(x => x.Key);
                    
                    foreach (KeyValuePair<string, decimal> i in sdic) //получить все значения из словаря
                    {
                        FightInnitiative.Items.Add(i.Key + " - " + i.Value);
                    }
                }
                catch
                {
                }
            }
            else
            {
                FightInnitiative.Items.Add("Дубликаты");
            }
        }        

        private void labelInitHero_Click(object sender, EventArgs e)
        {
            InitiativeHero1.Value = 0;
            InitiativeHero2.Value = 0;
            InitiativeHero3.Value = 0;
            InitiativeHero4.Value = 0;
            InitiativeHero5.Value = 0;
            InitiativeHero6.Value = 0;
        }              

        private void labelAll_Click(object sender, EventArgs e)
        {
            Monster1.Clear();
            Monster2.Clear();
            Monster3.Clear();
            Monster4.Clear();
            Monster5.Clear();
            Monster6.Clear();
            Monster7.Clear();
            Monster8.Clear();
            Monster9.Clear();
            Monster10.Clear();

            PasVisionMonster1.Clear();
            PasVisionMonster2.Clear();
            PasVisionMonster3.Clear();
            PasVisionMonster4.Clear();
            PasVisionMonster5.Clear();
            PasVisionMonster6.Clear();
            PasVisionMonster7.Clear();
            PasVisionMonster8.Clear();
            PasVisionMonster9.Clear();
            PasVisionMonster10.Clear();

            KdMonster1.Clear();
            KdMonster2.Clear();
            KdMonster3.Clear();
            KdMonster4.Clear();
            KdMonster5.Clear();
            KdMonster6.Clear();
            KdMonster7.Clear();
            KdMonster8.Clear();
            KdMonster9.Clear();
            KdMonster10.Clear();

            InitiativeMonster1.Value = 0;
            InitiativeMonster2.Value = 0;
            InitiativeMonster3.Value = 0;
            InitiativeMonster4.Value = 0;
            InitiativeMonster5.Value = 0;
            InitiativeMonster6.Value = 0;
            InitiativeMonster7.Value = 0;
            InitiativeMonster8.Value = 0;
            InitiativeMonster9.Value = 0;
            InitiativeMonster10.Value = 0;

            HpMonster1.Clear();
            HpMonster2.Clear();
            HpMonster3.Clear();
            HpMonster4.Clear();
            HpMonster5.Clear();
            HpMonster6.Clear();
            HpMonster7.Clear();
            HpMonster8.Clear();
            HpMonster9.Clear();
            HpMonster10.Clear();

            LastHpMinusMonster1.Clear();
            LastHpMinusMonster2.Clear();
            LastHpMinusMonster3.Clear();
            LastHpMinusMonster4.Clear();
            LastHpMinusMonster5.Clear();
            LastHpMinusMonster6.Clear();
            LastHpMinusMonster7.Clear();
            LastHpMinusMonster8.Clear();
            LastHpMinusMonster9.Clear();
            LastHpMinusMonster10.Clear();

            HpMinusMonster1.Clear();
            HpMinusMonster2.Clear();
            HpMinusMonster3.Clear();
            HpMinusMonster4.Clear();
            HpMinusMonster5.Clear();
            HpMinusMonster6.Clear();
            HpMinusMonster7.Clear();
            HpMinusMonster8.Clear();
            HpMinusMonster9.Clear();
            HpMinusMonster10.Clear();
        }

        private void labelMonsters_Click(object sender, EventArgs e)
        {
            Monster1.Clear();
            Monster2.Clear();
            Monster3.Clear();
            Monster4.Clear();
            Monster5.Clear();
            Monster6.Clear();
            Monster7.Clear();
            Monster8.Clear();
            Monster9.Clear();
            Monster10.Clear();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            PasVisionMonster1.Clear();
            PasVisionMonster2.Clear();
            PasVisionMonster3.Clear();
            PasVisionMonster4.Clear();
            PasVisionMonster5.Clear();
            PasVisionMonster6.Clear();
            PasVisionMonster7.Clear();
            PasVisionMonster8.Clear();
            PasVisionMonster9.Clear();
            PasVisionMonster10.Clear();
        }

        private void labelKDMonster_Click(object sender, EventArgs e)
        {
            KdMonster1.Clear();
            KdMonster2.Clear();
            KdMonster3.Clear();
            KdMonster4.Clear();
            KdMonster5.Clear();
            KdMonster6.Clear();
            KdMonster7.Clear();
            KdMonster8.Clear();
            KdMonster9.Clear();
            KdMonster10.Clear();
        }

        private void labelInitMonster_Click(object sender, EventArgs e)
        {
            InitiativeMonster1.Value = 0;
            InitiativeMonster2.Value = 0;
            InitiativeMonster3.Value = 0;
            InitiativeMonster4.Value = 0;
            InitiativeMonster5.Value = 0;
            InitiativeMonster6.Value = 0;
            InitiativeMonster7.Value = 0;
            InitiativeMonster8.Value = 0;
            InitiativeMonster9.Value = 0;
            InitiativeMonster10.Value = 0;
        }

        private void labelHPMonster_Click(object sender, EventArgs e)
        {
            HpMonster1.Clear();
            HpMonster2.Clear();
            HpMonster3.Clear();
            HpMonster4.Clear();
            HpMonster5.Clear();
            HpMonster6.Clear();
            HpMonster7.Clear();
            HpMonster8.Clear();
            HpMonster9.Clear();
            HpMonster10.Clear();
        }

        private void LosHPmonster_Click(object sender, EventArgs e)
        {
            LastHpMinusMonster1.Clear();
            LastHpMinusMonster2.Clear();
            LastHpMinusMonster3.Clear();
            LastHpMinusMonster4.Clear();
            LastHpMinusMonster5.Clear();
            LastHpMinusMonster6.Clear();
            LastHpMinusMonster7.Clear();
            LastHpMinusMonster8.Clear();
            LastHpMinusMonster9.Clear();
            LastHpMinusMonster10.Clear();

            HpMinusMonster1.Clear();
            HpMinusMonster2.Clear();
            HpMinusMonster3.Clear();
            HpMinusMonster4.Clear();
            HpMinusMonster5.Clear();
            HpMinusMonster6.Clear();
            HpMinusMonster7.Clear();
            HpMinusMonster8.Clear();
            HpMinusMonster9.Clear();
            HpMinusMonster10.Clear();
        }

        private void DnD_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {                    
            textBox1.Text = Convert.ToString(webBrowser1.Url);
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            webBrowser1.Navigate(textBox1.Text);
        }
        /*
        void notifyIcon1_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)            
            this.WindowState = FormWindowState.Minimized;
            else if (this.WindowState == FormWindowState.Maximized)
                this.WindowState = FormWindowState.Minimized;
            else
                this.WindowState = FormWindowState.Normal;
        }
        */
        private void Form1_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                Hide();
                notifyIcon1.Visible = true;
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            notifyIcon1.Visible = false;
            WindowState = FormWindowState.Normal;
        }

        void timer_Tick(object sender, EventArgs e)
        {
            dateLabel.Text = DateTime.Now.ToLongDateString();
            timeLabel.Text = DateTime.Now.ToLongTimeString();
            
            countLabel.Text = Convert.ToString(i);
            i += 1;
        }
    }
}

