using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace PavementCondition.DataAccess.Migrations
{
    public partial class AddRoadDefectRoadInspectionTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RoadInspections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoadId = table.Column<int>(type: "integer", nullable: false),
                    Number = table.Column<string>(type: "varchar(100)", nullable: false),
                    Engineer = table.Column<string>(type: "varchar(200)", nullable: false),
                    InspectionDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoadInspections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoadInspections_Roads_RoadId",
                        column: x => x.RoadId,
                        principalTable: "Roads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoadDefects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoadInspectionId = table.Column<int>(type: "integer", nullable: false),
                    DefectTypeId = table.Column<int>(type: "integer", nullable: false),
                    DefectStartPoint = table.Column<decimal>(type: "numeric", nullable: false),
                    DefectDistance = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoadDefects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoadDefects_DefectTypes_DefectTypeId",
                        column: x => x.DefectTypeId,
                        principalTable: "DefectTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoadDefects_RoadInspections_RoadInspectionId",
                        column: x => x.RoadInspectionId,
                        principalTable: "RoadInspections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RoadDefects_DefectTypeId",
                table: "RoadDefects",
                column: "DefectTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_RoadDefects_RoadInspectionId",
                table: "RoadDefects",
                column: "RoadInspectionId");

            migrationBuilder.CreateIndex(
                name: "IX_RoadInspections_RoadId",
                table: "RoadInspections",
                column: "RoadId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoadDefects");

            migrationBuilder.DropTable(
                name: "RoadInspections");
        }
    }
}
