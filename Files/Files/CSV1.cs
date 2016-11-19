using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Files
{
    class CSV1
    {
        public static IEnumerable<string[]> ReadCsv1()
        {
            using (var stream = new StreamReader("airquality.csv"))
            {
                while (true)
                {
                    var str = stream.ReadLine();
                    if (str == null)
                        yield break;

                    var array = str.Split(',');
                    for (int i = 0; i < array.Length; ++i)
                    {
                        if (array[i] == "NA")
                            array[i] = null;
                    }
                    yield return array;
                }
            }
        }

    }
}
