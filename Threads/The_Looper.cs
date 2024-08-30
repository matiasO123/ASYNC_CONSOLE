using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Threads
{
    public class The_Looper
    {
        //public Int64 until = 100000000;
        public Int64 until = 1000000000;
        public int steps =   100000;

        public void Only_Loop ()
        {
            for (int i = 0; i < until; i++) { }
        }

        public void Loop_and_writeLine()
        {
            //Same loop, no stopwatch
            for (int i = 0; i < until; i++) if (i % steps == 0) Console.Write(i.ToString() + "_");                
            Console.WriteLine(); Console.WriteLine();
        }
        public void Loop_and_writeLine(Int64 until, int steps)
        {
            //Same loop, no stopwatch
            for (int i = 0; i < until; i++) if (i % steps == 0) Console.Write(i.ToString() + "_");
            Console.WriteLine(); Console.WriteLine();
        }       
    }
    


}
