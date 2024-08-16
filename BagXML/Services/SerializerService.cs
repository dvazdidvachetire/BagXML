namespace BagXML.Services
{
    /// <summary>представляет абстрактный класс для сервисов сериализации</summary>
    public abstract class SerializerService
    {
        /// <summary>сериализует объекты в файл документа</summary>
        /// <param name="value">сериализуемый объект</param>
        /// <param name="stream">поток</param>
        public abstract void Serialize(object value, Stream stream);
        /// <summary>десериализует файл документа</summary>
        /// <param name="stream">поток</param>
        public abstract void Deserialize(Stream stream);
    }
}
