namespace ComparadorXMLconsola;

public static class MetodosArchivoNombres
{
    //CargarNuevoArchivoBuscado---------------------------------------------------------------------------------------------------------------------------

    public static string CargarNuevoArchivoBuscado()
    {
        string direccionArchivo = null!;

        try
        {
            Console.WriteLine("\nIngrese el nombre del archivo (sin su extension): ");
            string nombreArchivo = Console.ReadLine()!;

            Console.WriteLine("Ingrese la direccion del archivo (enter si esta en la misma carpeta que este .exe): ");
            string direccionUsuario = Console.ReadLine()!;

            direccionArchivo = Path.Combine(direccionUsuario, $"{nombreArchivo}.xml");

            if (!File.Exists(direccionArchivo))
            {
                throw new FileNotFoundException("El archivo no se encuentra.");
            }

            GuardarArchivoBuscado(direccionArchivo);
            EliminarDuplicados();
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("Nombre o direccion incorrecta. Ingrese de vuelta. ");
        }

        return direccionArchivo;
    }

    //GuardarArchivoBuscado---------------------------------------------------------------------------------------------------------------------------

    static void GuardarArchivoBuscado(string archivo)
    {
        try
        {
            string documentosPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string filePath = Path.Combine(documentosPath, "nombres_archivos_usados_Comparador.txt");

            using var writer = new StreamWriter(filePath, true);
            writer.WriteLine(archivo);
        }
        catch (IOException)
        {}
    }

    //RecuperarArchivosBuscado---------------------------------------------------------------------------------------------------------------------------

    public static List<string> RecuperarArchivosBuscado()
    {
        List<string> archivos = [];
        EliminarDuplicados();

        try
        {
            string documentosPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string filePath = Path.Combine(documentosPath, "nombres_archivos_usados_Comparador.txt");

            using var reader = new StreamReader(filePath);
            while (reader.ReadLine() is { } linea)
            {
                archivos.Add(linea);
            }
        }
        catch (IOException e)
        {
            Console.WriteLine($"Error al recuperar archivos: {e.Message}");
        }
        return archivos;
    }

    //BorrarNombreIncorrecto----------------------------------------------------------------------------------------------------------------------------------

    static void EliminarDuplicados()
    {
        try
        {
            string documentosPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string filePath = Path.Combine(documentosPath, "nombres_archivos_usados_Comparador.txt");

            List<string> lineas = File.ReadAllLines(filePath).ToList();
            // Elimina duplicados manteniendo el orden
            List<string> lineasUnicas = lineas.Distinct().ToList();
            // Sobreescribe el archivo con las líneas únicas
            File.WriteAllLines(filePath, lineasUnicas);
        }
        catch (IOException )
        {}
    }

    //BorrarNombreIncorrecto----------------------------------------------------------------------------------------------------------------------------------

    public static void BorrarNombreIncorrecto(string nombreArchivo)
    {
        try
        {
            string documentosPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string filePath = Path.Combine(documentosPath, "nombres_archivos_usados_Comparador.txt");

            List<string> lineas = File.ReadAllLines(filePath).ToList();

            string lineaEncontrada = lineas.FirstOrDefault(linea => linea.Equals(nombreArchivo, StringComparison.OrdinalIgnoreCase))!;

            lineas.Remove(lineaEncontrada);

            // Sobreescribe el archivo con las líneas restantes
            File.WriteAllLines(filePath, lineas);
        }
        catch (IOException)
        {}
    }

    //BorrarContenidoArchivoBuscado---------------------------------------------------------------------------------------------------------------------------

    public static void BorrarContenidoArchivoBuscado()
    {
        try
        {
            string documentosPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string filePath = Path.Combine(documentosPath, "nombres_archivos_usados_Comparador.txt");

            File.WriteAllText(filePath, string.Empty);
        }
        catch (IOException e)
        {
            Console.WriteLine($"Error al borrar contenido del archivo: {e.Message}");
        }
        Console.WriteLine("\nNombres borrados exitosamente.");
    }
}