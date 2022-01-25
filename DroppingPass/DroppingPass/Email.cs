using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Net.Mail;
using System.Configuration;
using System.Data.SqlClient;

namespace DroppingPass
{
    class Email
    {
        
        public void Sending(string USER, string PASS, string toMail)
        {            
            // отправитель - устанавливаем адрес и отображаемое в письме имя
            string fromMail= "@mail.ru";
            MailAddress from = new MailAddress(fromMail, "DELO");
            // кому отправляем
            MailAddress to = new MailAddress(toMail);
            // создаем объект сообщения
            MailMessage m = new MailMessage(from, to);
            // тема письма
            m.Subject = "Дело";
            // текст письма
            m.Body = "Данные для входа в систему " +
                      "\n" +
                      $"\nИмя: {USER.ToUpper()}" +
                      $"\nПароль: {PASS}" +
                      "\n" +
                      "\nДанное письмо сформировано автоматически и не требует ответа. ";

            //m.Body = "<h2>Письмо-тест работы smtp-клиента</h2>";
            // письмо представляет код html
            //m.IsBodyHtml = true;

            // адрес smtp-сервера и порт, с которого будем отправлять письмо
            SmtpClient smtp = new SmtpClient("smtp.mail.ru", 587);  //465
            // логин и пароль
            smtp.Credentials = new NetworkCredential("@mail.ru", "pass");
            smtp.EnableSsl = true;
            smtp.Send(m);
            //  Console.Read();
        }

    }
}

