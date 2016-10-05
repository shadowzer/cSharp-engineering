using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace def
{
    public class Game
    {
        private int[][] field;
        private Dictionary<int, int[]> map = new Dictionary<int, int[]>();

        public Game(params int[] values)
        {
            int ValuesLengthSqrt = (int)Math.Sqrt(values.Length);
            if (ValuesLengthSqrt != Math.Sqrt(values.Length))
                throw new Exception("Size of the field is not a cube.");

            field = new int[ValuesLengthSqrt][];
            int CountZeros = 0;
            for (int i = 0; i < ValuesLengthSqrt; ++i)
            {
                field[i] = new int[ValuesLengthSqrt];
                for (int j = 0; j < ValuesLengthSqrt; ++j)
                {
                    field[i][j] = values[i * ValuesLengthSqrt + j];
                    map.Add(values[i * ValuesLengthSqrt + j], new int[2] { i, j });
                    if (field[i][j] == 0)
                        ++CountZeros;
                }
            }
            if (CountZeros != 1)
                throw new Exception("There is must be one and only one '0' element in parameters for constructor.");
        }

        public int this[int x, int y]
        {
            get { return field[x][y]; }
            //set { throw new NotImplementedException(); }
        }
        
         // value is a key in dictionary map to find value's coordinates
        public void GetLocation(int value, out int x, out int y)
        {
            if (map.ContainsKey(value))
            {
                x = map[value][0];
                y = map[value][1];
                return;
            }
            else
                throw new Exception("Value is not found.");
        }

        public void Shift(int value)
        {
            int x, x0, y, y0;
            GetLocation(value, out x, out y);
            GetLocation(0, out x0, out y0);

            if (Math.Abs(x - x0) + Math.Abs(y - y0) == 1)
            {
                field[x][y] = 0;
                field[x0][y0] = value;
                map[value] = new int[2] { x0, y0 };
                map[0] = new int[2] { x, y };
            }
            else
                throw new Exception("You can not do turn with this value now.");
        }

        public void PrintField()
        {
            for (int i = 0; i < field.Length; ++i)
            {
                for (int j = 0; j < field.Length; ++j)
                {
                    Console.Write(field[i][j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
