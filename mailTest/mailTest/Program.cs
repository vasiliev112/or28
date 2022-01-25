using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Net.Mail;

namespace mailTest
{
    class Program
    {
        // VМетод асинхронной записи
        static async void Task1(string file_log, string name_user, string pass_user, string email_user)
        {
            
            // имя хоста
            //string myHost = Dns.GetHostName();

            // IP по имени хоста, выдает список, можно обойти в цикле весь, здесь берется первый адрес
            //string compIP = Dns.GetHostEntry(myHost).AddressList[1].ToString();

            //string userNameWin = Environment.UserName;

            // Имя компьютера
            string compName = Environment.MachineName;
            // Дата на компьютере
            string compDate = DateTime.Now.ToString();

            // Логирование
            string text = $"{compName} " + $"{compDate} " + $"{name_user} " + $"{pass_user} " + $"{email_user}";

            StreamWriter sw = new StreamWriter(file_log, true, Encoding.Default);

            await sw.WriteLineAsync(text);
            sw.Close();

        }


        static void Main(string[] args)
        {

            string file_log = @"D:\log_test.txt";
            string name_user = "ИВАНОВА";
            string pass_user = "qwerty11";
            string email_user = "mail@mail.ru";            

            Task1(file_log, name_user, pass_user, email_user);

            // ОТПРАВКА ПО ЕМЕЙЛ

            // отправитель - устанавливаем адрес и отображаемое в письме имя
            MailAddress from = new MailAddress("delo@amur-cit.ru", "DELO");
            // кому отправляем
            MailAddress to = new MailAddress("vasiliev.aa@amur-cit");
            // создаем объект сообщения
            MailMessage m = new MailMessage(from, to);
            // тема письма
            m.Subject = "Дело";
            // текст письма
            m.Body = "Данные для входа в систему ДЕЛО (https://docs.amurobl.ru/deloweb/) " +
                     "\n" +
                     $"\nИмя: {name_user.ToUpper()}" +
                     $"\nПароль: {pass_user}" +
                     "\n" +
                     "\nДанное письмо сформировано автоматически и не требует ответа. ";

            //m.Body = "<h2>Письмо-тест работы smtp-клиента</h2>";
            // письмо представляет код html
            //m.IsBodyHtml = true;

            // адрес smtp-сервера и порт, с которого будем отправлять письмо
            // SmtpClient smtp = new SmtpClient("smtp.mail.ru", 587);  //465 mail.ru? 587 DELO?
            SmtpClient smtp = new SmtpClient("mail.amur-cit.ru", 587);  //587 mail.ru? 465 DELO?
            // логин и пароль
            // smtp.Credentials = new NetworkCredential("adres@mail.ru", "password");
            smtp.Credentials = new NetworkCredential("delo@amur-cit.ru", "L67btcFV");
            smtp.EnableSsl = false;
            smtp.Send(m);
            Console.Read();

        }
    }
}
