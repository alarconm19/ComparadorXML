namespace ComparadorXMLconsola;
using System.Xml.Serialization;


[XmlRoot("raml", Namespace = "raml20.xsd")]
public class Raml20
{
    [XmlAttribute("version")]
    public string? Version { get; set; }

    [XmlElement("cmData", Namespace = "raml20.xsd")]
    public CmData20 CmData { get; set; } = new CmData20();
}

[XmlRoot("raml", Namespace = "raml21.xsd")]
public class Raml21
{
    [XmlAttribute("version")]
    public string? Version { get; set; }

    [XmlElement("cmData", Namespace = "raml21.xsd")]
    public CmData21 CmData { get; set; } = new CmData21();
}