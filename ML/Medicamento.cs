using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Medicamento
    {
        public int IdMedicamneto { get; set; }
        public string Nombre { get; set; }
        public Decimal Precio { get; set; }
        public int IdUsuario { get; set; }
        public List<object> Mediacementos { get; set; }
    }
}
