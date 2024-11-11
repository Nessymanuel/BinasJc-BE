using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BinasJc.DAL.Migrations
{
    /// <inheritdoc />
    public partial class tabelamensagem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Mensagem",
                columns: table => new
                {
                    MensagemID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioRemetenteID = table.Column<int>(type: "int", nullable: false),
                    UsuarioDestinatarioID = table.Column<int>(type: "int", nullable: false),
                    Conteudo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataEnvio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RemetenteUsuarioID = table.Column<int>(type: "int", nullable: false),
                    DestinatarioUsuarioID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mensagem", x => x.MensagemID);
                    table.ForeignKey(
                        name: "FK_Mensagem_Usuarios_DestinatarioUsuarioID",
                        column: x => x.DestinatarioUsuarioID,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Mensagem_Usuarios_RemetenteUsuarioID",
                        column: x => x.RemetenteUsuarioID,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Mensagem_DestinatarioUsuarioID",
                table: "Mensagem",
                column: "DestinatarioUsuarioID");

            migrationBuilder.CreateIndex(
                name: "IX_Mensagem_RemetenteUsuarioID",
                table: "Mensagem",
                column: "RemetenteUsuarioID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Mensagem");
        }
    }
}
