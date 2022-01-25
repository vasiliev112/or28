using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Starfinder
{
    public class Dice
    {

        public int D2()
        {
            Random rnd = new Random();
            int  r = rnd.Next(1,3);
            return r;
        }

        public int D4()
        {
            Random rnd = new Random();
            int r = rnd.Next(1, 5);
            return r;
        }
        public int D6()
        {
            Random rnd = new Random();
            int r = rnd.Next(1, 7);
            return r;
        }
        public int D8()
        {
            Random rnd = new Random();
            int r = rnd.Next(1, 9);
            return r;
        }
        public int D10()
        {
            Random rnd = new Random();
            int r = rnd.Next(1, 11);
            return r;
        }
        public int D12()
        {
            Random rnd = new Random();
            int r = rnd.Next(1, 13);
            return r;
        }
        public int D20()
        {
            Random rnd = new Random();
            int r = rnd.Next(1, 21);
            return r;
        }
        public int D100()
        {
            Random rnd = new Random();
            int r = rnd.Next(1, 101);
            return r;
        }
    }
}
