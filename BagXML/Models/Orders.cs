using System.Xml.Serialization;

namespace BagXML.Models
{
    [XmlRoot(ElementName = "orders")]
    public sealed class Orders
    {
        [XmlElement(ElementName = "order")] public Order[] OrdersCollection { get; set; } = null!;
    }
}
