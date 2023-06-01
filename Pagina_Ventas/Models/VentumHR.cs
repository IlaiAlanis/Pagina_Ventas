using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pagina_Ventas.Models
{
    public class VentumHR
    {
        public int IdVenta { get; set; }
        public int IdUsuarioVenta { get; set; }
        public DateTime FechaVenta { get; set; }
        public TimeSpan HoraVenta { get; set; }
        public int IdPagos { get; set; }
    }
}
