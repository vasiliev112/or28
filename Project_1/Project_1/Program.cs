using System;

namespace HelloApp
{
    class Calculator
    {
        /*public string Sum(string a, string b, string c = "")
        {
            return a + b + c;
        }*/

        public double Sum(double a, double b, double c = 0)
        {
            return a + b + c;
        }
    }

    class Program
    {
        
        static void Main(string[] args)
        {
            Calculator summa = new Calculator();

            //Console.WriteLine($" Сумма целых: {a1} + {a2} = {a12}");
            //Console.WriteLine($" Сумма целых: {b1} + {b2} = {b12}");

            double a1 = 2.123;
            int a2 = 2;

            Console.WriteLine(summa.Sum(1, 2));
            Console.WriteLine(summa.Sum(1, 2.3, 1));
            Console.WriteLine(Convert.ToDouble(Console.ReadLine()));
            Console.ReadLine();
        }
    }
}