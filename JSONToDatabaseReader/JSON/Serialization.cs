using System;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;

namespace JSONToDatabaseReader.JSON
{
    public class Serialization
    {
        public static T Deserialize<T>(string data) where T : class, new()
        {
            var deserializedObject = new T();
            DataContractJsonSerializer ser = new DataContractJsonSerializer(deserializedObject.GetType());
            using (MemoryStream s = new MemoryStream(Encoding.UTF8.GetBytes(data)))
            {
                deserializedObject = ser.ReadObject(s) as T;
            }
            return deserializedObject;
        }

        public static string Serialize<T>(T obj) where T : class, new()
        {
            var result = string.Empty;
            //Create a stream to serialize the object to.  
            using (MemoryStream ms = new MemoryStream())
            {
                // Serializer the User object to the stream.  
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(T));
                ser.WriteObject(ms, obj);
                byte[] json = ms.ToArray();
                ms.Close();
                result = Encoding.UTF8.GetString(json, 0, json.Length);
            }
            return result;
        }
    }
}