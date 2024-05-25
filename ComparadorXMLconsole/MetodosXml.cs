namespace ComparadorXMLconsola;
using System.Xml;
using System.Xml.Serialization;


public static class MetodosXml
{
    //BuscarEnXml---------------------------------------------------------------------------------------------------------------------------

    internal static string ClassBuscado = "";
    internal static string DistNameBuscado = "";
    internal static string VersionBuscado = "";

    public static void BuscarEnXml()
    {
        int opcion = 0;
        do
        {
            bool opcionIncorrecta;
            do
            {
                try
                {
                    opcionIncorrecta = false;

                    Console.WriteLine("\nRellene los campos por los que quiere realizar la búsqueda: ");
                    Console.WriteLine($"\n1. Clase / (valor actual): {ClassBuscado.ToUpper()}\n" +
                            $"2. distName / (valor actual): {DistNameBuscado.ToUpper()}" +
                            $"\n3. Version / (valor actual): {VersionBuscado.ToUpper()}" +
                            $"\n4. Limpiar todo. " +
                            $"\n5. Continuar (Si desea ver el archivo completo deje todo vacio). ");

                    Console.Write("Seleccione una opción: ");
                    opcion = int.Parse(Console.ReadLine()!);

                }
                catch (FormatException)
                {
                    Console.WriteLine("\nError: Ingrese un número.");
                    opcionIncorrecta = true;
                }
            } while (opcionIncorrecta);

            switch (opcion)
            {
                case 1:
                    Console.Write("\nIngrese la clase: ");
                    ClassBuscado = Console.ReadLine()!.ToUpper();
                    break;

                case 2:
                    Console.Write("\nIngrese el distName: ");
                    DistNameBuscado = Console.ReadLine()!.ToUpper();
                    break;

                case 3:
                    Console.Write("\nIngrese la versión: ");
                    VersionBuscado = Console.ReadLine()!;
                    break;

                case 4:
                    ClassBuscado = "";
                    DistNameBuscado = "";
                    VersionBuscado = "";
                    break;

                case 5:
                    break;

                default:
                    Console.WriteLine("Opción inválida.");
                    break;
            }
        } while (opcion != 5);
    }

    //CargarArchivoXml---------------------------------------------------------------------------------------------------------------------------

    public static void Modificar(ArchivoXml archivoXml, ArchivoXml archivoXml1, int opcionModificar)
    {
        char modificar;
        do
        {
            Console.Write("\n¿Desea modificar los resultados encontrados? (s-S / n-N): ");
            var keyInfo = Console.ReadKey();
            Console.WriteLine();

            if (char.TryParse(keyInfo.KeyChar.ToString(), out modificar))
            {
                modificar = char.ToLower(modificar);

                switch (modificar)
                {
                    case 's':

                        switch (opcionModificar)
                        {
                            case 0:
                            {
                                int i = 0;

                                foreach (var obj in archivoXml.ManagedObjects)
                                {
                                    MetodosMenu.Recorrido(obj, 2, i, "", 0, ConsoleColor.Black);
                                    i++;
                                }

                                SerializeListToXml(archivoXml);
                                break;
                            }

                            case 1:
                            {
                                bool opcionCorrecta;
                                do
                                {
                                    opcionCorrecta = true;
                                    try
                                    {
                                        Console.WriteLine($"\n1. Copiar de archivo 1 al 2. " +
                                                $"\n2. Copiar de archivo 2 al 1. " +
                                                $"\n3. Modificar 1. " +
                                                $"\n4. Modificar 2. " +
                                                $"\n5. Continuar. ");

                                        Console.Write("Seleccione una opción: ");
                                        int opcion = int.Parse(Console.ReadLine()!);

                                        switch (opcion)
                                        {
                                            case 1:
                                                MetodosMenu.Comparar(archivoXml, archivoXml1, 3, 1);
                                                SerializeListToXml(archivoXml1);
                                                break;

                                            case 2:
                                                MetodosMenu.Comparar(archivoXml1, archivoXml, 3, 1);
                                                SerializeListToXml(archivoXml);
                                                break;

                                            case 3:
                                            {
                                                int i = 0;

                                                foreach (var obj in archivoXml.ManagedObjects)
                                                {
                                                    MetodosMenu.Recorrido(obj, 4, i, archivoXml.Ruta, 1, ConsoleColor.Cyan);
                                                    i++;
                                                }

                                                SerializeListToXml(archivoXml);
                                                break;
                                            }

                                            case 4:
                                            {
                                                int i = 0;

                                                foreach (var obj in archivoXml1.ManagedObjects)
                                                {
                                                    MetodosMenu.Recorrido(obj, 4, i, archivoXml1.Ruta, 2, ConsoleColor.Magenta);
                                                    i++;
                                                }

                                                SerializeListToXml(archivoXml1);
                                                break;
                                            }

                                            case 5:
                                                break;

                                            default:
                                                Console.WriteLine("Opcion invalida. Ingrese nuevamente. ");
                                                break;
                                        }
                                    }
                                    catch (FormatException)
                                    {
                                        Console.WriteLine("Error. Ingrese un numero. ");
                                        opcionCorrecta = false;
                                    }
                                } while (!opcionCorrecta);
                                break;
                            }
                        }

                        modificar = 'n';
                        break;

                    case 'n':
                        break;

                    default:
                        // Respuesta no reconocida.
                        Console.WriteLine("Respuesta no válida.");
                        break;
                }
            }
            else
            {
                // No se pudo convertir a char.
                Console.WriteLine("Respuesta no válida.");
            }
        } while (modificar != 'n');
    }

