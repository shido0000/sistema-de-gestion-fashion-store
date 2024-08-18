using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API.Data.Migrations
{
    /// <inheritdoc />
    public partial class actualizaciondatos_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "EstadosProductos",
                columns: new[] { "Id", "ActualizadoPor", "CreadoPor", "Descripcion", "FechaActualizado", "FechaCreado" },
                values: new object[,]
                {
                    { new Guid("1c8fcfe3-5718-4a36-bd3a-681241488a6b"), "", "", "Disponible", new DateTime(2024, 8, 18, 12, 26, 6, 332, DateTimeKind.Local).AddTicks(4714), new DateTime(2024, 8, 18, 12, 26, 6, 332, DateTimeKind.Local).AddTicks(4711) },
                    { new Guid("37760da6-b5de-4a1d-b5b7-cde6a462e192"), "", "", "Agotado", new DateTime(2024, 8, 18, 12, 26, 6, 332, DateTimeKind.Local).AddTicks(4720), new DateTime(2024, 8, 18, 12, 26, 6, 332, DateTimeKind.Local).AddTicks(4720) },
                    { new Guid("4beeeb16-931b-4f2a-9355-fa19cf76ed54"), "", "", "Reservado", new DateTime(2024, 8, 18, 12, 26, 6, 332, DateTimeKind.Local).AddTicks(4723), new DateTime(2024, 8, 18, 12, 26, 6, 332, DateTimeKind.Local).AddTicks(4722) }
                });

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "EstadosProductos",
                keyColumn: "Id",
                keyValue: new Guid("1c8fcfe3-5718-4a36-bd3a-681241488a6b"));

            migrationBuilder.DeleteData(
                table: "EstadosProductos",
                keyColumn: "Id",
                keyValue: new Guid("37760da6-b5de-4a1d-b5b7-cde6a462e192"));

            migrationBuilder.DeleteData(
                table: "EstadosProductos",
                keyColumn: "Id",
                keyValue: new Guid("4beeeb16-931b-4f2a-9355-fa19cf76ed54"));

            migrationBuilder.UpdateData(
                table: "Permisos",
                keyColumn: "Id",
                keyValue: new Guid("4129cf49-cc22-46a1-9625-501855f2da8b"),
                columns: new[] { "FechaActualizado", "FechaCreado" },
                values: new object[] { new DateTime(2024, 8, 18, 9, 11, 52, 61, DateTimeKind.Local).AddTicks(1730), new DateTime(2024, 8, 18, 9, 11, 52, 61, DateTimeKind.Local).AddTicks(1730) });

            migrationBuilder.UpdateData(
                table: "Permisos",
                keyColumn: "Id",
                keyValue: new Guid("56b3924b-209b-40fb-9f31-ad75c12f4528"),
                columns: new[] { "FechaActualizado", "FechaCreado" },
                values: new object[] { new DateTime(2024, 8, 18, 9, 11, 52, 61, DateTimeKind.Local).AddTicks(1711), new DateTime(2024, 8, 18, 9, 11, 52, 61, DateTimeKind.Local).AddTicks(1709) });

            migrationBuilder.UpdateData(
                table: "Permisos",
                keyColumn: "Id",
                keyValue: new Guid("90abf232-a641-478d-8720-f0ae49e8a306"),
                columns: new[] { "FechaActualizado", "FechaCreado" },
                values: new object[] { new DateTime(2024, 8, 18, 9, 11, 52, 61, DateTimeKind.Local).AddTicks(1736), new DateTime(2024, 8, 18, 9, 11, 52, 61, DateTimeKind.Local).AddTicks(1736) });

            migrationBuilder.UpdateData(
                table: "Permisos",
                keyColumn: "Id",
                keyValue: new Guid("e36d283c-8b25-42b6-83bd-56edd953e770"),
                columns: new[] { "FechaActualizado", "FechaCreado" },
                values: new object[] { new DateTime(2024, 8, 18, 9, 11, 52, 61, DateTimeKind.Local).AddTicks(1734), new DateTime(2024, 8, 18, 9, 11, 52, 61, DateTimeKind.Local).AddTicks(1733) });

            migrationBuilder.UpdateData(
                table: "RolPermiso",
                keyColumn: "Id",
                keyValue: new Guid("4129cf49-cc22-46a1-9625-501855f2da8b"),
                columns: new[] { "FechaActualizado", "FechaCreado" },
                values: new object[] { new DateTime(2024, 8, 18, 9, 11, 52, 61, DateTimeKind.Local).AddTicks(1948), new DateTime(2024, 8, 18, 9, 11, 52, 61, DateTimeKind.Local).AddTicks(1948) });

            migrationBuilder.UpdateData(
                table: "RolPermiso",
                keyColumn: "Id",
                keyValue: new Guid("56b3924b-209b-40fb-9f31-ad75c12f4528"),
                columns: new[] { "FechaActualizado", "FechaCreado" },
                values: new object[] { new DateTime(2024, 8, 18, 9, 11, 52, 61, DateTimeKind.Local).AddTicks(1943), new DateTime(2024, 8, 18, 9, 11, 52, 61, DateTimeKind.Local).AddTicks(1942) });

            migrationBuilder.UpdateData(
                table: "RolPermiso",
                keyColumn: "Id",
                keyValue: new Guid("90abf232-a641-478d-8720-f0ae49e8a306"),
                columns: new[] { "FechaActualizado", "FechaCreado" },
                values: new object[] { new DateTime(2024, 8, 18, 9, 11, 52, 61, DateTimeKind.Local).AddTicks(1951), new DateTime(2024, 8, 18, 9, 11, 52, 61, DateTimeKind.Local).AddTicks(1951) });

            migrationBuilder.UpdateData(
                table: "RolPermiso",
                keyColumn: "Id",
                keyValue: new Guid("e36d283c-8b25-42b6-83bd-56edd953e770"),
                columns: new[] { "FechaActualizado", "FechaCreado" },
                values: new object[] { new DateTime(2024, 8, 18, 9, 11, 52, 61, DateTimeKind.Local).AddTicks(1950), new DateTime(2024, 8, 18, 9, 11, 52, 61, DateTimeKind.Local).AddTicks(1950) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("c0b7e3b3-a06e-4580-b985-bb2fc4336522"),
                columns: new[] { "FechaActualizado", "FechaCreado" },
                values: new object[] { new DateTime(2024, 8, 18, 9, 11, 52, 61, DateTimeKind.Local).AddTicks(575), new DateTime(2024, 8, 18, 9, 11, 52, 61, DateTimeKind.Local).AddTicks(561) });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: new Guid("42717fb8-6e3f-4c94-b6b1-a88e8718d0a6"),
                columns: new[] { "FechaActualizado", "FechaCreado" },
                values: new object[] { new DateTime(2024, 8, 18, 9, 11, 52, 61, DateTimeKind.Local).AddTicks(7789), new DateTime(2024, 8, 18, 9, 11, 52, 61, DateTimeKind.Local).AddTicks(7786) });
        }
    }
}
