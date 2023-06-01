using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Pagina_Ventas.Models.dbModels
{
    [Table("Categoria_Producto")]
    public partial class CategoriaProducto
    {
        public CategoriaProducto()
        {
            Productos = new HashSet<Producto>();
        }

        [Key]
        [Column("id_cat")]
        public int IdCat { get; set; }
        [Column("nombre_cat")]
        [StringLength(40)]
        [Unicode(false)]
        public string NombreCat { get; set; } = null!;
        [Column("descripcion_cat")]
        [StringLength(255)]
        [Unicode(false)]
        public string DescripcionCat { get; set; } = null!;

        [InverseProperty("IdCatProdNavigation")]
        public virtual ICollection<Producto> Productos { get; set; }
    }
}
