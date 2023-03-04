using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HBikebackend.Migrations
{
    /// <inheritdoc />
    public partial class journeystation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Stations",
                columns: table => new
                {
                    StationId = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StationName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stations", x => x.StationId);
                });

            migrationBuilder.CreateTable(
                name: "Journeys",
                columns: table => new
                {
                    JourneyId = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Departure = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Return = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DepartureStationStationId = table.Column<long>(type: "INTEGER", nullable: false),
                    ReturnStationStationId = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Journeys", x => x.JourneyId);
                    table.ForeignKey(
                        name: "FK_Journeys_Stations_DepartureStationStationId",
                        column: x => x.DepartureStationStationId,
                        principalTable: "Stations",
                        principalColumn: "StationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Journeys_Stations_ReturnStationStationId",
                        column: x => x.ReturnStationStationId,
                        principalTable: "Stations",
                        principalColumn: "StationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Journeys_DepartureStationStationId",
                table: "Journeys",
                column: "DepartureStationStationId");

            migrationBuilder.CreateIndex(
                name: "IX_Journeys_ReturnStationStationId",
                table: "Journeys",
                column: "ReturnStationStationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Journeys");

            migrationBuilder.DropTable(
                name: "Stations");
        }
    }
}
