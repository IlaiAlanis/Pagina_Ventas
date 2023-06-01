using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Pagina_Ventas.Models.dbModels
{
    public class ApplicationUser : IdentityUser<int>
    {

        public ApplicationUser()
        {
            Venta = new HashSet<Ventum>();
        }

        
        [Column("apellido_usuario")]
        [StringLength(60)]
        [Unicode(false)]
        public string ApellidoUsuario { get; set; } = null!;
        [Column("userfecha_nac_usuario", TypeName = "date")]
        public DateTime UserfechaNacUsuario { get; set; }
        [Column("dir_usuario")]
        [StringLength(80)]
        [Unicode(false)]
        public string DirUsuario { get; set; } = null!;
        [Column("num_ext_usuario")]
        public int NumExtUsuario { get; set; }
        [Column("id_est_usuario")]
        public int IdEstUsuario { get; set; }
        [Column("id_mun_usuario")]
        public int IdMunUsuario { get; set; }
        [Column("id_cargo")]
        public int IdCargo { get; set; }
        [ForeignKey("IdCargo")]
        [InverseProperty("ApplicationUser")]
        public virtual Cargo IdCargoNavigation { get; set; } = null!;
        [ForeignKey("IdEstUsuario")]
        [InverseProperty("ApplicationUser")]
        public virtual Estado IdEstUsuarioNavigation { get; set; } = null!;
        [ForeignKey("IdMunUsuario")]
        [InverseProperty("ApplicationUser")]
        public virtual Municipio IdMunUsuarioNavigation { get; set; } = null!;
        [InverseProperty("IdUsuarioVentaNavigation")]
        public virtual ICollection<Ventum> Venta { get; set; }
    
    }
}
