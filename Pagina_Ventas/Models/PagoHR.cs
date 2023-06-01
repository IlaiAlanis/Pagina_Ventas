using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Pagina_Ventas.Models
{
    public class PagoHR
    {
        public int IdPagos { get; set; }
        public string? MetodosPagoPagos { get; set; }
        public string? DescripcionPagos { get; set; }
    }
}
