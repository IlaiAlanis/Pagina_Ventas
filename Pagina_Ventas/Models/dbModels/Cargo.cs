using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Pagina_Ventas.Models.dbModels
{
    [Table("Cargo")]
    public partial class Cargo
    {
        public Cargo()
        {
            ApplicationUser = new HashSet<ApplicationUser>();
        }

        [Key]
        [Column("id_cargo")]
        public int IdCargo { get; set; }
        [Column("nombre_cargo")]
        [StringLength(15)]
        [Unicode(false)]
        public string NombreCargo { get; set; } = null!;
        [Column("descripcion_cargo")]
        [StringLength(100)]
        [Unicode(false)]
        public string DescripcionCargo { get; set; } = null!;
        [Column("salario_cargo")]
        public int SalarioCargo { get; set; }

        [InverseProperty("IdCargoNavigation")]
        public virtual ICollection<ApplicationUser> ApplicationUser { get; set; }
    }
}
