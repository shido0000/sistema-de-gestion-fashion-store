using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Data.Migrations
{
    /// <inheritdoc />
    public partial class actualizacion_bd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductosGestores_Ventas_VentaId",
                table: "ProductosGestores");

            migrationBuilder.DropIndex(
                name: "IX_ProductosGestores_VentaId",
                table: "ProductosGestores");

            migrationBuilder.DropColumn(
                name: "VentaId",
                table: "ProductosGestores");

            migrationBuilder.CreateTable(
                name: "VentasGestores",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VentaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GestorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FechaCreado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreadoPor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaActualizado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ActualizadoPor = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                table: "Permisos",
                keyColumn: "Id",
                keyValue: new Guid("4129cf49-cc22-46a1-9625-501855f2da8b"),
                columns: new[] { "FechaActualizado", "FechaCreado" },
                values: new object[] { new DateTime(2024, 8, 16, 19, 57, 27, 940, DateTimeKind.Local).AddTicks(726), new DateTime(2024, 8, 16, 19, 57, 27, 940, DateTimeKind.Local).AddTicks(726) });

            migrationBuilder.UpdateData(
                table: "Permisos",
                keyColumn: "Id",
                keyValue: new Guid("56b3924b-209b-40fb-9f31-ad75c12f4528"),
                columns: new[] { "FechaActualizado", "FechaCreado" },
                values: new object[] { new DateTime(2024, 8, 16, 19, 57, 27, 940, DateTimeKind.Local).AddTicks(709), new DateTime(2024, 8, 16, 19, 57, 27, 940, DateTimeKind.Local).AddTicks(708) });

            migrationBuilder.UpdateData(
                table: "Permisos",
                keyColumn: "Id",
                keyValue: new Guid("90abf232-a641-478d-8720-f0ae49e8a306"),
                columns: new[] { "FechaActualizado", "FechaCreado" },
                values: new object[] { new DateTime(2024, 8, 16, 19, 57, 27, 940, DateTimeKind.Local).AddTicks(732), new DateTime(2024, 8, 16, 19, 57, 27, 940, DateTimeKind.Local).AddTicks(731) });

            migrationBuilder.UpdateData(
                table: "Permisos",
                keyColumn: "Id",
                keyValue: new Guid("e36d283c-8b25-42b6-83bd-56edd953e770"),
                columns: new[] { "FechaActualizado", "FechaCreado" },
                values: new object[] { new DateTime(2024, 8, 16, 19, 57, 27, 940, DateTimeKind.Local).AddTicks(729), new DateTime(2024, 8, 16, 19, 57, 27, 940, DateTimeKind.Local).AddTicks(729) });

            migrationBuilder.UpdateData(
                table: "RolPermiso",
                keyColumn: "Id",
                keyValue: new Guid("4129cf49-cc22-46a1-9625-501855f2da8b"),
                columns: new[] { "FechaActualizado", "FechaCreado" },
                values: new object[] { new DateTime(2024, 8, 16, 19, 57, 27, 940, DateTimeKind.Local).AddTicks(883), new DateTime(2024, 8, 16, 19, 57, 27, 940, DateTimeKind.Local).AddTicks(882) });

            migrationBuilder.UpdateData(
                table: "RolPermiso",
                keyColumn: "Id",
                keyValue: new Guid("56b3924b-209b-40fb-9f31-ad75c12f4528"),
                columns: new[] { "FechaActualizado", "FechaCreado" },
                values: new object[] { new DateTime(2024, 8, 16, 19, 57, 27, 940, DateTimeKind.Local).AddTicks(876), new DateTime(2024, 8, 16, 19, 57, 27, 940, DateTimeKind.Local).AddTicks(875) });

            migrationBuilder.UpdateData(
                table: "RolPermiso",
                keyColumn: "Id",
                keyValue: new Guid("90abf232-a641-478d-8720-f0ae49e8a306"),
                columns: new[] { "FechaActualizado", "FechaCreado" },
                values: new object[] { new DateTime(2024, 8, 16, 19, 57, 27, 940, DateTimeKind.Local).AddTicks(885), new DateTime(2024, 8, 16, 19, 57, 27, 940, DateTimeKind.Local).AddTicks(885) });

            migrationBuilder.UpdateData(
                table: "RolPermiso",
                keyColumn: "Id",
                keyValue: new Guid("e36d283c-8b25-42b6-83bd-56edd953e770"),
                columns: new[] { "FechaActualizado", "FechaCreado" },
                values: new object[] { new DateTime(2024, 8, 16, 19, 57, 27, 940, DateTimeKind.Local).AddTicks(884), new DateTime(2024, 8, 16, 19, 57, 27, 940, DateTimeKind.Local).AddTicks(884) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("c0b7e3b3-a06e-4580-b985-bb2fc4336522"),
                columns: new[] { "FechaActualizado", "FechaCreado" },
                values: new object[] { new DateTime(2024, 8, 16, 19, 57, 27, 940, DateTimeKind.Local).AddTicks(540), new DateTime(2024, 8, 16, 19, 57, 27, 940, DateTimeKind.Local).AddTicks(529) });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: new Guid("42717fb8-6e3f-4c94-b6b1-a88e8718d0a6"),
                columns: new[] { "FechaActualizado", "FechaCreado" },
                values: new object[] { new DateTime(2024, 8, 16, 19, 57, 27, 940, DateTimeKind.Local).AddTicks(5499), new DateTime(2024, 8, 16, 19, 57, 27, 940, DateTimeKind.Local).AddTicks(5495) });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VentasGestores");

            migrationBuilder.AddColumn<Guid>(
                name: "VentaId",
                table: "ProductosGestores",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Permisos",
                keyColumn: "Id",
                keyValue: new Guid("4129cf49-cc22-46a1-9625-501855f2da8b"),
                columns: new[] { "FechaActualizado", "FechaCreado" },
                values: new object[] { new DateTime(2024, 8, 16, 19, 9, 32, 261, DateTimeKind.Local).AddTicks(8270), new DateTime(2024, 8, 16, 19, 9, 32, 261, DateTimeKind.Local).AddTicks(8269) });

            migrationBuilder.UpdateData(
                table: "Permisos",
                keyColumn: "Id",
                keyValue: new Guid("56b3924b-209b-40fb-9f31-ad75c12f4528"),
                columns: new[] { "FechaActualizado", "FechaCreado" },
                values: new object[] { new DateTime(2024, 8, 16, 19, 9, 32, 261, DateTimeKind.Local).AddTicks(8258), new DateTime(2024, 8, 16, 19, 9, 32, 261, DateTimeKind.Local).AddTicks(8257) });

            migrationBuilder.UpdateData(
                table: "Permisos",
                keyColumn: "Id",
                keyValue: new Guid("90abf232-a641-478d-8720-f0ae49e8a306"),
                columns: new[] { "FechaActualizado", "FechaCreado" },
                values: new object[] { new DateTime(2024, 8, 16, 19, 9, 32, 261, DateTimeKind.Local).AddTicks(8279), new DateTime(2024, 8, 16, 19, 9, 32, 261, DateTimeKind.Local).AddTicks(8278) });

            migrationBuilder.UpdateData(
                table: "Permisos",
                keyColumn: "Id",
                keyValue: new Guid("e36d283c-8b25-42b6-83bd-56edd953e770"),
                columns: new[] { "FechaActualizado", "FechaCreado" },
                values: new object[] { new DateTime(2024, 8, 16, 19, 9, 32, 261, DateTimeKind.Local).AddTicks(8276), new DateTime(2024, 8, 16, 19, 9, 32, 261, DateTimeKind.Local).AddTicks(8276) });

            migrationBuilder.UpdateData(
                table: "RolPermiso",
                keyColumn: "Id",
                keyValue: new Guid("4129cf49-cc22-46a1-9625-501855f2da8b"),
                columns: new[] { "FechaActualizado", "FechaCreado" },
                values: new object[] { new DateTime(2024, 8, 16, 19, 9, 32, 261, DateTimeKind.Local).AddTicks(8436), new DateTime(2024, 8, 16, 19, 9, 32, 261, DateTimeKind.Local).AddTicks(8436) });

            migrationBuilder.UpdateData(
                table: "RolPermiso",
                keyColumn: "Id",
                keyValue: new Guid("56b3924b-209b-40fb-9f31-ad75c12f4528"),
                columns: new[] { "FechaActualizado", "FechaCreado" },
                values: new object[] { new DateTime(2024, 8, 16, 19, 9, 32, 261, DateTimeKind.Local).AddTicks(8432), new DateTime(2024, 8, 16, 19, 9, 32, 261, DateTimeKind.Local).AddTicks(8431) });

            migrationBuilder.UpdateData(
                table: "RolPermiso",
                keyColumn: "Id",
                keyValue: new Guid("90abf232-a641-478d-8720-f0ae49e8a306"),
                columns: new[] { "FechaActualizado", "FechaCreado" },
                values: new object[] { new DateTime(2024, 8, 16, 19, 9, 32, 261, DateTimeKind.Local).AddTicks(8439), new DateTime(2024, 8, 16, 19, 9, 32, 261, DateTimeKind.Local).AddTicks(8439) });

            migrationBuilder.UpdateData(
                table: "RolPermiso",
                keyColumn: "Id",
                keyValue: new Guid("e36d283c-8b25-42b6-83bd-56edd953e770"),
                columns: new[] { "FechaActualizado", "FechaCreado" },
                values: new object[] { new DateTime(2024, 8, 16, 19, 9, 32, 261, DateTimeKind.Local).AddTicks(8438), new DateTime(2024, 8, 16, 19, 9, 32, 261, DateTimeKind.Local).AddTicks(8438) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("c0b7e3b3-a06e-4580-b985-bb2fc4336522"),
                columns: new[] { "FechaActualizado", "FechaCreado" },
                values: new object[] { new DateTime(2024, 8, 16, 19, 9, 32, 261, DateTimeKind.Local).AddTicks(8090), new DateTime(2024, 8, 16, 19, 9, 32, 261, DateTimeKind.Local).AddTicks(8079) });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: new Guid("42717fb8-6e3f-4c94-b6b1-a88e8718d0a6"),
                columns: new[] { "FechaActualizado", "FechaCreado" },
                values: new object[] { new DateTime(2024, 8, 16, 19, 9, 32, 262, DateTimeKind.Local).AddTicks(2955), new DateTime(2024, 8, 16, 19, 9, 32, 262, DateTimeKind.Local).AddTicks(2951) });

            migrationBuilder.CreateIndex(
                name: "IX_ProductosGestores_VentaId",
                table: "ProductosGestores",
                column: "VentaId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductosGestores_Ventas_VentaId",
                table: "ProductosGestores",
                column: "VentaId",
                principalTable: "Ventas",
                principalColumn: "Id");
        }
    }
}
