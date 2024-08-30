using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Threads
{
    static public class Designer
    {
        static public void Separator()
        {
            Console.WriteLine("------------"); Console.WriteLine("------------");
        }
        static public void Initial_Config()
        {
            [DllImport("user32.dll")]
            static extern bool ShowWindow(System.IntPtr hWnd, int cmdShow);
            Process p = Process.GetCurrentProcess();
            ShowWindow(p.MainWindowHandle, 3);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
        }
    }
}
