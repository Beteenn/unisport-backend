using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class AddEquipes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "TimeGerenciadoId",
                table: "Usuario",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Equipe",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    GerenteId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipe", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EquipeUsuario",
                columns: table => new
                {
                    UsuarioId = table.Column<long>(type: "bigint", nullable: false),
                    EquipeId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipeUsuario", x => new { x.EquipeId, x.UsuarioId });
                    table.ForeignKey(
                        name: "FK_EquipeUsuario_Equipe_EquipeId",
                        column: x => x.EquipeId,
                        principalTable: "Equipe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EquipeUsuario_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_TimeGerenciadoId",
                table: "Usuario",
                column: "TimeGerenciadoId",
                unique: true,
                filter: "[TimeGerenciadoId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_EquipeUsuario_UsuarioId",
                table: "EquipeUsuario",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Equipe_TimeGerenciadoId",
                table: "Usuario",
                column: "TimeGerenciadoId",
                principalTable: "Equipe",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Equipe_TimeGerenciadoId",
                table: "Usuario");

            migrationBuilder.DropTable(
                name: "EquipeUsuario");

            migrationBuilder.DropTable(
                name: "Equipe");

            migrationBuilder.DropIndex(
                name: "IX_Usuario_TimeGerenciadoId",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "TimeGerenciadoId",
                table: "Usuario");
        }
    }
}
