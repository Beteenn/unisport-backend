using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class FixPermiteUsuarioPossuirListaEquipes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Equipe_GerenteId",
                table: "Equipe");

            migrationBuilder.CreateIndex(
                name: "IX_Equipe_GerenteId",
                table: "Equipe",
                column: "GerenteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Equipe_GerenteId",
                table: "Equipe");

            migrationBuilder.CreateIndex(
                name: "IX_Equipe_GerenteId",
                table: "Equipe",
                column: "GerenteId",
                unique: true);
        }
    }
}
