using System;
using System.Collections.Generic;
using System.Linq;

namespace JSONToDatabaseReader
{
    public class ReadJSONAndWriteToDb
    {
        public static T ReadFile<T>(string filename) where T : class, new()
        {
            var objects = new T();
            var json = System.IO.File.ReadAllText(filename);
            objects = JSON.Serialization.Deserialize<T>(json);
            return objects;
        }

        public static IEnumerable<T> FilterEnumerable<T>(IEnumerable<T> enumerable, Func<T, bool> filter) where T : class
        {
            var result = enumerable.Where(filter);
            return result; 
        }
    }
}
