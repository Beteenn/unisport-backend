using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class RemoveEquipeGerenciadadousuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Equipe_TimeGerenciadoId",
                table: "Usuario");

            migrationBuilder.DropIndex(
                name: "IX_Usuario_TimeGerenciadoId",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "TimeGerenciadoId",
                table: "Usuario");

            migrationBuilder.CreateIndex(
                name: "IX_Equipe_GerenteId",
                table: "Equipe",
                column: "GerenteId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Equipe_Usuario_GerenteId",
                table: "Equipe",
                column: "GerenteId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Equipe_Usuario_GerenteId",
                table: "Equipe");

            migrationBuilder.DropIndex(
                name: "IX_Equipe_GerenteId",
                table: "Equipe");

            migrationBuilder.AddColumn<long>(
                name: "TimeGerenciadoId",
                table: "Usuario",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_TimeGerenciadoId",
                table: "Usuario",
                column: "TimeGerenciadoId",
                unique: true,
                filter: "[TimeGerenciadoId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Equipe_TimeGerenciadoId",
                table: "Usuario",
                column: "TimeGerenciadoId",
                principalTable: "Equipe",
                principalColumn: "Id");
        }
    }
}
