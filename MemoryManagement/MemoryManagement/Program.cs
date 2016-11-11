using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            var timer = new Timer();
            using (timer.Start())
            {
                for (int i = 0; i < 10000000; ++i) ;
            }
            Console.WriteLine(timer.ElapsedMilliseconds);

            using (timer.Continue())
            {
                for (int i = 0; i < 10000000; ++i) ;
            }
            Console.WriteLine(timer.ElapsedMilliseconds);
        }
    }
}
