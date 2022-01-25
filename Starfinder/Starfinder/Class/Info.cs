using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Starfinder
{
    class Info
    {
        public void messageerror()
        {

            MessageBox.Show("Что то пошло не так");

        }
        public void messageerrorint()
        {

            MessageBox.Show("Введите число");

        }
        public void messageerrorfile()
        {

            MessageBox.Show("File not exist/or another problem");

        }
    }
}
