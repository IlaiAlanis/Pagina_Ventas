using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Pagina_Ventas.Models.dbModels
{
    [Table("DetalleVP")]
    public partial class DetalleVp
    {
        [Key]
        [Column("id_venta_DVP")]
        public int IdVentaDvp { get; set; }
        [Key]
        [Column("id_producto_DVP")]
        public int IdProductoDvp { get; set; }
        [Column("precio_DVP", TypeName = "decimal(10, 2)")]
        public decimal PrecioDvp { get; set; }
        [Column("cantidad_DVP")]
        public int CantidadDvp { get; set; }

        [ForeignKey("IdProductoDvp")]
        [InverseProperty("DetalleVps")]
        public virtual Producto IdProductoDvpNavigation { get; set; } = null!;
        [ForeignKey("IdVentaDvp")]
        [InverseProperty("DetalleVps")]
        public virtual Ventum IdVentaDvpNavigation { get; set; } = null!;
    }
}
