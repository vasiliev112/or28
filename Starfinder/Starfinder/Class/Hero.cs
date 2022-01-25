using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Starfinder
{
    [Serializable]
    public class Hero
    {
        public string name { get; set; } = "Игрок";
        public double init { get; set; } = 10;
        public int kac { get; set; } = 10;
        public int eac { get; set; } = 10;
        public int maxhp { get; set; } = 100;
        public int curhp { get; set; } = 100;
        public int numb;

        //Ширина
        public int width { get; set; }
        //Высота
        public int height { get; set; }
        private float Angle;
        //Высота
        public float angle
        {
            get
            {
                return Angle;
            }

            set
            {
                if (angle == 360)
                    Angle = value - 360;
                else Angle = value;
            }
        }

        public void DMG(int dm)
        {

            curhp = maxhp - dm;

        }

    }
}
