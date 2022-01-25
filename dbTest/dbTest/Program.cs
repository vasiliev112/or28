using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Configuration;
using System.Data.SqlClient;

namespace dbTest
{

    class Base
    {
        public void dbdb()
        {
            
        }
    }

    class Program
    {            

        static void Main(string[] args)
        {

            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            // Создание подключения
            SqlConnection connection = new SqlConnection(connectionString);

            string isnUser = "1306624";
            //string sql = "SELECT * FROM USER_CL where CLASSIF_NAME = 'API';";
            string sql = "select ISN_USER, EMAIL from NTFY_USER_EMAIL where ISN_USER = " + isnUser + ";";
            
            try
            {
                // Открываем подключение
                connection.Open();
                Console.WriteLine("Подключение открыто");

                SqlCommand command = new SqlCommand(sql, connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    // считываем значения
                    while (reader.Read())
                    {
                        for (int i = 0; i < 1; i++)
                        Console.Write($"{reader[i]}\t");
                        Console.WriteLine();
                    }
                }

                reader.Close();

                // Вывод информации о подключении
                
                Console.WriteLine("Свойства подключения:");
                Console.WriteLine($"\tСтрока подключения: {connection.ConnectionString}");
                Console.WriteLine($"\tБаза данных: {connection.Database}");
                Console.WriteLine($"\tСервер: {connection.DataSource}");
                Console.WriteLine($"\tВерсия сервера: {connection.ServerVersion}");
                Console.WriteLine($"\tСостояние: {connection.State}");
                Console.WriteLine($"\tWorkstationld: {connection.WorkstationId}");
                
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                // закрываем подключение
                connection.Close();
                Console.WriteLine("Подключение закрыто...");
            }


            Console.Read();
        }



    }
    
}
