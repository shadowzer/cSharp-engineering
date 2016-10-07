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
            Cell CellValue = GetLocation(value);
            Cell Cell0 = GetLocation(0);

            if (Math.Abs(CellValue.X - Cell0.X) + Math.Abs(CellValue.Y - Cell0.Y) == 1)
            {
                Field[CellValue.X][CellValue.Y] = 0;
                Field[Cell0.X][Cell0.Y] = value;
                Map[value] = new int[2] { Cell0.X, Cell0.Y };
                Map[0] = new int[2] { CellValue.X, CellValue.Y };
            }
            else
                throw new Exception("You can not do turn with this value now.");
        }
    }
}
