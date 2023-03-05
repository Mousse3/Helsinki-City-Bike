using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HBikebackend.Migrations
{
    /// <inheritdoc />
    public partial class JourneyStationrelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "DepartureStationId",
                table: "Journeys",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "ReturnStationId",
                table: "Journeys",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Journeys_DepartureStationId",
                table: "Journeys",
                column: "DepartureStationId");

            migrationBuilder.CreateIndex(
                name: "IX_Journeys_ReturnStationId",
                table: "Journeys",
                column: "ReturnStationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Journeys_Stations_DepartureStationId",
                table: "Journeys",
                column: "DepartureStationId",
                principalTable: "Stations",
                principalColumn: "StationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Journeys_Stations_ReturnStationId",
                table: "Journeys",
                column: "ReturnStationId",
                principalTable: "Stations",
                principalColumn: "StationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Journeys_Stations_DepartureStationId",
                table: "Journeys");

            migrationBuilder.DropForeignKey(
                name: "FK_Journeys_Stations_ReturnStationId",
                table: "Journeys");

            migrationBuilder.DropIndex(
                name: "IX_Journeys_DepartureStationId",
                table: "Journeys");

            migrationBuilder.DropIndex(
                name: "IX_Journeys_ReturnStationId",
                table: "Journeys");

            migrationBuilder.DropColumn(
                name: "DepartureStationId",
                table: "Journeys");

            migrationBuilder.DropColumn(
                name: "ReturnStationId",
                table: "Journeys");
        }
    }
}
