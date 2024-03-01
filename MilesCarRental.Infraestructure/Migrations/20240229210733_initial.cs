using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MilesCarRental.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EstadoAlquilers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescripcionEstadoAlquiler = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsuarioAdd = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsuarioUp = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaAdd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaUp = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadoAlquilers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Localidades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescripcionLocalidad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsuarioAdd = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsuarioUp = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaAdd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaUp = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Localidades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoDocumentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescripcionTipoDocumento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsuarioAdd = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsuarioUp = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaAdd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaUp = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoDocumentos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreCliente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApellidoCliente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DocumentoCliente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdTipoDocumentoCliente = table.Column<int>(type: "int", nullable: false),
                    UsuarioAdd = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsuarioUp = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaAdd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaUp = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clientes_TipoDocumentos_IdTipoDocumentoCliente",
                        column: x => x.IdTipoDocumentoCliente,
                        principalTable: "TipoDocumentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Carros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdLocalidadRecogida = table.Column<int>(type: "int", nullable: false),
                    IdLocalidadDevolucion = table.Column<int>(type: "int", nullable: false),
                    usrId = table.Column<int>(type: "int", nullable: false),
                    Cilindraje = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Chasis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdCliente = table.Column<int>(type: "int", nullable: false),
                    IdEstadoAlquiler = table.Column<int>(type: "int", nullable: false),
                    UsuarioAdd = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsuarioUp = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaAdd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaUp = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carros", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Carros_Clientes_IdCliente",
                        column: x => x.IdCliente,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Carros_EstadoAlquilers_IdEstadoAlquiler",
                        column: x => x.IdEstadoAlquiler,
                        principalTable: "EstadoAlquilers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Carros_Localidades_IdLocalidadRecogida",
                        column: x => x.IdLocalidadRecogida,
                        principalTable: "Localidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Carros_Localidades_usrId",
                        column: x => x.usrId,
                        principalTable: "Localidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Carros_IdCliente",
                table: "Carros",
                column: "IdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Carros_IdEstadoAlquiler",
                table: "Carros",
                column: "IdEstadoAlquiler");

            migrationBuilder.CreateIndex(
                name: "IX_Carros_IdLocalidadRecogida",
                table: "Carros",
                column: "IdLocalidadRecogida");

            migrationBuilder.CreateIndex(
                name: "IX_Carros_usrId",
                table: "Carros",
                column: "usrId");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_IdTipoDocumentoCliente",
                table: "Clientes",
                column: "IdTipoDocumentoCliente");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Carros");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "EstadoAlquilers");

            migrationBuilder.DropTable(
                name: "Localidades");

            migrationBuilder.DropTable(
                name: "TipoDocumentos");
        }
    }
}
