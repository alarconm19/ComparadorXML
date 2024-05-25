namespace ComparadorXMLconsola;
using System.Xml.Serialization;


[XmlRoot("list")]
public class ListElement
{
    [XmlAttribute("name")]
    public string Name { get; set; } = "";

    [XmlElement("item")]
    public List<Item> Items { get; set; } = new List<Item>();

    [XmlElement("p")]
    public List<Property> Properties { get; set; } = new List<Property>();

    [XmlIgnore]
    public bool Mostrar { get; set; }
}