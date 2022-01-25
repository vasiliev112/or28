using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        bool z = false;
        public Form1()
        {
            InitializeComponent();
            button1.BackColor = Color.FromArgb(0, 0, 0);
            button1.ForeColor = Color.FromArgb(0, 255, 0);
            button1.FlatStyle = FlatStyle.Flat;
            //button1.FlatAppearance.BorderSize = 1;
            button1.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 0);
            
            button2.BackColor = Color.FromArgb(0, 0, 0);
            button2.ForeColor = Color.FromArgb(0, 255, 0);
            button2.FlatStyle = FlatStyle.Flat;
            button2.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 0);

            textBox1.TextAlign = HorizontalAlignment.Center;
            textBox1.BackColor = Color.FromArgb(0, 0, 0);
            textBox1.ForeColor = Color.FromArgb(0, 255, 0);

            //textBox1.BorderStyle = BorderStyle.None;
            //textBox1.FlatStyle = FlatStyle.Flat;
            //textBox1.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 0);



        }

        private void InitializeMyControl()
        {
            string[] a = {"w","e","r","t","y","u","o","p","a","s","d","f","h","k","z","x","c","v","b","n","m","1","2","3","4","5","6","7","8","9","0"};
            
            // Перемешивание массива
            Random rand = new Random();

            for (int i = a.Length - 1; i >= 1; i--)
            {
                int j = rand.Next(i + 1);
                // обменять значения data[j] и data[i]
                var temp = a[j];
                a[j] = a[i];
                a[i] = temp;
            }

            // Обрезание массива
            Array.Resize(ref a, 8);

            // Перевод массива в стринг
            var s = string.Join("", a);

            textBox1.Text = s;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            InitializeMyControl();
            button2.ForeColor = Color.FromArgb(0, 255, 0);
            z = true;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Копирование содержимого textBox1 в буфер
            if (z)  // Если значение не пустое(т.е. хоть раз была нажата кнопка "Generate")
            {
                Clipboard.SetText(textBox1.Text);
                button2.ForeColor = Color.FromArgb(255, 0, 255);
            }
            
        }
    }
}
