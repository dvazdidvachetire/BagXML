using System.Xml.Serialization;

namespace BagXML.DTOs
{
    [XmlRoot(ElementName = "order")]
    public sealed class Order
    {
        [XmlElement(ElementName = "no")] public string No { get; set; } = string.Empty;
        [XmlElement(ElementName = "reg_date")] public string Reg_Date { get; set; } = string.Empty;
        [XmlElement(ElementName = "sum")] public string Sum { get; set; } = string.Empty;
        [XmlElement(ElementName = "user")] public User User { get; set; } = null!;
        [XmlElement(ElementName = "product")] public Product[] Products { get; set; } = null!;
    }
}
