namespace BagXML.Services
{
    public abstract class SerializerService
    {
        public abstract void Serialize(object value, Stream stream);
        public abstract void Deserialize(Stream stream);
    }
}
