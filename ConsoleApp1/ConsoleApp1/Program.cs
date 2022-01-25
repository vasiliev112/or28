using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Numerics;
using System.IO;

namespace ConsoleApp1
{
   
    class Program
    {
        static void ShowEnvironmentDetalis()
        {
            Console.Title = "CONSOLE";
            Console.ForegroundColor = ConsoleColor.Green;

            foreach (string i in Environment.GetLogicalDrives())
            {
                Console.WriteLine($"Drive: {i}");
            }

            int a = 111111111;
            double b = 5.234234;
            string c = "asdff";
            int aa = default;
            double bb = new double();
            string aaa = "5,567";
            string aaaa = "1233";

            string name = "Vasiliev";
            string name2 = "Vasiliev";
            string name3 = "Va";

            Console.WriteLine($"OS: {Environment.OSVersion}");
            Console.WriteLine($"Number of processors: {Environment.ProcessorCount}");
            Console.WriteLine($".NET Version: {Environment.Version}");
            Console.WriteLine($"MachineName: {Environment.MachineName}");
            Console.WriteLine($"UserName: {Environment.UserName}");

            Console.WriteLine($"A - {a:n} B - {b:f3} C - {c}");
            Console.WriteLine($"Default aa = {aa} \n" +
                              $"Default bb = {bb} \n" +
                               "asd" + (char)10 +
                               "abc");
            //double bbb = Double.Parse(aaa);
            Console.WriteLine($"Max of int {int.MaxValue}");
            //Console.WriteLine(double.Parse(aaa));
            //Console.WriteLine(int.Parse(aaaa));

            DateTime dt = new DateTime(2019, 12, 27);
            // Какой это день месяца?
            Console.WriteLine("The day of {0} is {1}", dt.Date, dt.DayOfWeek);
            // Сейчас месяц декабрь.
            dt = dt.AddMonths(2);
            Console.WriteLine("Daylight savings: {0}", dt.IsDaylightSavingTime());
            // Этот конструктор принимает часы, минуты и секунды.
            TimeSpan ts = new TimeSpan(23, 45, 10);
            Console.WriteLine(ts);
            // Вычесть 15 минут из текущего значения TimeSpan и вывести результат.

            /*
            Console.WriteLine($"Name: {name}");
            Console.WriteLine($"Длина Name: {name.Length}");
            Console.WriteLine($"В верхнем регистре Name: {name.ToUpper()}");
            Console.WriteLine($"В нижнем регистре Name: {name.ToLower()}");
            Console.WriteLine($"Содержит ли букву 'а' Name: {name.Contains("a")}");
            Console.WriteLine($"Заменяет ev на 'EV' Name: {name.Replace("ev", "EV")}");

            Console.WriteLine(@"\nText\n\ttext\\");

            Console.WriteLine($"= {name == "Vasisliev"}");
            Console.WriteLine($"= {name == "VasislieV"}");
            Console.WriteLine($"= {name == "vasisliev"}");
            Console.WriteLine($"= {name}");

            string arg1 = name.Replace("ev", "V");
            Console.WriteLine(arg1);
            

            Console.WriteLine("=> String equality:");
            string s1 = "Hello!";
            string s2 = "Yo!";
            Console.WriteLine("si = {0}", s1);
            Console.WriteLine("s2 = {0}", s2);
            Console.WriteLine();
            // Проверить строки на равенство.
            Console.WriteLine("si == s2: {0}", s1 == s2);
            Console.WriteLine("si == Hello!: {0}", s1 == "Hello!");
            Console.WriteLine("si == HELLO!: {0}", s1 == "HELLO!");
            Console.WriteLine("si == hello!: {0}", s1 == "hello!");
            Console.WriteLine("si.Equals(s2): {0}", s1.Equals(s2));
            Console.WriteLine("Yo.Equals(s2): {0}", "Yo!".Equals(s2));
            Console.WriteLine();

            Console.Write(name.Equals(name2, StringComparison.OrdinalIgnoreCase));

            if (name.Equals(name2))
            {
                Console.WriteLine("Совпали");
            }
            */
            Console.WriteLine("");
            Console.WriteLine("=> Using the StringBuilder:");
            StringBuilder sb = new StringBuilder("**** Fantastic Games ****");
            sb.Append("\n");
            sb.AppendLine("Half Life");
            sb.AppendLine("Morrowind");
            sb.AppendLine("Deus Ex" + "2");
            sb.AppendLine("System Shock");
            Console.WriteLine(sb.ToString());
            sb.Replace("2", " Invisible War");
            Console.WriteLine(sb.ToString());
            Console.WriteLine("sb has {0} chars.", sb.Length);
            Console.WriteLine();
            string arg1 = sb.ToString();
            Console.WriteLine(arg1);
        }

        
        static double Test(double arg1, double arg2)
        {
            return arg1 + arg2;
        }
        static string Test(string arg1, string arg2)
        {
            return arg1 + " " + arg2;
        }

        struct strRAG
        {
            public int zz;
            public int xx;

            public strRAG(int argXX, int argZZ)
            {
                xx = argXX;
                zz = argZZ;
            }

            public void UpValue()
            {
                xx++;
                zz++;
            }

            public void DownValue()
            {
                xx--;
                zz--;
            }
            public void ShowValue()
            {
                Console.WriteLine($"{zz} {xx}");
            }
        }

        static void Main(string [] args)
        {

            //var a = 0;
            //var b = 5.434;
            //var c = "asd";

            //Console.WriteLine($"a - {a.GetType().Name} \nb - {b.GetType().Name} \nc- {c.GetType().Name}");
            //Console.ReadLine();

            //ShowEnvironmentDetalis();

            //string userMessage = string.Format($"100000 in hex is {100000:f3}");
            //MessageBox.Show($"100000 in hex is {100000:f3}");

            int a = 0;
            int b = 1;
            int c = 2;
            string d = "asd";
            string dd = "qwe";

            int[] sss = {0,1,2,3,4,5,6,7,8,9};
            object[] re = new object[] {1,2,"asd"};

            strRAG RAG = new strRAG(100,100);

            RAG.UpValue();

            Console.WriteLine($"XX = {RAG.xx} ZZ = {RAG.zz}");

            for (int i = 0; i < 5; i++) RAG.DownValue();

            Console.WriteLine($"XX = {RAG.xx} ZZ = {RAG.zz}");

            Console.ReadLine();            
        }
    }
}
