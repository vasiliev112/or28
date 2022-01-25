using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text;
using System.Net;
using System.IO;
using System.Net.Mail;
using System.Configuration;
using System.Data.SqlClient;

namespace DroppingPass
{
    class DataBase
    {

        public List<string> shoDB(string USER)
        {
            //Передача данных о подключении из App.config
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            // Создание подключения
            SqlConnection connection = new SqlConnection(connectionString);

            //Данные для sql запроса
            string sql = $"select ISN_USER, EMAIL from NTFY_USER_EMAIL, USER_CL where USER_CL.CLASSIF_NAME = '{USER}' and USER_CL.ISN_LCLASSIF = NTFY_USER_EMAIL.ISN_USER;";

            List<string> numbers = new List<string>();

            try
            {
                // Открываем подключение
                connection.Open();

                SqlCommand command = new SqlCommand(sql, connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {                                    
                    int n = 0;
                        // считываем значения
                    while (reader.Read())
                    {
                        //Построчно считываем, записываем каждую строку в лист
                        numbers.Add(reader[1].ToString());
                        n++;
                    }                        
                }

                reader.Close();
                
            }
            catch (SqlException ex)
            {
                //Console.WriteLine(ex.Message);
            }
            finally
            {
                // закрываем подключение
                connection.Close();
            }

            return numbers;
        }
    }
}
