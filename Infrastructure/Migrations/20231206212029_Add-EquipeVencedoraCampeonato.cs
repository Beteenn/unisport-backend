using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class AddEquipeVencedoraCampeonato : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "EquipeVencedoraId",
                table: "Campeonato",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Campeonato_EquipeVencedoraId",
                table: "Campeonato",
                column: "EquipeVencedoraId");

            migrationBuilder.AddForeignKey(
                name: "FK_Campeonato_Equipe_EquipeVencedoraId",
                table: "Campeonato",
                column: "EquipeVencedoraId",
                principalTable: "Equipe",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Campeonato_Equipe_EquipeVencedoraId",
                table: "Campeonato");

            migrationBuilder.DropIndex(
                name: "IX_Campeonato_EquipeVencedoraId",
                table: "Campeonato");

            migrationBuilder.DropColumn(
                name: "EquipeVencedoraId",
                table: "Campeonato");
        }
    }
}
