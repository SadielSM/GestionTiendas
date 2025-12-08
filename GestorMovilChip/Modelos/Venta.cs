using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorMovilChip.Modelos
{
    public class Venta
    {
        public int IdVenta { get; set; }
        public DateTime Fecha { get; set; }

        public int? IdCliente { get; set; }
        public string NombreCliente { get; set; }

        public int IdUsuario { get; set; }
        public string NombreUsuario { get; set; }

        public decimal Total { get; set; }
    }
}
