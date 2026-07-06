using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public class Servidor
    {
        public string nombre;
        public string ip;
        public string estado;

        public override string ToString()
        {
            return $"{nombre} (IP: {ip} - Estado: {estado})";
        }
    }
}
