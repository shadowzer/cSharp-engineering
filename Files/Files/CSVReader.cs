using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Files
{
    class CSVReader
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

        public static IEnumerable<T> ReadCsv2<T>() where T : new()
        {
            using (var stream = new StreamReader("airquality.csv"))
            {
                var fields = stream.ReadLine().Trim('"').Split(',');
                while (true)
                {
                    var str = stream.ReadLine().Split(',');
                    if (str == null)
                        yield break;

                    var obj = new T();
                    var objType = typeof(T);
                    var objProperties = objType.GetProperties();

                    foreach (var prop in objProperties)
                    {
                        int idx = 0;
                        while (idx < fields.Length && fields[idx] != prop.Name)
                            ++idx;

                        if (str[idx] == "NA")
                            str[idx] = null;
                        if (str[idx] == null && ((prop.GetType() == typeof(int)) || (prop.GetType() == typeof(double))))
                            throw new Exception(prop.GetType().ToString() + " cannot be null");
                        
                        if (prop.GetType() == typeof(int) || (prop.GetType() == typeof(int?) && str[idx] != null))
                            objType.GetProperty(prop.Name).SetValue(obj, Int32.Parse(str[idx]));
                        else if (prop.GetType() == typeof(int?))
                            objType.GetProperty(prop.Name).SetValue(obj, null);
                        else if (prop.GetType() == typeof(double) || (prop.GetType() == typeof(double?) && str[idx] != null))
                            objType.GetProperty(prop.Name).SetValue(obj, Double.Parse(str[idx]));
                        else if (prop.GetType() == typeof(double?))
                            objType.GetProperty(prop.Name).SetValue(obj, null);
                        else // string
                            objType.GetProperty(prop.Name).SetValue(obj, str[idx]);
                    }
                    yield return obj;
                }
            }
        }

        public static IEnumerable<Dictionary<string, object>> ReadCsv3()
        {
            using (var stream = new StreamReader())
            {
                var fields = stream.ReadLine().Trim('"').Split(',');
                while (true)
                {
                    var str = stream.ReadLine();
                    if (str == null)
                        yield break;

                    Dictionary<string, object> result = new Dictionary<string, object>();
                    var array = str.Split(',');
                    for (int i = 0; i < array.Length; ++i)
                    {
                        if (array[i] == "NA")
                            array[i] = null;
                        if (array[i] == null && ((fields[i].GetType() == typeof(int)) || (fields[i].GetType() == typeof(double))))
                            throw new Exception(fields[i].GetType().ToString() + " cannot be null");

                        if (fields[i].GetType() == typeof(int))
                            result.Add(fields[i], Int32.Parse(array[i]));
                        else if (fields[i].GetType() == typeof(double))
                            result.Add(fields[i], Double.Parse(array[i]));
                        else // string
                            result.Add(fields[i], array[i]);
                    }
                    yield return result;
                }
            }
        }
    }
}
