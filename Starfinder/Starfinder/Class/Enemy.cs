using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Starfinder
{
    [Serializable]
    public class Enemy
    {
        // Имя
        public string name { get; set; }
        //Класс опасности
        public string cr { get; set; }
        //Опыт
        public int exp { get; set; }
        //Категория размер
        //Крошеччный 0,5 фута - 
        //Миниатюрный 1 фут
        //Маленький 2,5 фута
        //Небольшой 5 футов
        //Средний 5 футов
        //Крупный 10 футов
        //Огромный 15 футов
        //Гигантский 20 футов
        //Коллосальный 30 футов
        public string cat { get; set; }
        //Скорость
        public int speed { get; set; }
        //Инициатива
        public string init { get; set; }
        //Класс кинетической брони 
        public int kac { get; set; }
        //Класс энергетической брони
        public int eac { get; set; }
        //Испытание стойкости
        public int fortitude { get; set; }
        //Испытание реакции
        public int reflex { get; set; }
        //Испытание воли
        public int will { get; set; }
        //Максимальное здоровье
        public int maxhp { get; set; }
        //Текущее здоровье
        public int curhp { get; set; }
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

        /*
        private string first;
        public string First 
        {
            get 
            {
                return first;
            }
            set 
            {
                first = value + "asd";
            } 
        }
        */
        public void DMG(int dm)
        {

            curhp = curhp - dm;

        }
    }
}
