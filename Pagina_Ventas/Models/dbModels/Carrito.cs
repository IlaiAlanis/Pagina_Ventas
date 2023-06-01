using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Pagina_Ventas.Models.dbModels
{
    [Table("Carrito")]
    public partial class Carrito
    {
        [Key]
        [Column("id_usuario_carrito")]
        public int IdUsuarioCarrito { get; set; }
        [Key]
        [Column("id_prod_carrito")]
        public int IdProdCarrito { get; set; }
        [Column("cantidad_carrito")]
        public int? CantidadCarrito { get; set; }

        [ForeignKey("IdProdCarrito")]
        [InverseProperty("Carritos")]
        public virtual Producto IdProdCarritoNavigation { get; set; } = null!;
        [ForeignKey("IdUsuarioCarrito")]
        [InverseProperty("Carritos")]
        public virtual Pago IdUsuarioCarritoNavigation { get; set; } = null!;
    }
}
