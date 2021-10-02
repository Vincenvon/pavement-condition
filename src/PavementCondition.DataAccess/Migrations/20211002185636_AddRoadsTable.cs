using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace PavementCondition.DataAccess.Migrations
{
    public partial class AddRoadsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Roads",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Number = table.Column<string>(type: "varchar(100)", nullable: false),
                    StartPoint = table.Column<string>(type: "varchar(100)", nullable: false),
                    EndPoint = table.Column<string>(type: "varchar(100)", nullable: false),
                    Distance = table.Column<decimal>(type: "numeric", nullable: false),
                    ServiceOrganization = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roads", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Roads");
        }
    }
}
