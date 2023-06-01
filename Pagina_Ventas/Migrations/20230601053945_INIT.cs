using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pagina_Ventas.Migrations
{
    public partial class INIT : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cargo",
                columns: table => new
                {
                    id_cargo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre_cargo = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false),
                    descripcion_cargo = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    salario_cargo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cargo", x => x.id_cargo);
                });

            migrationBuilder.CreateTable(
                name: "Categoria_Producto",
                columns: table => new
                {
                    id_cat = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre_cat = table.Column<string>(type: "varchar(40)", unicode: false, maxLength: 40, nullable: false),
                    descripcion_cat = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Categori__D54686DE04C47F30", x => x.id_cat);
                });

            migrationBuilder.CreateTable(
                name: "Estado",
                columns: table => new
                {
                    id_estado = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre_estado = table.Column<string>(type: "varchar(40)", unicode: false, maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Estado__86989FB24D3C5AA8", x => x.id_estado);
                });

            migrationBuilder.CreateTable(
                name: "Marca_Producto",
                columns: table => new
                {
                    id_marca = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre_mar = table.Column<string>(type: "varchar(40)", unicode: false, maxLength: 40, nullable: false),
                    descripcion_mar = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Marca_Pr__7E43E99E0C8E87E2", x => x.id_marca);
                });

            migrationBuilder.CreateTable(
                name: "Pagos",
                columns: table => new
                {
                    id_pagos = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    metodosPago_pagos = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    descripcion_pagos = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Pagos__314B93449203B735", x => x.id_pagos);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Municipio",
                columns: table => new
                {
                    id_municipio = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre_municipio = table.Column<string>(type: "varchar(40)", unicode: false, maxLength: 40, nullable: false),
                    id_estado = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Municipi__01C9EB99373BAFCA", x => x.id_municipio);
                    table.ForeignKey(
                        name: "fk_EstMun",
                        column: x => x.id_estado,
                        principalTable: "Estado",
                        principalColumn: "id_estado");
                });

            migrationBuilder.CreateTable(
                name: "Producto",
                columns: table => new
                {
                    id_prod = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_cat_prod = table.Column<int>(type: "int", nullable: false),
                    marca_prod = table.Column<int>(type: "int", nullable: false),
                    costo_prod = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    existencia_prod = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    descuento_prod = table.Column<int>(type: "int", nullable: false),
                    precio_prod = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    estado_prod = table.Column<int>(type: "int", nullable: false),
                    descripcion_prod = table.Column<string>(type: "varchar(1)", unicode: false, maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Producto__0DA34873C1FCB202", x => x.id_prod);
                    table.ForeignKey(
                        name: "fk_MarProd",
                        column: x => x.marca_prod,
                        principalTable: "Marca_Producto",
                        principalColumn: "id_marca");
                    table.ForeignKey(
                        name: "fk_SteProd",
                        column: x => x.estado_prod,
                        principalTable: "Estado",
                        principalColumn: "id_estado");
                    table.ForeignKey(
                        name: "fk_TipProd",
                        column: x => x.id_cat_prod,
                        principalTable: "Categoria_Producto",
                        principalColumn: "id_cat");
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    apellido_usuario = table.Column<string>(type: "varchar(60)", unicode: false, maxLength: 60, nullable: false),
                    userfecha_nac_usuario = table.Column<DateTime>(type: "date", nullable: false),
                    dir_usuario = table.Column<string>(type: "varchar(80)", unicode: false, maxLength: 80, nullable: false),
                    num_ext_usuario = table.Column<int>(type: "int", nullable: false),
                    id_est_usuario = table.Column<int>(type: "int", nullable: false),
                    id_mun_usuario = table.Column<int>(type: "int", nullable: false),
                    id_cargo = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Cargo_id_cargo",
                        column: x => x.id_cargo,
                        principalTable: "Cargo",
                        principalColumn: "id_cargo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Estado_id_est_usuario",
                        column: x => x.id_est_usuario,
                        principalTable: "Estado",
                        principalColumn: "id_estado",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Municipio_id_mun_usuario",
                        column: x => x.id_mun_usuario,
                        principalTable: "Municipio",
                        principalColumn: "id_municipio",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Carrito",
                columns: table => new
                {
                    id_usuario_carrito = table.Column<int>(type: "int", nullable: false),
                    id_prod_carrito = table.Column<int>(type: "int", nullable: false),
                    cantidad_carrito = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_Carrito", x => new { x.id_usuario_carrito, x.id_prod_carrito });
                    table.ForeignKey(
                        name: "fk_ProdCarr",
                        column: x => x.id_prod_carrito,
                        principalTable: "Producto",
                        principalColumn: "id_prod");
                    table.ForeignKey(
                        name: "fk_UsuCarr",
                        column: x => x.id_usuario_carrito,
                        principalTable: "Pagos",
                        principalColumn: "id_pagos");
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Venta",
                columns: table => new
                {
                    id_venta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_usuario_venta = table.Column<int>(type: "int", nullable: false),
                    fecha_venta = table.Column<DateTime>(type: "date", nullable: false),
                    hora_venta = table.Column<TimeSpan>(type: "time", nullable: false),
                    id_pagos = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Venta__459533BF52290940", x => x.id_venta);
                    table.ForeignKey(
                        name: "fk_ClteVen",
                        column: x => x.id_usuario_venta,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "fk_PagVen",
                        column: x => x.id_pagos,
                        principalTable: "Pagos",
                        principalColumn: "id_pagos");
                });

            migrationBuilder.CreateTable(
                name: "DetalleVP",
                columns: table => new
                {
                    id_venta_DVP = table.Column<int>(type: "int", nullable: false),
                    id_producto_DVP = table.Column<int>(type: "int", nullable: false),
                    precio_DVP = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    cantidad_DVP = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_DetalleVP", x => new { x.id_venta_DVP, x.id_producto_DVP });
                    table.ForeignKey(
                        name: "fk_ProdDVP",
                        column: x => x.id_producto_DVP,
                        principalTable: "Producto",
                        principalColumn: "id_prod");
                    table.ForeignKey(
                        name: "fk_VenDVP",
                        column: x => x.id_venta_DVP,
                        principalTable: "Venta",
                        principalColumn: "id_venta");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_id_cargo",
                table: "AspNetUsers",
                column: "id_cargo");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_id_est_usuario",
                table: "AspNetUsers",
                column: "id_est_usuario");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_id_mun_usuario",
                table: "AspNetUsers",
                column: "id_mun_usuario");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Carrito_id_prod_carrito",
                table: "Carrito",
                column: "id_prod_carrito");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleVP_id_producto_DVP",
                table: "DetalleVP",
                column: "id_producto_DVP");

            migrationBuilder.CreateIndex(
                name: "IX_Municipio_id_estado",
                table: "Municipio",
                column: "id_estado");

            migrationBuilder.CreateIndex(
                name: "IX_Producto_estado_prod",
                table: "Producto",
                column: "estado_prod");

            migrationBuilder.CreateIndex(
                name: "IX_Producto_id_cat_prod",
                table: "Producto",
                column: "id_cat_prod");

            migrationBuilder.CreateIndex(
                name: "IX_Producto_marca_prod",
                table: "Producto",
                column: "marca_prod");

            migrationBuilder.CreateIndex(
                name: "IX_Venta_id_pagos",
                table: "Venta",
                column: "id_pagos");

            migrationBuilder.CreateIndex(
                name: "IX_Venta_id_usuario_venta",
                table: "Venta",
                column: "id_usuario_venta");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Carrito");

            migrationBuilder.DropTable(
                name: "DetalleVP");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Producto");

            migrationBuilder.DropTable(
                name: "Venta");

            migrationBuilder.DropTable(
                name: "Marca_Producto");

            migrationBuilder.DropTable(
                name: "Categoria_Producto");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Pagos");

            migrationBuilder.DropTable(
                name: "Cargo");

            migrationBuilder.DropTable(
                name: "Municipio");

            migrationBuilder.DropTable(
                name: "Estado");
        }
    }
}
