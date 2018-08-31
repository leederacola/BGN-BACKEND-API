using Microsoft.EntityFrameworkCore.Migrations;

namespace again.Migrations
{
    public partial class eventmodeldbset3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventGames_Event_EventID",
                table: "EventGames");

            migrationBuilder.DropForeignKey(
                name: "FK_EventGames_Game_GameID",
                table: "EventGames");

            migrationBuilder.DropForeignKey(
                name: "FK_EventPlayers_Event_EventID",
                table: "EventPlayers");

            migrationBuilder.DropForeignKey(
                name: "FK_EventPlayers_Player_PlayerID",
                table: "EventPlayers");

            migrationBuilder.DropForeignKey(
                name: "FK_Game_Event_EventID",
                table: "Game");

            migrationBuilder.DropForeignKey(
                name: "FK_Player_Event_EventID",
                table: "Player");

            migrationBuilder.DropIndex(
                name: "IX_Player_EventID",
                table: "Player");

            migrationBuilder.DropIndex(
                name: "IX_Game_EventID",
                table: "Game");

            migrationBuilder.DropIndex(
                name: "IX_EventPlayers_EventID",
                table: "EventPlayers");

            migrationBuilder.DropIndex(
                name: "IX_EventPlayers_PlayerID",
                table: "EventPlayers");

            migrationBuilder.DropIndex(
                name: "IX_EventGames_EventID",
                table: "EventGames");

            migrationBuilder.DropIndex(
                name: "IX_EventGames_GameID",
                table: "EventGames");

            migrationBuilder.DropColumn(
                name: "EventID",
                table: "Player");

            migrationBuilder.DropColumn(
                name: "EventID",
                table: "Game");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EventID",
                table: "Player",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EventID",
                table: "Game",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Player_EventID",
                table: "Player",
                column: "EventID");

            migrationBuilder.CreateIndex(
                name: "IX_Game_EventID",
                table: "Game",
                column: "EventID");

            migrationBuilder.CreateIndex(
                name: "IX_EventPlayers_EventID",
                table: "EventPlayers",
                column: "EventID");

            migrationBuilder.CreateIndex(
                name: "IX_EventPlayers_PlayerID",
                table: "EventPlayers",
                column: "PlayerID");

            migrationBuilder.CreateIndex(
                name: "IX_EventGames_EventID",
                table: "EventGames",
                column: "EventID");

            migrationBuilder.CreateIndex(
                name: "IX_EventGames_GameID",
                table: "EventGames",
                column: "GameID");

            migrationBuilder.AddForeignKey(
                name: "FK_EventGames_Event_EventID",
                table: "EventGames",
                column: "EventID",
                principalTable: "Event",
                principalColumn: "EventID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventGames_Game_GameID",
                table: "EventGames",
                column: "GameID",
                principalTable: "Game",
                principalColumn: "GameID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventPlayers_Event_EventID",
                table: "EventPlayers",
                column: "EventID",
                principalTable: "Event",
                principalColumn: "EventID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventPlayers_Player_PlayerID",
                table: "EventPlayers",
                column: "PlayerID",
                principalTable: "Player",
                principalColumn: "PlayerID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Game_Event_EventID",
                table: "Game",
                column: "EventID",
                principalTable: "Event",
                principalColumn: "EventID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Player_Event_EventID",
                table: "Player",
                column: "EventID",
                principalTable: "Event",
                principalColumn: "EventID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
