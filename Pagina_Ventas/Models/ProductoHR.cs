using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Pagina_Ventas.Models
{
    public class ProductoHR
    {
        
        public int IdProd { get; set; }
        public int IdCatProd { get; set; }
        public int MarcaProd { get; set; }
        public decimal CostoProd { get; set; }
        public decimal ExistenciaProd { get; set; }
        public int DescuentoProd { get; set; }
        public decimal PrecioProd { get; set; }
        public int EstadoProd { get; set; }
        public string DescripcionProd { get; set; } = null!;

    }
}
