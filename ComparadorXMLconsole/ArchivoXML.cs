namespace ComparadorXMLconsola;

public class ArchivoXml
{
    public readonly string Ruta = "";

    public List<IManagedObject> ManagedObjects = [];

    public ArchivoXml() {}
    public ArchivoXml(string ruta, List<IManagedObject> managedObject)
    {
        Ruta = ruta;
        ManagedObjects = managedObject;
    }
}