using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class RemoveFaculdade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Faculdade_FaculdadeId",
                table: "Usuario");

            migrationBuilder.DropTable(
                name: "Faculdade");

            migrationBuilder.DropIndex(
                name: "IX_Usuario_FaculdadeId",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "FaculdadeId",
                table: "Usuario");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "FaculdadeId",
                table: "Usuario",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "Faculdade",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DominioEmail = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faculdade", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_FaculdadeId",
                table: "Usuario",
                column: "FaculdadeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Faculdade_FaculdadeId",
                table: "Usuario",
                column: "FaculdadeId",
                principalTable: "Faculdade",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
