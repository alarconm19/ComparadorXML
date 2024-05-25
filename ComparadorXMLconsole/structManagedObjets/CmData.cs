namespace ComparadorXMLconsola;
using System.Xml.Serialization;


[XmlRoot("cmData", Namespace = "raml20.xsd")]
public class CmData20
{
    [XmlAttribute("type")]
    public string? Type { get; set; }

    [XmlElement("header")]
    public Header20? Header { get; set; }

    [XmlElement("managedObject")]
    public List<ManagedObject20> ManagedObjects { get; set; } = [];
}
[XmlRoot("cmData", Namespace = "raml21.xsd")]
public class CmData21
{
    [XmlAttribute("type")]
    public string? Type { get; set; }

    [XmlAttribute("scope")]
    public string? Scope { get; set; }

    [XmlAttribute("id")]
    public string? Id { get; set; }

    [XmlElement("header")]
    public Header21? Header { get; set; }

    [XmlElement("managedObject")]
    public List<ManagedObject21> ManagedObjects { get; set; } = [];
}