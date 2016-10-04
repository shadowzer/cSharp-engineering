using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace def
{
    class Program
    {
        static void Main(string[] args)
        {
            Game g = new Game(1, 2, 3, 0);
            Console.WriteLine(g[0, 0]);
            Console.ReadKey();
        }
    }

    class Game
    {
        private int[][] field;
        private Dictionary<int, int[]> map = new Dictionary<int,int[]>();

        public Game(params int[] values)
        {
            int ValuesLengthSqrt = (int)Math.Sqrt(values.Length);
            if (ValuesLengthSqrt != Math.Sqrt(values.Length))
                throw new Exception("Size of the field is not a cube.");

            field = new int[ValuesLengthSqrt][];
            for (int i = 0; i < ValuesLengthSqrt; ++i)
            {
                field[i] = new int[ValuesLengthSqrt];
                for (int j = 0; j < ValuesLengthSqrt; ++j)
                {
                    field[i][j] = values[i * ValuesLengthSqrt + j];
                    map.Add(values[i * ValuesLengthSqrt + j], new int[2] { i, j });
                }
            }
        }

        public int this[int x, int y]
        {
            get { return field[x][y]; }
            //set { throw new NotImplementedException(); }
        }

        // value is a key in dictionary map to find value's coordinates
        public int[] GetLocation(int value) 
        {
            if (map.ContainsKey(value))
            {
                return map[value];
            }
            else
                throw new Exception("Value is not found");
        }

        public bool Shift(int value)
        {
            // todo method
            return true;
        }
    }
}