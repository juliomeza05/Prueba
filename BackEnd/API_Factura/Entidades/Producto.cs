using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Producto
    {
        public int codigo { get; set; }
        public Double valor { get; set; }
        public string nombre { get; set; }

        public Producto()
        {
            codigo = 0;
            valor = 0;
            nombre = "";
        }
    }
}
