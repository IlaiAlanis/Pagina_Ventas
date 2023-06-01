using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Pagina_Ventas.Models.dbModels
{
    public partial class Pago
    {
        public Pago()
        {
            Carritos = new HashSet<Carrito>();
            Venta = new HashSet<Ventum>();
        }

        [Key]
        [Column("id_pagos")]
        public int IdPagos { get; set; }
        [Column("metodosPago_pagos")]
        [StringLength(50)]
        [Unicode(false)]
        public string? MetodosPagoPagos { get; set; }
        [Column("descripcion_pagos")]
        [StringLength(50)]
        [Unicode(false)]
        public string? DescripcionPagos { get; set; }

        [InverseProperty("IdUsuarioCarritoNavigation")]
        public virtual ICollection<Carrito> Carritos { get; set; }
        [InverseProperty("IdPagosNavigation")]
        public virtual ICollection<Ventum> Venta { get; set; }
    }
}
