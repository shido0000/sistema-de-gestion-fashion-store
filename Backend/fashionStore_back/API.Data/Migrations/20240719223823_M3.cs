using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Data.Migrations
{
    /// <inheritdoc />
    public partial class M3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Camareras",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Supervisora = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    FechaCreado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreadoPor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaActualizado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ActualizadoPor = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    Codigo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    FechaCreado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreadoPor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaActualizado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ActualizadoPor = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    Descripcion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    FechaCreado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreadoPor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaActualizado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ActualizadoPor = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    Codigo = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    FechaCreado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreadoPor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaActualizado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ActualizadoPor = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    Descripcion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    FechaCreado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreadoPor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaActualizado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ActualizadoPor = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    Descripcion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    FechaCreado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreadoPor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaActualizado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ActualizadoPor = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    Codigo = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    FechaCreado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreadoPor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaActualizado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ActualizadoPor = table.Column<string>(type: "nvarchar(max)", nullable: false)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.UpdateData(
                table: "Permisos",
                keyColumn: "Id",
                keyValue: new Guid("4129cf49-cc22-46a1-9625-501855f2da8b"),
                columns: new[] { "FechaActualizado", "FechaCreado" },
                values: new object[] { new DateTime(2024, 6, 28, 23, 18, 26, 102, DateTimeKind.Local).AddTicks(7067), new DateTime(2024, 6, 28, 23, 18, 26, 102, DateTimeKind.Local).AddTicks(7058) });

            migrationBuilder.UpdateData(
                table: "Permisos",
                keyColumn: "Id",
                keyValue: new Guid("56b3924b-209b-40fb-9f31-ad75c12f4528"),
                columns: new[] { "FechaActualizado", "FechaCreado" },
                values: new object[] { new DateTime(2024, 6, 28, 23, 18, 26, 102, DateTimeKind.Local).AddTicks(7038), new DateTime(2024, 6, 28, 23, 18, 26, 102, DateTimeKind.Local).AddTicks(7030) });

            migrationBuilder.UpdateData(
                table: "Permisos",
                keyColumn: "Id",
                keyValue: new Guid("90abf232-a641-478d-8720-f0ae49e8a306"),
                columns: new[] { "FechaActualizado", "FechaCreado" },
                values: new object[] { new DateTime(2024, 6, 28, 23, 18, 26, 102, DateTimeKind.Local).AddTicks(7094), new DateTime(2024, 6, 28, 23, 18, 26, 102, DateTimeKind.Local).AddTicks(7091) });

            migrationBuilder.UpdateData(
                table: "Permisos",
                keyColumn: "Id",
                keyValue: new Guid("e36d283c-8b25-42b6-83bd-56edd953e770"),
                columns: new[] { "FechaActualizado", "FechaCreado" },
                values: new object[] { new DateTime(2024, 6, 28, 23, 18, 26, 102, DateTimeKind.Local).AddTicks(7086), new DateTime(2024, 6, 28, 23, 18, 26, 102, DateTimeKind.Local).AddTicks(7083) });

            migrationBuilder.UpdateData(
                table: "RolPermiso",
                keyColumn: "Id",
                keyValue: new Guid("4129cf49-cc22-46a1-9625-501855f2da8b"),
                columns: new[] { "FechaActualizado", "FechaCreado" },
                values: new object[] { new DateTime(2024, 6, 28, 23, 18, 26, 102, DateTimeKind.Local).AddTicks(7396), new DateTime(2024, 6, 28, 23, 18, 26, 102, DateTimeKind.Local).AddTicks(7394) });

            migrationBuilder.UpdateData(
                table: "RolPermiso",
                keyColumn: "Id",
                keyValue: new Guid("56b3924b-209b-40fb-9f31-ad75c12f4528"),
                columns: new[] { "FechaActualizado", "FechaCreado" },
                values: new object[] { new DateTime(2024, 6, 28, 23, 18, 26, 102, DateTimeKind.Local).AddTicks(7383), new DateTime(2024, 6, 28, 23, 18, 26, 102, DateTimeKind.Local).AddTicks(7375) });

            migrationBuilder.UpdateData(
                table: "RolPermiso",
                keyColumn: "Id",
                keyValue: new Guid("90abf232-a641-478d-8720-f0ae49e8a306"),
                columns: new[] { "FechaActualizado", "FechaCreado" },
                values: new object[] { new DateTime(2024, 6, 28, 23, 18, 26, 102, DateTimeKind.Local).AddTicks(7425), new DateTime(2024, 6, 28, 23, 18, 26, 102, DateTimeKind.Local).AddTicks(7423) });

            migrationBuilder.UpdateData(
                table: "RolPermiso",
                keyColumn: "Id",
                keyValue: new Guid("e36d283c-8b25-42b6-83bd-56edd953e770"),
                columns: new[] { "FechaActualizado", "FechaCreado" },
                values: new object[] { new DateTime(2024, 6, 28, 23, 18, 26, 102, DateTimeKind.Local).AddTicks(7417), new DateTime(2024, 6, 28, 23, 18, 26, 102, DateTimeKind.Local).AddTicks(7401) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("c0b7e3b3-a06e-4580-b985-bb2fc4336522"),
                columns: new[] { "FechaActualizado", "FechaCreado" },
                values: new object[] { new DateTime(2024, 6, 28, 23, 18, 26, 102, DateTimeKind.Local).AddTicks(6759), new DateTime(2024, 6, 28, 23, 18, 26, 102, DateTimeKind.Local).AddTicks(6702) });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: new Guid("42717fb8-6e3f-4c94-b6b1-a88e8718d0a6"),
                columns: new[] { "FechaActualizado", "FechaCreado" },
                values: new object[] { new DateTime(2024, 6, 28, 23, 18, 26, 103, DateTimeKind.Local).AddTicks(5331), new DateTime(2024, 6, 28, 23, 18, 26, 103, DateTimeKind.Local).AddTicks(5311) });
        }
    }
}
