using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API.Data.Migrations
{
    /// <inheritdoc />
    public partial class entidades : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ConversionesPrecios",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ValorCambio = table.Column<float>(type: "real", nullable: false),
                    FechaCreado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreadoPor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaActualizado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ActualizadoPor = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConversionesPrecios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EstadosProductos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaCreado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreadoPor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaActualizado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ActualizadoPor = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadosProductos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Gestores",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Apellidos = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    FechaCreado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreadoPor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaActualizado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ActualizadoPor = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gestores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Permisos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    FechaCreado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreadoPor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaActualizado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ActualizadoPor = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permisos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FechaCreado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreadoPor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaActualizado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ActualizadoPor = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Trazas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TablaBD = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FechaCreado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreadoPor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaActualizado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ActualizadoPor = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trazas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ventas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Codigo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaCreado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreadoPor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaActualizado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ActualizadoPor = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ventas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Codigo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Costo = table.Column<float>(type: "real", nullable: false),
                    PrecioUSD = table.Column<float>(type: "real", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    CantidadStock = table.Column<int>(type: "int", nullable: false),
                    EstadoProductoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FechaCreado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreadoPor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaActualizado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ActualizadoPor = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Productos_EstadosProductos_EstadoProductoId",
                        column: x => x.EstadoProductoId,
                        principalTable: "EstadosProductos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RolPermiso",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RolId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PermisoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FechaCreado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreadoPor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaActualizado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ActualizadoPor = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolPermiso", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RolPermiso_Permisos_PermisoId",
                        column: x => x.PermisoId,
                        principalTable: "Permisos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RolPermiso_Roles_RolId",
                        column: x => x.RolId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RolId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Apellidos = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Contrasenna = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    DebeCambiarContrasenna = table.Column<bool>(type: "bit", nullable: false),
                    FechaCreado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreadoPor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaActualizado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ActualizadoPor = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuarios_Roles_RolId",
                        column: x => x.RolId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PagosGestores",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VentaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PagoTotal = table.Column<float>(type: "real", nullable: false),
                    Pagado = table.Column<bool>(type: "bit", nullable: false),
                    FechaCreado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreadoPor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaActualizado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ActualizadoPor = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PagosGestores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PagosGestores_Ventas_VentaId",
                        column: x => x.VentaId,
                        principalTable: "Ventas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ValesDeVentas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Domicilio = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    VentaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FechaCreado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreadoPor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaActualizado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ActualizadoPor = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ValesDeVentas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ValesDeVentas_Ventas_VentaId",
                        column: x => x.VentaId,
                        principalTable: "Ventas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductosVendidos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PrecioGestor = table.Column<float>(type: "real", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    ProductoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GestorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VentaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FechaCreado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreadoPor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaActualizado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ActualizadoPor = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductosVendidos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductosVendidos_Gestores_GestorId",
                        column: x => x.GestorId,
                        principalTable: "Gestores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductosVendidos_Productos_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Productos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductosVendidos_Ventas_VentaId",
                        column: x => x.VentaId,
                        principalTable: "Ventas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "EstadosProductos",
                columns: new[] { "Id", "ActualizadoPor", "CreadoPor", "Descripcion", "FechaActualizado", "FechaCreado" },
                values: new object[,]
                {
                    { new Guid("1c8fcfe3-5718-4a36-bd3a-681241488a6b"), "", "", "Disponible", new DateTime(2024, 10, 5, 14, 29, 28, 694, DateTimeKind.Local).AddTicks(3641), new DateTime(2024, 10, 5, 14, 29, 28, 694, DateTimeKind.Local).AddTicks(3638) },
                    { new Guid("37760da6-b5de-4a1d-b5b7-cde6a462e192"), "", "", "Agotado", new DateTime(2024, 10, 5, 14, 29, 28, 694, DateTimeKind.Local).AddTicks(3648), new DateTime(2024, 10, 5, 14, 29, 28, 694, DateTimeKind.Local).AddTicks(3647) },
                    { new Guid("4beeeb16-931b-4f2a-9355-fa19cf76ed54"), "", "", "Reservado", new DateTime(2024, 10, 5, 14, 29, 28, 694, DateTimeKind.Local).AddTicks(3651), new DateTime(2024, 10, 5, 14, 29, 28, 694, DateTimeKind.Local).AddTicks(3650) }
                });

            migrationBuilder.InsertData(
                table: "Permisos",
                columns: new[] { "Id", "ActualizadoPor", "CreadoPor", "Descripcion", "FechaActualizado", "FechaCreado", "Nombre" },
                values: new object[,]
                {
                    { new Guid("4129cf49-cc22-46a1-9625-501855f2da8b"), "", "", "Permite ver, crear, modificar y eliminar usuarios en el sistema.", new DateTime(2024, 10, 5, 14, 29, 28, 693, DateTimeKind.Local).AddTicks(2767), new DateTime(2024, 10, 5, 14, 29, 28, 693, DateTimeKind.Local).AddTicks(2766), "Gestionar usuarios" },
                    { new Guid("56b3924b-209b-40fb-9f31-ad75c12f4528"), "", "", "Permite ver los usuarios existentes en el sistema y sus datos.", new DateTime(2024, 10, 5, 14, 29, 28, 693, DateTimeKind.Local).AddTicks(2762), new DateTime(2024, 10, 5, 14, 29, 28, 693, DateTimeKind.Local).AddTicks(2758), "Listar usuarios" },
                    { new Guid("90abf232-a641-478d-8720-f0ae49e8a306"), "", "", "Permite ver, crear, modificar y eliminar roles en el sistema.", new DateTime(2024, 10, 5, 14, 29, 28, 693, DateTimeKind.Local).AddTicks(2772), new DateTime(2024, 10, 5, 14, 29, 28, 693, DateTimeKind.Local).AddTicks(2772), "Gestionar rol" },
                    { new Guid("e36d283c-8b25-42b6-83bd-56edd953e770"), "", "", "Permite ver los roles existentes en el sistema y sus datos.", new DateTime(2024, 10, 5, 14, 29, 28, 693, DateTimeKind.Local).AddTicks(2769), new DateTime(2024, 10, 5, 14, 29, 28, 693, DateTimeKind.Local).AddTicks(2769), "Listar roles" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ActualizadoPor", "CreadoPor", "FechaActualizado", "FechaCreado", "Nombre" },
                values: new object[,]
                {
                    { new Guid("c0b7e3b3-a06e-4580-b985-bb2fc4336522"), "", "", new DateTime(2024, 10, 5, 14, 29, 28, 693, DateTimeKind.Local).AddTicks(2683), new DateTime(2024, 10, 5, 14, 29, 28, 693, DateTimeKind.Local).AddTicks(2668), "Administrador" },
                    { new Guid("c0b7e3b3-a06e-4580-b985-bb2fc4336523"), "", "", new DateTime(2024, 10, 5, 14, 29, 28, 693, DateTimeKind.Local).AddTicks(2740), new DateTime(2024, 10, 5, 14, 29, 28, 693, DateTimeKind.Local).AddTicks(2740), "Vendedor" }
                });

            migrationBuilder.InsertData(
                table: "RolPermiso",
                columns: new[] { "Id", "ActualizadoPor", "CreadoPor", "FechaActualizado", "FechaCreado", "PermisoId", "RolId" },
                values: new object[,]
                {
                    { new Guid("4129cf49-cc22-46a1-9625-501855f2da8b"), "", "", new DateTime(2024, 10, 5, 14, 29, 28, 693, DateTimeKind.Local).AddTicks(2953), new DateTime(2024, 10, 5, 14, 29, 28, 693, DateTimeKind.Local).AddTicks(2953), new Guid("4129cf49-cc22-46a1-9625-501855f2da8b"), new Guid("c0b7e3b3-a06e-4580-b985-bb2fc4336522") },
                    { new Guid("56b3924b-209b-40fb-9f31-ad75c12f4528"), "", "", new DateTime(2024, 10, 5, 14, 29, 28, 693, DateTimeKind.Local).AddTicks(2948), new DateTime(2024, 10, 5, 14, 29, 28, 693, DateTimeKind.Local).AddTicks(2947), new Guid("56b3924b-209b-40fb-9f31-ad75c12f4528"), new Guid("c0b7e3b3-a06e-4580-b985-bb2fc4336522") },
                    { new Guid("90abf232-a641-478d-8720-f0ae49e8a306"), "", "", new DateTime(2024, 10, 5, 14, 29, 28, 693, DateTimeKind.Local).AddTicks(2957), new DateTime(2024, 10, 5, 14, 29, 28, 693, DateTimeKind.Local).AddTicks(2956), new Guid("90abf232-a641-478d-8720-f0ae49e8a306"), new Guid("c0b7e3b3-a06e-4580-b985-bb2fc4336522") },
                    { new Guid("e36d283c-8b25-42b6-83bd-56edd953e770"), "", "", new DateTime(2024, 10, 5, 14, 29, 28, 693, DateTimeKind.Local).AddTicks(2955), new DateTime(2024, 10, 5, 14, 29, 28, 693, DateTimeKind.Local).AddTicks(2955), new Guid("e36d283c-8b25-42b6-83bd-56edd953e770"), new Guid("c0b7e3b3-a06e-4580-b985-bb2fc4336522") }
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "ActualizadoPor", "Apellidos", "Contrasenna", "CreadoPor", "DebeCambiarContrasenna", "FechaActualizado", "FechaCreado", "Nombre", "RolId", "Username" },
                values: new object[] { new Guid("42717fb8-6e3f-4c94-b6b1-a88e8718d0a6"), "", "1", "$2a$10$EixZaYVK1fsbw1Zfbx3OXePaWxn96p36Zf4d0xF4f5f5f5f5f5f5f", "", false, new DateTime(2024, 10, 5, 14, 29, 28, 693, DateTimeKind.Local).AddTicks(9350), new DateTime(2024, 10, 5, 14, 29, 28, 693, DateTimeKind.Local).AddTicks(9346), "1", new Guid("c0b7e3b3-a06e-4580-b985-bb2fc4336522"), "1" });

            migrationBuilder.CreateIndex(
                name: "IX_ConversionesPrecios_Descripcion",
                table: "ConversionesPrecios",
                column: "Descripcion",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ConversionesPrecios_Id",
                table: "ConversionesPrecios",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EstadosProductos_Id",
                table: "EstadosProductos",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Gestores_Id",
                table: "Gestores",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Gestores_Nombre_Apellidos",
                table: "Gestores",
                columns: new[] { "Nombre", "Apellidos" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PagosGestores_Id",
                table: "PagosGestores",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PagosGestores_VentaId",
                table: "PagosGestores",
                column: "VentaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Permisos_Id",
                table: "Permisos",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Productos_Codigo",
                table: "Productos",
                column: "Codigo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Productos_EstadoProductoId",
                table: "Productos",
                column: "EstadoProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_Id",
                table: "Productos",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductosVendidos_GestorId",
                table: "ProductosVendidos",
                column: "GestorId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductosVendidos_Id",
                table: "ProductosVendidos",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductosVendidos_ProductoId",
                table: "ProductosVendidos",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductosVendidos_VentaId_ProductoId_GestorId",
                table: "ProductosVendidos",
                columns: new[] { "VentaId", "ProductoId", "GestorId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Roles_Id",
                table: "Roles",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RolPermiso_Id",
                table: "RolPermiso",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RolPermiso_PermisoId",
                table: "RolPermiso",
                column: "PermisoId");

            migrationBuilder.CreateIndex(
                name: "IX_RolPermiso_RolId_PermisoId",
                table: "RolPermiso",
                columns: new[] { "RolId", "PermisoId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Trazas_Id",
                table: "Trazas",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_Id",
                table: "Usuarios",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_Nombre_Apellidos",
                table: "Usuarios",
                columns: new[] { "Nombre", "Apellidos" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_RolId",
                table: "Usuarios",
                column: "RolId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_Username",
                table: "Usuarios",
                column: "Username",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ValesDeVentas_Id",
                table: "ValesDeVentas",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ValesDeVentas_VentaId",
                table: "ValesDeVentas",
                column: "VentaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ventas_Codigo",
                table: "Ventas",
                column: "Codigo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ventas_Id",
                table: "Ventas",
                column: "Id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConversionesPrecios");

            migrationBuilder.DropTable(
                name: "PagosGestores");

            migrationBuilder.DropTable(
                name: "ProductosVendidos");

            migrationBuilder.DropTable(
                name: "RolPermiso");

            migrationBuilder.DropTable(
                name: "Trazas");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "ValesDeVentas");

            migrationBuilder.DropTable(
                name: "Gestores");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "Permisos");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Ventas");

            migrationBuilder.DropTable(
                name: "EstadosProductos");
        }
    }
}
