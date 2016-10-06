using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Def
{
    public class Game :  AbstractClass
    {
        public Game(params int[] values)
        {
            int ValuesLengthSqrt = (int)Math.Sqrt(values.Length);
            if (ValuesLengthSqrt != Math.Sqrt(values.Length))
                throw new Exception("Size of the field is not a cube.");

            Field = new int[ValuesLengthSqrt][];
            int CountZeros = 0;
            for (int i = 0; i < ValuesLengthSqrt; ++i)
            {
                Field[i] = new int[ValuesLengthSqrt];
                for (int j = 0; j < ValuesLengthSqrt; ++j)
                {
                    Field[i][j] = values[i * ValuesLengthSqrt + j];
                    Map.Add(values[i * ValuesLengthSqrt + j], new int[2] { i, j });
                    if (Field[i][j] == 0)
                        ++CountZeros;
                }
            }
            if (CountZeros != 1)
                throw new Exception("There is must be one and only one '0' element in parameters for constructor.");
        }

        public void Shift(int value)
        {
            int x, x0, y, y0;
            GetLocation(value, out x, out y);
            GetLocation(0, out x0, out y0);

            if (Math.Abs(x - x0) + Math.Abs(y - y0) == 1)
            {
                Field[x][y] = 0;
                Field[x0][y0] = value;
                Map[value] = new int[2] { x0, y0 };
                Map[0] = new int[2] { x, y };
            }
            else
                throw new Exception("You can not do turn with this value now.");
        }
    }
}
