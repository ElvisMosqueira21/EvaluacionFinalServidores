using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public class Grafo
    {
        ListaSimple l_vertices = new ListaSimple();
        int[,] ma;

        string[] nom_servidores = { "Amazonas", "Ancash", "Apurimac", "Arequipa", "Ayacucho", "Cajamarca", "Cusco", "Huancavelica", "Huanuco", "Ica", "Junin", "La Libertad", "Lambayeque", "Lima", "Loreto", "Madre de Dios", "Moquegua", "Pasco", "Piura", "Puno", "San Martin", "Tacna", "Tumbes","Ucayali" };
        string[] ips = { "192.168.1.1", "192.168.1.2", "192.168.1.3", "192.168.1.4", "192.168.1.5", "192.168.1.6", "192.168.1.7", "192.168.1.8", "192.168.1.9", "192.168.1.10", "192.168.1.11", "192.168.1.12", "192.168.1.13", "192.168.1.14", "192.168.1.15", "192.168.1.16", "192.168.1.17", "192.168.1.18", "192.168.1.19", "192.168.1.20", "192.168.1.21", "192.168.1.22", "192.168.1.23", "192.168.1.24" };

        public Grafo(int cant)
        {
            Random r = new Random();
            for (int i = 0; i < cant; i++)
            {
                Servidor s = new Servidor();
                s.nombre = nom_servidores[i];
                s.ip = ips[i];
                s.estado = "Activo";
                l_vertices.Insertar(s);
            }
            ma = new int[cant, cant];
        }

        public Vertice GetInicio()
        {
            return l_vertices.primero;
        }

        public void GenerarMatriz()
        {
            Random r = new Random();
            for (int i = 0; i < ma.GetLength(0); i++)
                for (int j = 0; j < ma.GetLength(1); j++)
                    ma[i, j] = r.Next(0, 2);
        }

        public void MostrarMatriz()
        {
            for (int i = 0; i < ma.GetLength(0); i++)
            {
                for (int j = 0; j < ma.GetLength(1); j++)
                    Console.Write(ma[i, j] + "\t");
                Console.WriteLine();
            }
        }

        public void CrearGrafo()
        {
            Random rnd = new Random();
            Vertice temp_i = l_vertices.primero;
            for (int i = 0; i < ma.GetLength(0); i++)
            {
                Vertice temp_j = l_vertices.primero;
                for (int j = 0; j < ma.GetLength(1); j++)
                {
                    if (ma[i, j] == 1 && i != j)
                    {
                        
                        temp_i.ls.Insertar(temp_j, rnd.Next(1, 100));
                    }
                    temp_j = temp_j.sig;
                }
                temp_i = temp_i.sig;
            }
        }

        
        public Vertice GetVertice(int indice)
        {
            Vertice temp = l_vertices.primero;
            for (int i = 0; i < indice; i++)
                temp = temp.sig;
            return temp;
        }

        public void MostrarServidores()
        {
            Vertice temp = l_vertices.primero;
            int i = 0;
            while (temp != null)
            {
                Console.WriteLine(i + ". " + temp.dato);
                temp = temp.sig;
                i++;
            }
        }

        //Algoritmo dijkstra
        public void Dijkstra(Vertice origen, Vertice destino)
        {
            Vertice temp = l_vertices.primero;
            while (temp != null)
            {
                temp.distancia = float.MaxValue;
                temp.visitado = false;
                temp.anterior = null;
                temp.pesoAnterior = 0;
                temp = temp.sig;
            }

            origen.distancia = 0;

            while (true)
            {
                Vertice actual = null;
                temp = l_vertices.primero;
                while (temp != null)
                {
                    if (!temp.visitado && (actual == null || temp.distancia < actual.distancia))
                        actual = temp;
                    temp = temp.sig;
                }

                if (actual == null || actual.distancia == float.MaxValue)
                    break;

                actual.visitado = true;

                if (actual == destino)
                    break;

                Arista a = actual.ls.primero;
                while (a != null)
                {
                    if (!a.destino.visitado)
                    {
                        float nuevaDistancia = actual.distancia + a.peso;
                        if (nuevaDistancia < a.destino.distancia)
                        {
                            a.destino.distancia = nuevaDistancia;
                            a.destino.anterior = actual;
                            a.destino.pesoAnterior = a.peso;
                        }
                    }
                    a = a.sig;
                }
            }

            if (destino.distancia == float.MaxValue)
            {
                Console.WriteLine($"No existe ruta entre {origen.dato.nombre} y {destino.dato.nombre}.");
            }
            else
            {
                Console.WriteLine("Ruta mas rapida:");
                ImprimirCamino(destino);
                Console.Write($"Latencia total: ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"{destino.distancia} ms");
                Console.ResetColor();
            }
        }


        private void ImprimirCamino(Vertice v)
        {
            if (v.anterior != null)
            {
                ImprimirCamino(v.anterior);
                Console.WriteLine($"{v.anterior.dato.nombre} -> {v.dato.nombre} : {v.pesoAnterior} ms");
            }
        }
    }
}
