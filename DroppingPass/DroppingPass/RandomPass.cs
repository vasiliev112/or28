using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DroppingPass
{
    class RandomPass
    {

        public string Gen()
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
            var s = string.Join("", a);

            return s;
        }

    }
}
