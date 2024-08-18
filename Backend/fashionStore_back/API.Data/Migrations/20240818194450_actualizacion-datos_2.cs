using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Data.Migrations
{
    /// <inheritdoc />
    public partial class actualizaciondatos_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VentasGestores");

            migrationBuilder.AddColumn<Guid>(
                name: "GestorId",
                table: "Ventas",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

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
                name: "IX_Ventas_GestorId",
                table: "Ventas",
                column: "GestorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ventas_Gestores_GestorId",
                table: "Ventas",
                column: "GestorId",
                principalTable: "Gestores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ventas_Gestores_GestorId",
                table: "Ventas");

            migrationBuilder.DropIndex(
                name: "IX_Ventas_GestorId",
                table: "Ventas");

            migrationBuilder.DropColumn(
                name: "GestorId",
                table: "Ventas");

            migrationBuilder.CreateTable(
                name: "VentasGestores",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GestorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VentaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ActualizadoPor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreadoPor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaActualizado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaCreado = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VentasGestores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VentasGestores_Gestores_GestorId",
                        column: x => x.GestorId,
                        principalTable: "Gestores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VentasGestores_Ventas_VentaId",
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
                values: new object[] { new DateTime(2024, 8, 18, 12, 26, 6, 332, DateTimeKind.Local).AddTicks(4714), new DateTime(2024, 8, 18, 12, 26, 6, 332, DateTimeKind.Local).AddTicks(4711) });

            migrationBuilder.UpdateData(
                table: "EstadosProductos",
                keyColumn: "Id",
                keyValue: new Guid("37760da6-b5de-4a1d-b5b7-cde6a462e192"),
                columns: new[] { "FechaActualizado", "FechaCreado" },
                values: new object[] { new DateTime(2024, 8, 18, 12, 26, 6, 332, DateTimeKind.Local).AddTicks(4720), new DateTime(2024, 8, 18, 12, 26, 6, 332, DateTimeKind.Local).AddTicks(4720) });

            migrationBuilder.UpdateData(
                table: "EstadosProductos",
                keyColumn: "Id",
                keyValue: new Guid("4beeeb16-931b-4f2a-9355-fa19cf76ed54"),
                columns: new[] { "FechaActualizado", "FechaCreado" },
                values: new object[] { new DateTime(2024, 8, 18, 12, 26, 6, 332, DateTimeKind.Local).AddTicks(4723), new DateTime(2024, 8, 18, 12, 26, 6, 332, DateTimeKind.Local).AddTicks(4722) });

            migrationBuilder.UpdateData(
                table: "Permisos",
                keyColumn: "Id",
                keyValue: new Guid("4129cf49-cc22-46a1-9625-501855f2da8b"),
                columns: new[] { "FechaActualizado", "FechaCreado" },
                values: new object[] { new DateTime(2024, 8, 18, 12, 26, 6, 331, DateTimeKind.Local).AddTicks(5750), new DateTime(2024, 8, 18, 12, 26, 6, 331, DateTimeKind.Local).AddTicks(5750) });

            migrationBuilder.UpdateData(
                table: "Permisos",
                keyColumn: "Id",
                keyValue: new Guid("56b3924b-209b-40fb-9f31-ad75c12f4528"),
                columns: new[] { "FechaActualizado", "FechaCreado" },
                values: new object[] { new DateTime(2024, 8, 18, 12, 26, 6, 331, DateTimeKind.Local).AddTicks(5734), new DateTime(2024, 8, 18, 12, 26, 6, 331, DateTimeKind.Local).AddTicks(5734) });

            migrationBuilder.UpdateData(
                table: "Permisos",
                keyColumn: "Id",
                keyValue: new Guid("90abf232-a641-478d-8720-f0ae49e8a306"),
                columns: new[] { "FechaActualizado", "FechaCreado" },
                values: new object[] { new DateTime(2024, 8, 18, 12, 26, 6, 331, DateTimeKind.Local).AddTicks(5755), new DateTime(2024, 8, 18, 12, 26, 6, 331, DateTimeKind.Local).AddTicks(5754) });

            migrationBuilder.UpdateData(
                table: "Permisos",
                keyColumn: "Id",
                keyValue: new Guid("e36d283c-8b25-42b6-83bd-56edd953e770"),
                columns: new[] { "FechaActualizado", "FechaCreado" },
                values: new object[] { new DateTime(2024, 8, 18, 12, 26, 6, 331, DateTimeKind.Local).AddTicks(5753), new DateTime(2024, 8, 18, 12, 26, 6, 331, DateTimeKind.Local).AddTicks(5752) });

            migrationBuilder.UpdateData(
                table: "RolPermiso",
                keyColumn: "Id",
                keyValue: new Guid("4129cf49-cc22-46a1-9625-501855f2da8b"),
                columns: new[] { "FechaActualizado", "FechaCreado" },
                values: new object[] { new DateTime(2024, 8, 18, 12, 26, 6, 331, DateTimeKind.Local).AddTicks(5920), new DateTime(2024, 8, 18, 12, 26, 6, 331, DateTimeKind.Local).AddTicks(5920) });

            migrationBuilder.UpdateData(
                table: "RolPermiso",
                keyColumn: "Id",
                keyValue: new Guid("56b3924b-209b-40fb-9f31-ad75c12f4528"),
                columns: new[] { "FechaActualizado", "FechaCreado" },
                values: new object[] { new DateTime(2024, 8, 18, 12, 26, 6, 331, DateTimeKind.Local).AddTicks(5915), new DateTime(2024, 8, 18, 12, 26, 6, 331, DateTimeKind.Local).AddTicks(5914) });

            migrationBuilder.UpdateData(
                table: "RolPermiso",
                keyColumn: "Id",
                keyValue: new Guid("90abf232-a641-478d-8720-f0ae49e8a306"),
                columns: new[] { "FechaActualizado", "FechaCreado" },
                values: new object[] { new DateTime(2024, 8, 18, 12, 26, 6, 331, DateTimeKind.Local).AddTicks(5923), new DateTime(2024, 8, 18, 12, 26, 6, 331, DateTimeKind.Local).AddTicks(5923) });

            migrationBuilder.UpdateData(
                table: "RolPermiso",
                keyColumn: "Id",
                keyValue: new Guid("e36d283c-8b25-42b6-83bd-56edd953e770"),
                columns: new[] { "FechaActualizado", "FechaCreado" },
                values: new object[] { new DateTime(2024, 8, 18, 12, 26, 6, 331, DateTimeKind.Local).AddTicks(5922), new DateTime(2024, 8, 18, 12, 26, 6, 331, DateTimeKind.Local).AddTicks(5921) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("c0b7e3b3-a06e-4580-b985-bb2fc4336522"),
                columns: new[] { "FechaActualizado", "FechaCreado" },
                values: new object[] { new DateTime(2024, 8, 18, 12, 26, 6, 331, DateTimeKind.Local).AddTicks(5544), new DateTime(2024, 8, 18, 12, 26, 6, 331, DateTimeKind.Local).AddTicks(5532) });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: new Guid("42717fb8-6e3f-4c94-b6b1-a88e8718d0a6"),
                columns: new[] { "FechaActualizado", "FechaCreado" },
                values: new object[] { new DateTime(2024, 8, 18, 12, 26, 6, 332, DateTimeKind.Local).AddTicks(866), new DateTime(2024, 8, 18, 12, 26, 6, 332, DateTimeKind.Local).AddTicks(863) });

            migrationBuilder.CreateIndex(
                name: "IX_VentasGestores_GestorId_VentaId",
                table: "VentasGestores",
                columns: new[] { "GestorId", "VentaId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VentasGestores_Id",
                table: "VentasGestores",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VentasGestores_VentaId",
                table: "VentasGestores",
                column: "VentaId");
        }
    }
}
