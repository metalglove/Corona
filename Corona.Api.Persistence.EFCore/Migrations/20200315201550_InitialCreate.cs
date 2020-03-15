using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Corona.Api.Persistence.EFCore.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CoronaTimeSeriesRegion",
                columns: table => new
                {
                    Region = table.Column<string>(nullable: false),
                    Latitude = table.Column<string>(nullable: false),
                    Longitude = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoronaTimeSeriesRegion", x => x.Region);
                });

            migrationBuilder.CreateTable(
                name: "CoronaTimeSeriesRecord",
                columns: table => new
                {
                    TimeStamp = table.Column<DateTime>(nullable: false),
                    Region = table.Column<string>(nullable: false),
                    Confirmed = table.Column<int>(nullable: false),
                    Deaths = table.Column<int>(nullable: false),
                    Recoverd = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoronaTimeSeriesRecord", x => new { x.Region, x.TimeStamp });
                    table.ForeignKey(
                        name: "FK_CoronaTimeSeriesRecord_CoronaTimeSeriesRegion_Region",
                        column: x => x.Region,
                        principalTable: "CoronaTimeSeriesRegion",
                        principalColumn: "Region",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CoronaTimeSeriesRecord");

            migrationBuilder.DropTable(
                name: "CoronaTimeSeriesRegion");
        }
    }
}
