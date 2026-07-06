using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public class Vertice
    {
        public Servidor dato;
        
        public Vertice sig = null;

        
        public ListaAristas ls = new ListaAristas();

        //Datos para dijkstra
        public float distancia = float.MaxValue;
        public bool visitado = false;
        public Vertice anterior = null;
        public float pesoAnterior = 0;
    }
}
