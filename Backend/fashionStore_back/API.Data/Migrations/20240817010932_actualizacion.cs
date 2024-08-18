using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Data.Migrations
{
    /// <inheritdoc />
    public partial class actualizacion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                columns: new[] { "Apellidos", "Contrasenna", "Correo", "FechaActualizado", "FechaCreado", "Nombre", "Username" },
                values: new object[] { "1", "$2a$10$EixZaYVK1fsbw1Zfbx3OXePaWxn96p36Zf4d0xF4f5f5f5f5f5f5f", "1@api.cu", new DateTime(2024, 8, 16, 19, 9, 32, 262, DateTimeKind.Local).AddTicks(2955), new DateTime(2024, 8, 16, 19, 9, 32, 262, DateTimeKind.Local).AddTicks(2951), "1", "1" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                columns: new[] { "Apellidos", "Contrasenna", "Correo", "FechaActualizado", "FechaCreado", "Nombre", "Username" },
                values: new object[] { "System", "poner hash", "admin.system@api.cu", new DateTime(2024, 8, 15, 23, 42, 24, 189, DateTimeKind.Local).AddTicks(6355), new DateTime(2024, 8, 15, 23, 42, 24, 189, DateTimeKind.Local).AddTicks(6352), "Admin", "admin.system" });
        }
    }
}
