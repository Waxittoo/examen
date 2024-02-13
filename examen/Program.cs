using System;

class Program
{
    static int numeroFacturaConsecutivo = 1;

    static string[] numeroFactura = new string[15];
    static string[] numeroDePlaca = new string[15];
    static DateTime[] fecha = new DateTime[15];
    static string[] hora = new string[15];
    static int[] tipodevehiculo = new int[15];
    static int[] numeroCaseta = new int[15];
    static double[] montoPagar = new double[15];
    static double[] pagaCon = new double[15];
    static double[] vuelto = new double[15];
    static int vehiculosRegistrados = 0;
    static int opcion = 0;

    static void Main(string[] args)
    {
        int opcion;
        do
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("*****************Pajea Braulio Carrillo *************************");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("1 - Inicializar Vectores");
            Console.WriteLine("2 - Ingresar Paso de vehiculo");
            Console.WriteLine("3 - ver vehiculos ");
            Console.WriteLine("4 - Modificar datos vehiculos x numero de placa");
            Console.WriteLine("5 - Mostrar Factura  ");
            Console.WriteLine("6 - Salir");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Seleccione una opción: ");
            opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    InicializarVectores();
                    break;
                case 2:
                    IngresarPasoVehicular();
                    break;
                case 3:
                     MostrarVehiculosRegistrados();
                    break;
                case 4:
                     ModificarPagos();
                    break;
                case 5:
                    MostrarResultadoPago();
                     
                    break;
                case 6:
                    Console.WriteLine("Saliendo del programa...");
                    break;
                default:
                    Console.WriteLine("Opción no válida. Intente nuevamente.");
                    break;
            }

            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadKey();
        } while (opcion != 6);
    }

    static void InicializarVectores()
    {
        numeroFacturaConsecutivo = 1;

        for (int i = 0; i < 15; i++)
        {
            fecha[i] = DateTime.Now;
            hora[i] = DateTime.Now.ToString("HH:mm");
            numeroDePlaca[i] = "";
            tipodevehiculo[i] = 0;
            numeroCaseta[i] = new Random().Next(1, 3);
            
            montoPagar[i] = 0;
            // Asignar un valor fijo o asignar valores posteriormente
            pagaCon[i] = 0;
            vuelto[i] = 0;
        }
        vehiculosRegistrados = 0;
        Console.WriteLine("Vectores inicializados correctamente\n");
    }

    static void IngresarPasoVehicular()
    {
        int i = vehiculosRegistrados; // Declarar e inicializar el contador

        if (i < 15) // Verificar si hay espacio disponible en el array
        {
            do
            {
                Console.Write("Ingrese el número de placa del vehículo (debe ser de 4 dígitos): ");
                string numeroPlaca = Console.ReadLine();
                if (numeroPlaca.Length != 4)
                {
                    Console.WriteLine("El número de placa debe tener exactamente 4 dígitos. Intente nuevamente.");
                    continue; // Regresar al inicio del ciclo si la placa no tiene 4 dígitos
                }

                numeroDePlaca[i] = numeroPlaca;

                int tipoServicioActual;
                do
                {
                    Console.WriteLine("Tabla precios");
                    Console.WriteLine("\u001b[33mVehículo liviano\t\t\u001b[36m¢700\u001b[0m");
                    Console.WriteLine("\u001b[33mCamión o Pesado\t\t\u001b[36m¢2700\u001b[0m");
                    Console.WriteLine("\u001b[33mMotocicleta\t\t\u001b[36m\t¢500\u001b[0m");
                    Console.WriteLine("\u001b[33mAutobús\t\t\t\t\u001b[36m¢3700\u001b[0m");
                    Console.Write("Tipo de Servicio (1 = Precio de  moto, 2= Precio de autos liviano, 3= Precio de camion 4=  Precio de autobus): precione enter para continuar  ");
                    if (!int.TryParse(Console.ReadLine(), out tipoServicioActual) || (tipoServicioActual < 1 || tipoServicioActual > 4))
                        Console.WriteLine("Opción inválida. Intente nuevamente.");
                    else
                        tipodevehiculo[i] = tipoServicioActual;
                } while (tipodevehiculo[i] == 0);

                do
                {
                   
                } while (!double.TryParse(Console.ReadLine(), out montoPagar[i]));

                switch (tipodevehiculo[i])
                {
                    case 1:
                        montoPagar[i] = 700;
                        break;
                    case 2:
                        montoPagar[i] = 2700;
                        break;
                    case 3:
                        montoPagar[i] = 500;
                        break;
                    case 4:
                        montoPagar[i] = 3700;
                        break;
                    default:
                        break;
                }

                double montoPagaCliente; // Variable para almacenar el monto pagado por el cliente
                do
                {
                    Console.Write($" Monto con a pagar por el vehiculo  : {montoPagar[i]}");
                    Console.WriteLine(" Monto a Pagar del Cliente: ");
                } while (!double.TryParse(Console.ReadLine(), out montoPagaCliente) || montoPagaCliente < montoPagar[i]);

                vuelto[i] = montoPagar[i] - montoPagaCliente;

                //MostrarResultadoPago(i); // Mostrar resultado del pago

                Console.WriteLine($"Número de Factura asignado: {numeroFactura[i]}\n");

                vehiculosRegistrados++; // Incrementar el contador de vehículos registrados

                if (i < 14) // Verificar si hay espacio para ingresar otro pago
                {
                    Console.Write("¿Desea ingresar otro pago? (S/N): ");
                    string continuar;
                    do
                    {
                        continuar = Console.ReadLine().ToUpper();
                        if (continuar != "S" && continuar != "N")
                            Console.WriteLine("Opción inválida. Intente nuevamente.");
                    } while (continuar != "S" && continuar != "N");

                    if (continuar == "N")
                        return; // Salir de la función si no se desea ingresar otro pago
                }
                else
                {
                    Console.WriteLine("Vectores llenos. No se permiten más pagos.\n");
                    return; // Salir de la función si no hay espacio para más pagos
                }
            } while (true); // Repetir el proceso hasta que se decida no ingresar otro pago
        }
        else
        {
            Console.WriteLine("Vectores llenos. No se permiten más pagos.\n");
            return; // Salir de la función si no hay espacio para más pagos
        }
    }

    static void ModificarPagos()
    {
        Console.Write("Ingrese el número de placa del vehículo que desea modificar: ");
        string numeroPlacaModificar = Console.ReadLine();
        int indice = -1;

        // Buscar el vehículo por su número de placa
        for (int i = 0; i < vehiculosRegistrados; i++)
        {
            if (numeroDePlaca[i] == numeroPlacaModificar)
            {
                indice = i;
                break;
            }
        }

        if (indice != -1)
        {
            Console.WriteLine($"Vehículo encontrado. Datos actuales:");
            MostrarResultadoPago();

            // Solicitar nuevos datos para el vehículo
            Console.WriteLine("Ingrese los nuevos datos para este vehículo:");
            Console.Write("Nuevo número de placa: ");
            string nuevaPlaca = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(nuevaPlaca))
                numeroDePlaca[indice] = nuevaPlaca;

            int nuevoTipoServicio;
            do
            {
                Console.Write("Nuevo tipo de Servicio (1= Recibo de moto, 2= Recibo liviano, 3= Recibo de camion 4= autobus): ");
            } while (!int.TryParse(Console.ReadLine(), out nuevoTipoServicio) || (nuevoTipoServicio < 1 || nuevoTipoServicio > 4));
            tipodevehiculo[indice] = nuevoTipoServicio;

            double nuevoMontoPagar;
            do
            {
                Console.Write("Nuevo Monto a Pagar: ");
            } while (!double.TryParse(Console.ReadLine(), out nuevoMontoPagar));
            montoPagar[indice] = nuevoMontoPagar;

            Console.WriteLine("Vehículo modificado con éxito.");
        }
        else
        {
            Console.WriteLine("Vehículo no encontrado. Verifique el número de placa e intente nuevamente.");
        }
    }


    static void MostrarResultadoPago()
    {
        Console.WriteLine("Título del Reporte");
        Console.WriteLine("N factura    Placa           Tipo de vehículo          Caseta        Monto Pagar   Paga con     Vuelto");
        Console.WriteLine("===========================================================================================================");
        for (int i = 0; i < vehiculosRegistrados; i++)
        {
            Console.WriteLine($"{numeroFactura[i]}\t{numeroDePlaca[i]}\t\t{tipodevehiculo[i]}\t\t{numeroCaseta[i]}\t{montoPagar[i]}\t\t{pagaCon[i]}\t\t{vuelto[i]}");
        }
        Console.WriteLine("=======================================================================================================================");
        double totalMontoPagar = 0;
        for (int i = 0; i < vehiculosRegistrados; i++)
        {
            totalMontoPagar += montoPagar[i];
        }
        Console.WriteLine($"Cantidad de vehículos: {vehiculosRegistrados}\t\t\t\ttotal: {totalMontoPagar}");
        Console.WriteLine("=======================================================================================================================");
        Console.WriteLine("                                 <<< Pulse tecla para regresar >>>");
        Console.ReadKey();
    }

    static void MostrarVehiculosRegistrados()
    {
        Console.WriteLine("Vehículos Registrados:");
        Console.WriteLine("┌────────────────────┬────────────────────┬──────────────────┐");
        Console.WriteLine("│   Número de Placa  │   Tipo de Vehículo │   Monto a Pagar  │");
        Console.WriteLine("├────────────────────┼────────────────────┼──────────────────┤");
        for (int i = 0; i < vehiculosRegistrados; i++)
        {
            Console.WriteLine($"│ {numeroDePlaca[i],-18} │ {ObtenerTipoVehiculo(tipodevehiculo[i]),-18} │ {montoPagar[i],-16} │");
        }
        Console.WriteLine("└────────────────────┴────────────────────┴──────────────────┘");
    }

    static string ObtenerTipoVehiculo(int tipo)
    {
        switch (tipo)
        {
            case 1:
                return "Moto";
            case 2:
                return "Vehículo Liviano";
            case 3:
                return "Camión o Pesado";
            case 4:
                return "Autobús";
            default:
                return "Desconocido";
        }
    }



}
