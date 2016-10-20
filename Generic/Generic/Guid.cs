using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic
{
    class MyGuid
    {
        Dictionary<Type, Dictionary<Guid, object>> TheDictionary = new Dictionary<Type, Dictionary<Guid, object>>();

        //Первый метод создает объект переданного типа (предполагается, что этот тип имеет конструктор по умолчанию), создает для этого объекта Guid, сохраняет соответствие между объектом и Guid в базе и возвращает объект.
        public T CreateObject<T>() where T : new ()
        {
            var obj = new T();

            if (!TheDictionary.ContainsKey(typeof(T)))
            {
                TheDictionary.Add(typeof(T), new Dictionary<Guid, object>());
            }
            TheDictionary[typeof(T)].Add(Guid.NewGuid(), obj);

            return obj;
        }

        //Второй метод умеет быстро выводить пары вида (Guid, объект) для каждого типа объектов.
        public Dictionary<Guid, object> GetGuidAndObjectByType<T>()
        {
            return TheDictionary.ContainsKey(typeof(T)) ? TheDictionary[typeof(T)] :  null;
        }

        //Третий метод умеет быстро выводить по переданному Guid объект переданного типа, либо null, если такой объект отсутствует.
        public T GetObject<T>(Guid guid)
        {
            if (TheDictionary.ContainsKey(typeof(T)))
            {
                return TheDictionary[typeof(T)].ContainsKey(guid) ? (T)TheDictionary[typeof(T)][guid] : default(T);
            }
            else
            {
                return default(T);
            }
        }
    }
}
