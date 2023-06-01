using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Pagina_Ventas.Models.dbModels
{
    public partial class Ventum
    {
        public Ventum()
        {
            DetalleVps = new HashSet<DetalleVp>();
        }

        [Key]
        [Column("id_venta")]
        public int IdVenta { get; set; }
        [Column("id_usuario_venta")]
        public int IdUsuarioVenta { get; set; }
        [Column("fecha_venta", TypeName = "date")]
        public DateTime FechaVenta { get; set; }
        [Column("hora_venta")]
        public TimeSpan HoraVenta { get; set; }
        [Column("id_pagos")]
        public int IdPagos { get; set; }

        [ForeignKey("IdPagos")]
        [InverseProperty("Venta")]
        public virtual Pago IdPagosNavigation { get; set; } = null!;
        [ForeignKey("IdUsuarioVenta")]
        [InverseProperty("Venta")]
        public virtual ApplicationUser IdUsuarioVentaNavigation { get; set; } = null!;
        [InverseProperty("IdVentaDvpNavigation")]
        public virtual ICollection<DetalleVp> DetalleVps { get; set; }
    }
}
