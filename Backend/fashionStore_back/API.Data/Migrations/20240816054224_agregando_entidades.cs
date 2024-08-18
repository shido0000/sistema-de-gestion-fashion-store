using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Data.Migrations
{
    /// <inheritdoc />
    public partial class agregando_entidades : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Camareras");

            migrationBuilder.DropTable(
                name: "CausasFueraOrden");

            migrationBuilder.DropTable(
                name: "ProcedenciaAverias");

            migrationBuilder.DropTable(
                name: "RangosHabitaciones");

            migrationBuilder.DropTable(
                name: "TecnicosAverias");

            migrationBuilder.DropTable(
                name: "TiposAverias");

            migrationBuilder.DropTable(
                name: "ZonasComunes");

            migrationBuilder.CreateTable(
                name: "ConversionesPrecios",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    valorCambio = table.Column<float>(type: "real", nullable: false),
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
                name: "Ventas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    Codigo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Costo = table.Column<float>(type: "real", nullable: false),
                    PrecioUSD = table.Column<float>(type: "real", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
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
                name: "ProductosGestores",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PrecioGestor = table.Column<float>(type: "real", nullable: false),
                    ProductoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GestorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VentaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FechaCreado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreadoPor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaActualizado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ActualizadoPor = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductosGestores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductosGestores_Gestores_GestorId",
                        column: x => x.GestorId,
                        principalTable: "Gestores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductosGestores_Productos_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Productos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductosGestores_Ventas_VentaId",
                        column: x => x.VentaId,
                        principalTable: "Ventas",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "Permisos",
                keyColumn: "Id",
                keyValue: new Guid("4129cf49-cc22-46a1-9625-501855f2da8b"),
                columns: new[] { "FechaActualizado", "FechaCreado" },
                values: new object[] { new DateTime(2024, 8, 15, 23, 42, 24, 189, DateTimeKind.Local).AddTicks(1653), new DateTime(2024, 8, 15, 23, 42, 24, 189, DateTimeKind.Local).AddTicks(1653) });

            migrationBuilder.UpdateData(
                table: "Permisos",
                keyColumn: "Id",
                keyValue: new Guid("56b3924b-209b-40fb-9f31-ad75c12f4528"),
                columns: new[] { "FechaActualizado", "FechaCreado" },
                values: new object[] { new DateTime(2024, 8, 15, 23, 42, 24, 189, DateTimeKind.Local).AddTicks(1641), new DateTime(2024, 8, 15, 23, 42, 24, 189, DateTimeKind.Local).AddTicks(1641) });

            migrationBuilder.UpdateData(
                table: "Permisos",
                keyColumn: "Id",
                keyValue: new Guid("90abf232-a641-478d-8720-f0ae49e8a306"),
                columns: new[] { "FechaActualizado", "FechaCreado" },
                values: new object[] { new DateTime(2024, 8, 15, 23, 42, 24, 189, DateTimeKind.Local).AddTicks(1659), new DateTime(2024, 8, 15, 23, 42, 24, 189, DateTimeKind.Local).AddTicks(1658) });

            migrationBuilder.UpdateData(
                table: "Permisos",
                keyColumn: "Id",
                keyValue: new Guid("e36d283c-8b25-42b6-83bd-56edd953e770"),
                columns: new[] { "FechaActualizado", "FechaCreado" },
                values: new object[] { new DateTime(2024, 8, 15, 23, 42, 24, 189, DateTimeKind.Local).AddTicks(1656), new DateTime(2024, 8, 15, 23, 42, 24, 189, DateTimeKind.Local).AddTicks(1656) });

            migrationBuilder.UpdateData(
                table: "RolPermiso",
                keyColumn: "Id",
                keyValue: new Guid("4129cf49-cc22-46a1-9625-501855f2da8b"),
                columns: new[] { "FechaActualizado", "FechaCreado" },
                values: new object[] { new DateTime(2024, 8, 15, 23, 42, 24, 189, DateTimeKind.Local).AddTicks(1812), new DateTime(2024, 8, 15, 23, 42, 24, 189, DateTimeKind.Local).AddTicks(1812) });

            migrationBuilder.UpdateData(
                table: "RolPermiso",
                keyColumn: "Id",
                keyValue: new Guid("56b3924b-209b-40fb-9f31-ad75c12f4528"),
                columns: new[] { "FechaActualizado", "FechaCreado" },
                values: new object[] { new DateTime(2024, 8, 15, 23, 42, 24, 189, DateTimeKind.Local).AddTicks(1807), new DateTime(2024, 8, 15, 23, 42, 24, 189, DateTimeKind.Local).AddTicks(1806) });

            migrationBuilder.UpdateData(
                table: "RolPermiso",
                keyColumn: "Id",
                keyValue: new Guid("90abf232-a641-478d-8720-f0ae49e8a306"),
                columns: new[] { "FechaActualizado", "FechaCreado" },
                values: new object[] { new DateTime(2024, 8, 15, 23, 42, 24, 189, DateTimeKind.Local).AddTicks(1815), new DateTime(2024, 8, 15, 23, 42, 24, 189, DateTimeKind.Local).AddTicks(1815) });

            migrationBuilder.UpdateData(
                table: "RolPermiso",
                keyColumn: "Id",
                keyValue: new Guid("e36d283c-8b25-42b6-83bd-56edd953e770"),
                columns: new[] { "FechaActualizado", "FechaCreado" },
                values: new object[] { new DateTime(2024, 8, 15, 23, 42, 24, 189, DateTimeKind.Local).AddTicks(1814), new DateTime(2024, 8, 15, 23, 42, 24, 189, DateTimeKind.Local).AddTicks(1813) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("c0b7e3b3-a06e-4580-b985-bb2fc4336522"),
                columns: new[] { "FechaActualizado", "FechaCreado" },
                values: new object[] { new DateTime(2024, 8, 15, 23, 42, 24, 189, DateTimeKind.Local).AddTicks(1465), new DateTime(2024, 8, 15, 23, 42, 24, 189, DateTimeKind.Local).AddTicks(1453) });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: new Guid("42717fb8-6e3f-4c94-b6b1-a88e8718d0a6"),
                columns: new[] { "FechaActualizado", "FechaCreado" },
                values: new object[] { new DateTime(2024, 8, 15, 23, 42, 24, 189, DateTimeKind.Local).AddTicks(6355), new DateTime(2024, 8, 15, 23, 42, 24, 189, DateTimeKind.Local).AddTicks(6352) });

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
                name: "IX_Productos_EstadoProductoId",
                table: "Productos",
                column: "EstadoProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_Id",
                table: "Productos",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductosGestores_GestorId_ProductoId",
                table: "ProductosGestores",
                columns: new[] { "GestorId", "ProductoId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductosGestores_Id",
                table: "ProductosGestores",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductosGestores_ProductoId",
                table: "ProductosGestores",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductosGestores_VentaId",
                table: "ProductosGestores",
                column: "VentaId");

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
                name: "ProductosGestores");

            migrationBuilder.DropTable(
                name: "ValesDeVentas");

            migrationBuilder.DropTable(
                name: "Gestores");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "Ventas");

            migrationBuilder.DropTable(
                name: "EstadosProductos");

            migrationBuilder.CreateTable(
                name: "Camareras",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    ActualizadoPor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreadoPor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    FechaActualizado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaCreado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Supervisora = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Camareras", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CausasFueraOrden",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    ActualizadoPor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Codigo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreadoPor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaActualizado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaCreado = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CausasFueraOrden", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProcedenciaAverias",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    ActualizadoPor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreadoPor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    FechaActualizado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaCreado = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcedenciaAverias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RangosHabitaciones",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    ActualizadoPor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Codigo = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreadoPor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    FechaActualizado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaCreado = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RangosHabitaciones", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TecnicosAverias",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    ActualizadoPor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreadoPor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    FechaActualizado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaCreado = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TecnicosAverias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TiposAverias",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    ActualizadoPor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreadoPor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    FechaActualizado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaCreado = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposAverias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ZonasComunes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    ActualizadoPor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Codigo = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreadoPor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    FechaActualizado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaCreado = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZonasComunes", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Permisos",
                keyColumn: "Id",
                keyValue: new Guid("4129cf49-cc22-46a1-9625-501855f2da8b"),
                columns: new[] { "FechaActualizado", "FechaCreado" },
                values: new object[] { new DateTime(2024, 7, 19, 15, 38, 23, 184, DateTimeKind.Local).AddTicks(5208), new DateTime(2024, 7, 19, 15, 38, 23, 184, DateTimeKind.Local).AddTicks(5198) });

            migrationBuilder.UpdateData(
                table: "Permisos",
                keyColumn: "Id",
                keyValue: new Guid("56b3924b-209b-40fb-9f31-ad75c12f4528"),
                columns: new[] { "FechaActualizado", "FechaCreado" },
                values: new object[] { new DateTime(2024, 7, 19, 15, 38, 23, 184, DateTimeKind.Local).AddTicks(5184), new DateTime(2024, 7, 19, 15, 38, 23, 184, DateTimeKind.Local).AddTicks(5171) });

            migrationBuilder.UpdateData(
                table: "Permisos",
                keyColumn: "Id",
                keyValue: new Guid("90abf232-a641-478d-8720-f0ae49e8a306"),
                columns: new[] { "FechaActualizado", "FechaCreado" },
                values: new object[] { new DateTime(2024, 7, 19, 15, 38, 23, 184, DateTimeKind.Local).AddTicks(5238), new DateTime(2024, 7, 19, 15, 38, 23, 184, DateTimeKind.Local).AddTicks(5235) });

            migrationBuilder.UpdateData(
                table: "Permisos",
                keyColumn: "Id",
                keyValue: new Guid("e36d283c-8b25-42b6-83bd-56edd953e770"),
                columns: new[] { "FechaActualizado", "FechaCreado" },
                values: new object[] { new DateTime(2024, 7, 19, 15, 38, 23, 184, DateTimeKind.Local).AddTicks(5229), new DateTime(2024, 7, 19, 15, 38, 23, 184, DateTimeKind.Local).AddTicks(5227) });

            migrationBuilder.UpdateData(
                table: "RolPermiso",
                keyColumn: "Id",
                keyValue: new Guid("4129cf49-cc22-46a1-9625-501855f2da8b"),
                columns: new[] { "FechaActualizado", "FechaCreado" },
                values: new object[] { new DateTime(2024, 7, 19, 15, 38, 23, 184, DateTimeKind.Local).AddTicks(6037), new DateTime(2024, 7, 19, 15, 38, 23, 184, DateTimeKind.Local).AddTicks(6035) });

            migrationBuilder.UpdateData(
                table: "RolPermiso",
                keyColumn: "Id",
                keyValue: new Guid("56b3924b-209b-40fb-9f31-ad75c12f4528"),
                columns: new[] { "FechaActualizado", "FechaCreado" },
                values: new object[] { new DateTime(2024, 7, 19, 15, 38, 23, 184, DateTimeKind.Local).AddTicks(6019), new DateTime(2024, 7, 19, 15, 38, 23, 184, DateTimeKind.Local).AddTicks(6007) });

            migrationBuilder.UpdateData(
                table: "RolPermiso",
                keyColumn: "Id",
                keyValue: new Guid("90abf232-a641-478d-8720-f0ae49e8a306"),
                columns: new[] { "FechaActualizado", "FechaCreado" },
                values: new object[] { new DateTime(2024, 7, 19, 15, 38, 23, 184, DateTimeKind.Local).AddTicks(6069), new DateTime(2024, 7, 19, 15, 38, 23, 184, DateTimeKind.Local).AddTicks(6067) });

            migrationBuilder.UpdateData(
                table: "RolPermiso",
                keyColumn: "Id",
                keyValue: new Guid("e36d283c-8b25-42b6-83bd-56edd953e770"),
                columns: new[] { "FechaActualizado", "FechaCreado" },
                values: new object[] { new DateTime(2024, 7, 19, 15, 38, 23, 184, DateTimeKind.Local).AddTicks(6063), new DateTime(2024, 7, 19, 15, 38, 23, 184, DateTimeKind.Local).AddTicks(6041) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("c0b7e3b3-a06e-4580-b985-bb2fc4336522"),
                columns: new[] { "FechaActualizado", "FechaCreado" },
                values: new object[] { new DateTime(2024, 7, 19, 15, 38, 23, 184, DateTimeKind.Local).AddTicks(4693), new DateTime(2024, 7, 19, 15, 38, 23, 184, DateTimeKind.Local).AddTicks(4628) });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: new Guid("42717fb8-6e3f-4c94-b6b1-a88e8718d0a6"),
                columns: new[] { "FechaActualizado", "FechaCreado" },
                values: new object[] { new DateTime(2024, 7, 19, 15, 38, 23, 185, DateTimeKind.Local).AddTicks(7946), new DateTime(2024, 7, 19, 15, 38, 23, 185, DateTimeKind.Local).AddTicks(7870) });

            migrationBuilder.CreateIndex(
                name: "IX_Camareras_Id",
                table: "Camareras",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProcedenciaAverias_Id",
                table: "ProcedenciaAverias",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RangosHabitaciones_Id",
                table: "RangosHabitaciones",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TecnicosAverias_Id",
                table: "TecnicosAverias",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TiposAverias_Id",
                table: "TiposAverias",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ZonasComunes_Id",
                table: "ZonasComunes",
                column: "Id",
                unique: true);
        }
    }
}
