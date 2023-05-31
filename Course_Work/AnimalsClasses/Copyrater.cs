using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Course_Work
{
    class Copyrater
    {
        public static T CreateDeepCopy<T>(T obj)
        {
            using var ms = new MemoryStream();
            XmlSerializer serializer = new(obj.GetType());
            serializer.Serialize(ms, obj);
            ms.Seek(0, SeekOrigin.Begin);
            return (T)serializer.Deserialize(ms);
        }
    }
}
