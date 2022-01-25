using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MOVE
{
    class Program
    {       
        static void copyDir(string organ, string common)
        {            
            Directory.CreateDirectory(common);
            foreach (string s1 in Directory.GetFiles(organ))
            {
                string s2 = common + "\\" + Path.GetFileName(s1);
                File.Copy(s1, s2);
            }
            foreach (string i in Directory.GetDirectories(organ))
            {
                copyDir(i, common + "\\" + Path.GetFileName(i));
            }
        }

        static void delDir(string organ)
        {
            foreach (string i in Directory.GetDirectories(organ))
            {
                Directory.Delete(i, true);
            }            
        }       

        static void Main(string[] args)
        {
            
            string settings = "C:\\MOVE_MEDO_settings.ini";         

            string[] line = File.ReadAllLines(settings);     
            string commonMEDO = line[0];
            
            for (int i = 1; i < line.Length; i++)
            {
                copyDir(line[i], commonMEDO);
                delDir(line[i]);
            }
            
        }
    }
}
