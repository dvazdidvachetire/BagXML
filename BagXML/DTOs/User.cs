using System.Xml.Serialization;

namespace BagXML.DTOs
{
    [XmlRoot(ElementName = "user")]
    public sealed class User
    {
        [XmlElement(ElementName = "fio")] public string FIO { get; set; } = string.Empty;
        [XmlElement(ElementName = "email")] public string Email { get; set; } = string.Empty;
    }
}
