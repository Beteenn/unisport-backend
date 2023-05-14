using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class AddInscricao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EquipeCampeonato");

            migrationBuilder.CreateTable(
                name: "Inscricao",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CampeonatoId = table.Column<long>(type: "bigint", nullable: false),
                    DataInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataFim = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inscricao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inscricao_Campeonato_CampeonatoId",
                        column: x => x.CampeonatoId,
                        principalTable: "Campeonato",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EquipeInscricao",
                columns: table => new
                {
                    InscricaoId = table.Column<long>(type: "bigint", nullable: false),
                    EquipeId = table.Column<long>(type: "bigint", nullable: false),
                    Id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipeInscricao", x => new { x.EquipeId, x.InscricaoId });
                    table.ForeignKey(
                        name: "FK_EquipeInscricao_Equipe_EquipeId",
                        column: x => x.EquipeId,
                        principalTable: "Equipe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EquipeInscricao_Inscricao_InscricaoId",
                        column: x => x.InscricaoId,
                        principalTable: "Inscricao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EquipeInscricao_InscricaoId",
                table: "EquipeInscricao",
                column: "InscricaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Inscricao_CampeonatoId",
                table: "Inscricao",
                column: "CampeonatoId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EquipeInscricao");

            migrationBuilder.DropTable(
                name: "Inscricao");

            migrationBuilder.CreateTable(
                name: "EquipeCampeonato",
                columns: table => new
                {
                    EquipeId = table.Column<long>(type: "bigint", nullable: false),
                    CampeonatoId = table.Column<long>(type: "bigint", nullable: false),
                    Id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipeCampeonato", x => new { x.EquipeId, x.CampeonatoId });
                    table.ForeignKey(
                        name: "FK_EquipeCampeonato_Campeonato_CampeonatoId",
                        column: x => x.CampeonatoId,
                        principalTable: "Campeonato",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EquipeCampeonato_Equipe_EquipeId",
                        column: x => x.EquipeId,
                        principalTable: "Equipe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EquipeCampeonato_CampeonatoId",
                table: "EquipeCampeonato",
                column: "CampeonatoId");
        }
    }
}
