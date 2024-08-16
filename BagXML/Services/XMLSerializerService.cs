using BagXML.Models;
using System.Xml.Serialization;

namespace BagXML.Services
{
    public class XMLSerializerService : SerializerService
    {
        public object? DeserializeObject { get; private set; }

        public override void Deserialize(Stream stream)
        {
            try
            {
                var serializer = new XmlSerializer(typeof(Orders));
                DeserializeObject = serializer.Deserialize(stream);
            }
            catch (Exception ex)
            {
                Console.Out.WriteLine(ex.Message);
            }
        }

        public override void Serialize(object value, Stream stream) {}
    }
}
