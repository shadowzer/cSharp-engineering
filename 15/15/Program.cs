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
            //Game g = new Game(1, 2, 3, 0, 4, 5, 6, 7, 8);
            //g.PrintField();
            //g.Shift(1);
            //g.PrintField();
            //g.Shift(1);
            //g.PrintField();
            //g.Shift(4);
            //g.PrintField();

            GameImmutable g = new GameImmutable(1, 2, 3, 0, 4, 5, 6, 7, 8);
            g.ToString();
            g.Shift(4);
            g.ToString();
            g = g.Shift(4);
            g.ToString();
            Console.ReadKey();
        }
    }
}