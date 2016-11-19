using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Files
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (var item in CSVReader.ReadCsv1())
            {
                Console.WriteLine(item);
            }
        }
    }
}
