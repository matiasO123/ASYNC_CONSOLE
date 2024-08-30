using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Threads
{
    public class Barman
    {
        public void Warm_Up_Snack()
        {
            Console.WriteLine("put the snack in the oven");
            Thread.Sleep(3000);
            Console.WriteLine("Take the snack out");
        }

        public void Make_Coctel()
        {
            Console.WriteLine("Starting the coctel");
            Thread.Sleep(3000);
            Console.WriteLine("Finishing the coctel");
        }

        public async Task<bool> Warm_Up_Snack_Async()
        {
            Console.WriteLine("put the snack in the oven");
            await Task.Delay(3000);
            Console.WriteLine("Take the snack out");
            return true;
        }

        public async Task<bool> Make_Coctel_Async()
        {
            Console.WriteLine("Starting the coctel");
            await Task.Delay(3000);
            Console.WriteLine("Finishing the coctel");
            return true;
        }

    }
}
