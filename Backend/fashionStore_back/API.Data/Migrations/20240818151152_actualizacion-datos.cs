using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Data.Migrations
{
    /// <inheritdoc />
    public partial class actualizaciondatos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "valorCambio",
                table: "ConversionesPrecios",
                newName: "ValorCambio");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ValorCambio",
                table: "ConversionesPrecios",
                newName: "valorCambio");

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
        }
    }
}
