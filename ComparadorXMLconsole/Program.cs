namespace ComparadorXMLconsola;


/*
 vlnif
 iprt
 ntp
 */ 
static class Menu
{ 
    static void Main()
    {
        int opcionMenu = 0;
        bool opcionMenuIncorrecto;

        var archivoXml = MetodosXml.CargarArchivoXml();
        MetodosMenu.RedesActivas(archivoXml.ManagedObjects);
        Console.WriteLine("\x1b[8;30;100t");

        do
        {
            try
            {
                opcionMenuIncorrecto = false;

                Console.WriteLine("\n1. Cargar otro archivo \n2. Buscar \n3. Comparar 2 archivos \n4. Listar archivo completo \n5. Salir ");
                Console.Write("Seleccione una opción: ");

                opcionMenu = int.Parse(Console.ReadLine()!);
                Console.WriteLine();

                int i;
                switch (opcionMenu)
                {
                    case 1:
                        archivoXml = MetodosXml.CargarArchivoXml();
                        MetodosMenu.RedesActivas(archivoXml.ManagedObjects);
                        break;

                    case 2:

                        MetodosXml.BuscarEnXml();
                        i = 0;
                        int encontrados = 0;

                        foreach (var obj in archivoXml.ManagedObjects)
                        {
                            encontrados += MetodosMenu.Recorrido(obj, 1, i, "", 0, ConsoleColor.Black);
                            i++;
                        }

                        if (encontrados > 0) MetodosXml.Modificar(archivoXml, null!, 0);
                        break;

                    case 3:

                        Console.WriteLine("Seleccione o ingrese el segundo archivo. ");
                        var archivoXml1 = MetodosXml.CargarArchivoXml();
                        MetodosMenu.RedesActivas(archivoXml1.ManagedObjects);


                        bool opcionCorrecta;
                        do
                        {
                            opcionCorrecta = true;
                            try
                            {
                                Console.WriteLine("\n1. Todas las coincidencias. \n2. Buscar por clase/ distName/ version.");
                                Console.Write("Seleccione una opcion: ");

                                int opcion = int.Parse(Console.ReadLine()!);

                                switch (opcion)
                                {
                                    case 1:
                                        MetodosXml.ClassBuscado = "";
                                        MetodosXml.DistNameBuscado = "";
                                        MetodosXml.VersionBuscado = "";
                                        break;

                                    case 2:
                                        MetodosXml.BuscarEnXml();
                                        break;

                                    default:
                                        Console.WriteLine("Valor no válido. Ingrese de vuelta. ");
                                        opcionCorrecta = false;
                                        break;
                                }
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Error. Ingrese un numero. ");
                                opcionCorrecta = false;
                            }
                        } while (!opcionCorrecta);

                        MetodosMenu.Comparar(archivoXml, archivoXml1, 3, 0);

                        MetodosXml.Modificar(archivoXml, archivoXml1, 1);

                        break;

                    case 4:
                        Console.WriteLine("Listando archivo completo...");

                        i = 0;
                        if (archivoXml.ManagedObjects.Count > 0)
                        {
                            foreach (var obj in archivoXml.ManagedObjects)
                            {
                                MetodosMenu.Recorrido(obj, 0, i, "", 0, ConsoleColor.Black);
                                i++;
                            }
                        }
                        break;

                    case 5:
                        Console.WriteLine("¡Hasta la próxima!");
                        break;

                    default:
                        Console.WriteLine("Opción inválida. ");
                        break;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("\nError. Ingrese un número.");
                opcionMenuIncorrecto = true;
            }
        } while (opcionMenuIncorrecto || opcionMenu != 5);
    }
}