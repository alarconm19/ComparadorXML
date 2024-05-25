namespace ComparadorXMLconsola; 
using System.Xml.Serialization;


public class Item
{
    [XmlElement("p")]
    public List<Property> Properties { get; set; } = new List<Property>();

    [XmlIgnore]
    public bool Mostrar { get; set; }
}