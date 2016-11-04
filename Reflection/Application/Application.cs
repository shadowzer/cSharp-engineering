using Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    class Application
    {
        static void Main(string[] args)
        {
            var searchRes = Directory.GetFiles("C:\\Users\\cod_s\\YandexDisk\\Git-repository\\cSharp-engineering\\Reflection", "plugin*.dll");

            foreach (var path in searchRes)
            {
                var plugin = GetPlugin(path);
                Console.WriteLine(plugin.Name);
            }
        }

        private static IPlugin GetPlugin(string path) 
        {
            var asm = Assembly.LoadFile(path);
            foreach (var type in asm.GetTypes())
            {
                if (type.GetInterface(typeof(IPlugin).FullName) != null && !type.IsInterface)
                    return (IPlugin)Activator.CreateInstance(typeof(IPlugin));
            }

            return null;
        }
    }
}
