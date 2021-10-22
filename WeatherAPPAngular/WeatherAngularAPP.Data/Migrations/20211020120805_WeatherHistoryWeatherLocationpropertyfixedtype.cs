using Microsoft.EntityFrameworkCore.Migrations;

namespace WeatherAngularAPP.Data.Migrations
{
    public partial class WeatherHistoryWeatherLocationpropertyfixedtype : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WeatherHistories_WeatherHistories_WeatherLocationWeatherHistoryId",
                table: "WeatherHistories");

            migrationBuilder.RenameColumn(
                name: "WeatherLocationWeatherHistoryId",
                table: "WeatherHistories",
                newName: "WeatherLocationId");

            migrationBuilder.RenameIndex(
                name: "IX_WeatherHistories_WeatherLocationWeatherHistoryId",
                table: "WeatherHistories",
                newName: "IX_WeatherHistories_WeatherLocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_WeatherHistories_WeatherLocations_WeatherLocationId",
                table: "WeatherHistories",
                column: "WeatherLocationId",
                principalTable: "WeatherLocations",
                principalColumn: "WeatherLocationId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WeatherHistories_WeatherLocations_WeatherLocationId",
                table: "WeatherHistories");

            migrationBuilder.RenameColumn(
                name: "WeatherLocationId",
                table: "WeatherHistories",
                newName: "WeatherLocationWeatherHistoryId");

            migrationBuilder.RenameIndex(
                name: "IX_WeatherHistories_WeatherLocationId",
                table: "WeatherHistories",
                newName: "IX_WeatherHistories_WeatherLocationWeatherHistoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_WeatherHistories_WeatherHistories_WeatherLocationWeatherHistoryId",
                table: "WeatherHistories",
                column: "WeatherLocationWeatherHistoryId",
                principalTable: "WeatherHistories",
                principalColumn: "WeatherHistoryId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
