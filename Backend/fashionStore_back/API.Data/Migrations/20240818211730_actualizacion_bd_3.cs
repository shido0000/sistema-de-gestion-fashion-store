using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Data.Migrations
{
    /// <inheritdoc />
    public partial class actualizacion_bd_3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductosGestores");

            migrationBuilder.AlterColumn<string>(
                name: "Codigo",
                table: "Productos",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "ProductosVentas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PrecioGestor = table.Column<float>(type: "real", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    ProductoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VentaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FechaCreado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreadoPor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaActualizado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ActualizadoPor = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductosVentas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductosVentas_Productos_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Productos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductosVentas_Ventas_VentaId",
                        column: x => x.VentaId,
                        principalTable: "Ventas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "EstadosProductos",
                keyColumn: "Id",
                keyValue: new Guid("1c8fcfe3-5718-4a36-bd3a-681241488a6b"),
                columns: new[] { "FechaActualizado", "FechaCreado" },
                values: new object[] { new DateTime(2024, 8, 18, 15, 17, 29, 881, DateTimeKind.Local).AddTicks(9476), new DateTime(2024, 8, 18, 15, 17, 29, 881, DateTimeKind.Local).AddTicks(9473) });

            migrationBuilder.UpdateData(
                table: "EstadosProductos",
                keyColumn: "Id",
                keyValue: new Guid("37760da6-b5de-4a1d-b5b7-cde6a462e192"),
                columns: new[] { "FechaActualizado", "FechaCreado" },
                values: new object[] { new DateTime(2024, 8, 18, 15, 17, 29, 881, DateTimeKind.Local).AddTicks(9483), new DateTime(2024, 8, 18, 15, 17, 29, 881, DateTimeKind.Local).AddTicks(9483) });

            migrationBuilder.UpdateData(
                table: "EstadosProductos",
                keyColumn: "Id",
                keyValue: new Guid("4beeeb16-931b-4f2a-9355-fa19cf76ed54"),
                columns: new[] { "FechaActualizado", "FechaCreado" },
                values: new object[] { new DateTime(2024, 8, 18, 15, 17, 29, 881, DateTimeKind.Local).AddTicks(9485), new DateTime(2024, 8, 18, 15, 17, 29, 881, DateTimeKind.Local).AddTicks(9485) });

            migrationBuilder.UpdateData(
                table: "Permisos",
                keyColumn: "Id",
                keyValue: new Guid("4129cf49-cc22-46a1-9625-501855f2da8b"),
                columns: new[] { "FechaActualizado", "FechaCreado" },
                values: new object[] { new DateTime(2024, 8, 18, 15, 17, 29, 881, DateTimeKind.Local).AddTicks(1046), new DateTime(2024, 8, 18, 15, 17, 29, 881, DateTimeKind.Local).AddTicks(1045) });

            migrationBuilder.UpdateData(
                table: "Permisos",
                keyColumn: "Id",
                keyValue: new Guid("56b3924b-209b-40fb-9f31-ad75c12f4528"),
                columns: new[] { "FechaActualizado", "FechaCreado" },
                values: new object[] { new DateTime(2024, 8, 18, 15, 17, 29, 881, DateTimeKind.Local).AddTicks(1034), new DateTime(2024, 8, 18, 15, 17, 29, 881, DateTimeKind.Local).AddTicks(1033) });

            migrationBuilder.UpdateData(
                table: "Permisos",
                keyColumn: "Id",
                keyValue: new Guid("90abf232-a641-478d-8720-f0ae49e8a306"),
                columns: new[] { "FechaActualizado", "FechaCreado" },
                values: new object[] { new DateTime(2024, 8, 18, 15, 17, 29, 881, DateTimeKind.Local).AddTicks(1050), new DateTime(2024, 8, 18, 15, 17, 29, 881, DateTimeKind.Local).AddTicks(1049) });

            migrationBuilder.UpdateData(
                table: "Permisos",
                keyColumn: "Id",
                keyValue: new Guid("e36d283c-8b25-42b6-83bd-56edd953e770"),
                columns: new[] { "FechaActualizado", "FechaCreado" },
                values: new object[] { new DateTime(2024, 8, 18, 15, 17, 29, 881, DateTimeKind.Local).AddTicks(1048), new DateTime(2024, 8, 18, 15, 17, 29, 881, DateTimeKind.Local).AddTicks(1047) });

            migrationBuilder.UpdateData(
                table: "RolPermiso",
                keyColumn: "Id",
                keyValue: new Guid("4129cf49-cc22-46a1-9625-501855f2da8b"),
                columns: new[] { "FechaActualizado", "FechaCreado" },
                values: new object[] { new DateTime(2024, 8, 18, 15, 17, 29, 881, DateTimeKind.Local).AddTicks(1230), new DateTime(2024, 8, 18, 15, 17, 29, 881, DateTimeKind.Local).AddTicks(1230) });

            migrationBuilder.UpdateData(
                table: "RolPermiso",
                keyColumn: "Id",
                keyValue: new Guid("56b3924b-209b-40fb-9f31-ad75c12f4528"),
                columns: new[] { "FechaActualizado", "FechaCreado" },
                values: new object[] { new DateTime(2024, 8, 18, 15, 17, 29, 881, DateTimeKind.Local).AddTicks(1224), new DateTime(2024, 8, 18, 15, 17, 29, 881, DateTimeKind.Local).AddTicks(1224) });

            migrationBuilder.UpdateData(
                table: "RolPermiso",
                keyColumn: "Id",
                keyValue: new Guid("90abf232-a641-478d-8720-f0ae49e8a306"),
                columns: new[] { "FechaActualizado", "FechaCreado" },
                values: new object[] { new DateTime(2024, 8, 18, 15, 17, 29, 881, DateTimeKind.Local).AddTicks(1233), new DateTime(2024, 8, 18, 15, 17, 29, 881, DateTimeKind.Local).AddTicks(1232) });

            migrationBuilder.UpdateData(
                table: "RolPermiso",
                keyColumn: "Id",
                keyValue: new Guid("e36d283c-8b25-42b6-83bd-56edd953e770"),
                columns: new[] { "FechaActualizado", "FechaCreado" },
                values: new object[] { new DateTime(2024, 8, 18, 15, 17, 29, 881, DateTimeKind.Local).AddTicks(1231), new DateTime(2024, 8, 18, 15, 17, 29, 881, DateTimeKind.Local).AddTicks(1231) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("c0b7e3b3-a06e-4580-b985-bb2fc4336522"),
                columns: new[] { "FechaActualizado", "FechaCreado" },
                values: new object[] { new DateTime(2024, 8, 18, 15, 17, 29, 881, DateTimeKind.Local).AddTicks(860), new DateTime(2024, 8, 18, 15, 17, 29, 881, DateTimeKind.Local).AddTicks(845) });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: new Guid("42717fb8-6e3f-4c94-b6b1-a88e8718d0a6"),
                columns: new[] { "FechaActualizado", "FechaCreado" },
                values: new object[] { new DateTime(2024, 8, 18, 15, 17, 29, 881, DateTimeKind.Local).AddTicks(5794), new DateTime(2024, 8, 18, 15, 17, 29, 881, DateTimeKind.Local).AddTicks(5791) });

            migrationBuilder.CreateIndex(
                name: "IX_Productos_Codigo",
                table: "Productos",
                column: "Codigo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductosVentas_Id",
                table: "ProductosVentas",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductosVentas_ProductoId",
                table: "ProductosVentas",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductosVentas_VentaId_ProductoId",
                table: "ProductosVentas",
                columns: new[] { "VentaId", "ProductoId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductosVentas");

            migrationBuilder.DropIndex(
                name: "IX_Productos_Codigo",
                table: "Productos");

            migrationBuilder.AlterColumn<string>(
                name: "Codigo",
                table: "Productos",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.CreateTable(
                name: "ProductosGestores",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GestorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ActualizadoPor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreadoPor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaActualizado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaCreado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PrecioGestor = table.Column<float>(type: "real", nullable: false)
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
                });

            migrationBuilder.UpdateData(
                table: "EstadosProductos",
                keyColumn: "Id",
                keyValue: new Guid("1c8fcfe3-5718-4a36-bd3a-681241488a6b"),
                columns: new[] { "FechaActualizado", "FechaCreado" },
                values: new object[] { new DateTime(2024, 8, 18, 13, 44, 50, 45, DateTimeKind.Local).AddTicks(9329), new DateTime(2024, 8, 18, 13, 44, 50, 45, DateTimeKind.Local).AddTicks(9326) });

            migrationBuilder.UpdateData(
                table: "EstadosProductos",
                keyColumn: "Id",
                keyValue: new Guid("37760da6-b5de-4a1d-b5b7-cde6a462e192"),
                columns: new[] { "FechaActualizado", "FechaCreado" },
                values: new object[] { new DateTime(2024, 8, 18, 13, 44, 50, 45, DateTimeKind.Local).AddTicks(9336), new DateTime(2024, 8, 18, 13, 44, 50, 45, DateTimeKind.Local).AddTicks(9335) });

            migrationBuilder.UpdateData(
                table: "EstadosProductos",
                keyColumn: "Id",
                keyValue: new Guid("4beeeb16-931b-4f2a-9355-fa19cf76ed54"),
                columns: new[] { "FechaActualizado", "FechaCreado" },
                values: new object[] { new DateTime(2024, 8, 18, 13, 44, 50, 45, DateTimeKind.Local).AddTicks(9338), new DateTime(2024, 8, 18, 13, 44, 50, 45, DateTimeKind.Local).AddTicks(9337) });

            migrationBuilder.UpdateData(
                table: "Permisos",
                keyColumn: "Id",
                keyValue: new Guid("4129cf49-cc22-46a1-9625-501855f2da8b"),
                columns: new[] { "FechaActualizado", "FechaCreado" },
                values: new object[] { new DateTime(2024, 8, 18, 13, 44, 50, 45, DateTimeKind.Local).AddTicks(1475), new DateTime(2024, 8, 18, 13, 44, 50, 45, DateTimeKind.Local).AddTicks(1474) });

            migrationBuilder.UpdateData(
                table: "Permisos",
                keyColumn: "Id",
                keyValue: new Guid("56b3924b-209b-40fb-9f31-ad75c12f4528"),
                columns: new[] { "FechaActualizado", "FechaCreado" },
                values: new object[] { new DateTime(2024, 8, 18, 13, 44, 50, 45, DateTimeKind.Local).AddTicks(1463), new DateTime(2024, 8, 18, 13, 44, 50, 45, DateTimeKind.Local).AddTicks(1462) });

            migrationBuilder.UpdateData(
                table: "Permisos",
                keyColumn: "Id",
                keyValue: new Guid("90abf232-a641-478d-8720-f0ae49e8a306"),
                columns: new[] { "FechaActualizado", "FechaCreado" },
                values: new object[] { new DateTime(2024, 8, 18, 13, 44, 50, 45, DateTimeKind.Local).AddTicks(1481), new DateTime(2024, 8, 18, 13, 44, 50, 45, DateTimeKind.Local).AddTicks(1481) });

            migrationBuilder.UpdateData(
                table: "Permisos",
                keyColumn: "Id",
                keyValue: new Guid("e36d283c-8b25-42b6-83bd-56edd953e770"),
                columns: new[] { "FechaActualizado", "FechaCreado" },
                values: new object[] { new DateTime(2024, 8, 18, 13, 44, 50, 45, DateTimeKind.Local).AddTicks(1477), new DateTime(2024, 8, 18, 13, 44, 50, 45, DateTimeKind.Local).AddTicks(1477) });

            migrationBuilder.UpdateData(
                table: "RolPermiso",
                keyColumn: "Id",
                keyValue: new Guid("4129cf49-cc22-46a1-9625-501855f2da8b"),
                columns: new[] { "FechaActualizado", "FechaCreado" },
                values: new object[] { new DateTime(2024, 8, 18, 13, 44, 50, 45, DateTimeKind.Local).AddTicks(1641), new DateTime(2024, 8, 18, 13, 44, 50, 45, DateTimeKind.Local).AddTicks(1640) });

            migrationBuilder.UpdateData(
                table: "RolPermiso",
                keyColumn: "Id",
                keyValue: new Guid("56b3924b-209b-40fb-9f31-ad75c12f4528"),
                columns: new[] { "FechaActualizado", "FechaCreado" },
                values: new object[] { new DateTime(2024, 8, 18, 13, 44, 50, 45, DateTimeKind.Local).AddTicks(1635), new DateTime(2024, 8, 18, 13, 44, 50, 45, DateTimeKind.Local).AddTicks(1635) });

            migrationBuilder.UpdateData(
                table: "RolPermiso",
                keyColumn: "Id",
                keyValue: new Guid("90abf232-a641-478d-8720-f0ae49e8a306"),
                columns: new[] { "FechaActualizado", "FechaCreado" },
                values: new object[] { new DateTime(2024, 8, 18, 13, 44, 50, 45, DateTimeKind.Local).AddTicks(1644), new DateTime(2024, 8, 18, 13, 44, 50, 45, DateTimeKind.Local).AddTicks(1644) });

            migrationBuilder.UpdateData(
                table: "RolPermiso",
                keyColumn: "Id",
                keyValue: new Guid("e36d283c-8b25-42b6-83bd-56edd953e770"),
                columns: new[] { "FechaActualizado", "FechaCreado" },
                values: new object[] { new DateTime(2024, 8, 18, 13, 44, 50, 45, DateTimeKind.Local).AddTicks(1642), new DateTime(2024, 8, 18, 13, 44, 50, 45, DateTimeKind.Local).AddTicks(1642) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("c0b7e3b3-a06e-4580-b985-bb2fc4336522"),
                columns: new[] { "FechaActualizado", "FechaCreado" },
                values: new object[] { new DateTime(2024, 8, 18, 13, 44, 50, 45, DateTimeKind.Local).AddTicks(1270), new DateTime(2024, 8, 18, 13, 44, 50, 45, DateTimeKind.Local).AddTicks(1258) });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: new Guid("42717fb8-6e3f-4c94-b6b1-a88e8718d0a6"),
                columns: new[] { "FechaActualizado", "FechaCreado" },
                values: new object[] { new DateTime(2024, 8, 18, 13, 44, 50, 45, DateTimeKind.Local).AddTicks(5993), new DateTime(2024, 8, 18, 13, 44, 50, 45, DateTimeKind.Local).AddTicks(5989) });

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
        }
    }
}
