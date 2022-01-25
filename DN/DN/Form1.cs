using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DN
{
    public partial class DN : Form
    {
        public DN()
        {
            InitializeComponent();
        }

        private void pole1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form2 = new Form2();
            form2.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> countries = new Dictionary<string, string>();
            
                countries.Add("Город1","Работа");
                countries.Add("Город2","Отдых");
                countries.Add("Город1","Азарт");
                /*
                ["Город1"] = {"Работа"},
                ["Город2"] = {"Отдых"},
                ["Город3"] = {"Работа", "Азарт"}
                                */
            
            foreach (var i in countries)
                //if (i.Key == "Германия")
                    //{
                    listBox2.Items.Add(i.Value);
                    //}
            //listBox2.Items.Add("{0} - {1}", i.Key, i.Value);
        }
        
    }
}
