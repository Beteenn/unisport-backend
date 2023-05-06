using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class AddOrganizadorCampeonato : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "OrganizadorId",
                table: "Campeonato",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Campeonato_OrganizadorId",
                table: "Campeonato",
                column: "OrganizadorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Campeonato_Usuario_OrganizadorId",
                table: "Campeonato",
                column: "OrganizadorId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Campeonato_Usuario_OrganizadorId",
                table: "Campeonato");

            migrationBuilder.DropIndex(
                name: "IX_Campeonato_OrganizadorId",
                table: "Campeonato");

            migrationBuilder.DropColumn(
                name: "OrganizadorId",
                table: "Campeonato");
        }
    }
}
