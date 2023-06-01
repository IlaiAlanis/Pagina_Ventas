using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Pagina_Ventas.Models.dbModels
{ /*Se hereda de identityDBContext*/
    public partial class TiendaSoftContext : IdentityDbContext<ApplicationUser, IdentityRole<int>, int>
    {
        public TiendaSoftContext()
        {
        }

        public TiendaSoftContext(DbContextOptions<TiendaSoftContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Carrito> Carritos { get; set; } = null!;
        public virtual DbSet<CategoriaProducto> CategoriaProductos { get; set; } = null!;
        public virtual DbSet<DetalleVp> DetalleVps { get; set; } = null!;
        public virtual DbSet<Estado> Estados { get; set; } = null!;
        public virtual DbSet<MarcaProducto> MarcaProductos { get; set; } = null!;
        public virtual DbSet<Municipio> Municipios { get; set; } = null!;
        public virtual DbSet<Pago> Pagos { get; set; } = null!;
        public virtual DbSet<Producto> Productos { get; set; } = null!;
        public virtual DbSet<Ventum> Venta { get; set; } = null!;

   
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);         

            modelBuilder.Entity<Carrito>(entity =>
            {
                entity.HasKey(e => new { e.IdUsuarioCarrito, e.IdProdCarrito })
                    .HasName("pk_Carrito");

                entity.HasOne(d => d.IdProdCarritoNavigation)
                    .WithMany(p => p.Carritos)
                    .HasForeignKey(d => d.IdProdCarrito)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_ProdCarr");

                entity.HasOne(d => d.IdUsuarioCarritoNavigation)
                    .WithMany(p => p.Carritos)
                    .HasForeignKey(d => d.IdUsuarioCarrito)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_UsuCarr");
            });

            modelBuilder.Entity<CategoriaProducto>(entity =>
            {
                entity.HasKey(e => e.IdCat)
                    .HasName("PK__Categori__D54686DE04C47F30");
            });

            modelBuilder.Entity<DetalleVp>(entity =>
            {
                entity.HasKey(e => new { e.IdVentaDvp, e.IdProductoDvp })
                    .HasName("pk_DetalleVP");

                entity.HasOne(d => d.IdProductoDvpNavigation)
                    .WithMany(p => p.DetalleVps)
                    .HasForeignKey(d => d.IdProductoDvp)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_ProdDVP");

                entity.HasOne(d => d.IdVentaDvpNavigation)
                    .WithMany(p => p.DetalleVps)
                    .HasForeignKey(d => d.IdVentaDvp)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_VenDVP");
            });

            modelBuilder.Entity<Estado>(entity =>
            {
                entity.HasKey(e => e.IdEstado)
                    .HasName("PK__Estado__86989FB24D3C5AA8");
            });

            modelBuilder.Entity<MarcaProducto>(entity =>
            {
                entity.HasKey(e => e.IdMarca)
                    .HasName("PK__Marca_Pr__7E43E99E0C8E87E2");
            });

            modelBuilder.Entity<Municipio>(entity =>
            {
                entity.HasKey(e => e.IdMunicipio)
                    .HasName("PK__Municipi__01C9EB99373BAFCA");

                entity.HasOne(d => d.IdEstadoNavigation)
                    .WithMany(p => p.Municipios)
                    .HasForeignKey(d => d.IdEstado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_EstMun");
            });

            modelBuilder.Entity<Pago>(entity =>
            {
                entity.HasKey(e => e.IdPagos)
                    .HasName("PK__Pagos__314B93449203B735");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.IdProd)
                    .HasName("PK__Producto__0DA34873C1FCB202");

                entity.HasOne(d => d.EstadoProdNavigation)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.EstadoProd)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_SteProd");

                entity.HasOne(d => d.IdCatProdNavigation)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.IdCatProd)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_TipProd");

                entity.HasOne(d => d.MarcaProdNavigation)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.MarcaProd)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_MarProd");
            });

            
            modelBuilder.Entity<Ventum>(entity =>
            {
                entity.HasKey(e => e.IdVenta)
                    .HasName("PK__Venta__459533BF52290940");

                entity.HasOne(d => d.IdPagosNavigation)
                    .WithMany(p => p.Venta)
                    .HasForeignKey(d => d.IdPagos)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_PagVen");

                entity.HasOne(d => d.IdUsuarioVentaNavigation)
                    .WithMany(p => p.Venta)
                    .HasForeignKey(d => d.IdUsuarioVenta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_ClteVen");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
