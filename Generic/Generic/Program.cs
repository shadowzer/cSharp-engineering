using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic
{
    class MyEngine { }
    class MyEntity { }
    class MyLogger { }

    class Program
    {
        static void Main(string[] args)
        {            
            var Processor = ProcessorWrapper.CreateEngine<MyEngine>().For<MyEntity>().With<MyLogger>();
        }
    }
}
