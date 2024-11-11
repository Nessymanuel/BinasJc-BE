using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BinasJc.DAL.Migrations
{
    /// <inheritdoc />
    public partial class TablesOfProject : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Estacoes",
                columns: table => new
                {
                    EstacaoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeEstacao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Latitude = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Longitude = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BicicletasDisponiveis = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estacoes", x => x.EstacaoID);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    UsuarioID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SenhaHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PontuacaoTotal = table.Column<int>(type: "int", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.UsuarioID);
                });

            migrationBuilder.CreateTable(
                name: "Bicicletas",
                columns: table => new
                {
                    BicicletaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BeaconID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EstacaoID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bicicletas", x => x.BicicletaID);
                    table.ForeignKey(
                        name: "FK_Bicicletas_Estacoes_EstacaoID",
                        column: x => x.EstacaoID,
                        principalTable: "Estacoes",
                        principalColumn: "EstacaoID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pontos",
                columns: table => new
                {
                    PontoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioOrigemID = table.Column<int>(type: "int", nullable: false),
                    UsuarioDestinoID = table.Column<int>(type: "int", nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    DataTransferencia = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pontos", x => x.PontoID);
                    table.ForeignKey(
                        name: "FK_Pontos_Usuarios_UsuarioDestinoID",
                        column: x => x.UsuarioDestinoID,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pontos_Usuarios_UsuarioOrigemID",
                        column: x => x.UsuarioOrigemID,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Reservas",
                columns: table => new
                {
                    ReservaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioID = table.Column<int>(type: "int", nullable: false),
                    BicicletaID = table.Column<int>(type: "int", nullable: false),
                    EstacaoRetiradaID = table.Column<int>(type: "int", nullable: false),
                    EstacaoDevolucaoID = table.Column<int>(type: "int", nullable: false),
                    DataHoraRetirada = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataHoraDevolucao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DistanciaPercorrida = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PontosGanhos = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservas", x => x.ReservaID);
                    table.ForeignKey(
                        name: "FK_Reservas_Bicicletas_BicicletaID",
                        column: x => x.BicicletaID,
                        principalTable: "Bicicletas",
                        principalColumn: "BicicletaID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reservas_Estacoes_EstacaoDevolucaoID",
                        column: x => x.EstacaoDevolucaoID,
                        principalTable: "Estacoes",
                        principalColumn: "EstacaoID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reservas_Estacoes_EstacaoRetiradaID",
                        column: x => x.EstacaoRetiradaID,
                        principalTable: "Estacoes",
                        principalColumn: "EstacaoID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reservas_Usuarios_UsuarioID",
                        column: x => x.UsuarioID,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bicicletas_EstacaoID",
                table: "Bicicletas",
                column: "EstacaoID");

            migrationBuilder.CreateIndex(
                name: "IX_Pontos_UsuarioDestinoID",
                table: "Pontos",
                column: "UsuarioDestinoID");

            migrationBuilder.CreateIndex(
                name: "IX_Pontos_UsuarioOrigemID",
                table: "Pontos",
                column: "UsuarioOrigemID");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_BicicletaID",
                table: "Reservas",
                column: "BicicletaID");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_EstacaoDevolucaoID",
                table: "Reservas",
                column: "EstacaoDevolucaoID");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_EstacaoRetiradaID",
                table: "Reservas",
                column: "EstacaoRetiradaID");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_UsuarioID",
                table: "Reservas",
                column: "UsuarioID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pontos");

            migrationBuilder.DropTable(
                name: "Reservas");

            migrationBuilder.DropTable(
                name: "Bicicletas");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Estacoes");
        }
    }
}
