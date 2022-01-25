using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace Dice
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new DnD());
        }


    }

    // Класс генерации бросков
    #region
    public class Gen
    {
        public int D4()
        {
            Random rnd = new Random();
            Thread.Sleep(25);
            return rnd.Next(1, 4);
        }

        public int D6()
        {
            Random rnd = new Random();
            Thread.Sleep(25);
            return rnd.Next(1, 6);
        }

        public int D8()
        {
            Random rnd = new Random();
            Thread.Sleep(25);
            return rnd.Next(1, 8);
        }

        public int D10()
        {
            Random rnd = new Random();
            Thread.Sleep(25);
            return rnd.Next(1, 10);
        }

        public int D12()
        {
            Random rnd = new Random();
            Thread.Sleep(25);
            return rnd.Next(1, 12);
        }
        public int D20()
        {
            Random rnd = new Random();
            Thread.Sleep(25);
            return rnd.Next(1, 20);
        }
        public int D100()
        {
            Random rnd = new Random();
            Thread.Sleep(25);
            return rnd.Next(1, 100);
        }
    }
    #endregion
}
