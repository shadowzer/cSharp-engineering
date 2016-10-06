using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Def
{
    public abstract class AbstractClass
    {
        protected int[][] Field;
        protected Dictionary<int, int[]> Map = new Dictionary<int, int[]>();
        
        public int this[int x, int y]
        {
            get { return Field[x][y]; }
        }

        // value is a key in dictionary map to find value's coordinates
        public void GetLocation(int value, out int x, out int y)
        {
            if (Map.ContainsKey(value))
            {
                x = Map[value][0];
                y = Map[value][1];
                return;
            }
            else
                throw new Exception("Value is not found.");
        }

        public string ToString()
        {
            string Ans = "";
            for (int i = 0; i < Field.Length; ++i)
            {
                for (int j = 0; j < Field.Length; ++j)
                {
                    Ans += Field[i][j] + " ";
                }
                Ans += "\n";
            }
            return Ans;
        }
    }
}
