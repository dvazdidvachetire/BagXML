using System.Xml.Serialization;

namespace BagXML.DTOs
{
    [XmlRoot(ElementName = "orders")]
    public sealed class Orders
    {
        [XmlElement(ElementName = "order")] public Order[] OrdersCollection { get; set; } = null!;
    }
}
