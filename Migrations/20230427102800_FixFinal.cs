using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web_Api_Event_Game.Migrations
{
    /// <inheritdoc />
    public partial class FixFinal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Coupons_Games_GameId",
                table: "Coupons");

            migrationBuilder.DropForeignKey(
                name: "FK_EventGames_Events_EventId",
                table: "EventGames");

            migrationBuilder.DropForeignKey(
                name: "FK_EventGames_Games_GameId",
                table: "EventGames");

            migrationBuilder.DropForeignKey(
                name: "FK_Events_Clients_ClientId",
                table: "Events");

            migrationBuilder.AddForeignKey(
                name: "FK_Coupons_Games_GameId",
                table: "Coupons",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "GameId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventGames_Events_EventId",
                table: "EventGames",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "EventId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventGames_Games_GameId",
                table: "EventGames",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "GameId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Clients_ClientId",
                table: "Events",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "ClientId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Coupons_Games_GameId",
                table: "Coupons");

            migrationBuilder.DropForeignKey(
                name: "FK_EventGames_Events_EventId",
                table: "EventGames");

            migrationBuilder.DropForeignKey(
                name: "FK_EventGames_Games_GameId",
                table: "EventGames");

            migrationBuilder.DropForeignKey(
                name: "FK_Events_Clients_ClientId",
                table: "Events");

            migrationBuilder.AddForeignKey(
                name: "FK_Coupons_Games_GameId",
                table: "Coupons",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "GameId",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_EventGames_Events_EventId",
                table: "EventGames",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "EventId",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_EventGames_Games_GameId",
                table: "EventGames",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "GameId",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Clients_ClientId",
                table: "Events",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "ClientId",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
