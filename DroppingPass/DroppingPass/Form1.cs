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
using System.Net.Mail;
using System.Configuration;
using System.Data.SqlClient;

namespace DroppingPass
{
    public partial class Form1 : Form
    {
        string usr = "";
        List<string> em = new List<string>();

        public Form1()
        {
            InitializeComponent();
            // Кнопка 1
            button1.BackColor = Color.FromArgb(0, 0, 0);
            button1.ForeColor = Color.FromArgb(0, 255, 0);
            button1.FlatStyle = FlatStyle.Flat;
            //button1.FlatAppearance.BorderSize = 1;
            button1.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 0);

            // Кнопка 2
            button2.BackColor = Color.FromArgb(0, 0, 0);
            button2.ForeColor = Color.FromArgb(0, 255, 0);
            button2.FlatStyle = FlatStyle.Flat;
            button2.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 0);

            // Текстовый 1
            textBox1.TextAlign = HorizontalAlignment.Center;
            textBox1.BackColor = Color.FromArgb(0, 0, 0);
            textBox1.ForeColor = Color.FromArgb(0, 255, 0);

            //textBox1.BorderStyle = BorderStyle.None;
            //textBox1.FlatStyle = FlatStyle.Flat;
            //textBox1.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 0);
        }

        // Сгенерировать
        private void button1_Click(object sender, EventArgs e)
        {
            RandomPass pass = new RandomPass();
            textBox1.Text = pass.Gen();            

            button2.ForeColor = Color.FromArgb(0, 255, 0);
        }

        // Копировать
        private void button2_Click(object sender, EventArgs e)
        {
            // Копирование содержимого textBox1 в буфер
            if (textBox1.Text != null)  // Если значение не пустое(т.е. хоть раз была нажата кнопка "Generate")
            {
                Clipboard.SetText(textBox1.Text);
                button2.ForeColor = Color.FromArgb(255, 0, 255);             
            }
        }

        // Отправить
        private void button3_Click(object sender, EventArgs e)
        {
            RandomPass pass = new RandomPass();
            textBox1.Text = pass.Gen();

            Email email = new Email();
            /*
            foreach (string i in em)
            {
                email.Sending(usr, pass.Gen(), i);
            }
            */
            for (int i = 0; i < em.Count; i++)
            {
                email.Sending(usr, pass.Gen(), em[i]);
            }            
            
        }

        // Найти
        private void button4_Click(object sender, EventArgs e)
        {
            usr = textBox3.Text;
            string dbValue = "";
            //dbValue +=  + "\n";
            //string abc = "1306624";
            DataBase data = new DataBase();
            List<string> numbers = data.shoDB(usr);

            em = data.shoDB(usr);
            
            for (int i = 0; i < em.Count; i++)
            {
                dbValue += em[i] + "\n";
            }
            
            //textBox2.Text = data.shoDB(textUser);
            //richTextBox1.Text = data.shoDB(textUser);
            richTextBox1.Text = dbValue;
        }
    }
}
