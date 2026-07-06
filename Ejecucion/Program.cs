using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clases;

namespace Ejecucion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Grafo gf = null;
            int opcion;

            do
            {
                Console.Clear();
                Console.ForegroundColor= ConsoleColor.Cyan;
                Console.WriteLine("\n============ OPTIMIZACION DE RUTAS EN SERVIDORES=============");
                Console.WriteLine("1.======================= Crear grafo=========================");
                Console.WriteLine("2.====================== Mostrar matriz=======================");
                Console.WriteLine("3.==================== Mostrar servidores=====================");
                Console.WriteLine("4.======================= Buscar ruta=========================");
                Console.WriteLine("0.========================= Salir ============================");
                Console.ResetColor();
                Console.Write("Seleccione una opcion: ");


                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        Console.Write("Ingrese cantidad de servidores(1-24): ");
                        int cant = int.Parse(Console.ReadLine());

                        gf = new Grafo(cant);
                        gf.GenerarMatriz();
                        gf.CrearGrafo();

                        Console.WriteLine("Grafo creado correctamente.");
                        break;

                    case 2:
                        if (gf != null)
                            gf.MostrarMatriz();
                        else
                            Console.WriteLine("Primero debes crear el grafo.");
                        break;

                    case 3:
                        if (gf != null)

                            gf.MostrarServidores();
                        else
                            Console.WriteLine("Primero debes crear el grafo.");
                        break;

                    case 4:
                        if (gf != null)
                        {
                            gf.MostrarServidores();
                            Console.Write("\nIngrese el servidor de ORIGEN: ");
                            int orig = int.Parse(Console.ReadLine());

                            Console.Write("Ingrese el servidor de DESTINO: ");
                            int dest = int.Parse(Console.ReadLine());

                            Vertice origen = gf.GetVertice(orig);
                            Vertice destino = gf.GetVertice(dest);

                            gf.Dijkstra(origen, destino);
                        }
                        else
                        {
                            Console.WriteLine("Primero debe crear el grafo.");
                        }
                        break;

                    case 0:
                        Console.WriteLine("Programa finalizado.");
                        break;

                    default:
                        Console.WriteLine("Opcion invalida.");
                        break;
                }
                if (opcion != 0)
                {
                    Console.WriteLine("\nPresione una tecla para continuar");
                    Console.ReadKey();
                }

            } while (opcion != 0);
        }
    }
}
