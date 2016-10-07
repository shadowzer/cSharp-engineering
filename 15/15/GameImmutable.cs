using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Def
{
    public class GameImmutable : AbstractClass
    {
        public GameImmutable(params int[] values)
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
        
        public GameImmutable Shift(int value)
        {
            Cell CellValue = GetLocation(value);
            Cell Cell0 = GetLocation(0);

            if (Math.Abs(CellValue.X - Cell0.X) + Math.Abs(CellValue.Y - Cell0.Y) == 1)
            {
                int[] CopyField = new int[Field.Length * Field.Length];

                for (int i = 0; i < Field.Length; ++i )
                {
                    for (int j = 0; j < Field.Length; ++j)
                    {
                        CopyField[i * Field.Length + j] = Field[i][j];
                    }
                }
                CopyField[CellValue.X * Field.Length + CellValue.Y] = 0;
                CopyField[Cell0.X * Field.Length + Cell0.Y] = value;
                return new GameImmutable(CopyField);
            }
            else
                throw new Exception("You can not do turn with this value now.");
        }
    }
}
