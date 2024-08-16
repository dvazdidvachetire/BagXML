using System.Xml.Serialization;

namespace BagXML.Models
{
    [XmlRoot(ElementName = "user")]
    public sealed class User
    {
        [XmlElement(ElementName = "fio")] public string FIO { get; set; } = string.Empty;
        [XmlElement(ElementName = "email")] public string Email { get; set; } = string.Empty;
    }
}
