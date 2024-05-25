namespace ComparadorXMLconsola;
using System.Xml.Serialization;


[XmlRoot("header", Namespace = "raml20.xsd")]
public class Header20
{
    [XmlElement("log")]
    public Log20? Log { get; set; }
}

[XmlRoot("header", Namespace = "raml21.xsd")]
public class Header21
{
    [XmlElement("log")]
    public Log21? Log { get; set; }
}