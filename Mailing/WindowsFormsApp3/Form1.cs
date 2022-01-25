using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Net.Mail;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        string file_log = @"D:\log_test.txt";
        bool success;
        public Form1()
        {
            
            InitializeComponent();

            //MessageBox.Show("пусто");

            /*
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
            */

            //textBox1.BorderStyle = BorderStyle.None;
            //textBox1.FlatStyle = FlatStyle.Flat;
            //textBox1.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 0);

            /*
            string file_log = @"D:\log_test.txt";
            string name_user = "ИВАНОВА";
            string pass_user = "qwerty11";
            string email_user = "mail@mail.ru";
            */

        }

        // ОТПРАВКА ПО ЕМЕЙЛ
        private void Send(string file_log, string name_user, string pass_user, string email_user)
        {
            try
            {
                // отправитель - устанавливаем адрес и отображаемое в письме имя
                MailAddress from = new MailAddress("delo@amur-cit.ru", "DELO");
                // кому отправляем
                MailAddress to = new MailAddress(email_user);
                // создаем объект сообщения
                MailMessage m = new MailMessage(from, to);
                // тема письма
                m.Subject = "Дело";
                // текст письма
                m.Body = "Данные для входа в систему ДЕЛО " +
                         "\n" +
                         $"\nИмя: {name_user.ToUpper()}" +
                         $"\nПароль: {pass_user}" +
                         "\n" +
                         "\nДанное письмо сформировано автоматически и не требует ответа. ";

                // (https://docs.amurobl.ru/deloweb/)

                //m.Body = "<h2>Письмо-тест работы smtp-клиента</h2>";
                // письмо представляет код html
                //m.IsBodyHtml = true;

                // адрес smtp-сервера и порт, с которого будем отправлять письмо
                // SmtpClient smtp = new SmtpClient("smtp.mail.ru", 587);  //587 mail.ru? 465 DELO?
                SmtpClient smtp = new SmtpClient("smtp.mail.amur-cit.ru", 465);  //587 mail.ru? 465 DELO?

                // логин и пароль
                // smtp.Credentials = new NetworkCredential("adres@mail.ru", "password");
                smtp.Credentials = new NetworkCredential("delo@amur-cit.ru", "L67btcFV");
                smtp.EnableSsl = true;
                smtp.Send(m);
                Logs(file_log, name_user, pass_user, email_user);
                success = true;
            }

            catch(Exception e)
            {
                string error_text = e.Message;
                Logs_error(file_log, name_user, pass_user, email_user, error_text);
                success = false;

            }
            
        }

        // ЛОГИРОВАНИЕ (метод асинхронной записи)
        private async void Logs(string file_log, string name_user, string pass_user, string email_user)
        {
            // Имя компьютера
            string compName = Environment.MachineName;
            // Дата на компьютере
            string compDate = DateTime.Now.ToString();

            // Логирование
            string text = $"{compName} " + $"Date: {compDate} " + $"Login: {name_user} " + $"Pass: {pass_user} " + $"Email: {email_user}";

            StreamWriter sw = new StreamWriter(file_log, true, Encoding.Default);

            await sw.WriteLineAsync(text);
            sw.Close();
        }

        // ЛОГИРОВАНИЕ error (метод асинхронной записи)
        private async void Logs_error(string file_log, string name_user, string pass_user, string email_user, string error_text)
        {
            // Имя компьютера
            string compName = Environment.MachineName;
            // Дата на компьютере
            string compDate = DateTime.Now.ToString();

            // Логирование
            string text = $"{compName} " + $"Date: {compDate} " + $"Login: {name_user} " + $"Pass: {pass_user} " + $"Email: {email_user} " + $"Error: {error_text}";

            StreamWriter sw = new StreamWriter(file_log, true, Encoding.Default);

            await sw.WriteLineAsync(text);
            sw.Close();
        }

        private string GenPass()
        {
            string[] a = { "w", "e", "r", "t", "y", "u", "o", "p", "a", "s", "d", "f", "h", "k", "z", "x", "c", "v", "b", "n", "m", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };

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
            string s = string.Join("", a);

            return s;
        }
        
        private void button_gen_1_click(object sender, EventArgs e)
        {            
            textBox_pass_1.Text = GenPass();
        }
        private void button_gen_2_click(object sender, EventArgs e)
        {
            textBox_pass_2.Text = GenPass();
        }
        private void button_gen_3_click(object sender, EventArgs e)
        {
            textBox_pass_3.Text = GenPass();
        }
        private void button_gen_4_click(object sender, EventArgs e)
        {
            textBox_pass_4.Text = GenPass();
        }
        private void button_gen_5_click(object sender, EventArgs e)
        {
            textBox_pass_5.Text = GenPass();
        }
        private void button_gen_6_click(object sender, EventArgs e)
        {
            textBox_pass_6.Text = GenPass();
        }
        private void button_gen_7_click(object sender, EventArgs e)
        {
            textBox_pass_7.Text = GenPass();
        }
        private void button_gen_8_click(object sender, EventArgs e)
        {
            textBox_pass_8.Text = GenPass();
        }
        private void button_gen_9_click(object sender, EventArgs e)
        {
            textBox_pass_9.Text = GenPass();
        }
        private void button_gen_10_click(object sender, EventArgs e)
        {
            textBox_pass_10.Text = GenPass();
        }
        private void button_gen_11_click(object sender, EventArgs e)
        {
            textBox_pass_11.Text = GenPass();
        }
        private void button_gen_all_click(object sender, EventArgs e)
        {

            if (textBox_email_1.Text != "" & textBox_user_1.Text != "") textBox_pass_1.Text = GenPass();
            Thread.Sleep(15);
            if (textBox_email_2.Text != "" & textBox_user_2.Text != "") textBox_pass_2.Text = GenPass();
            Thread.Sleep(15);
            if (textBox_email_3.Text != "" & textBox_user_3.Text != "") textBox_pass_3.Text = GenPass();
            Thread.Sleep(15);
            if (textBox_email_4.Text != "" & textBox_user_4.Text != "") textBox_pass_4.Text = GenPass();
            Thread.Sleep(15);
            if (textBox_email_5.Text != "" & textBox_user_5.Text != "") textBox_pass_5.Text = GenPass();
            Thread.Sleep(15);
            if (textBox_email_6.Text != "" & textBox_user_6.Text != "") textBox_pass_6.Text = GenPass();
            Thread.Sleep(15);
            if (textBox_email_7.Text != "" & textBox_user_7.Text != "") textBox_pass_7.Text = GenPass();
            Thread.Sleep(15);
            if (textBox_email_8.Text != "" & textBox_user_8.Text != "") textBox_pass_8.Text = GenPass();
            Thread.Sleep(15);
            if (textBox_email_9.Text != "" & textBox_user_9.Text != "") textBox_pass_9.Text = GenPass();
            Thread.Sleep(15);
            if (textBox_email_10.Text != "" & textBox_user_10.Text != "") textBox_pass_10.Text = GenPass();
        }

        private void button_copy_1_click(object sender, EventArgs e)
        {
            if (textBox_pass_1.Text != "") Clipboard.SetText(textBox_pass_1.Text);
        }
        private void button_copy_2_click(object sender, EventArgs e)
        {
            if (textBox_pass_2.Text != "") Clipboard.SetText(textBox_pass_2.Text);
        }
        private void button_copy_3_click(object sender, EventArgs e)
        {
            if (textBox_pass_3.Text != "") Clipboard.SetText(textBox_pass_3.Text);
        }
        private void button_copy_4_click(object sender, EventArgs e)
        {
            if (textBox_pass_4.Text != "") Clipboard.SetText(textBox_pass_4.Text);
        }
        private void button_copy_5_click(object sender, EventArgs e)
        {
            if (textBox_pass_5.Text != "") Clipboard.SetText(textBox_pass_5.Text);
        }
        private void button_copy_6_click(object sender, EventArgs e)
        {
            if (textBox_pass_6.Text != "") Clipboard.SetText(textBox_pass_6.Text);
        }
        private void button_copy_7_click(object sender, EventArgs e)
        {
            if (textBox_pass_7.Text != "") Clipboard.SetText(textBox_pass_7.Text);
        }
        private void button_copy_8_click(object sender, EventArgs e)
        {
            if (textBox_pass_8.Text != "") Clipboard.SetText(textBox_pass_8.Text);
        }
        private void button_copy_9_click(object sender, EventArgs e)
        {
            if (textBox_pass_9.Text != "") Clipboard.SetText(textBox_pass_9.Text);
        }
        private void button_copy_10_click(object sender, EventArgs e)
        {
            if (textBox_pass_10.Text != "") Clipboard.SetText(textBox_pass_10.Text);
        }
        private void button_copy_11_click(object sender, EventArgs e)
        {
            if (textBox_pass_11.Text != "") Clipboard.SetText(textBox_pass_11.Text);
        }

        private void button_clean_click(object sender, EventArgs e)
        {
            textBox_email_1.Text = "";
            textBox_email_2.Text = "";
            textBox_email_3.Text = "";
            textBox_email_4.Text = "";
            textBox_email_5.Text = "";
            textBox_email_6.Text = "";
            textBox_email_7.Text = "";
            textBox_email_8.Text = "";
            textBox_email_9.Text = "";
            textBox_email_10.Text = "";

            textBox_user_1.Text = "";
            textBox_user_2.Text = "";
            textBox_user_3.Text = "";
            textBox_user_4.Text = "";
            textBox_user_5.Text = "";
            textBox_user_6.Text = "";
            textBox_user_7.Text = "";
            textBox_user_8.Text = "";
            textBox_user_9.Text = "";
            textBox_user_10.Text = "";

            textBox_pass_1.Text = "";
            textBox_pass_2.Text = "";
            textBox_pass_3.Text = "";
            textBox_pass_4.Text = "";
            textBox_pass_5.Text = "";
            textBox_pass_6.Text = "";
            textBox_pass_7.Text = "";
            textBox_pass_8.Text = "";
            textBox_pass_9.Text = "";
            textBox_pass_10.Text = "";

            label_inform_1.Text = "";
            label_inform_2.Text = "";
            label_inform_3.Text = "";
            label_inform_4.Text = "";
            label_inform_5.Text = "";
            label_inform_6.Text = "";
            label_inform_7.Text = "";
            label_inform_8.Text = "";
            label_inform_9.Text = "";
            label_inform_10.Text = "";

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void SendEmail(object sender, EventArgs e)
        {
            label_inform_1.Text = "";
            label_inform_2.Text = "";
            label_inform_3.Text = "";
            label_inform_4.Text = "";
            label_inform_5.Text = "";
            label_inform_6.Text = "";
            label_inform_7.Text = "";
            label_inform_8.Text = "";
            label_inform_9.Text = "";
            label_inform_10.Text = "";

            if (textBox_email_1.Text != "" & textBox_user_1.Text != "" & textBox_pass_1.Text != "")
            {
                Send(file_log, textBox_user_1.Text, textBox_pass_1.Text, textBox_email_1.Text);
                //label_inform_1.BackColor = Color.FromArgb(255, 0, 0);
                label_inform_1.ForeColor = Color.FromArgb(255, 0, 0);
                if (success)
                {
                    label_inform_1.ForeColor = Color.FromArgb(0, 255, 0);
                    label_inform_1.Text = "+";
                }
                if (!success)
                {
                    label_inform_1.ForeColor = Color.FromArgb(255, 0, 0);
                    label_inform_1.Text = "×";
                }
            }
            if (textBox_email_2.Text != "" & textBox_user_2.Text != "" & textBox_pass_2.Text != "")
            {
                Send(file_log, textBox_user_2.Text, textBox_pass_2.Text, textBox_email_2.Text);
                if (success)
                {
                    label_inform_2.ForeColor = Color.FromArgb(0, 255, 0);
                    label_inform_2.Text = "+";
                }
                if (!success)
                {
                    label_inform_2.ForeColor = Color.FromArgb(255, 0, 0);
                    label_inform_2.Text = "×";
                }
            }
            if (textBox_email_3.Text != "" & textBox_user_3.Text != "" & textBox_pass_3.Text != "")
            {
                Send(file_log, textBox_user_3.Text, textBox_pass_3.Text, textBox_email_3.Text);
                if (success)
                {
                    label_inform_3.ForeColor = Color.FromArgb(0, 255, 0);
                    label_inform_3.Text = "+";
                }
                if (!success)
                {
                    label_inform_3.ForeColor = Color.FromArgb(255, 0, 0);
                    label_inform_3.Text = "×";
                }
            }
            if (textBox_email_4.Text != "" & textBox_user_4.Text != "" & textBox_pass_4.Text != "")
            {
                Send(file_log, textBox_user_4.Text, textBox_pass_4.Text, textBox_email_4.Text);
                if (success)
                {
                    label_inform_4.ForeColor = Color.FromArgb(0, 255, 0);
                    label_inform_4.Text = "+";
                }
                if (!success)
                {
                    label_inform_4.ForeColor = Color.FromArgb(255, 0, 0);
                    label_inform_4.Text = "×";
                }
            }
            if (textBox_email_5.Text != "" & textBox_user_5.Text != "" & textBox_pass_5.Text != "")
            {
                Send(file_log, textBox_user_5.Text, textBox_pass_5.Text, textBox_email_5.Text);
                if (success)
                {
                    label_inform_5.ForeColor = Color.FromArgb(0, 255, 0);
                    label_inform_5.Text = "+";
                }
                if (!success)
                {
                    label_inform_5.ForeColor = Color.FromArgb(255, 0, 0);
                    label_inform_5.Text = "×";
                }
            }
            if (textBox_email_6.Text != "" & textBox_user_6.Text != "" & textBox_pass_6.Text != "")
            {
                Send(file_log, textBox_user_6.Text, textBox_pass_6.Text, textBox_email_6.Text);
                if (success)
                {
                    label_inform_6.ForeColor = Color.FromArgb(0, 255, 0);
                    label_inform_6.Text = "+";
                }
                if (!success)
                {
                    label_inform_6.ForeColor = Color.FromArgb(255, 0, 0);
                    label_inform_6.Text = "×";
                }
            }
            if (textBox_email_7.Text != "" & textBox_user_7.Text != "" & textBox_pass_7.Text != "")
            {
                Send(file_log, textBox_user_7.Text, textBox_pass_7.Text, textBox_email_7.Text);
                if (success)
                {
                    label_inform_7.ForeColor = Color.FromArgb(0, 255, 0);
                    label_inform_7.Text = "+";
                }
                if (!success)
                {
                    label_inform_7.ForeColor = Color.FromArgb(255, 0, 0);
                    label_inform_7.Text = "×";
                }
            }
            if (textBox_email_8.Text != "" & textBox_user_8.Text != "" & textBox_pass_8.Text != "")
            {
                Send(file_log, textBox_user_8.Text, textBox_pass_8.Text, textBox_email_8.Text);
                if (success)
                {
                    label_inform_8.ForeColor = Color.FromArgb(0, 255, 0);
                    label_inform_8.Text = "+";
                }
                if (!success)
                {
                    label_inform_8.ForeColor = Color.FromArgb(255, 0, 0);
                    label_inform_8.Text = "×";
                }
            }
            if (textBox_email_9.Text != "" & textBox_user_9.Text != "" & textBox_pass_9.Text != "")
            {
                Send(file_log, textBox_user_9.Text, textBox_pass_9.Text, textBox_email_9.Text);
                if (success)
                {
                    label_inform_9.ForeColor = Color.FromArgb(0, 255, 0);
                    label_inform_9.Text = "+";
                }
                if (!success)
                {
                    label_inform_9.ForeColor = Color.FromArgb(255, 0, 0);
                    label_inform_9.Text = "×";
                }
            }
            if (textBox_email_10.Text != "" & textBox_user_10.Text != "" & textBox_pass_10.Text != "")
            {
                Send(file_log, textBox_user_10.Text, textBox_pass_10.Text, textBox_email_10.Text);
                if (success)
                {
                    label_inform_10.ForeColor = Color.FromArgb(0, 255, 0);
                    label_inform_10.Text = "+";
                }
                if (!success)
                {
                    label_inform_10.ForeColor = Color.FromArgb(255, 0, 0);
                    label_inform_10.Text = "×";
                }
            }
        }
    }
}
