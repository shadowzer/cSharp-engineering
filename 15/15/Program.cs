using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Def
{
    class Program
    {
        static void Main(string[] args)
        {
            Game g = new Game(1, 2, 3, 0, 4, 5, 6, 7, 8);
            Console.WriteLine(g.ToString());
            g.Shift(1);
            Console.WriteLine(g.ToString());
            g.Shift(1);
            Console.WriteLine(g.ToString());
            g.Shift(4);
            Console.WriteLine(g.ToString() + "\n--------\n");

            GameImmutable gi = new GameImmutable(1, 2, 3, 0, 4, 5, 6, 7, 8);
            Console.WriteLine(gi.ToString());
            gi.Shift(4);
            Console.WriteLine(gi.ToString());
            gi = gi.Shift(4);
            Console.WriteLine(gi.ToString());

            Console.ReadKey();
        }
    }
}