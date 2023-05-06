using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class AddCampeonato : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ModalidadeCampeonato",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModalidadeCampeonato", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StatusCampeonato",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusCampeonato", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoCampeonato",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoCampeonato", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Campeonato",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    TipoCampeonatoId = table.Column<int>(type: "int", nullable: false),
                    StatusCampeonatoId = table.Column<int>(type: "int", nullable: false),
                    ModalidadeCampeonatoId = table.Column<int>(type: "int", nullable: false),
                    DataInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataFim = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campeonato", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Campeonato_ModalidadeCampeonato_ModalidadeCampeonatoId",
                        column: x => x.ModalidadeCampeonatoId,
                        principalTable: "ModalidadeCampeonato",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Campeonato_StatusCampeonato_StatusCampeonatoId",
                        column: x => x.StatusCampeonatoId,
                        principalTable: "StatusCampeonato",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Campeonato_TipoCampeonato_TipoCampeonatoId",
                        column: x => x.TipoCampeonatoId,
                        principalTable: "TipoCampeonato",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Campeonato_ModalidadeCampeonatoId",
                table: "Campeonato",
                column: "ModalidadeCampeonatoId");

            migrationBuilder.CreateIndex(
                name: "IX_Campeonato_StatusCampeonatoId",
                table: "Campeonato",
                column: "StatusCampeonatoId");

            migrationBuilder.CreateIndex(
                name: "IX_Campeonato_TipoCampeonatoId",
                table: "Campeonato",
                column: "TipoCampeonatoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Campeonato");

            migrationBuilder.DropTable(
                name: "ModalidadeCampeonato");

            migrationBuilder.DropTable(
                name: "StatusCampeonato");

            migrationBuilder.DropTable(
                name: "TipoCampeonato");
        }
    }
}
