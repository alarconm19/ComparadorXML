namespace ComparadorXMLconsola;


public static class MetodosMenu
{
    //MostrarPorPantalla---------------------------------------------------------------------------------------------------------------------------

    static void MostrarPorPantallaClase(int cont, IManagedObject obj)
    {
        Console.ResetColor();
        Console.Write($"\n{cont + 1}. Class: ");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write(obj.Class[(obj.Class.IndexOf(':') + 1)..]);

        Console.ResetColor();
        Console.Write(" -.- DistName: ");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write(obj.DistName);

        Console.ResetColor();
        Console.Write(" -.- Version: ");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(obj.Version);
        Console.ResetColor();
    }

    static void MostrarPorPantallaProterty(int cont, Property property, int opcion)
    {
        Console.ResetColor();
        Console.Write($"\n\t{cont + 1}. P: ");
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.Write(property.Name);
        Console.ResetColor();

        Console.Write(", Value: ");
        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.WriteLine(property.Value);

        if (opcion is 2 or 4)
        {
            Console.ResetColor();
            Console.Write("\tIngrese nuevo valor (enter para dejar el mismo): ");
            Console.ForegroundColor = ConsoleColor.Blue;
            string value = Console.ReadLine()!;
            if(value != "") property.Value = value;
        }

        Console.ResetColor();
    }

    static class MostrarPorPantallaLists
    {
        public static void MostrarNombreList(int cont, ListElement list)
        {
            Console.ResetColor();
            Console.Write($"\n\t\t{cont + 1}. List: ");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine(list.Name);
            Console.ResetColor();
        }

