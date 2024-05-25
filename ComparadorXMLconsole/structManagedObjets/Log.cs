namespace ComparadorXMLconsola;
using System.Xml.Serialization;

[XmlRoot("log", Namespace = "raml20.xsd")]
public class Log20
{
    [XmlAttribute("dateTime")]
    public string? DateTime { get; set; }

    [XmlAttribute("action")]
    public string? Action { get; set; }

    [XmlAttribute("appInfo")]
    public string? AppInfo { get; set; }

    [XmlText]
    public string? Value { get; set; }
}

[XmlRoot("log", Namespace = "raml21.xsd")]
public class Log21
{
    [XmlAttribute("action")]
    public string? Action { get; set; }

    [XmlAttribute("dateTime")]
    public string? DateTime { get; set; }
}