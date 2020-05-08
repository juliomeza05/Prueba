using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Item
    {
        public Producto producto { get; set; }
        public int cantidad { get; set; }
        public double valorTotal { get; set; }
    }
}
