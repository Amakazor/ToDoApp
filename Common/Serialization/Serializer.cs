using System;
using System.IO;
using System.Runtime.Serialization;
using System.Xml;

namespace Common.Serialization
{
    public static class Serializer
    {
        public static string SerializeObject<T>(T toSerialize)
        {
            StringWriter stringWriter = new();
            XmlTextWriter writer = new(stringWriter);
            DataContractSerializer serializer = new(typeof(T));
            serializer.WriteObject(writer, toSerialize);
            return stringWriter.GetStringBuilder().ToString();
        }

        public static T DeserializeObject<T>(string toDeserialize)
        {
            StringReader stringReader = new(toDeserialize);
            XmlTextReader reader = new(stringReader);
            DataContractSerializer serializer = new(typeof(T));
            return (T)serializer.ReadObject(reader);
        }

        internal static object DeserializeObject<T>(object requestData)
        {
            throw new NotImplementedException();
        }
    }
}
