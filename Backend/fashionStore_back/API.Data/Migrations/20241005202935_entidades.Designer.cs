﻿// <auto-generated />
using System;
using API.Data.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace API.Data.Migrations
{
    [DbContext(typeof(ApiDbContext))]
    [Migration("20241005202935_entidades")]
    partial class entidades
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.19")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("API.Data.Entidades.Gestion.Nomencladores.ConversionPrecio", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ActualizadoPor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreadoPor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("FechaActualizado")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaCreado")
                        .HasColumnType("datetime2");

                    b.Property<float>("ValorCambio")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("Descripcion")
                        .IsUnique();

                    b.HasIndex("Id")
                        .IsUnique();

                    b.ToTable("ConversionesPrecios", (string)null);
                });

            modelBuilder.Entity("API.Data.Entidades.Gestion.Nomencladores.EstadoProducto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ActualizadoPor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreadoPor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaActualizado")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaCreado")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.ToTable("EstadosProductos", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("1c8fcfe3-5718-4a36-bd3a-681241488a6b"),
                            ActualizadoPor = "",
                            CreadoPor = "",
                            Descripcion = "Disponible",
                            FechaActualizado = new DateTime(2024, 10, 5, 14, 29, 28, 694, DateTimeKind.Local).AddTicks(3641),
                            FechaCreado = new DateTime(2024, 10, 5, 14, 29, 28, 694, DateTimeKind.Local).AddTicks(3638)
                        },
                        new
                        {
                            Id = new Guid("37760da6-b5de-4a1d-b5b7-cde6a462e192"),
                            ActualizadoPor = "",
                            CreadoPor = "",
                            Descripcion = "Agotado",
                            FechaActualizado = new DateTime(2024, 10, 5, 14, 29, 28, 694, DateTimeKind.Local).AddTicks(3648),
                            FechaCreado = new DateTime(2024, 10, 5, 14, 29, 28, 694, DateTimeKind.Local).AddTicks(3647)
                        },
                        new
                        {
                            Id = new Guid("4beeeb16-931b-4f2a-9355-fa19cf76ed54"),
                            ActualizadoPor = "",
                            CreadoPor = "",
                            Descripcion = "Reservado",
                            FechaActualizado = new DateTime(2024, 10, 5, 14, 29, 28, 694, DateTimeKind.Local).AddTicks(3651),
                            FechaCreado = new DateTime(2024, 10, 5, 14, 29, 28, 694, DateTimeKind.Local).AddTicks(3650)
                        });
                });

            modelBuilder.Entity("API.Data.Entidades.Gestion.Nomencladores.Gestor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ActualizadoPor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Apellidos")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("CreadoPor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime>("FechaActualizado")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaCreado")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.HasIndex("Nombre", "Apellidos")
                        .IsUnique();

                    b.ToTable("Gestores", (string)null);
                });

            modelBuilder.Entity("API.Data.Entidades.Gestion.Nomencladores.Producto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ActualizadoPor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<int>("CantidadStock")
                        .HasColumnType("int");

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<float>("Costo")
                        .HasColumnType("real");

                    b.Property<string>("CreadoPor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("EstadoProductoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("FechaActualizado")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaCreado")
                        .HasColumnType("datetime2");

                    b.Property<float>("PrecioUSD")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("Codigo")
                        .IsUnique();

                    b.HasIndex("EstadoProductoId");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.ToTable("Productos", (string)null);
                });

            modelBuilder.Entity("API.Data.Entidades.Gestion.Nomencladores.ProductoVendido", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ActualizadoPor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<string>("CreadoPor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaActualizado")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaCreado")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("GestorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<float>("PrecioGestor")
                        .HasColumnType("real");

                    b.Property<Guid>("ProductoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("VentaId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("GestorId");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.HasIndex("ProductoId");

                    b.HasIndex("VentaId", "ProductoId", "GestorId")
                        .IsUnique();

                    b.ToTable("ProductosVendidos", (string)null);
                });

            modelBuilder.Entity("API.Data.Entidades.Gestion.Nomencladores.ValeDeVenta", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ActualizadoPor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreadoPor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Domicilio")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime>("FechaActualizado")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaCreado")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("VentaId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.HasIndex("VentaId")
                        .IsUnique();

                    b.ToTable("ValesDeVentas", (string)null);
                });

            modelBuilder.Entity("API.Data.Entidades.Gestion.Nomencladores.Venta", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ActualizadoPor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CreadoPor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaActualizado")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaCreado")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("Codigo")
                        .IsUnique();

                    b.HasIndex("Id")
                        .IsUnique();

                    b.ToTable("Ventas", (string)null);
                });

            modelBuilder.Entity("API.Data.Entidades.Pago.Nomencladores.PagoGestor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ActualizadoPor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreadoPor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaActualizado")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaCreado")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Pagado")
                        .HasColumnType("bit");

                    b.Property<float>("PagoTotal")
                        .HasColumnType("real");

                    b.Property<Guid>("VentaId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.HasIndex("VentaId")
                        .IsUnique();

                    b.ToTable("PagosGestores", (string)null);
                });

            modelBuilder.Entity("API.Data.Entidades.Seguridad.Permiso", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ActualizadoPor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreadoPor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime>("FechaActualizado")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaCreado")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.ToTable("Permisos", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("56b3924b-209b-40fb-9f31-ad75c12f4528"),
                            ActualizadoPor = "",
                            CreadoPor = "",
                            Descripcion = "Permite ver los usuarios existentes en el sistema y sus datos.",
                            FechaActualizado = new DateTime(2024, 10, 5, 14, 29, 28, 693, DateTimeKind.Local).AddTicks(2762),
                            FechaCreado = new DateTime(2024, 10, 5, 14, 29, 28, 693, DateTimeKind.Local).AddTicks(2758),
                            Nombre = "Listar usuarios"
                        },
                        new
                        {
                            Id = new Guid("4129cf49-cc22-46a1-9625-501855f2da8b"),
                            ActualizadoPor = "",
                            CreadoPor = "",
                            Descripcion = "Permite ver, crear, modificar y eliminar usuarios en el sistema.",
                            FechaActualizado = new DateTime(2024, 10, 5, 14, 29, 28, 693, DateTimeKind.Local).AddTicks(2767),
                            FechaCreado = new DateTime(2024, 10, 5, 14, 29, 28, 693, DateTimeKind.Local).AddTicks(2766),
                            Nombre = "Gestionar usuarios"
                        },
                        new
                        {
                            Id = new Guid("e36d283c-8b25-42b6-83bd-56edd953e770"),
                            ActualizadoPor = "",
                            CreadoPor = "",
                            Descripcion = "Permite ver los roles existentes en el sistema y sus datos.",
                            FechaActualizado = new DateTime(2024, 10, 5, 14, 29, 28, 693, DateTimeKind.Local).AddTicks(2769),
                            FechaCreado = new DateTime(2024, 10, 5, 14, 29, 28, 693, DateTimeKind.Local).AddTicks(2769),
                            Nombre = "Listar roles"
                        },
                        new
                        {
                            Id = new Guid("90abf232-a641-478d-8720-f0ae49e8a306"),
                            ActualizadoPor = "",
                            CreadoPor = "",
                            Descripcion = "Permite ver, crear, modificar y eliminar roles en el sistema.",
                            FechaActualizado = new DateTime(2024, 10, 5, 14, 29, 28, 693, DateTimeKind.Local).AddTicks(2772),
                            FechaCreado = new DateTime(2024, 10, 5, 14, 29, 28, 693, DateTimeKind.Local).AddTicks(2772),
                            Nombre = "Gestionar rol"
                        });
                });

            modelBuilder.Entity("API.Data.Entidades.Seguridad.Rol", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ActualizadoPor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreadoPor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaActualizado")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaCreado")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.ToTable("Roles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("c0b7e3b3-a06e-4580-b985-bb2fc4336522"),
                            ActualizadoPor = "",
                            CreadoPor = "",
                            FechaActualizado = new DateTime(2024, 10, 5, 14, 29, 28, 693, DateTimeKind.Local).AddTicks(2683),
                            FechaCreado = new DateTime(2024, 10, 5, 14, 29, 28, 693, DateTimeKind.Local).AddTicks(2668),
                            Nombre = "Administrador"
                        },
                        new
                        {
                            Id = new Guid("c0b7e3b3-a06e-4580-b985-bb2fc4336523"),
                            ActualizadoPor = "",
                            CreadoPor = "",
                            FechaActualizado = new DateTime(2024, 10, 5, 14, 29, 28, 693, DateTimeKind.Local).AddTicks(2740),
                            FechaCreado = new DateTime(2024, 10, 5, 14, 29, 28, 693, DateTimeKind.Local).AddTicks(2740),
                            Nombre = "Vendedor"
                        });
                });

            modelBuilder.Entity("API.Data.Entidades.Seguridad.RolPermiso", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ActualizadoPor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreadoPor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaActualizado")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaCreado")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("PermisoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RolId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.HasIndex("PermisoId");

                    b.HasIndex("RolId", "PermisoId")
                        .IsUnique();

                    b.ToTable("RolPermiso", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("56b3924b-209b-40fb-9f31-ad75c12f4528"),
                            ActualizadoPor = "",
                            CreadoPor = "",
                            FechaActualizado = new DateTime(2024, 10, 5, 14, 29, 28, 693, DateTimeKind.Local).AddTicks(2948),
                            FechaCreado = new DateTime(2024, 10, 5, 14, 29, 28, 693, DateTimeKind.Local).AddTicks(2947),
                            PermisoId = new Guid("56b3924b-209b-40fb-9f31-ad75c12f4528"),
                            RolId = new Guid("c0b7e3b3-a06e-4580-b985-bb2fc4336522")
                        },
                        new
                        {
                            Id = new Guid("4129cf49-cc22-46a1-9625-501855f2da8b"),
                            ActualizadoPor = "",
                            CreadoPor = "",
                            FechaActualizado = new DateTime(2024, 10, 5, 14, 29, 28, 693, DateTimeKind.Local).AddTicks(2953),
                            FechaCreado = new DateTime(2024, 10, 5, 14, 29, 28, 693, DateTimeKind.Local).AddTicks(2953),
                            PermisoId = new Guid("4129cf49-cc22-46a1-9625-501855f2da8b"),
                            RolId = new Guid("c0b7e3b3-a06e-4580-b985-bb2fc4336522")
                        },
                        new
                        {
                            Id = new Guid("e36d283c-8b25-42b6-83bd-56edd953e770"),
                            ActualizadoPor = "",
                            CreadoPor = "",
                            FechaActualizado = new DateTime(2024, 10, 5, 14, 29, 28, 693, DateTimeKind.Local).AddTicks(2955),
                            FechaCreado = new DateTime(2024, 10, 5, 14, 29, 28, 693, DateTimeKind.Local).AddTicks(2955),
                            PermisoId = new Guid("e36d283c-8b25-42b6-83bd-56edd953e770"),
                            RolId = new Guid("c0b7e3b3-a06e-4580-b985-bb2fc4336522")
                        },
                        new
                        {
                            Id = new Guid("90abf232-a641-478d-8720-f0ae49e8a306"),
                            ActualizadoPor = "",
                            CreadoPor = "",
                            FechaActualizado = new DateTime(2024, 10, 5, 14, 29, 28, 693, DateTimeKind.Local).AddTicks(2957),
                            FechaCreado = new DateTime(2024, 10, 5, 14, 29, 28, 693, DateTimeKind.Local).AddTicks(2956),
                            PermisoId = new Guid("90abf232-a641-478d-8720-f0ae49e8a306"),
                            RolId = new Guid("c0b7e3b3-a06e-4580-b985-bb2fc4336522")
                        });
                });

            modelBuilder.Entity("API.Data.Entidades.Seguridad.Traza", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ActualizadoPor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreadoPor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaActualizado")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaCreado")
                        .HasColumnType("datetime2");

                    b.Property<string>("TablaBD")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.ToTable("Trazas", (string)null);
                });

            modelBuilder.Entity("API.Data.Entidades.Seguridad.Usuario", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ActualizadoPor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Apellidos")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Contrasenna")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("CreadoPor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("DebeCambiarContrasenna")
                        .HasColumnType("bit");

                    b.Property<DateTime>("FechaActualizado")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaCreado")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<Guid>("RolId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.HasIndex("RolId");

                    b.HasIndex("Username")
                        .IsUnique();

                    b.HasIndex("Nombre", "Apellidos")
                        .IsUnique();

                    b.ToTable("Usuarios", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("42717fb8-6e3f-4c94-b6b1-a88e8718d0a6"),
                            ActualizadoPor = "",
                            Apellidos = "1",
                            Contrasenna = "$2a$10$EixZaYVK1fsbw1Zfbx3OXePaWxn96p36Zf4d0xF4f5f5f5f5f5f5f",
                            CreadoPor = "",
                            DebeCambiarContrasenna = false,
                            FechaActualizado = new DateTime(2024, 10, 5, 14, 29, 28, 693, DateTimeKind.Local).AddTicks(9350),
                            FechaCreado = new DateTime(2024, 10, 5, 14, 29, 28, 693, DateTimeKind.Local).AddTicks(9346),
                            Nombre = "1",
                            RolId = new Guid("c0b7e3b3-a06e-4580-b985-bb2fc4336522"),
                            Username = "1"
                        });
                });

            modelBuilder.Entity("API.Data.Entidades.Gestion.Nomencladores.Producto", b =>
                {
                    b.HasOne("API.Data.Entidades.Gestion.Nomencladores.EstadoProducto", "EstadoProducto")
                        .WithMany("Productos")
                        .HasForeignKey("EstadoProductoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("EstadoProducto");
                });

            modelBuilder.Entity("API.Data.Entidades.Gestion.Nomencladores.ProductoVendido", b =>
                {
                    b.HasOne("API.Data.Entidades.Gestion.Nomencladores.Gestor", "Gestor")
                        .WithMany("ProductosVendidos")
                        .HasForeignKey("GestorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Data.Entidades.Gestion.Nomencladores.Producto", "Producto")
                        .WithMany("ProductosVendidos")
                        .HasForeignKey("ProductoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Data.Entidades.Gestion.Nomencladores.Venta", "Venta")
                        .WithMany("ProductosVendidos")
                        .HasForeignKey("VentaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Gestor");

                    b.Navigation("Producto");

                    b.Navigation("Venta");
                });

            modelBuilder.Entity("API.Data.Entidades.Gestion.Nomencladores.ValeDeVenta", b =>
                {
                    b.HasOne("API.Data.Entidades.Gestion.Nomencladores.Venta", "Venta")
                        .WithMany()
                        .HasForeignKey("VentaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Venta");
                });

            modelBuilder.Entity("API.Data.Entidades.Pago.Nomencladores.PagoGestor", b =>
                {
                    b.HasOne("API.Data.Entidades.Gestion.Nomencladores.Venta", "Venta")
                        .WithMany()
                        .HasForeignKey("VentaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Venta");
                });

            modelBuilder.Entity("API.Data.Entidades.Seguridad.RolPermiso", b =>
                {
                    b.HasOne("API.Data.Entidades.Seguridad.Permiso", "Permiso")
                        .WithMany("RolPermiso")
                        .HasForeignKey("PermisoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Data.Entidades.Seguridad.Rol", "Rol")
                        .WithMany("RolPermiso")
                        .HasForeignKey("RolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Permiso");

                    b.Navigation("Rol");
                });

            modelBuilder.Entity("API.Data.Entidades.Seguridad.Usuario", b =>
                {
                    b.HasOne("API.Data.Entidades.Seguridad.Rol", "Rol")
                        .WithMany("Usuarios")
                        .HasForeignKey("RolId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Rol");
                });

            modelBuilder.Entity("API.Data.Entidades.Gestion.Nomencladores.EstadoProducto", b =>
                {
                    b.Navigation("Productos");
                });

            modelBuilder.Entity("API.Data.Entidades.Gestion.Nomencladores.Gestor", b =>
                {
                    b.Navigation("ProductosVendidos");
                });

            modelBuilder.Entity("API.Data.Entidades.Gestion.Nomencladores.Producto", b =>
                {
                    b.Navigation("ProductosVendidos");
                });

            modelBuilder.Entity("API.Data.Entidades.Gestion.Nomencladores.Venta", b =>
                {
                    b.Navigation("ProductosVendidos");
                });

            modelBuilder.Entity("API.Data.Entidades.Seguridad.Permiso", b =>
                {
                    b.Navigation("RolPermiso");
                });

            modelBuilder.Entity("API.Data.Entidades.Seguridad.Rol", b =>
                {
                    b.Navigation("RolPermiso");

                    b.Navigation("Usuarios");
                });
#pragma warning restore 612, 618
        }
    }
}
