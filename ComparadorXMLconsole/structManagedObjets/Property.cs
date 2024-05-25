namespace ComparadorXMLconsola;
using System.Xml.Serialization;

[XmlRoot("p")]
public class Property
{
    [XmlAttribute("name")]
    public string Name { get; set; } = "";

    [XmlText]
    public string Value { get; set; } = "";

    [XmlIgnore]
    public bool Mostrar { get; set; }
}