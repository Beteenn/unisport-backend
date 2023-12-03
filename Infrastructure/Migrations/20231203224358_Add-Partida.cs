using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class AddPartida : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "QuantidadeRodadas",
                table: "Campeonato",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Partida",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CampeonatoId = table.Column<long>(type: "bigint", nullable: false),
                    EquipeAId = table.Column<long>(type: "bigint", nullable: true),
                    EquipeBId = table.Column<long>(type: "bigint", nullable: true),
                    EquipeVencedoraId = table.Column<long>(type: "bigint", nullable: true),
                    DataInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataFim = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Rodada = table.Column<int>(type: "int", nullable: false),
                    ProximaPartidaId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partida", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Partida_Campeonato_CampeonatoId",
                        column: x => x.CampeonatoId,
                        principalTable: "Campeonato",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Partida_Equipe_EquipeAId",
                        column: x => x.EquipeAId,
                        principalTable: "Equipe",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Partida_Equipe_EquipeBId",
                        column: x => x.EquipeBId,
                        principalTable: "Equipe",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Partida_Equipe_EquipeVencedoraId",
                        column: x => x.EquipeVencedoraId,
                        principalTable: "Equipe",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Partida_Partida_ProximaPartidaId",
                        column: x => x.ProximaPartidaId,
                        principalTable: "Partida",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Partida_CampeonatoId",
                table: "Partida",
                column: "CampeonatoId");

            migrationBuilder.CreateIndex(
                name: "IX_Partida_EquipeAId",
                table: "Partida",
                column: "EquipeAId");

            migrationBuilder.CreateIndex(
                name: "IX_Partida_EquipeBId",
                table: "Partida",
                column: "EquipeBId");

            migrationBuilder.CreateIndex(
                name: "IX_Partida_EquipeVencedoraId",
                table: "Partida",
                column: "EquipeVencedoraId");

            migrationBuilder.CreateIndex(
                name: "IX_Partida_ProximaPartidaId",
                table: "Partida",
                column: "ProximaPartidaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Partida");

            migrationBuilder.DropColumn(
                name: "QuantidadeRodadas",
                table: "Campeonato");
        }
    }
}
