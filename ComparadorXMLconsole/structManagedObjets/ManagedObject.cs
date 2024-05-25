namespace ComparadorXMLconsola;
using System.Xml.Serialization;

[XmlInclude(typeof(ManagedObject20))]
[XmlInclude(typeof(ManagedObject21))]
//*
public interface IManagedObject
{
    string Class { get; }
    string DistName { get; }
    string Version { get; }
    List<Property> Property { get; }
    List<ListElement> Lists { get; }
    bool Mostrar { get; set; }
}
//*/

[XmlRoot("managedObject", Namespace = "raml20.xsd")]
public class ManagedObject20 : IManagedObject
{
    [XmlAttribute("class")]
    public string Class { get; set; } = "";

    [XmlAttribute("version")]
    public string Version { get; set; } = "";

    [XmlAttribute("distName")]
    public string DistName { get; set; } = "";

    [XmlAttribute("id")]
    public string Id { get; set; } = "";

    [XmlElement("p")]
    public List<Property> Property { get; set; } = new List<Property>();

    [XmlElement("list")]
    public List<ListElement> Lists { get; set; } = new List<ListElement>();

    [XmlIgnore]
    public bool Mostrar { get; set; }
}

[XmlRoot("managedObject", Namespace = "raml21.xsd")]
public class ManagedObject21 : IManagedObject
{
    [XmlAttribute("class")]
    public string Class { get; set; } = "";

    [XmlAttribute("distName")]
    public string DistName { get; set; } = "";

    [XmlAttribute("version")]
    public string Version { get; set; } = "";

    [XmlAttribute("operation")]
    public string Operation { get; set; } = "";

    [XmlElement("p")]
    public List<Property> Property { get; set; } = new List<Property>();

    [XmlElement("list")]
    public List<ListElement> Lists { get; set; } = new List<ListElement>();

    [XmlIgnore]
    public bool Mostrar { get; set; }
}

public static class Metodos
{
    public static List<ManagedObject20> ConvertToManagedObject20List(this IEnumerable<IManagedObject> sourceList)
    {
        return sourceList
                .OfType<ManagedObject20>()
                .ToList();
    }

    public static List<ManagedObject21> ConvertToManagedObject21List(this IEnumerable<IManagedObject> sourceList)
    {
        return sourceList
                .OfType<ManagedObject21>()
                .ToList();
    }
}
