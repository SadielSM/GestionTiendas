using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorMovilChip.Modelos
{
    public class Producto
    {
        public int IdProducto { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public int IdCategoria { get; set; }
        public string NombreCategoria { get; set; }

        public decimal PrecioCompra { get; set; }
        public decimal PrecioVenta { get; set; }
        public int Stock { get; set; }
        public string CodigoBarras { get; set; }
        public bool Activo { get; set; }
    }
}
