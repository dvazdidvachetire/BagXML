using System.Xml.Serialization;

namespace BagXML.Models
{
    [XmlRoot(ElementName = "product")]
    public sealed class Product
    {
        [XmlElement(ElementName = "quantity")] public string Quantity { get; set; } = string.Empty;
        [XmlElement(ElementName = "name")] public string Name { get; set; } = string.Empty;
        [XmlElement(ElementName = "price")] public string Price { get; set; } = string.Empty;
    }
}
