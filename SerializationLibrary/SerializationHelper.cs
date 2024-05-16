using System.Xml.Serialization;
using Newtonsoft.Json;

namespace SerializationLibrary
{
    public class SerializationHelper
    {
        public static void SerializeXml<T>(T obj, string fileName)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (TextWriter writer = new StreamWriter(fileName))
            {
                serializer.Serialize(writer, obj);
            }
        }

        public static T DeserializeXml<T>(string fileName)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (TextReader reader = new StreamReader(fileName))
            {
                return (T)serializer.Deserialize(textReader: reader);
            }
        }

        public static void SerializeJson<T>(T obj, string fileName)
        {
            string json = JsonConvert.SerializeObject(obj);
            File.WriteAllText(fileName, json);
        }

        public static T DeserializeJson<T>(string fileName)
        {
            string json = File.ReadAllText(fileName);
            return JsonConvert.DeserializeObject<T>(value: json);
        }
    }
}
