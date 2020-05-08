using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Factura
    {
        public string cliente { get; set; }
        public Item[] item { get; set; }
        public double valorTotal { get; set; }
    }
}
