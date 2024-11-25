﻿// <auto-generated />
using System;
using GestionEventos.Models.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GestionEventos.Models.Migrations
{
    [DbContext(typeof(GestionEventosContext))]
    [Migration("20241117072114_CreacionInicial")]
    partial class CreacionInicial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GestionEventos.Models.Models.AsistenteEvento", b =>
                {
                    b.Property<int>("IdAsistenteEvento")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdAsistenteEvento"));

                    b.Property<bool>("EstadoAsistenteEvento")
                        .HasColumnType("bit");

                    b.Property<int>("IdEventoAsistenteEvento")
                        .HasColumnType("int");

                    b.Property<int>("IdUsuarioAsistenteEvento")
                        .HasColumnType("int");

                    b.HasKey("IdAsistenteEvento");

                    b.HasIndex("IdEventoAsistenteEvento");

                    b.HasIndex("IdUsuarioAsistenteEvento");

                    b.ToTable("AsistentesEventos");
                });

            modelBuilder.Entity("GestionEventos.Models.Models.Evento", b =>
                {
                    b.Property<int>("IdEvento")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdEvento"));

                    b.Property<int>("CapacidadEvento")
                        .HasColumnType("int");

                    b.Property<string>("DescripcionEvento")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EstadoEvento")
                        .HasColumnType("bit");

                    b.Property<DateTime>("FechaEvento")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdUsuarioEvento")
                        .HasColumnType("int");

                    b.Property<string>("NombreEvento")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UbicacionEvento")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdEvento");

                    b.HasIndex("IdUsuarioEvento");

                    b.ToTable("Eventos");
                });

            modelBuilder.Entity("GestionEventos.Models.Models.Usuario", b =>
                {
                    b.Property<int>("IdUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdUsuario"));

                    b.Property<string>("ApellidoUsuario")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContrasenaUsuarioLogin")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EstadoUsuario")
                        .HasColumnType("bit");

                    b.Property<string>("NombreUsuario")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreUsuarioLogin")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdUsuario");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("GestionEventos.Models.Models.AsistenteEvento", b =>
                {
                    b.HasOne("GestionEventos.Models.Models.Evento", "Evento")
                        .WithMany()
                        .HasForeignKey("IdEventoAsistenteEvento")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GestionEventos.Models.Models.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("IdUsuarioAsistenteEvento")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Evento");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("GestionEventos.Models.Models.Evento", b =>
                {
                    b.HasOne("GestionEventos.Models.Models.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("IdUsuarioEvento")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });
#pragma warning restore 612, 618
        }
    }
}