        public static void MostrarNombreItem(int cont)
        {
            Console.ResetColor();
            Console.WriteLine($"\n\t\t\t{cont + 1}. Item: ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.ResetColor();
        }

        public static void MostrarProtertyItem(int cont, Property property, int opcion)
        {
            Console.ResetColor();
            Console.Write($"\n\t\t\t\t{cont + 1}. P: ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(property.Name);
            Console.ResetColor();

            Console.Write(", Value: ");
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine(property.Value);

            if (opcion is 2 or 4)
            {
                Console.ResetColor();
                Console.Write("\t\t\t\tIngrese nuevo valor (enter para dejar el mismo): ");
                Console.ForegroundColor = ConsoleColor.Blue;
                string value = Console.ReadLine()!;
                if(value != "") property.Value = value;
            }
            Console.ResetColor();
        }

        public static void MostrarPropertyList(int cont, Property property, int opcion)
        {
            Console.ResetColor();
            Console.Write($"\n\t\t\t{cont + 1}. Value: ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(property.Value);

            if (opcion is 2 or 4)
            {
                Console.ResetColor();
                Console.Write("\t\t\tIngrese nuevo valor (enter para dejar el mismo): ");
                Console.ForegroundColor = ConsoleColor.Blue;
                string value = Console.ReadLine()!;
                if(value != "") property.Value = value;
            }

            Console.ResetColor();
        }
    }

    static void MostrarArchivo(int narchivo, ConsoleColor color, string nombre)
    {
        if (narchivo == 1)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n-----------------------------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("\n-----------------------------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("\n-----------------------------------------------------------------------------------------------------------------------------------------------");
        }
        Console.ForegroundColor = color;
        Console.Write($"\nArchivo {narchivo}: -----------------------------".PadLeft(15, '-'));
        Console.Write(nombre);
        Console.WriteLine("".PadRight(30, '-'));
        Console.ResetColor();
    }

    //Recorrido---------------------------------------------------------------------------------------------------------------------------

    public static int Recorrido(IManagedObject obj, int opcion, int i , string ruta, int archivo, ConsoleColor color)
    {
        if (opcion is 0 || opcion is 1 or 2 or 3 or 4 && (obj.Class[(obj.Class.IndexOf(':') + 1)..].Equals(MetodosXml.ClassBuscado) || MetodosXml.ClassBuscado == "") &&
            (obj.DistName.Equals(MetodosXml.DistNameBuscado) || MetodosXml.DistNameBuscado == "") && (obj.Version.Equals(MetodosXml.VersionBuscado) || MetodosXml.VersionBuscado == ""))
        {
            if (opcion is 3 or 4 && obj.Mostrar)
                MostrarArchivo(archivo, color, ruta);


            if (opcion is 0 or 1 or 2|| opcion is 3 or 4 && obj.Mostrar)
                MostrarPorPantallaClase(i, obj);


            if (obj.Property.Count > 0)
            {
                int contProperties = 0;
                foreach (var property in obj.Property)
                {
                    if (opcion is 0 or 1 or 2 || opcion is 3 or 4 & property.Mostrar)
                    {
                        MostrarPorPantallaProterty(contProperties, property, opcion);
                    }
                    contProperties++;
                }
            }

            if (obj.Lists.Count > 0)
            {
                int contLists = 0;
                foreach (var list in obj.Lists)
                {
                    if (opcion is 0 or 1 or 2 || opcion is 3 or 4 & list.Mostrar)
                    {
                        MostrarPorPantallaLists.MostrarNombreList(contLists, list);
                    }
                    if (list.Items.Count > 0)
                    {
                        int contItems = 0;
                        foreach (var item in list.Items)
                        {
                            if (opcion is 0 or 1 or 2 || opcion is 3 or 4 & item.Mostrar)
                            {
                                MostrarPorPantallaLists.MostrarNombreItem(contItems);
                            }
                            int contProperties = 0;
                            foreach (var property in item.Properties)
                            {
                                if (opcion is 0 or 1 or 2 || opcion is 3 or 4 & property.Mostrar)
                                {
                                    MostrarPorPantallaLists.MostrarProtertyItem(contProperties, property, opcion);
                                }
                                contProperties++;
                            }
                            contItems++;
                        }
                    }

                    if (list.Properties.Count > 0)
                    {
                        int contProperties = 0;
                        foreach (var property in list.Properties)
                        {
                            if (opcion is 0 or 1 or 2 || opcion is 3 or 4 & property.Mostrar)
                            {
                                MostrarPorPantallaLists.MostrarPropertyList(contProperties, property, opcion);
                            }
                            contProperties++;
                        }
                    }
                    contLists++;
                }
            }
        }
        Console.ResetColor();
        return 1;
    }

    //Comparar---------------------------------------------------------------------------------------------------------------------------

    /*
    public static void Comparar(ArchivoXml archivoXml, ArchivoXml archivoXml1, int opcion)
    {
        string parteFija1 = "";
        string parteFija2 = "";

        int i = -1;
        foreach (var obj in archivoXml.ManagedObjects)
        {
            i++;
            int j = -1;

            string? resultado1;
            if (i == 0)
            {
                parteFija1 = obj.DistName;

                resultado1 = obj.DistName[parteFija1.Length..];

                parteFija1 += "/";
            }
            else
                resultado1 = obj.DistName[parteFija1.Length..];

            foreach (var obj1 in archivoXml1.ManagedObjects)
            {
                j++;

                string? resultado2;
                if (j == 0)
                {
                    parteFija2 = obj1.DistName;

                    resultado2 = obj1.DistName[parteFija2.Length..];

                    parteFija2 += "/";
                }
                else
                    resultado2 = obj1.DistName[parteFija2.Length..];

                //PROPERTY---------------------------------------------------------------------------------------------------------------------

                if(!resultado1.Equals(resultado2)) continue;
                if (!obj.Class[(obj.Class.IndexOf(':') + 1)..].Equals(obj1.Class[(obj1.Class.IndexOf(':') + 1)..])) continue;

                IManagedObject? managedObject = null;
                IManagedObject? managedObject1 = null;

                if (obj.Property.Count > 0)
                {
                    foreach (var prop in obj.Property)
                    {
                        var prop1 = obj1.Property.FirstOrDefault(p => p.Name == prop.Name);

                        if (prop1 == null || prop.Value == prop1.Value) continue;

                        managedObject ??= new ManagedObject21()
                        {
                                Class = obj.Class,
                                DistName = obj.DistName,
                                Version = obj.Version,
                                Property = new List<Property>()
                        };
                        managedObject.Property.Add(prop);

                        managedObject1 ??= new ManagedObject21
                        {
                                Class = obj1.Class,
                                DistName = obj1.DistName,
                                Version = obj1.Version,
                                Property = new List<Property>()
                        };
                        managedObject1.Property.Add(prop1);
                    }
                }

                // Comparar las listas
                if (obj.Lists.Count > 0)
                {
                    foreach (var list in obj.Lists)
                    {
                        var list1 = obj1.Lists.FirstOrDefault(l => l.Name == list.Name);
                        if (list1 == null) continue;

                        List<Item> differentItems = new List<Item>();
                        List<Item> differentItems1 = new List<Item>();

                        // Comparar elementos (Items) dentro de la lista
                        if (list.Items.Count > 0 && list.Items.Count == list1.Items.Count)
                        {
                            for (int contItems = 0; contItems < list.Items.Count; contItems++)
                            {
                                var item = list.Items[contItems];
                                var item1 = list1.Items[contItems];

                                List<Property> differentPropertiesItems = new List<Property>();
                                List<Property> differentPropertiesItems1 = new List<Property>();

                                foreach (var prop in item.Properties)
                                {
                                    var prop1 = item1.Properties.FirstOrDefault(p => p.Name == prop.Name);

                                    if (prop1 == null || prop.Value == prop1.Value) continue;
                                    differentPropertiesItems.Add(prop);
                                    differentPropertiesItems1.Add(prop1);
                                }

                                if (differentPropertiesItems.Count <= 0) continue;

                                var newItem = new Item
                                {
                                    Properties = differentPropertiesItems
                                };

                                var newItem1 = new Item
                                {
                                    Properties = differentPropertiesItems1
                                };

                                differentItems.Add(newItem);
                                differentItems1.Add(newItem1);
                            }
                        }

                        // Comparar propiedades (Properties) dentro de la lista
                        List<Property> differentProperties = new List<Property>();
                        List<Property> differentProperties1 = new List<Property>();

                        if (list.Properties.Count > 0)
                        {
                            foreach (var prop in list.Properties)
                            {
                                foreach (var prop1 in list1.Properties.Where(prop1 => prop.Name != prop1.Name))
                                {
                                    differentProperties.Add(prop);
                                    differentProperties1.Add(prop1);
                                }
                            }
                        }

                        if (differentProperties.Count > 0)
                        {
                            var newItem = new Item
                            {
                                Properties = differentProperties
                            };
                            differentItems.Add(newItem);
                            var newItem1 = new Item
                            {
                                Properties = differentProperties1
                            };
                            differentItems1.Add(newItem1);
                        }

                        managedObject ??= new ManagedObject21
                        {
                            Class = obj.Class,
                            DistName = obj.DistName,
                            Version = obj.Version,
                            Lists = new List<ListElement>()
                        };
                        managedObject1 ??= new ManagedObject21
                        {
                            Class = obj1.Class,
                            DistName = obj1.DistName,
                            Version = obj1.Version,
                            Lists = new List<ListElement>()
                        };

                        switch (differentItems.Count)
                        {
                            case > 0 when differentProperties.Count > 0:
                            {
                                var newList = new ListElement
                                {
                                        Name = list.Name,
                                        Items = differentItems,
                                        Properties = differentProperties
                                };

                                var newList1 = new ListElement
                                {
                                        Name = list1.Name,
                                        Items = differentItems1,
                                        Properties = differentProperties1
                                };

                                managedObject.Lists.Add(newList);
                                managedObject1.Lists.Add(newList1);
                                break;
                            }

                            case > 0 when differentProperties.Count == 0:
                            {
                                var newList = new ListElement
                                {
                                        Name = list.Name,
                                        Items = differentItems,
                                };

                                var newList1 = new ListElement
                                {
                                        Name = list1.Name,
                                        Items = differentItems1,
                                };

                                managedObject.Lists.Add(newList);
                                managedObject1.Lists.Add(newList1);
                                break;
                            }

                            case 0 when differentProperties.Count > 0:
                            {
                                var newList = new ListElement
                                {
                                        Name = list.Name,
                                        Properties = differentProperties
                                };

                                var newList1 = new ListElement
                                {
                                        Name = list1.Name,
                                        Properties = differentProperties1
                                };

                                managedObject.Lists.Add(newList);
                                managedObject1.Lists.Add(newList1);
                                break;
                            }
                        }
                    }
                }

                //MOSTRAR---------------------------------------------------------------------------------------------------------------------

                //ARCHIVO 1-------------------------------------------------------------------------------------------------------------------------------

                if(managedObject == null) continue;
                if(managedObject.Property.Count == 0 && managedObject.Lists.Count == 0) continue;

                //Console.WriteLine($"{resultado1} - {resultado2}");

                Recorrido(managedObject, opcion, i, archivoXml.Ruta, 1);

                //ARCHIVO 2-------------------------------------------------------------------------------------------------------------------------------

                if(managedObject1 == null) continue;
                if(managedObject1.Property.Count == 0 && managedObject1.Lists.Count == 0) continue;

                Recorrido(managedObject1, opcion, j, archivoXml.Ruta, 2);


                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n-----------------------------------------------------------------------------------------------------------------------------------------------");
                Console.WriteLine("\n-----------------------------------------------------------------------------------------------------------------------------------------------");
                Console.WriteLine("\n-----------------------------------------------------------------------------------------------------------------------------------------------");

                Console.ResetColor();
            }

        }
    }
    //*/


    public static void Comparar(ArchivoXml archivoXml, ArchivoXml archivoXml1, int opcionRecorridoUnico, int opcionRecorridoDoble)
    {
        string parteFija1 = "";
        string parteFija2 = "";

        int i = -1;
        foreach (var obj in archivoXml.ManagedObjects)
        {
            i++;
            int j = -1;

            string? resultado1;
            if (i == 0)
            {
                parteFija1 = obj.DistName;

                resultado1 = obj.DistName[parteFija1.Length..];

                parteFija1 += "/";
            }
            else
                resultado1 = obj.DistName[parteFija1.Length..];

            foreach (var obj1 in archivoXml1.ManagedObjects)
            {
                j++;

                string? resultado2;
                if (j == 0)
                {
                    parteFija2 = obj1.DistName;

                    resultado2 = obj1.DistName[parteFija2.Length..];

                    parteFija2 += "/";
                }
                else
                    resultado2 = obj1.DistName[parteFija2.Length..];

                //PROPERTY---------------------------------------------------------------------------------------------------------------------

                if(!resultado1.Equals(resultado2)) continue;
                if (!obj.Class[(obj.Class.IndexOf(':') + 1)..].Equals(obj1.Class[(obj1.Class.IndexOf(':') + 1)..])) continue;

                RecorridoComparar(obj, obj1, opcionRecorridoDoble);

                //MOSTRAR---------------------------------------------------------------------------------------------------------------------

                //ARCHIVO 1-------------------------------------------------------------------------------------------------------------------------------

                Recorrido(obj, opcionRecorridoUnico, i, archivoXml.Ruta, 1, ConsoleColor.Cyan);

                //ARCHIVO 2-------------------------------------------------------------------------------------------------------------------------------

                Recorrido(obj1, opcionRecorridoUnico, j, archivoXml1.Ruta, 2, ConsoleColor.Magenta);

                Console.ResetColor();
            }
        }
    }

    //RecorridoComparar---------------------------------------------------------------------------------------------------------------------------

    static void RecorridoComparar(IManagedObject obj, IManagedObject obj1, int opcion)
    {
        if (obj.Property.Count > 0)
        {
            foreach (var prop in obj.Property)
            {
                var prop1 = obj1.Property.FirstOrDefault(p => p.Name == prop.Name);
                if (prop1 == null) continue;

                if (prop.Value != prop1.Value && opcion is 0)
                {
                    obj.Mostrar = true;
                    obj1.Mostrar = true;
                    prop.Mostrar = true;
                    prop1.Mostrar = true;
                }
                else
                {
                    if (!prop.Mostrar || !prop1.Mostrar || opcion is not 1) continue;

                    prop1.Value = prop.Value;

                    obj.Mostrar = false;
                    obj1.Mostrar = false;
                    prop.Mostrar = false;
                    prop1.Mostrar = false;
                }
            }
        }

        // Comparar las listas
        if (obj.Lists.Count <= 0) return;
        foreach (var list in obj.Lists)
        {
            var list1 = obj1.Lists.FirstOrDefault(l => l.Name == list.Name);
            if (list1 == null) continue;

            // Comparar elementos (Items) dentro de la lista
            if (list.Items.Count > 0 && list.Items.Count == list1.Items.Count)
            {
                for (int contItems = 0; contItems < list.Items.Count; contItems++)
                {
                    var item = list.Items[contItems];
                    var item1 = list1.Items[contItems];

                    foreach (var prop in item.Properties)
                    {
                        var prop1 = item1.Properties.FirstOrDefault(p => p.Name == prop.Name);
                        if (prop1 == null) continue;

                        if (prop.Value != prop1.Value && opcion is 0)
                        {
                            obj.Mostrar = true;
                            obj1.Mostrar = true;
                            list.Mostrar = true;
                            list1.Mostrar = true;
                            item.Mostrar = true;
                            item1.Mostrar = true;
                            prop.Mostrar = true;
                            prop1.Mostrar = true;
                        }
                        else
                        {
                            if (!prop.Mostrar || !prop1.Mostrar || opcion is not 1) continue;

                            prop1.Value = prop.Value;

                            obj.Mostrar = false;
                            obj1.Mostrar = false;
                            list.Mostrar = false;
                            list1.Mostrar = false;
                            item.Mostrar = false;
                            item1.Mostrar = false;
                            prop.Mostrar = false;
                            prop1.Mostrar = false;
                        }
                    }
                }
            }

            if (list.Properties.Count <= 0 || list.Properties.Count != list1.Properties.Count) continue;
            for (int contProperties = 0; contProperties < list.Properties.Count; contProperties++)
            {
                var prop = list.Properties[contProperties];
                var prop1 = list1.Properties[contProperties];

                if (!prop.Value.Equals(prop1.Value) && opcion is 0)
                {
                    obj.Mostrar = true;
                    obj1.Mostrar = true;
                    prop.Mostrar = true;
                    prop1.Mostrar = true;
                    list.Mostrar = true;
                    list1.Mostrar = true;
                }
                else
                {
                    if (!prop.Mostrar || !prop1.Mostrar || opcion is not 1) continue;

                    prop1.Value = prop.Value;

                    obj.Mostrar = false;
                    obj1.Mostrar = false;
                    list.Mostrar = false;
                    list1.Mostrar = false;
                    prop.Mostrar = false;
                    prop1.Mostrar = false;
                }
            }
        }
    }

    //RedesActivas---------------------------------------------------------------------------------------------------------------------------

    public static void RedesActivas(IEnumerable<IManagedObject> managedObjects)
    {
        bool red2G = false;
        bool red3G = false;
        bool red4G = false;
        bool red5G = false;

        Console.WriteLine();

        foreach (var obj in managedObjects.Where(obj => obj.Class.Contains("CHANNEL")))
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            if (obj.DistName.Contains("LCELC") && !red2G)
            {
                Console.WriteLine("Este servidor maneja 2g. ");
                red2G = true;
            }
            if (obj.DistName.Contains("LCELW") && !red3G)
            {
                Console.WriteLine("Este servidor maneja 3g. ");
                red3G = true;
            }
            if (obj.DistName.Contains("LCELL") && !red4G)
            {
                Console.WriteLine("Este servidor maneja 4g. ");
                red4G = true;
            }
            if (obj.DistName.Contains("LCELNR") && !red5G)
            {
                Console.WriteLine("Este servidor maneja 5g. ");
                red5G = true;
            }
            Console.ResetColor();
            if (!red2G || !red3G || !red4G || !red5G) continue;
            break;

        }
    }
}