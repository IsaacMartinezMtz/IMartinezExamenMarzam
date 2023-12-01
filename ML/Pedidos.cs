using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Pedidos
    {
        public int IdPedido { get; set; }
        public int Cantidad { get; set; }
        public decimal Total { get; set; }
        public decimal Costo { get; set; }
        public ML.Usuario Usuario { get; set; }
        public ML.Medicamento Medicamento { get; set; }

        public List<object> Pedido { get; set; }
    }
}
