using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameZone.Migrations
{
    /// <inheritdoc />
    public partial class AddDeviceGameTableIdAfterRemoveToSolveError : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_DeviceGames",
                table: "DeviceGames");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "DeviceGames",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DeviceGames",
                table: "DeviceGames",
                columns: new[] { "Id", "DeviceId", "GameId" });

            migrationBuilder.CreateIndex(
                name: "IX_DeviceGames_DeviceId",
                table: "DeviceGames",
                column: "DeviceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_DeviceGames",
                table: "DeviceGames");

            migrationBuilder.DropIndex(
                name: "IX_DeviceGames_DeviceId",
                table: "DeviceGames");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "DeviceGames");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DeviceGames",
                table: "DeviceGames",
                columns: new[] { "DeviceId", "GameId" });
        }
    }
}
