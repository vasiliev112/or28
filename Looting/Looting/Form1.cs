using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Looting
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            
            InitializeComponent();
            Proc(textBox1, progressBar1);
        }

        //[DllImport("user32.dll")]
        [System.Runtime.InteropServices.DllImport("user32.dll")]

        public static extern IntPtr PostMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

        public static void sendKeystroke(int id)
        {
            const uint WM_KEYDOWN = 0x0100;
            const uint WM_KEYUP = 0x0101;

            IntPtr hWnd;

            foreach (Process P in Process.GetProcesses())
            {
                if (P.Id == id)
                {
                    MessageBox.Show(P.ProcessName);
                    IntPtr edit = P.MainWindowHandle;
                    //PostMessage(edit, WM_KEYDOWN, (IntPtr)(Keys.Control), IntPtr.Zero);
                    //PostMessage(edit, WM_KEYDOWN, (IntPtr)(Keys.Alt), IntPtr.Zero);
                    //PostMessage(edit, WM_KEYDOWN, (IntPtr)(Keys.X), IntPtr.Zero);
                    //PostMessage(edit, WM_KEYDOWN, (IntPtr)(Keys.Escape), IntPtr.Zero);
                    //PostMessage(edit, WM_KEYUP, (IntPtr)(Keys.Control), IntPtr.Zero);
                    PostMessage(edit, WM_KEYDOWN, (IntPtr)(Keys.Escape), IntPtr.Zero);
                    PostMessage(edit, WM_KEYUP, (IntPtr)(Keys.Escape), IntPtr.Zero);
                }
            }
        }

        public static void Proc(TextBox textBox1, ProgressBar progressBar1)
        {
            List<int> idProc = new List<int>();
            List<string> nameProc = new List<string>();
            List<string> info = new List<string>();

            progressBar1.Value = 0;

            Process[] processList = Process.GetProcesses();
            foreach (Process process in processList)
            {
                // выводим id и имя процесса
                idProc.Add(process.Id);
                nameProc.Add(process.ProcessName);
                //MessageBox.Show($"ID: {process.Id}  Name: {process.ProcessName}");
                progressBar1.Value += progressBar1.Maximum / processList.Length;
            }

            for (int i = 0; i < idProc.Count; i++)
            {
                info.Add(idProc[i] + " " + nameProc[i]);
                
            }

            foreach (string i in info)
            {
                textBox1.Text += i + '\r' + '\n';
                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sendKeystroke(Convert.ToInt32(textBox2.Text));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Proc(textBox1, progressBar1);
        }
    }
}
