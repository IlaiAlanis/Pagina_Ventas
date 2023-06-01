using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Pagina_Ventas.Models.dbModels
{
    [Table("Producto")]
    public partial class Producto
    {
        public Producto()
        {
            Carritos = new HashSet<Carrito>();
            DetalleVps = new HashSet<DetalleVp>();
        }

        [Key]
        [Column("id_prod")]
        public int IdProd { get; set; }
        [Column("id_cat_prod")]
        public int IdCatProd { get; set; }
        [Column("marca_prod")]
        public int MarcaProd { get; set; }
        [Column("costo_prod", TypeName = "decimal(10, 2)")]
        public decimal CostoProd { get; set; }
        [Column("existencia_prod", TypeName = "decimal(10, 2)")]
        public decimal ExistenciaProd { get; set; }
        [Column("descuento_prod")]
        public int DescuentoProd { get; set; }
        [Column("precio_prod", TypeName = "decimal(10, 2)")]
        public decimal PrecioProd { get; set; }
        [Column("estado_prod")]
        public int EstadoProd { get; set; }
        [Column("descripcion_prod")]
        [StringLength(1)]
        [Unicode(false)]
        public string DescripcionProd { get; set; } = null!;

        [ForeignKey("EstadoProd")]
        [InverseProperty("Productos")]
        public virtual Estado EstadoProdNavigation { get; set; } = null!;
        [ForeignKey("IdCatProd")]
        [InverseProperty("Productos")]
        public virtual CategoriaProducto IdCatProdNavigation { get; set; } = null!;
        [ForeignKey("MarcaProd")]
        [InverseProperty("Productos")]
        public virtual MarcaProducto MarcaProdNavigation { get; set; } = null!;
        [InverseProperty("IdProdCarritoNavigation")]
        public virtual ICollection<Carrito> Carritos { get; set; }
        [InverseProperty("IdProductoDvpNavigation")]
        public virtual ICollection<DetalleVp> DetalleVps { get; set; }
    }
}
