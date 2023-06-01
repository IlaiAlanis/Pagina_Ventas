using System.ComponentModel.DataAnnotations.Schema;

namespace Pagina_Ventas.Models
{
    public class CarritoHR
    {
        public int IdUsuarioCarrito { get; set; }
        public int IdProdCarrito { get; set; }
        public int? CantidadCarrito { get; set; }
    }
}
