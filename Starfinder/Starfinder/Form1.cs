using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Starfinder
{
    public partial class StarfinderMainForm : Form
    {
        private Info inf = new Info();

        public StarfinderMainForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Global.GopenForms)
                {
                    Form form = new ChoiceMap();
                    form.ShowDialog();
                    this.WindowState = FormWindowState.Minimized;
                }
                else if (Global.GopenForms)
                {
                    MessageBox.Show("Карта уже открыта");
                }
            }
            catch
            {
                inf.messageerror();
            }
            
        }
    }
}
