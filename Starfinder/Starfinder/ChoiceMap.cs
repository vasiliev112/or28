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
    public partial class ChoiceMap : Form
    {
        public ChoiceMap()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Global.Gmapears = true;
            Global.GopenForms = true;
            MapsForm mapform = new MapsForm();
            this.Close();
            mapform.Show(); 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Global.Gmaspaсe = true;
            Global.GopenForms = true;
            MapsForm mapform = new MapsForm();
            this.Close();
            mapform.Show();            
        }
    }
}
