using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Pagina_Ventas.Models.dbModels
{
    [Table("Municipio")]
    public partial class Municipio
    {
        public Municipio()
        {
            ApplicationUser = new HashSet<ApplicationUser>();
        }

        [Key]
        [Column("id_municipio")]
        public int IdMunicipio { get; set; }
        [Column("nombre_municipio")]
        [StringLength(40)]
        [Unicode(false)]
        public string NombreMunicipio { get; set; } = null!;
        [Column("id_estado")]
        public int IdEstado { get; set; }

        [ForeignKey("IdEstado")]
        [InverseProperty("Municipios")]
        public virtual Estado IdEstadoNavigation { get; set; } = null!;
        [InverseProperty("IdMunUsuarioNavigation")]
        public virtual ICollection<ApplicationUser> ApplicationUser { get; set; }
    }
}
