using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Pagina_Ventas.Models
{
    public class MarcaProductoHR
    {
        public int IdMarca { get; set; }
        public string NombreMar { get; set; } = null!;
        public string DescripcionMar { get; set; } = null!;
    }
}