    //CargarArchivoXml---------------------------------------------------------------------------------------------------------------------------

    public static ArchivoXml CargarArchivoXml()
    {
        bool archivoCargado = false;
        var archivoXml = new ArchivoXml();

        do
        {
            try
            {
                Console.WriteLine("\n1. Lista de archivos previamente usados. \n2. Ingresar un nuevo archivo. \n3. Borrar lista de archivos usados previamente. ");
                Console.Write("Seleccione una opción: ");
                int opcionMenu = Convert.ToInt32(Console.ReadLine());

                switch (opcionMenu)
                {
                    case 1:
                        Console.WriteLine("\nLista de archivos usados: ");

                        List<string> nombresArchivosGuardados = MetodosArchivoNombres.RecuperarArchivosBuscado();
                        if (nombresArchivosGuardados.Count > 0)
                        {
                            try
                            {
                                for (int i = 0; i < nombresArchivosGuardados.Count; i++)
                                {
                                    Console.WriteLine($"\n{i + 1}. {nombresArchivosGuardados[i]}");
                                }

                                Console.Write("\nSeleccione una opción: ");
                                int numeroArchivos = Convert.ToInt32(Console.ReadLine());

                                if (numeroArchivos > 0 && numeroArchivos <= nombresArchivosGuardados.Count)
                                {
                                    if ((archivoXml = DeserializeXmlToList(nombresArchivosGuardados[numeroArchivos - 1])) != null!)
                                    {
                                        Console.WriteLine("Archivo cargado correctamente.");
                                        archivoCargado = true;
                                    }
                                    else
                                        MetodosArchivoNombres.BorrarNombreIncorrecto(nombresArchivosGuardados[numeroArchivos - 1]);
                                }
                                else
                                {
                                    Console.WriteLine("Número de archivo no válido. Por favor, elija una opción válida.");
                                }

                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Por favor, ingrese un número.");
                            }
                            catch (IndexOutOfRangeException)
                            {
                                Console.WriteLine("Número de archivo no válido. Por favor, elija una opción válida.");
                            }
                            catch (Exception ex)
                            {
                                // Captura otras excepciones no esperadas
                                Console.WriteLine($"Ocurrió un error inesperado: {ex.Message}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("\nEstá vacía.");
                        }
                        break;

                    case 2:

                        if ((archivoXml = DeserializeXmlToList(MetodosArchivoNombres.CargarNuevoArchivoBuscado())) != null)
                        {
                            Console.WriteLine("Archivo cargado correctamente.");
                            archivoCargado = true;
                        }
                        else Console.WriteLine("El archivo no fue cargado.");
                        break;

                    case 3:
                        MetodosArchivoNombres.BorrarContenidoArchivoBuscado();
                        break;

                    default:
                        Console.WriteLine("Opción inválida. Ingrese nuevamente.");
                        break;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: Ingrese un número.");
            }

        } while (!archivoCargado);

        return archivoXml!;
    }

    //DeserializeXmlToList---------------------------------------------------------------------------------------------------------------------------

    static ArchivoXml DeserializeXmlToList (string xmlFilePath)
    {
        try
        {
            //*
            var xmlDocument = new XmlDocument();
            xmlDocument.Load(xmlFilePath);

            string version = xmlDocument.DocumentElement!.GetAttribute("version");
            switch (version)
            {
                case "2.0":
                {
                    var serializer = new XmlSerializer(typeof(Raml20));
                    using var fileStream = new FileStream(xmlFilePath, FileMode.Open);
                    var raml = (Raml20)serializer.Deserialize(fileStream)!;

                    var archivoXml = new ArchivoXml(xmlFilePath, [..raml.CmData.ManagedObjects]);

                    return archivoXml;
                }

                case "2.1":
                {
                    var serializer = new XmlSerializer(typeof(Raml21));
                    using var fileStream = new FileStream(xmlFilePath, FileMode.Open);
                    var raml = (Raml21)serializer.Deserialize(fileStream)!;

                    var archivoXml = new ArchivoXml(xmlFilePath, [..raml.CmData.ManagedObjects]);

                    return archivoXml;
                }

                default:
                    Console.WriteLine("Versión de XML no compatible. ");
                    return null!;
            }
            //*/
        }
        catch (FileNotFoundException ex)
        {
            // Captura la excepción si el archivo no se encuentra
            Console.WriteLine("Error: No se pudo encontrar el archivo. ");
            Console.WriteLine($"Detalles del error: {ex.Message}");
            return null!;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al deserializar: {ex.Message}");

            if (ex.InnerException == null) return null!;
            Console.WriteLine($"Inner Exception: {ex.InnerException.Message}");
            if (ex.InnerException.InnerException == null) return null!;
            Console.WriteLine($"Inner Exception: {ex.InnerException.InnerException.Message}");
            if (ex.InnerException.InnerException.InnerException == null) return null!;
            Console.WriteLine($"Inner Exception: {ex.InnerException.InnerException.InnerException.Message}");
            if (ex.InnerException.InnerException.InnerException.InnerException == null) return null!;
            Console.WriteLine($"Inner Exception: {ex.InnerException.InnerException.InnerException.InnerException.Message}");
            if (ex.InnerException.InnerException.InnerException.InnerException.InnerException != null)
                Console.WriteLine($"Inner Exception: {ex.InnerException.InnerException.InnerException.InnerException.InnerException!.Message}");

            return null!;
        }
    }


    static Raml20 _raml20(string xmlFilePath)
    {
        try
        {
            var serializer = new XmlSerializer(typeof(Raml20));
            using var fileStream = new FileStream(xmlFilePath, FileMode.Open);
            var raml = (Raml20)serializer.Deserialize(fileStream)!;

            return raml;

        }
        catch (FileNotFoundException ex)
        {
            Console.WriteLine("Error: No se pudo encontrar el archivo. ");
            Console.WriteLine($"Detalles del error: {ex.Message}");
            return null!;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al deserializar: {ex.Message}");
            return null!;
        }
    }
    static Raml21 _raml21(string xmlFilePath)
    {
        try
        {
            var serializer = new XmlSerializer(typeof(Raml21));
            using var fileStream = new FileStream(xmlFilePath, FileMode.Open);
            var raml = (Raml21)serializer.Deserialize(fileStream)!;

            return raml;

        }
        catch (FileNotFoundException ex)
        {
            Console.WriteLine("Error: No se pudo encontrar el archivo. ");
            Console.WriteLine($"Detalles del error: {ex.Message}");
            return null!;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al deserializar: {ex.Message}");
            return null!;
        }
    }

    //SerializeXmlToList---------------------------------------------------------------------------------------------------------------------------

    //*
    static void SerializeListToXml(ArchivoXml archivoXml)
    {
        try
        {
            var xmlDocument = new XmlDocument();
            xmlDocument.Load(archivoXml.Ruta);

            // Identificar la versión del XML y seleccionar la deserialización adecuada
            string version = xmlDocument.DocumentElement!.GetAttribute("version");
            XmlSerializer? serializer;

            switch (version)
            {
                case "2.0":
                {
                    var raml20 = _raml20(archivoXml.Ruta);

                    List<ManagedObject20> managedObject20List = archivoXml.ManagedObjects.ConvertToManagedObject20List();
                    raml20.CmData.ManagedObjects = managedObject20List;

                    serializer = new XmlSerializer(typeof(Raml20));

                    using var fileStream = new FileStream(archivoXml.Ruta, FileMode.Create);
                    serializer.Serialize(fileStream, raml20);

                    break;
                }

                case "2.1":
                {
                    var raml21 = _raml21(archivoXml.Ruta);

                    List<ManagedObject21> managedObject21List = archivoXml.ManagedObjects.ConvertToManagedObject21List();
                    raml21.CmData.ManagedObjects = managedObject21List;

                    serializer = new XmlSerializer(typeof(Raml21));

                    using var fileStream = new FileStream(archivoXml.Ruta, FileMode.Create);
                    serializer.Serialize(fileStream, raml21);

                    break;
                }

                default:
                    Console.WriteLine("Version de xml inválida. ");
                    break;
            }
            Console.WriteLine("\nArchivo XML modificado y serializado exitosamente.");

            xmlDocument = new XmlDocument();
            xmlDocument.Load(archivoXml.Ruta);
            xmlDocument.DocumentElement!.RemoveAttribute("xmlns:xsi");
            xmlDocument.DocumentElement!.RemoveAttribute("xmlns:xsd");
            xmlDocument.Save(archivoXml.Ruta);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al serializar y escribir en el archivo XML: {ex.Message}");
        }
    }
    //*/
}