using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Windows.Forms;
using System.Timers;

class InterceptKeys
    {
        private const int WH_KEYBOARD_LL = 13;
        //private const int WM_KEYDOWN = 0x0100;
        private const int WM_KEYUP = 0x0101;

        static int sw = 0;   // Константа для определения клавиши

        private static LowLevelKeyboardProc _proc = HookCallback;
        private static IntPtr _hookID = IntPtr.Zero;

        [STAThread]
        public static void Main()
        {
            _hookID = SetHook(_proc);
            Application.Run();
            UnhookWindowsHookEx(_hookID);
        }

        private static IntPtr SetHook(LowLevelKeyboardProc proc)
        {
            using (Process curProcess = Process.GetCurrentProcess())
            using (ProcessModule curModule = curProcess.MainModule)
            {
                return SetWindowsHookEx(WH_KEYBOARD_LL, proc,
                    GetModuleHandle(curModule.ModuleName), 0);
            }
        }

        private delegate IntPtr LowLevelKeyboardProc(
            int nCode, IntPtr wParam, IntPtr lParam);

        private static IntPtr HookCallback(
            int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0 && wParam == (IntPtr)WM_KEYUP)
            {
                int vkCode = Marshal.ReadInt32(lParam);
                //Console.WriteLine(vkCode);
                //Console.WriteLine($"ОЧЕРЕДЬ-{sw}");
                //Console.WriteLine($"БУФФЕР-{Clipboard.GetText()}");
            if (vkCode == 162 && sw == 0) sw++;
            if (vkCode == 67 && sw == 1)
            {
                sw++;
                // Create a timer with a 1.5 second interval.
                System.Timers.Timer aTimer = new System.Timers.Timer(2000);

                // Hook up the event handler for the Elapsed event.
                aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);

                // Only raise the event the first time Interval elapses.
                aTimer.AutoReset = false;
                aTimer.Enabled = true;
            }
            if (vkCode == 163 && sw == 2) sw++;
            if (vkCode == 19 && sw == 3)
                {
                    //SendKeys.Send("^c");
                    //Thread.Sleep(1000);
                    string Buffer = Clipboard.GetText();
                    char[] arBuffer = Buffer.ToCharArray();
                    for (int i = 0; i < arBuffer.Length; i++)
                    {
                        arBuffer[i] = Zamena(arBuffer[i]);
                    }
                    string updateBuffer = new string(arBuffer);
                //if (Clipboard.ContainsText() == true)
                    Clipboard.SetText(updateBuffer);
                    SendKeys.Send("^м");
                
                    //Clipboard.Clear();
                    sw = 0;
                }            
            }            
            return CallNextHookEx(_hookID, nCode, wParam, lParam);            
        }

        private static void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            sw = 0;
        }

        private static char Zamena(char arg1)
        {
            char arg2 = ' ';
            switch (arg1)
            {
            case 'q':                arg2 = 'й';
                break;
            case 'w':                arg2 = 'ц';
                break;
            case 'e':                arg2 = 'у';
                break;
            case 'r':                arg2 = 'к';
                break;
            case 't':                arg2 = 'е';
                break;
            case 'y':                arg2 = 'н';
                break;
            case 'u':                arg2 = 'г';
                break;
            case 'i':                arg2 = 'ш';
                break;
            case 'o':                arg2 = 'щ';
                break;
            case 'p':                arg2 = 'з';
                break;
            case '[':                arg2 = 'х';
                break;
            case ']':                arg2 = 'ъ';
                break;
            case 'a':                arg2 = 'ф';
                break;
            case 's':                arg2 = 'ы';
                break;
            case 'd':                arg2 = 'в';
                break;
            case 'f':                arg2 = 'а';
                break;
            case 'g':                arg2 = 'п';
                break;
            case 'h':                arg2 = 'р';
                break;
            case 'j':                arg2 = 'о';
                break;
            case 'k':                arg2 = 'л';
                break;
            case 'l':                arg2 = 'д';
                break;
            case ';':                arg2 = 'ж';
                break;
            case '\u0027':           arg2 = 'э';    // Символ '
                break;
            case 'z':                arg2 = 'я';
                break;
            case 'x':                arg2 = 'ч';
                break;
            case 'c':                arg2 = 'с';
                break;
            case 'v':                arg2 = 'м';
                break;
            case 'b':                arg2 = 'и';
                break;
            case 'n':                arg2 = 'т';
                break;
            case 'm':                arg2 = 'ь';
                break;
            case ',':                arg2 = 'б';
                break;
            case '.':                arg2 = 'ю';
                break;
            case '/':                arg2 = '.';
                break;
            case '`':                arg2 = 'ё';
                break;
            case '|':                arg2 = '/';
                break;
            case '@':                arg2 = '"';
                break;
            case '#':                arg2 = '№';
                break;
            case '$':                arg2 = ';';
                break;
            case '%':                arg2 = '%';
                break;
            case '^':                arg2 = ':';
                break;
            case '&':                arg2 = '?';
                break;
            case 'Q':                arg2 = 'Й';
                break;
            case 'W':                arg2 = 'Ц';
                break;
            case 'E':                arg2 = 'У';
                break;
            case 'R':                arg2 = 'К';
                break;
            case 'T':                arg2 = 'Е';
                break;
            case 'Y':                arg2 = 'Н';
                break;
            case 'U':                arg2 = 'Г';
                break;
            case 'I':                arg2 = 'Ш';
                break;
            case 'O':                arg2 = 'Щ';
                break;
            case 'P':                arg2 = 'З';
                break;
            case '{':                arg2 = 'Х';    
                break;
            case '}':                arg2 = 'Ъ';    
                break;
            case 'A':                arg2 = 'Ф';
                break;
            case 'S':                arg2 = 'Ы';
                break;
            case 'D':                arg2 = 'В';
                break;
            case 'F':                arg2 = 'А';
                break;
            case 'G':                arg2 = 'П';
                break;
            case 'H':                arg2 = 'Р';
                break;
            case 'J':                arg2 = 'О';
                break;
            case 'K':                arg2 = 'Л';
                break;
            case 'L':                arg2 = 'Д';
                break;
            case '\u003a':           arg2 = 'Ж';    // Символ :
                break;
            case '\u0022':           arg2 = 'Э';    // Символ "
                break;
            case 'Z':                arg2 = 'Я';
                break;
            case 'X':                arg2 = 'Ч';
                break;
            case 'C':                arg2 = 'С';
                break;
            case 'V':                arg2 = 'М';
                break;
            case 'B':                arg2 = 'И';
                break;
            case 'N':                arg2 = 'Т';
                break;
            case 'M':                arg2 = 'Ь';
                break;
            case '<':                arg2 = 'Б';    
                break;
            case '>':                arg2 = 'Ю';   
                break;
            default:                 arg2 = arg1;
                break;
            }
        return arg2;        
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook,
            LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode,
            IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);
    }





