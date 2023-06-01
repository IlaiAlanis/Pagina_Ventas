using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Pagina_Ventas.Models.dbModels
{
    [Table("Marca_Producto")]
    public partial class MarcaProducto
    {
        public MarcaProducto()
        {
            Productos = new HashSet<Producto>();
        }

        [Key]
        [Column("id_marca")]
        public int IdMarca { get; set; }
        [Column("nombre_mar")]
        [StringLength(40)]
        [Unicode(false)]
        public string NombreMar { get; set; } = null!;
        [Column("descripcion_mar")]
        [StringLength(255)]
        [Unicode(false)]
        public string DescripcionMar { get; set; } = null!;
        /*[Column("imagen_mar")]
        [StringLength(255)]
        [Unicode(false)]
        public string ImagenMar { get; set; } = null!;*/
        [InverseProperty("MarcaProdNavigation")]
        public virtual ICollection<Producto> Productos { get; set; }
    }
}
