using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Pagina_Ventas.Models.dbModels
{
    [Table("Estado")]
    public partial class Estado
    {
        public Estado()
        {
            Municipios = new HashSet<Municipio>();
            Productos = new HashSet<Producto>();
            ApplicationUser = new HashSet<ApplicationUser>();
        }

        [Key]
        [Column("id_estado")]
        public int IdEstado { get; set; }
        [Column("nombre_estado")]
        [StringLength(40)]
        [Unicode(false)]
        public string NombreEstado { get; set; } = null!;

        [InverseProperty("IdEstadoNavigation")]
        public virtual ICollection<Municipio> Municipios { get; set; }
        [InverseProperty("EstadoProdNavigation")]
        public virtual ICollection<Producto> Productos { get; set; }
        [InverseProperty("IdEstUsuarioNavigation")]
        public virtual ICollection<ApplicationUser> ApplicationUser { get; set; }
    }
}
