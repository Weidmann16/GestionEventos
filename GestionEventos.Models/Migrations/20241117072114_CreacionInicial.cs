using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionEventos.Models.Migrations
{
    /// <inheritdoc />
    public partial class CreacionInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    NombreUsuarioLogin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContrasenaUsuarioLogin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NombreUsuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApellidoUsuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EstadoUsuario = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.IdUsuario);
                });

            migrationBuilder.CreateTable(
                name: "Eventos",
                columns: table => new
                {
                    IdEvento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreEvento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DescripcionEvento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaEvento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UbicacionEvento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CapacidadEvento = table.Column<int>(type: "int", nullable: false),
                    EstadoEvento = table.Column<bool>(type: "bit", nullable: false),
                    IdUsuarioEvento = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eventos", x => x.IdEvento);
                    table.ForeignKey(
                        name: "FK_Eventos_Usuarios_IdUsuarioEvento",
                        column: x => x.IdUsuarioEvento,
                        principalTable: "Usuarios",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "AsistentesEventos",
                columns: table => new
                {
                    IdAsistenteEvento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdEventoAsistenteEvento = table.Column<int>(type: "int", nullable: false),
                    IdUsuarioAsistenteEvento = table.Column<int>(type: "int", nullable: false),
                    EstadoAsistenteEvento = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AsistentesEventos", x => x.IdAsistenteEvento);
                    table.ForeignKey(
                        name: "FK_AsistentesEventos_Eventos_IdEventoAsistenteEvento",
                        column: x => x.IdEventoAsistenteEvento,
                        principalTable: "Eventos",
                        principalColumn: "IdEvento",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_AsistentesEventos_Usuarios_IdUsuarioAsistenteEvento",
                        column: x => x.IdUsuarioAsistenteEvento,
                        principalTable: "Usuarios",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AsistentesEventos_IdEventoAsistenteEvento",
                table: "AsistentesEventos",
                column: "IdEventoAsistenteEvento");

            migrationBuilder.CreateIndex(
                name: "IX_AsistentesEventos_IdUsuarioAsistenteEvento",
                table: "AsistentesEventos",
                column: "IdUsuarioAsistenteEvento");

            migrationBuilder.CreateIndex(
                name: "IX_Eventos_IdUsuarioEvento",
                table: "Eventos",
                column: "IdUsuarioEvento");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AsistentesEventos");

            migrationBuilder.DropTable(
                name: "Eventos");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
