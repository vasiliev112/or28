using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Grinding
{
    public partial class Form1 : Form
    {
        List<string> lvl = new List<string>();
        List<string> gem = new List<string>();

        DataSet ds = new DataSet();
        string[] arraNameColumnGrind;
        string[] arraCellGrind;

        string[] arraNameColumnGem;
        string[] arraCellGem;

        string[] arraNameColumnLevel;
        string[] arraCellLevel;

        List<string[]> strokiGrind = new List<string[]>();
        List<string[]> strokiGem = new List<string[]>();
        List<string[]> strokiLevel = new List<string[]>();

        private float oldFormWidth;

        float fs;

        int fontsize = 6;

        // УВ - уровень вещи
        decimal YV;
        // КУВ - Коэффициент уровня вещи
        decimal KYV;
        // БШ - Базовый шанс
        decimal BSH;
        // КВК - Коэффициент влияния камней
        decimal KVK;
        // РШ - Расчетный шанс
        decimal RSH;
        // ИШ - Итоговый шанс
        decimal ISH;

        //метод заполняет dataGridView данными из текстового файла
        public void Function_Grind()
        {
            //создаем временную таблицу
            ds.Tables.Add("Temp");

            //путь к текстовому файлу
            string path = @"Grind.ini";
            StreamReader sr = new StreamReader(path);

            /*создаем колонки в таблице и заполняем их названиями*/
            //считываем первую строку из файла, в ней названия столбцов
            string firstLine = sr.ReadLine();
            //удаление пробелов, табуляций в начале и в конце
            string firstLineMod = System.Text.RegularExpressions.Regex.Replace(firstLine, @"\s*;\s*", ";");
            //массив имен колонок из файла
            arraNameColumnGrind = System.Text.RegularExpressions.Regex.Split(firstLineMod, ";");
            for (int i = 0; i < arraNameColumnGrind.Length; i++)
            {
                if (i == 0)
                    ds.Tables[0].Columns.Add(arraNameColumnGrind[i]);
                else
                    ds.Tables[0].Columns.Add("+" + arraNameColumnGrind[i]);
            }

            /*заполняем строки в таблице*/
            string Line = sr.ReadLine();
            while (Line != null)
            {
                //удаление пробелов, табуляций в начале и в конце
                string LineMod = System.Text.RegularExpressions.Regex.Replace(Line, @"\s*;\s*", ";");

                arraCellGrind = System.Text.RegularExpressions.Regex.Split(LineMod, ";");
                ds.Tables[0].Rows.Add(arraCellGrind);
                strokiGrind.Add(arraCellGrind);
                Line = sr.ReadLine();
            }

            //привязываем dataGridView к таблице
            dataGridView1.DataSource = ds.Tables[0];

        }

        public void Function_Gem()
        {
            //путь к текстовому файлу
            string path = @"Gem.ini";
            StreamReader sr = new StreamReader(path);

            /*создаем колонки в таблице и заполняем их названиями*/
            //считываем первую строку из файла, в ней названия столбцов
            string firstLine = sr.ReadLine();
            //удаление пробелов, табуляций в начале и в конце
            string firstLineMod = System.Text.RegularExpressions.Regex.Replace(firstLine, @"\s*;\s*", ";");
            //массив имен колонок из файла
            arraNameColumnGem = System.Text.RegularExpressions.Regex.Split(firstLineMod, ";");

            /*заполняем строки в таблице*/
            string Line = sr.ReadLine();
            while (Line != null)
            {
                //удаление пробелов, табуляций в начале и в конце
                string LineMod = System.Text.RegularExpressions.Regex.Replace(Line, @"\s*;\s*", ";");

                arraCellGem = System.Text.RegularExpressions.Regex.Split(LineMod, ";");
                strokiGem.Add(arraCellGem);
                Line = sr.ReadLine();
            }
            if (arraNameColumnGem.Length != arraCellGem.Length)
                MessageBox.Show("Проблемы с файлом Gem.ini");
        }

        public void Function_Level()
        {
            //путь к текстовому файлу
            string path = @"Level.ini";
            StreamReader sr = new StreamReader(path);

            /*создаем колонки в таблице и заполняем их названиями*/
            //считываем первую строку из файла, в ней названия столбцов
            string firstLine = sr.ReadLine();
            //удаление пробелов, табуляций в начале и в конце
            string firstLineMod = System.Text.RegularExpressions.Regex.Replace(firstLine, @"\s*;\s*", ";");
            //массив имен колонок из файла
            arraNameColumnLevel = System.Text.RegularExpressions.Regex.Split(firstLineMod, ";");

            /*заполняем строки в таблице*/
            string Line = sr.ReadLine();
            while (Line != null)
            {
                //удаление пробелов, табуляций в начале и в конце
                string LineMod = System.Text.RegularExpressions.Regex.Replace(Line, @"\s*;\s*", ";");

                arraCellLevel = System.Text.RegularExpressions.Regex.Split(LineMod, ";");
                strokiLevel.Add(arraCellLevel);
                Line = sr.ReadLine();
            }
            if (arraNameColumnLevel.Length != arraCellLevel.Length)
                MessageBox.Show("Проблемы с файлом Gem.ini");

        }

        public void Function_Exit()
        {
            if (Application.MessageLoop)
            {
                // Use this since we are a WinForms app
                Application.Exit();
            }
            else
            {
                // Use this since we are a console app
                Environment.Exit(1);
            }
        }

        public Form1()
        {
            InitializeComponent();
            //dataGridView1.MaximumSize = new Size(this.dataGridView1.Width, 0);
            //dataGridView1.AutoSize = true;
            oldFormWidth = Size.Width;

            Function_Grind();
            Function_Gem();
            Function_Level();
            fs = dataGridView1.Font.Size;

            dataGridView1.EnableHeadersVisualStyles = false;

            button1.BackColor = Color.White;
            button2.BackColor = Color.Black;


            foreach (string i in arraNameColumnGem)
            {
                gem.Add(i);
            }                    
            comboBoxGem.DataSource = gem;


            for (int i = Convert.ToInt32(arraCellLevel[0]); i <= Convert.ToInt32(arraCellLevel[1]); i++)
            {
                lvl.Add(i.ToString());
            }
            comboBoxLVL.DataSource = lvl;
            

            foreach (string i in arraNameColumnGrind)
            {
                if (string.IsNullOrWhiteSpace(i))
                {
                    MessageBox.Show("Ошибка в файле - Grind.ini");
                    Function_Exit();
                }
            }

            foreach (string i in arraCellGrind)
            {
                if (string.IsNullOrWhiteSpace(i))
                {
                    MessageBox.Show("Ошибка в файле - Grind.ini");
                    Function_Exit();
                }
            }

            foreach (string i in arraNameColumnGem)
            {
                if (string.IsNullOrWhiteSpace(i))
                {
                    MessageBox.Show("Ошибка в файле - Gem.ini");
                    Function_Exit();
                }
            }

            foreach (string i in arraCellGem)
            {
                if (string.IsNullOrWhiteSpace(i))
                {
                    MessageBox.Show("Ошибка в файле - Gem.ini");
                    Function_Exit();
                }
            }

            Function_Change();

            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            //dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[0].Frozen = true;
            dataGridView1.Rows[0].Frozen = true;

            //colorTheme(Color.Black, Color.White);
            colorTheme(Color.White, Color.Black);
        }

        private void colorTheme(Color backColor, Color fontColor)
        {
            // Цвет текста
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = fontColor;
            dataGridView1.DefaultCellStyle.ForeColor = fontColor;

            label1.ForeColor = fontColor;
            label2.ForeColor = fontColor;
            label3.ForeColor = fontColor;

            comboBoxGem.ForeColor = fontColor;
            comboBoxLVL.ForeColor = fontColor;

            // Цвет фона
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = backColor;            

            dataGridView1.DefaultCellStyle.BackColor = backColor;
            dataGridView1.BackgroundColor = backColor;

            panel1.BackColor = backColor;
            panel2.BackColor = backColor;

            button1.FlatStyle = FlatStyle.Flat;
            button2.FlatStyle = FlatStyle.Flat;

            button1.FlatAppearance.BorderColor = fontColor;
            button2.FlatAppearance.BorderColor = fontColor;

            comboBoxGem.BackColor = backColor;
            comboBoxLVL.BackColor = backColor;


        }
        private void dataGridView1_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            for (int i = 0; i < dataGridView1.RowCount; i+=2)
            {
                dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.LightGray;
            }
                
        }

        public void Function_Change()
        {
            progressBar1.Value = 0;
            dataGridView1.Refresh();
            int gem = Array.IndexOf(arraNameColumnGem, comboBoxGem.SelectedItem);

            int progr = progressBar1.Maximum / strokiGrind.Count;
            
            for (int j = 0; j < strokiGrind.Count; j++)
            {
                progressBar1.Value += progr;
                //dataGridView1.Rows[j].Cells[0].Value = lstype[j];
                //this.dataGridView1.Rows.Add();
                for (int i = 1; i < strokiGrind[j].Length; i++)
                {
                    YV = Convert.ToDecimal(comboBoxLVL.SelectedItem);
                    KYV = 30 / YV;          
                    KVK = 4 * Convert.ToDecimal(arraCellGem[gem]);
                    BSH = Convert.ToDecimal(strokiGrind[j][i]);
                    if (BSH == 0 && KVK != 0)
                    {
                        RSH = KVK * 100 / 4;
                    }
                    else if (BSH != 0 && KVK == 0)
                    {
                        RSH = BSH * 100 / 4;
                    }
                    else if (BSH == 0 && KVK == 0)
                    {
                        RSH = 100 / 4;
                    }
                    else
                        RSH = BSH * KVK * 100 / 4;

                    ISH = RSH * KYV / 1000;

                    string number = "";
                    for (int z = 0; z < Convert.ToInt32(numericUpDown1.Value); z++)
                    {
                        number += "0";
                    }
                    string numbers = "0." + number;

                    dataGridView1.Rows[j].Cells[i].Value = ISH.ToString(numbers) + @"%";
                }
            }
        }

            private void SelectionChangeCommitted(object sender, EventArgs e)
        {
            /*
            for (int j = 0; j < strokiGrind.Count; j++)
            {
                //dataGridView1.Rows[j].Cells[0].Value = lstype[j];
                //this.dataGridView1.Rows.Add();

                for (int i = 1; i < strokiGrind[j].Length; i++)
                {
                    dataGridView1.Rows[j].Cells[i].Value +=@"%";
                }
            }
            */
            Function_Change();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            dataGridView1.Font = new Font("Microsoft Sans Serif", fontsize);
            fontsize++;

            //dataGridView1.Font = new Font("Verdana", 9, FontStyle.Regular);
            //dataGridView1.Refresh();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            Control control = (Control)sender;
            var newFormWidth = Size.Width;

            float fontSize = Font.Size * newFormWidth / oldFormWidth;
            if (fontSize >= fs)
            {            
                dataGridView1.Font = new Font("Microsoft Sans Serif", fontSize);
            }



        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            colorTheme(Color.White, Color.Black);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            colorTheme(Color.Black, Color.White);
        }
    }
}
